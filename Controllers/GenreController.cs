using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAnimeMVC.AnimeMVC.Data;
using MyAnimeMVC.AnimeMVC.Models.Genre;

namespace MyAnimeMVC.AnimeMVC.Controllers
{
    public class GenreController : Controller
    {
        private AnimeDbContext _context;
        public GenreController(AnimeDbContext context)
        {
            _context = context;
        }

        public ActionResult GenreListItem()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GenreListItem> ratings = await _context.Genres
            .Select(r => new GenreListItem()
            {
                AnimeId = r.Anime.Title,
                YearCreated = r.YearCreated,
                Name = r.Name,
            }).ToListAsync();

            return View(ratings);
        }

        [HttpGet]
        public async Task<IActionResult> Anime(int id)
        {
            IEnumerable<GenreListItem> genres = await _context.Genres
            .Where(r => r.AnimeId == id)
            .Select(r => new GenreListItem()
            {
                AnimeId = r.Anime.Title,
                YearCreated = r.YearCreated,
                Name = r.Name,
            }).ToListAsync();

            Anime anime = await _context.Animes.FindAsync(id);
            ViewBag.AnimeTitle = anime.Title;

            return View(genres);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> animeOptions = await _context.Animes.Select(r => new SelectListItem()
            {
                Text = r.Title,
                Value = r.Id.ToString()
            }).ToListAsync();

            GenreCreate model = new GenreCreate();
            model.AnimeOptions = animeOptions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Genre genre = new Genre()
            {
                AnimeId = model.AnimeTitle,
                YearCreated = model.YearCreated,
                Name = model.Name,
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
