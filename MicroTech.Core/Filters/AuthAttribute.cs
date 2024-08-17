using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroTech.Core.Filters
{
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           
        }
    }
}
