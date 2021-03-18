using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View();
        }

        // GET: AdminPanel/Sessions/Details/5
        public async Task<IActionResult> Details(string? date)
        {
            var session = await _db.Sessions
                .Include(a => a.Reservations)
                .FirstOrDefaultAsync(m => m.DateID == date);

            if (session == null)
            {
                return Index();
            }

            return View(session);
        }
    }


}
