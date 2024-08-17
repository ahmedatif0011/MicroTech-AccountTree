using MicroTech.Api.Bases;
using MicroTech.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MicroTech.Core.Handlers.Accounts.Query.Models;

namespace MicroTech.Api.Controllers
{
    public class AccountsController : AppControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route(Router.AccountRouting.GetAllAccounts)]
        [SwaggerOperation(summary: "الحصول بيانات المستخدمين")]
        public async Task<IActionResult> getAllAccounts([FromQuery] string? accountNumber) => Ok(await mediator.Send(new GetTopLevelAccountsRequest()));


        [HttpGet]
        [AllowAnonymous]
        [Route(Router.AccountRouting.GetAccuontDetalies + "/{accountNumber}")]
        [SwaggerOperation(summary: "الحصول بيانات مستخدم تفصيلي")]
        public async Task<IActionResult> getAccuontDetalies(string? accountNumber) => Ok(await mediator.Send(new GetParentDetailsRequest { accountNumber = accountNumber }));

    }
}
