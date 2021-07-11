using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Domain.Entities;
using currencyExchangeService.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace currencyExchangeService.Infrastructure.Services
{
    public class ExchangeRatesApiCurrencyRateService : ICurrencyExchangeRatesService
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        private readonly string _apiKey;

        public ExchangeRatesApiCurrencyRateService(IConfiguration config)
        {
            _config = config;

            _apiUrl = _config.GetValue<string>("CurrencyExchangeRateProvider:EchangeRatesApi.io:ApiUrl");
            _apiKey = _config.GetValue<string>("CurrencyExchangeRateProvider:EchangeRatesApi.io:ApiKey");
        }


        public async Task<IEnumerable<CurrencyRate>> GetCurrencyRates()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_apiUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var queryParameter = $"{_apiUrl}latest?access_key={_apiKey}&base={nameof(Currencies.AUD)}&sumbols={nameof(Currencies.USD)},{nameof(Currencies.NZD)},{nameof(Currencies.CNY)},{nameof(Currencies.JPY)}";
            // It requires to pay $10/month to be able to get AUD as base currency etc, so the below is a workaround.
            queryParameter = $"{_apiUrl}latest?access_key={_apiKey}";

            HttpResponseMessage response = await httpClient.GetAsync(queryParameter);  
            if (response.IsSuccessStatusCode)
            {
                var rateData = await response.Content.ReadAsAsync<RateProviderData>();               
                var exchangeRates = ConvertResponseData(rateData);

                // Todo: pay for the API, then set the base to AUD in the request, then remove this extra process
                if (!rateData.From.Equals(Currencies.AUD.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    // Adjust for different base rate rather than AUD, this only for unpaid provider version
                    var baseToAudRate = exchangeRates.First(r => r.ToCurrency == Currencies.AUD)?.ExchangeRate ?? 1;

                    exchangeRates = exchangeRates.Select(rate => {
                        rate.ExchangeRate /= baseToAudRate;
                        return rate;
                    });
                }

                return exchangeRates.Where(r => r.ToCurrency != Currencies.AUD);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new Exception($"{nameof(CurrencyRateService)} failed to get currency rates from {_apiUrl}.");
            }
        }

        // Todo: pay for the API, then set the base to AUD in the request, then replace the hardcode AUD
        private IEnumerable<CurrencyRate> ConvertResponseData(RateProviderData rateData)
        {
            var baseCurrency = Currencies.AUD; // default
            Enum.TryParse(rateData.From, true, out baseCurrency);

            Currencies toCurrency;
            return rateData.Rates
                .Where(rate => Enum.TryParse(rate.Key, true, out toCurrency))
                .Select(rate =>
                   new CurrencyRate
                    {
                        FromCurrency = baseCurrency,
                        ToCurrency = Enum.Parse<Currencies>(rate.Key),
                        ExchangeRate = rate.Value
                    }
            );
        }
    }



    public class RateProviderData
    {
        [JsonProperty("base")]
        public string From { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rates { get; set; }

    }
}
