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

        public IActionResult Check()
        {
            IEnumerable<Reservation> objList = _db.Reservations;
            return View(objList);
        }
    }
}
