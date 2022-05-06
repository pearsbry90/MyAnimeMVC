using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Genre
{
    public class GenreCreate
    {
        [Required]
        [Display(Name = "Anime")]
        public int AnimeTitle { get; set; }

        [Required]
        [Display(Name = "YearCreated")]
        public string YearCreated { get; set; }

        [Required]
        [Display(Name = "GenreName")]
        public string Name { get; set; }
        public IEnumerable<SelectListItem> AnimeOptions { get; set; } = new List<SelectListItem>();

    }
}
