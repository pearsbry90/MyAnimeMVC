using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Anime
{
    public class AnimeCreate
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string YearCreated { get; set; }

        [Required]
        [StringLength(100)]
        public string GenreId { get; set; }
    }
}
