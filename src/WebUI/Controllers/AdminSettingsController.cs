using currencyExchangeService.Application.CurrencyRates.Commands;
using currencyExchangeService.Application.CurrencyRates.Queries.GetMarkupSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace currencyExchangeService.WebUI.Controllers
{
    [Authorize]
    public class AdminSettingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MarkupVm>> Get()
        {
            return await Mediator.Send(new GetMarkupQuery());
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateMarkupSettingCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
