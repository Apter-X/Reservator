﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Create(int id)
        {
            var s = new Reservation
            {
                SessID = id,
                Statement = "InProgress" // Default Value
            };

            _context.Add(s);
            await _context.SaveChangesAsync();

            return Index();
        }
    }
}
