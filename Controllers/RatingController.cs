using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAnimeMVC.AnimeMVC.Data;
using MyAnimeMVC.AnimeMVC.Models.Rating;

namespace MyAnimeMVC.AnimeMVC.Controllers
{
    public class RatingController : Controller
    {
        private AnimeDbContext _context;
        public RatingController(AnimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RatingListItem> ratings = await _context.Ratings
            .Select(r => new RatingListItem()
            {
                AnimeTitle = r.Anime.Title,
                YearCreated = r.Anime.YearCreated,
                Score = r.Score,
            }).ToListAsync();

            return View(ratings);
        }

        [HttpGet]
        public async Task<IActionResult> Anime(int id)
        {
            IEnumerable<RatingListItem> ratings = await _context.Ratings
            .Where(r => r.AnimeId == id)
            .Select(r => new RatingListItem()
            {
                AnimeTitle = r.Anime.Title,
                YearCreated = r.Anime.YearCreated,
                Score = r.Score,
            }).ToListAsync();

            Anime anime = await _context.Animes.FindAsync(id);
            ViewBag.AnimeTitle = anime.Title;

            return View(ratings);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> animeOptions = await _context.Animes.Select(r => new SelectListItem()
            {
                Text = r.Title,
                Value = r.Id.ToString()
            }).ToListAsync();

            RatingCreate model = new RatingCreate();
            model.AnimeOptions = animeOptions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Rating rating = new Rating()
            {
                AnimeId = model.AnimeId,
                YearCreated = model.YearCreated,
                Score = model.Score,
            };

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
