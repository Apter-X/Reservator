using Microsoft.AspNetCore.Mvc;
using Reservator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Controllers
{
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SessionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(DateTime searchDate)
        {
            var events = from e in _db.Reservations
                         select e;

            if (!String.IsNullOrEmpty(searchDate.ToLongTimeString()))
            {
                return View(events.Where(s => s.Date.CompareTo(searchDate) == 0));
            }

            return Search();
        }

        public IActionResult Search()
        {
            return View();
        }
    }


}
