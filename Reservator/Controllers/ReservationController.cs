using Microsoft.AspNetCore.Mvc;
using Reservator.Data;
using Reservator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReservationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Check(DateTime searchDate)
        {
            var events = from e in _db.Reservations
                         select e;

            if (!String.IsNullOrEmpty(searchDate.ToLongTimeString()))
            {
                return View(events.Where(s => s.Date.CompareTo(searchDate) == 0));
            }

            return View();
        }
    }
}
