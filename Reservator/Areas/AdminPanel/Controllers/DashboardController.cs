using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public string GetJson()
        {
            Dictionary<string, int> statements = new Dictionary<string, int>
            {
                { "InProgress", _context.Reservations.Where(c => c.Statement == "InProgress").Count() },
                { "Canceled", _context.Reservations.Where(c => c.Statement == "Canceled").Count() },
                { "Confirmed", _context.Reservations.Where(c => c.Statement == "Confirmed").Count() },
                { "Refused", _context.Reservations.Where(c => c.Statement == "Refused").Count() }
            };

            string json = JsonConvert.SerializeObject(statements, Formatting.Indented);

            return json;
        }
    }
}
