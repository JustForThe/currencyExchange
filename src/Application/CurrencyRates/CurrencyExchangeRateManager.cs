using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.CurrencyRates
{
    public class CurrencyExchangeRateManager : ICurrencyExchangeRateManager
    {
        private const int RefreshAfterMinutes = 60;

        private static List<CurrencyRate> cachedExchangeRates = new List<CurrencyRate>();
        private static DateTime ExpeiredAt;

        private readonly ICurrencyExchangeRatesService _exchangeRateService;
        private readonly ICurrncyExchangeMarkupManager _markupManager;
        private readonly IDateTime _dateTime;

        public CurrencyExchangeRateManager(ICurrencyExchangeRatesService exchangeRateService, IDateTime dateTime, ICurrncyExchangeMarkupManager markupManager)
        {
            _exchangeRateService = exchangeRateService;
            _markupManager = markupManager;
            _dateTime = dateTime;
            SetExpired();
        }

        public void SetExpired()
        {
            ExpeiredAt = new DateTime(1, 1, 1);
        }

        public async Task<IEnumerable<CurrencyRate>> GetCurrencyRates()
        {
            if(ExpeiredAt <= _dateTime.Now)
            {
                var newRates = await _exchangeRateService.GetCurrencyRates();
                cachedExchangeRates = ApplyMarkup(newRates).ToList();

                ExpeiredAt = _dateTime.Now.AddMinutes(RefreshAfterMinutes);
            }

            return cachedExchangeRates;
        }

        private IEnumerable<CurrencyRate> ApplyMarkup(IEnumerable<CurrencyRate> rates)
        {
            return rates.SelectMany(rate => {
                var markup = _markupManager.GetMarkup(rate.ToCurrency);
                rate.FinalExchangeRate =  rate.ExchangeRate / (1 + markup);
                var oppositeRate = new CurrencyRate
                {
                    FromCurrency = rate.ToCurrency,
                    ToCurrency = rate.FromCurrency,
                    ExchangeRate = 1 / rate.ExchangeRate,
                    FinalExchangeRate = 1 / rate.ExchangeRate / (1 + markup)
                };
                return new[] { 
                    rate,
                    oppositeRate
                };
             });
        }
    }
}
