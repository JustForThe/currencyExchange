using currencyExchangeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public interface ICurrencyExchangeRatesService
    {
        Task<IEnumerable<CurrencyRate>> GetCurrencyRates();
    }
}
