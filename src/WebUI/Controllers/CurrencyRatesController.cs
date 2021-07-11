using currencyExchangeService.Application.CurrencyRates.Queries.GetCurrencyRates;
using currencyExchangeService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currencyExchangeService.WebUI.Controllers
{
    public class CurrencyRatesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CurrencyRate>> Get()
        {
            return await Mediator.Send(new GetCurrencyRatesQuery());
        }
    }
}
