using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservator.Data;
using Reservator.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        // GET: AdminPanel/Sessions/Details/5
        public async Task<IActionResult> Details(string date)
        {
            if (!SessionExists(date))
            {
                var s = new Session
                {
                    DateID = date
                };

                _db.Add(s);
                await _db.SaveChangesAsync();
            }

            var session = await _db.Sessions
                .Include(a => a.Reservations)
                .FirstOrDefaultAsync(m => m.DateID == date);

            return View(session);
        }

        private bool SessionExists(string date)
        {
            return _db.Sessions.Any(e => e.DateID == date);
        }
    }
}
