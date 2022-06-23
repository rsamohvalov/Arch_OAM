using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        ApplicationContext DbContext;

        public HomeController( ILogger<HomeController> logger, ApplicationContext context ) {
            _logger = logger;
            DbContext = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error() {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}
