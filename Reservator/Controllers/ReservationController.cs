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
        public IActionResult Index() 
        {
            return View();
        }
    }
}
