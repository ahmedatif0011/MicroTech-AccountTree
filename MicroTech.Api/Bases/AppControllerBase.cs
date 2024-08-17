using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MicroTech.Api.Bases
{
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator mediatorInstance;
        protected IMediator mediator => mediatorInstance ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    }

}
