using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Models.Rating
{
    public class RatingListItem
    {
        [Display(Name = "Anime")]
        public string AnimeTitle { get; set; }
        [Display(Name = "YearCreated")]
        public string YearCreated { get; set; }
        [Display(Name = "Rating")]
        public double Score { get; set; }
    }
}
