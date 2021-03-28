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
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            return View();
        }

        public async Task<IActionResult> Create(int sessId, string userId)
        {
            int rank = Ranker(1, 1);

            var s = new Reservation
            {
                Score = rank,
                SessID = sessId,
                UsrID = userId,
                Statement = "InProgress" // Default Value
            };

            _context.Add(s);
            await _context.SaveChangesAsync();

            return Index();
        }

        private int Ranker(int resRefused, int resAccepted)
        {
            int rank = 30;

            rank += (resRefused * 10) - (resAccepted * 5);

            return rank;
        }
    }
}
