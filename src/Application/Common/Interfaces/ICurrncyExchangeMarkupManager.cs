using currencyExchangeService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public interface ICurrncyExchangeMarkupManager
    {
        public decimal GetMarkup(Currencies currency);

        public decimal UpdateMarkup(Currencies currency, decimal newMarkupSettingPercentage);
    }
}
