using Microsoft.AspNetCore.Mvc;
using Reservator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["In-progress"] = 0;
            ViewData["Canceled"] = 0;
            ViewData["Validated"] = 0;
            ViewData["Refused"] = 0;

            return View();
        }
    }
}
