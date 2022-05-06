using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Genre
{
    public class GenreListItem
    {
        [Display(Name = "Anime")]
        public string AnimeTitle { get; set; }
        [Display(Name = "YearCreated")]
        public string YearCreated { get; set; }
        [Display(Name = "GenreName")]
        public string Name { get; set; }
    }
}
