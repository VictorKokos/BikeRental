using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BikeRental
{
    public class BikeRentalContext : DbContext
    {
        public DbSet<Bike> Bike { get; set; }
        public DbSet<Review> Review { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasKey(u => u.UserId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=BikeRental;User=sa;Password=1234;");
            }
            catch (Exception ex)
            {
                string logPath = @"D:\Work\Kusrach4\Application\BikeRental\log.txt";
                File.WriteAllText(logPath, $"Произошла ошибка при подключении к базе данных: {ex.Message}");
            }
        }
    }
}
