using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net;
using System.Text.Json;

namespace MicroTech.Core.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;

        }
        // called in runtime in pipline
        // Get Current Request 
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                Log.Error(ex.ToString(), context.Request);
                Log.CloseAndFlush();
                await response.WriteAsync(ex.Message);
            }
        }
    }
}
