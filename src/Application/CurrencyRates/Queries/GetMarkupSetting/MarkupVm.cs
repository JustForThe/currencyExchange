using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Application.Common.Mappings;

namespace currencyExchangeService.Application.CurrencyRates.Commands
{
    public class MarkupVm: IMapFrom<MarkupSetting>
    {
        public int Id { get; set; }
        public decimal MarkupSettingPercentage { get; set; }
        public decimal MaximumMarkupPercentage { get; set; }
        public decimal MinimunMarkupPercentage { get; set; }
    }
}
