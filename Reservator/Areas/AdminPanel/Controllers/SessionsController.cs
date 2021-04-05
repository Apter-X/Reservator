 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservator.Data;
using Reservator.Models;

namespace Reservator.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "admin")]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminPanel/Sessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessions.ToListAsync());
        }

        // GET: AdminPanel/Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           

            var session = await _context.Sessions
                .Include(a => a.Reservations)
                .ThenInclude(u => u.UserInfo)
                
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null)
            {
                return NotFound();
            }
            
            return View(session) ;
        }
        public async Task<IActionResult> List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var session = await _context.Sessions
              .Include(a => a.Reservations)
              .ThenInclude(u => u.UserInfo)
              .FirstOrDefaultAsync(m => m.SessionID == id);

            int data = _context.Reservations
                   .Where(r => r.Statement == "InProgress")
                   .Where(r => r.SessID == id).Count();
            if(data > 0)
            {
                int counter = 0;
                int count = _context.Reservations
                                          .Where(r => r.SessID == id).Count();
                while (counter < count)
                {
                    if (counter < 30)
                    {
                        var res = _context.Reservations
                                           .Where(r => r.Statement == "InProgress")
                                          .Where(r => r.SessID == id).OrderByDescending(s => s.Score).First();
                        res.Statement = "Confirmed";


                        counter++;
                    }
                    else
                    {
                        var res = _context.Reservations
                              .Where(r => r.Statement == "InProgress")
              .Where(r => r.SessID == id).First();
                        res.Statement = "Refused";
                        counter++;
                    }
                    _context.SaveChanges();

                }


                return View("Details", session);
            }
            return View("Details",session);

        }
        // GET: AdminPanel/Sessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionID,Date")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        // GET: AdminPanel/Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: AdminPanel/Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionID,Date")] Session session)
        {
            if (id != session.SessionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.SessionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        // GET: AdminPanel/Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: AdminPanel/Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.SessionID == id);
        }
    }
}
