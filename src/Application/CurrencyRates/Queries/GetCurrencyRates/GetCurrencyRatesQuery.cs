using currencyExchangeService.Application.Common.Interfaces;
using currencyExchangeService.Domain.Entities;
using currencyExchangeService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.CurrencyRates.Queries.GetCurrencyRates
{
    public class GetCurrencyRatesQuery : IRequest<IEnumerable<CurrencyRate>>
    {
    }
    public class GetCurrencyRatesQueryHandler : IRequestHandler<GetCurrencyRatesQuery, IEnumerable<CurrencyRate>>
    {
        private readonly ICurrencyExchangeRateManager _exchangeRateManager;

        public GetCurrencyRatesQueryHandler(ICurrencyExchangeRateManager exchangeRateManager)
        {
            _exchangeRateManager = exchangeRateManager;
        }

        public Task<IEnumerable<CurrencyRate>> Handle(GetCurrencyRatesQuery request, CancellationToken cancellationToken)
        {
            return _exchangeRateManager.GetCurrencyRates();
        }
    }
}
