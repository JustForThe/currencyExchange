using AutoMapper;
using AutoMapper.QueryableExtensions;
using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Application.CurrencyRates.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using currencyExchangeService.Domain.Enums;

namespace currencyExchangeService.Application.CurrencyRates.Queries.GetMarkupSetting
{
    public class GetMarkupQuery : IRequest<MarkupVm>
    {
    }

    public class MarkupSettingQueryHandler : IRequestHandler<GetMarkupQuery, MarkupVm>
    {
        private readonly ICurrncyExchangeMarkupManager _markupManager;

        public MarkupSettingQueryHandler(ICurrncyExchangeMarkupManager markupManager)
        {
            _markupManager = markupManager;
        }

        public async Task<MarkupVm> Handle(GetMarkupQuery request, CancellationToken cancellationToken)
        {
            var markupSettings = _markupManager.GetMarkup(Currencies.AUD);

            var makupSetting = new MarkupVm
            {
                Id = 1,
                MarkupSettingPercentage = markupSettings,
                MaximumMarkupPercentage = 0.2m,
                MinimunMarkupPercentage = 0.001m  
            };

            return makupSetting;
        }
    }
}
