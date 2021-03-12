using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesManagememtSystem.Data;
using MoviesManagememtSystem.Models;

namespace MoviesManagememtSystem.Controllers
{
    [Authorize]
    public class MakersController : Controller
    {
        private readonly MovieArtistsDbContext _context;

        public MakersController(MovieArtistsDbContext context)
        {
            _context = context;
        }

        // GET: Makers
        public async Task<IActionResult> Index()
        {
            var movieArtistsDbContext = _context.Maker.Include(m => m.Movie);
            return View(await movieArtistsDbContext.ToListAsync());
        }

        // GET: Makers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Maker
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // GET: Makers/Create
        public IActionResult Create()
        {
            ViewData["MovieFK"] = new SelectList(_context.Movie, "ID", "ID");
            return View();
        }

        // POST: Makers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,DOB,Bio,MovieFK")] Maker maker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieFK"] = new SelectList(_context.Movie, "ID", "ID", maker.MovieFK);
            return View(maker);
        }

        // GET: Makers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Maker.FindAsync(id);
            if (maker == null)
            {
                return NotFound();
            }
            ViewData["MovieFK"] = new SelectList(_context.Movie, "ID", "ID", maker.MovieFK);
            return View(maker);
        }

        // POST: Makers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,DOB,Bio,MovieFK")] Maker maker)
        {
            if (id != maker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakerExists(maker.ID))
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
            ViewData["MovieFK"] = new SelectList(_context.Movie, "ID", "ID", maker.MovieFK);
            return View(maker);
        }

        // GET: Makers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Maker
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (maker == null)
            {
                return NotFound();
            }

            return View(maker);
        }

        // POST: Makers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maker = await _context.Maker.FindAsync(id);
            _context.Maker.Remove(maker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakerExists(int id)
        {
            return _context.Maker.Any(e => e.ID == id);
        }
    }
}
