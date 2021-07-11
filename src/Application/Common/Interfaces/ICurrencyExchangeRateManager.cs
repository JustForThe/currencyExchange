using currencyExchangeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public interface ICurrencyExchangeRateManager
    {
        Task<IEnumerable<CurrencyRate>> GetCurrencyRates();

        void SetExpired();
    }
}
