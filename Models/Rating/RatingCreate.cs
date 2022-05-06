using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Rating
{
    public class RatingCreate
    {
        [Required]
        [Display(Name = "Anime")]
        public int AnimeId { get; set; }

        [Required]
        [Display(Name = "YearCreated")]
        public string YearCreated { get; set; }

        [Required]
        [Range(1, 10)]
        public double Score { get; set; }
        public IEnumerable<SelectListItem> AnimeOptions { get; set; } = new List<SelectListItem>();
    }
}
