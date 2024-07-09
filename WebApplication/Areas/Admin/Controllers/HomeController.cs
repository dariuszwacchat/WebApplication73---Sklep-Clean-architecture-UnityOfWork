using Domain.Models;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")] 
    public class HomeController : Controller
    {
        public IActionResult Index ()
        {
            NI.Navigation = Navigation.HomeIndex;
            return View();
        }
    }
}
