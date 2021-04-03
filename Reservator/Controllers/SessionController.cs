using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: AdminPanel/Sessions/Details/5
        public async Task<IActionResult> Details(string date)
        {
            DateTime selectedDate = DateTime.Parse(date);
            DateTime currentDate = DateTime.Today;

            if (selectedDate < currentDate)
            {
                return View("Invalid");
            }
            if (!SessionExists(date))
            {
                var s = new Session
                {
                    DateID = date
                };

                _context.Add(s);
                await _context.SaveChangesAsync();
            }

            var session = await _context.Sessions
                .Include(a => a.Reservations.OrderByDescending(s => s.Score))
                .ThenInclude(u => u.UserInfo)
                .FirstOrDefaultAsync(m => m.DateID == date);
            

            return View(session);
        }

        private bool SessionExists(string date)
        {
            return _context.Sessions.Any(e => e.DateID == date);
        }
    }
}
