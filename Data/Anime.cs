using System.ComponentModel.DataAnnotations;

namespace MyAnimeMVC.AnimeMVC.Data
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string YearCreated { get; set; }

        [Required]
        public string GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        public double Score
        {
            get
            {
                return Ratings.Count > 0 ? Ratings.Select(r => r.Score).Sum() / Ratings.Count : 0;
            }
        }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
