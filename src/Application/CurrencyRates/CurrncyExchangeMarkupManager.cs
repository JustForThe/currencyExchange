using currencyExchangeService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using currencyExchangeService.Application.Common.Interfaces;

namespace currencyExchangeService.Application.CurrencyRates
{
    public class CurrncyExchangeMarkupManager : ICurrncyExchangeMarkupManager
    {
        private static decimal MarkupSettingPercentage = 0;

        private readonly IConfiguration _config;
        public CurrncyExchangeMarkupManager(IConfiguration config)
        {
            _config = config;
        }

        public decimal GetMarkup(Currencies currency)
        {
            // Todo: support different markup percentage for different currency

            if(MarkupSettingPercentage <= 0)
            {
                MarkupSettingPercentage = GetCurrencyExchangeRateMarkupFromConfig();
            }

            return MarkupSettingPercentage;
        }

        public decimal UpdateMarkup(Currencies currency, decimal newMarkupSettingPercentage)
        {
            MarkupSettingPercentage = newMarkupSettingPercentage;
            return newMarkupSettingPercentage;
        }

        private decimal GetCurrencyExchangeRateMarkupFromConfig()
        {
            return _config.GetValue<decimal>("CurrencyExchangeRateMarkup"); 
        }
    }
}
