using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Domain.Entities;
using currencyExchangeService.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace currencyExchangeService.Infrastructure.Services
{
    public class CurrencyRateService : ICurrencyExchangeRatesService
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        private readonly string _apiKey;

        public CurrencyRateService(IConfiguration config)
        {
            _config = config;

            _apiUrl = _config.GetValue<string>("CurrencyExchangeRateProvider:ApiUrl");
            _apiKey = _config.GetValue<string>("CurrencyExchangeRateProvider:ApiKey");
        }


        public async Task<IEnumerable<CurrencyRate>> GetCurrencyRates()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_apiUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var queryParameter = $"{_apiUrl}latest?access_key={_apiKey}&base={nameof(Currencies.AUD)}&sumbols={nameof(Currencies.USD)},{nameof(Currencies.NZD)}";
            // It requires to pay $10/month to be able to get AUD as base currency, so the below is for prototype test only.
            queryParameter = $"latest?access_key={_apiKey}";
            HttpResponseMessage response = await httpClient.GetAsync(queryParameter);  
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<CurrencyRate>>();  
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new Exception($"{nameof(CurrencyRateService)} failed to get currency rates from {_apiUrl}.");
            }
        }
    }
}
