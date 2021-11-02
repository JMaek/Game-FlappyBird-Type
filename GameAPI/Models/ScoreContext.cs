using Microsoft.EntityFrameworkCore;

namespace GameAPI.Models
{
    public class ScoreContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }

        public ScoreContext(DbContextOptions<ScoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                new Game()
                {
                    GameId = 1,
                    GameName = "a"
                }
            });
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User()
                {
                    UserId = 1,
                    UserName = "ua"
                }
            });
            modelBuilder.Entity<Score>().HasData(new Score[]
            {
                new Score()
                {
                    ScoreId = 1,
                    GameId = 1,
                    UserId = 1,
                    Points = 123,
                    TStamp = System.DateTimeOffset.Now
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}