using currencyExchangeService.Domain.Common;
using System.Collections.Generic;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public class MarkupSetting : AuditableEntity
    {
            public int Id { get; set; }

            public decimal MarkupSettingPercentage { get; set; }
     }
}