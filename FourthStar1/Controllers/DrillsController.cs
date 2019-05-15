using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FourthStar1.Data;
using FourthStar1.Models;
using FourthStar1.Models.ViewModels;
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

        //below .Include() clause to Category Table was modeled after C29/IcePhantoms/Bangazon/HomeController
        //below Index method also indebted to Microsoft tutorial for adding search functionality to MVC:  
        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-2.2

        public async Task<IActionResult> Index(string searchString)
        {
            var currentuser = await GetCurrentUserAsync();

            var drills = from d in _context.Drills
                         select d;

            //conditional - Is the user using the search bar?
            if (!String.IsNullOrEmpty(searchString))
            {
                drills = drills.Where(s => s.DrillDescription.Contains(searchString))
                    .Include(d => d.Category)
                    .Where(m => m.UserId == currentuser.Id);
                return View(await drills.ToListAsync());

            }

            //this view is returned if user is NOT trying to implement search functionality.
            return View(await _context.Drills
                .Include(d => d.Category)
                .Where(m => m.UserId == currentuser.Id)
                .ToListAsync());
        }
        

        // GET: Drills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drill = await _context.Drills
                .Include(d => d.Category)
                //.Where(d => d.CategoryId == id)
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

            {
                //instantiate new viewmodel
                var viewModel = new DrillCategory()
                {
                    //i think Drill ='s null because the user is creating it, not the viewModel
                    Drill = null,

                    CategoryOptions = _context.Categories.Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    }).ToList()
                };
 
                return View(viewModel);
            }
            
        }

        // POST: Drills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DrillName,DrillDescription,PlayersRequired,UserId,CategoryId,Category,DateCreated")] Drill drill)
        {
            //don't fully understand why removing user/userId from ModelState here.
            ModelState.Remove("User");
            ModelState.Remove("userId");

            var user = await GetCurrentUserAsync();
            drill.UserId = user.Id;
            drill.DateCreated = DateTime.Now;

            

            var viewmodel = new DrillCategory()
            {
                Drill = null,
                CategoryOptions = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList()
            };

            //this is awful.  I want to run the code inside the conditional, but i have to override the conditional with ! to set it to !ModelState.IsValid.  It appears that i don't need a valid model state in order to set current dateTime.  don't understand
            if (!ModelState.IsValid)
            {
                _context.Add(drill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View(viewmodel);

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

            var viewmodel = new DrillCategory()
            {
                Drill = drill,
                CategoryOptions = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList()
            };
           
            return View(viewmodel);
        }

        // POST: Drills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DrillName,DrillDescription,PlayersRequired,DateCreated,CategoryId")] Drill drill)
        {
            if (id != drill.Id)
            {
                return NotFound();
            }

            //don't fully understand why removing user/userId from ModelState here.
            ModelState.Remove("User");
            ModelState.Remove("userId");

            var user = await GetCurrentUserAsync();
            drill.UserId = user.Id;

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

            /*else do the work similar to create/ 'post' however drill is already defined, Drill = drill*/
            var viewmodel = new DrillCategory()
            {
                Drill = drill,
                CategoryOptions = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList()
            };


            return View(viewmodel);
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
