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
        public async Task<IActionResult> Result()
        {
            
            DateTime currentDate = DateTime.Today;

            string date = currentDate.ToString("yyyy-MM-dd");

            var session = await _context.Sessions
                .Include(a => a.Reservations.Where(r => r.Statement == "Confirmed").OrderByDescending(s => s.Score))
                .ThenInclude(u => u.UserInfo)
                
                .FirstOrDefaultAsync(m => m.Date == date);


                

            return View(session);
        }


        // GET: AdminPanel/Sessions/Details/5
        public async Task<IActionResult> Details(string date)
        {
            if (date== null)
            {
                return NotFound();
            }
            DateTime selectedDate = DateTime.Parse(date);
            DateTime currentDate = DateTime.Today;
            int currentHour = DateTime.Now.Hour;
            if(currentHour >= 23 && selectedDate == currentDate)
            {
                return View("Closed");
            }

            if (selectedDate < currentDate)
            {
                return View("Invalid");
            }
            if (!SessionExists(date))
            {
                var s = new Session
                {
                    Date = date
                };

                _context.Add(s);
                await _context.SaveChangesAsync();
            }

            

            var session = await _context.Sessions
                .Include(a => a.Reservations.OrderByDescending(s => s.Score))
                .ThenInclude(u => u.UserInfo)
                .FirstOrDefaultAsync(m => m.Date == date);
            

            return View(session);
        }




        private bool SessionExists(string date)
        {
            
            return _context.Sessions.Any(e => e.Date == date);
        }

  /*      private bool ResultExists(string date)
        {
            return _context.Sessions
                .Include(a => a.Reservations.Where(r => r.Statement == "Confirmed"))
                .ThenInclude(u => u.UserInfo)
                .FirstOrDefaultAsync(m => m.Date == date);
        }*/



    }
}
