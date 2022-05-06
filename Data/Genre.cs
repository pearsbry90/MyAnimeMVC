﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAnimeMVC.AnimeMVC.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Anime")]
        public int AnimeId { get; set; }

        [Required]
        public string YearCreated { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
