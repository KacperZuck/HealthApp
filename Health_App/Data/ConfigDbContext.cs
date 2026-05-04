using Health_App.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Health_App.Data
{
    public class ConfigDbContext : DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> user { get; set; }
        public DbSet<UserData> userData { get; set; }
        public DbSet<Friends> friends { get; set; }

        // SEED
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var adminGuid = Guid.Parse("7d2a8494-0e3a-4467-966c-54378f7e268f");
            var testGuid = Guid.Parse("7d2a8494-0e3a-9967-966c-54378f7e268f");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = adminGuid,
                    name = "Admin",
                    surname = "Admin",
                    email = "admin@health.pl",
                    pasword = "admin123",
                    birth_date = new DateOnly(1990, 1, 1)
                },
                new User
                {
                    id = testGuid,
                    name = "Test",
                    surname = "Test",
                    email = "test@test.pl",
                    pasword = "test123",
                    birth_date = new DateOnly(2000, 5, 15)
                }
            );

            modelBuilder.Entity<UserData>().HasData(
                new UserData { id = Guid.NewGuid(), name = "Glukoza",user_id = adminGuid, mesurment = 75, created_at = DateTime.Now.AddDays(-1) },
                new UserData { id = Guid.NewGuid(), name = "Glukoza", user_id = adminGuid, mesurment = 85, created_at = DateTime.Now },
                new UserData { id = Guid.NewGuid(), name = "Glukoza", user_id = testGuid, mesurment = 7, created_at = DateTime.Now.AddDays(-1) },
                new UserData { id = Guid.NewGuid(), name = "Glukoza", user_id = testGuid, mesurment = 25, created_at = DateTime.Now },
                               
                new UserData { id = Guid.NewGuid(), name = "Dawka insuliny", user_id = adminGuid, mesurment = 15, created_at = DateTime.Now.AddDays(-1) },
                new UserData { id = Guid.NewGuid(), name = "Dawka insuliny", user_id = adminGuid, mesurment = 8, created_at = DateTime.Now },
                new UserData { id = Guid.NewGuid(), name = "Dawka insuliny", user_id = testGuid, mesurment = 7, created_at = DateTime.Now.AddDays(-1) },
                new UserData { id = Guid.NewGuid(), name = "Dawka insuliny", user_id = testGuid, mesurment = 20, created_at = DateTime.Now }
            );

            modelBuilder.Entity<Friends>().HasData(
                new Friends { id = Guid.NewGuid(), userId = adminGuid, friendId = testGuid }
                );
        }
    }
}