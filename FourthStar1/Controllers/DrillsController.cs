using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FourthStar1.Data;
using FourthStar1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace FourthStar1.Controllers
{
    public class DrillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;


        public DrillsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //any method that needs to see who the user is can invoke the method
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);



        // GET: Drills
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drills.ToListAsync());
        }

        // GET: Drills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drill = await _context.Drills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drill == null)
            {
                return NotFound();
            }

            return View(drill);
        }

        // GET: Drills/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Drills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DrillName,DrillDescription,PlayersRequired,DateCreated,UserId")] Drill drill)
        {
            ModelState.Remove("User");
            ModelState.Remove("userId");

            var user = await GetCurrentUserAsync();
            drill.UserId = user.Id;


            if (ModelState.IsValid)
            {
                _context.Add(drill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drill);
        }

        // GET: Drills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drill = await _context.Drills.FindAsync(id);
            if (drill == null)
            {
                return NotFound();
            }
            return View(drill);
        }

        // POST: Drills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DrillName,DrillDescription,PlayersRequired,DateCreated")] Drill drill)
        {
            if (id != drill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrillExists(drill.Id))
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
            return View(drill);
        }

        // GET: Drills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drill = await _context.Drills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drill == null)
            {
                return NotFound();
            }

            return View(drill);
        }

        // POST: Drills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drill = await _context.Drills.FindAsync(id);
            _context.Drills.Remove(drill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrillExists(int id)
        {
            return _context.Drills.Any(e => e.Id == id);
        }
    }
}
