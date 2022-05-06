using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAnimeMVC.AnimeMVC.Data;
using MyAnimeMVC.AnimeMVC.Models.Anime;

namespace MyAnimeMVC.AnimeMVC.Controllers
{
    public class AnimeController : Controller
    {
        private AnimeDbContext _context;
        public AnimeController(AnimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AnimeListItem> animes = await _context.Animes
            .Include(r => r.Ratings)
            .Include(r => r.Genre)
            .Select(r => new AnimeListItem()
            {
                Id = r.Id,
                Title = r.Title,
                YearCreated = r.YearCreated,
                GenreId = r.GenreId,
                Score = r.Score,
            }).ToListAsync();

            return View(animes);
        }

        [ActionName("Details")]
        public async Task<IActionResult> Anime(int id)
        {
            Anime anime = await _context.Animes.
                Include(r => r.Ratings)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (anime == null)
                return RedirectToAction(nameof(Index));

            AnimeDetail animeDetail = new AnimeDetail()
            {
                Id = anime.Id,
                Title = anime.Title,
                YearCreated = anime.YearCreated,
                GenreId = anime.GenreId,
                Score = anime.Score,
            };

            return View(animeDetail);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimeCreate model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.errorMessage = ModelState.FirstOrDefault().Value.Errors.FirstOrDefault().ErrorMessage;
                return View();
            }

            Anime anime = new Anime()
            {
                Title = model.Title,
                YearCreated = model.YearCreated,
                GenreId = model.GenreId,
            };

            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Anime anime = await _context.Animes.FindAsync(id);

            if (anime == null)
                return RedirectToAction(nameof(Index));

            AnimeEdit animeEdit = new AnimeEdit()
            {
                Id = anime.Id,
                Title = anime.Title,
                YearCreated = anime.YearCreated,
                GenreId = anime.GenreId,
            };

            return View(animeEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AnimeEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            Anime anime = await _context.Animes.FindAsync(id);

            if (anime == null)
                return RedirectToAction(nameof(Index));

            anime.Title = model.Title;
            anime.YearCreated = model.YearCreated;
            anime.GenreId = model.GenreId;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = anime.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            Anime anime = await _context.Animes.FindAsync(id);

            if (anime == null)
                return RedirectToAction(nameof(Index));

            AnimeDetail animeDetail = new AnimeDetail()
            {
                Id = anime.Id,
                Title = anime.Title,
                YearCreated = anime.YearCreated,
                GenreId = anime.GenreId,
            };

            return View(animeDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, AnimeDetail model)
        {
            Anime anime = await _context.Animes.FindAsync(model.Id);

            if (anime == null)
                return RedirectToAction(nameof(Index));

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
