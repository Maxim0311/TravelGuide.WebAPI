using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Persistence.EFCore
{
    public class AppDbContext : DbContext
    {

        public DbSet<Point> Points { get; set; }
        public DbSet<TouristRoute> Routes { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация таблиц
            modelBuilder.Entity<Point>()
                .HasKey(p => p.Id)
                .HasName("point");

            modelBuilder.Entity<Point>()
                .HasOne(p => p.Route)
                .WithMany(t => t.Points)
                .HasForeignKey(p => p.RouteId);

            modelBuilder.Entity<TouristRoute>()
                .HasKey(p => p.Id)
                .HasName("route");

            modelBuilder.Entity<TouristRoute>()
                .HasOne(p => p.User)
                .WithMany(t => t.Routes)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id)
                .HasName("user");

            // Конфигурация полей
            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(p => p.Username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(p => p.FirstName).HasColumnName("firstname");
            modelBuilder.Entity<User>().Property(p => p.LastName).HasColumnName("lastname");
            modelBuilder.Entity<User>().Property(p => p.Password).HasColumnName("password");

            modelBuilder.Entity<Point>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Point>().Property(p => p.Title).HasColumnName("title");
            modelBuilder.Entity<Point>().Property(p => p.RouteId).HasColumnName("route_id");
            modelBuilder.Entity<Point>().Property(p => p.Latitude).HasColumnName("latitude");
            modelBuilder.Entity<Point>().Property(p => p.Longitude).HasColumnName("longitude");

            modelBuilder.Entity<TouristRoute>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<TouristRoute>().Property(p => p.Title).HasColumnName("title");
            modelBuilder.Entity<TouristRoute>().Property(p => p.UserId).HasColumnName("user_id");
            modelBuilder.Entity<TouristRoute>().Property(p => p.Rating).HasColumnName("rating");
            modelBuilder.Entity<TouristRoute>().Property(p => p.Country).HasColumnName("country");
            modelBuilder.Entity<TouristRoute>().Property(p => p.CreatedDate).HasColumnName("created_date");

            // Начальные данные
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "User",
                    FirstName = "Firstname",
                    LastName = "Lastname",
                    Password = "password"
                });

            modelBuilder.Entity<TouristRoute>()
                .HasData(new TouristRoute
                {
                    Id = 1,
                    Title = "testRoute",
                    UserId = 1,
                    Country = "Россия",
                    Rating = 4.2f,
                    CreatedDate = DateTime.Now,
                });

            modelBuilder.Entity<Point>()
                .HasData(new Point[]
                {
                    new Point { Id = 1, Title = "point1", Latitude = 55.55m, Longitude = 44.44m, RouteId = 1 },
                    new Point { Id = 2, Title = "point2", Latitude = 54.65m, Longitude = 24.44m, RouteId = 1 },
                    new Point { Id = 3, Title = "point3", Latitude = 52.75m, Longitude = 14.44m, RouteId = 1 },
                });
        }
    }
}
