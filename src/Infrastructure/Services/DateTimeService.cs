using currencyExchangeService.Application.Common.Interfaces;
using System;

namespace currencyExchangeService.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
