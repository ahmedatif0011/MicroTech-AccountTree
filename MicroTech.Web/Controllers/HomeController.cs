using Microsoft.AspNetCore.Mvc;
using MicroTech.Core.Handlers.Accounts.Query;
using MicroTech.Core.Handlers.Accounts.Query.Models;
using MicroTech.Data.Entities;
using MicroTech.Data.Responses;
using MicroTech.Web.Models;
using System.Diagnostics;

namespace MicroTech.Web.Controllers
{
    public class HomeController : Bases.ControllerBase
    {
        public HomeController()
        {

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
