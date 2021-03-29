using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["In-progress"] = _context.Reservations.Where(c => c.Statement == "InProgress").Count();
            ViewData["Canceled"] = _context.Reservations.Where(c => c.Statement == "Canceled").Count();
            ViewData["Confirmed"] = _context.Reservations.Where(c => c.Statement == "Confirmed").Count();
            ViewData["Refused"] = _context.Reservations.Where(c => c.Statement == "Refused").Count();

            return View();
        }
    }
}
