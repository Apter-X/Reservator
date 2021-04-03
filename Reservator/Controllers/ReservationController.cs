using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reservator.Data;
using Reservator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reservator.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserInfo> _userManager;

        public ReservationController(ApplicationDbContext context, UserManager<UserInfo> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index() 
        {
            return View();
        }

        public async Task<IActionResult> Create(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var check = _context.Reservations.Where(c => c.UsrID == userId).Where(d => d.SessID == id );

            if (check.Count() != 0)
            {
                return View("Exist");
            }

            var rand = new Random();

            int rank = Ranker(rand.Next(10, 60), rand.Next(5, 30));

            var s = new Reservation
            {
                Score = rank,
                SessID = id,
                UsrID = userId,
                Statement = "InProgress" // Default Value
            };

            _context.Add(s);
            await _context.SaveChangesAsync();

            return Index();
        }

        public IActionResult Exist()
        {
            return View();
        }

        private int Ranker(int resRefused, int resAccepted)
        {
            int rank = 30;

            rank += (resRefused * 10) - (resAccepted * 5);

            return rank;
        }
    }
}
