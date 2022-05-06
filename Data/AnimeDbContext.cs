using Microsoft.EntityFrameworkCore;

namespace MyAnimeMVC.AnimeMVC.Data
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options) { }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
