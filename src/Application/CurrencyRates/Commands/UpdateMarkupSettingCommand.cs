using MediatR;
using System.Threading;
using System.Threading.Tasks;
using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Domain.Enums;

namespace currencyExchangeService.Application.CurrencyRates.Commands
{
    public class UpdateMarkupSettingCommand : IRequest
    {
        public int Id { get; set; }

        public decimal MarkupSettingPercentage { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateMarkupSettingCommand>
    {
        private readonly ICurrncyExchangeMarkupManager _markupManager;
        private readonly ICurrencyExchangeRateManager _exchangeRateManager;

        public UpdateTodoItemCommandHandler(ICurrncyExchangeMarkupManager markupManager,
            ICurrencyExchangeRateManager exchangeRateManager)
        {
            _markupManager = markupManager;
            _exchangeRateManager = exchangeRateManager;
        }

        public async Task<Unit> Handle(UpdateMarkupSettingCommand request, CancellationToken cancellationToken)
        {
            _markupManager.UpdateMarkup(Currencies.AUD, request.MarkupSettingPercentage);

            _exchangeRateManager.SetExpired();

            return Unit.Value;
        }
    }
}
