using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Anime
{
    public class AnimeListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YearCreated { get; set; }
        public string GenreId { get; set; }
        [Display(Name = "Average Score")]
        public double Score { get; set; }
    }
}
