using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MicroTech.Web.Bases
{
    public class ControllerBase : Controller
    {
        private IMediator mediatorInstance;
        protected IMediator _mediator => mediatorInstance ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
