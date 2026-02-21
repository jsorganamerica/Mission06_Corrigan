using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Corrigan.Models;

namespace Mission06_Corrigan.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieCollectionContext _context;

        public MoviesController(MovieCollectionContext context)
        {
            _context = context;
        }

        // LIST ALL MOVIES
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .OrderBy(m => m.Title)
                .ToListAsync();

            return View(movies);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.MovieId) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}