using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DataAccess.Data
{
    public class CinemaDbContext : IdentityDbContext<User>
    {
        public CinemaDbContext() { }
        public CinemaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataAccesss;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = 1, Name = "Action" },
                new Genre() { Id = 2, Name = "Adventure" },
                new Genre() { Id = 3, Name = "Comedy" },
                new Genre() { Id = 4, Name = "Detective" },
                new Genre() { Id = 5, Name = "Drama" },
                new Genre() { Id = 6, Name = "Documentary" },
                new Genre() { Id = 7, Name = "Horror" },
                new Genre() { Id = 8, Name = "Thriller" }
            });

            modelBuilder.Entity<Movie>().HasData(new[]
            {
                new Movie() { Id = 1, Name = "Oppenheimer", GenreId = 6, TicketPrice = 120, ImageUrl = "https://m.media-amazon.com/images/I/71lqDylcvGL._AC_SL1500_.jpg", Description = "The story of American scientist, J. Robert Oppenheimer, and his role in the development of the atomic bomb." },
                new Movie() { Id = 2, Name = "Barbie", GenreId = 2, TicketPrice = 120, ImageUrl = "https://deadline.com/wp-content/uploads/2023/04/barbie-BARBIE_VERT_TSR_W_TALENT_2764x4096_DOM_rgb.jpg?w=1280", Description = "Barbie suffers a crisis that leads her to question her world and her existence." },
                new Movie() { Id = 3, Name = "The Nun II", GenreId= 7, TicketPrice = 120, ImageUrl = "https://www.joblo.com/wp-content/uploads/2023/04/the-nun-2-review.jpg", Description = "The sequel to the worldwide smash hit follows Sister Irene as she once again comes face-to-face with Valak, the demon nun."}
            });

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
