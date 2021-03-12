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
    public class MovieArtistsController : Controller
    {
        private readonly MovieArtistsDbContext _context;

        public MovieArtistsController(MovieArtistsDbContext context)
        {
            _context = context;
        }

        // GET: MovieArtists
        public async Task<IActionResult> Index()
        {
            var movieArtistsDbContext = _context.MovieArtist.Include(m => m.Movie);
            return View(await movieArtistsDbContext.ToListAsync());
        }

        // GET: MovieArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieArtist = await _context.MovieArtist
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movieArtist == null)
            {
                return NotFound();
            }

            return View(movieArtist);
        }

        // GET: MovieArtists/Create
        public IActionResult Create()
        {
            ViewData["MovieFK"] = new SelectList(_context.Set<Movie>(), "ID", "ID");
            return View();
        }

        // POST: MovieArtists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,gender,DOB,Bio,IsFamous,MovieFK")] MovieArtist movieArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieFK"] = new SelectList(_context.Set<Movie>(), "ID", "ID", movieArtist.MovieFK);
            return View(movieArtist);
        }

        // GET: MovieArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieArtist = await _context.MovieArtist.FindAsync(id);
            if (movieArtist == null)
            {
                return NotFound();
            }
            ViewData["MovieFK"] = new SelectList(_context.Set<Movie>(), "ID", "ID", movieArtist.MovieFK);
            return View(movieArtist);
        }

        // POST: MovieArtists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,gender,DOB,Bio,IsFamous,MovieFK")] MovieArtist movieArtist)
        {
            if (id != movieArtist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieArtistExists(movieArtist.ID))
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
            ViewData["MovieFK"] = new SelectList(_context.Set<Movie>(), "ID", "ID", movieArtist.MovieFK);
            return View(movieArtist);
        }

        // GET: MovieArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieArtist = await _context.MovieArtist
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movieArtist == null)
            {
                return NotFound();
            }

            return View(movieArtist);
        }

        // POST: MovieArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieArtist = await _context.MovieArtist.FindAsync(id);
            _context.MovieArtist.Remove(movieArtist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieArtistExists(int id)
        {
            return _context.MovieArtist.Any(e => e.ID == id);
        }
    }
}
