using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BikeRental
{
    public class BikeRentalContext : DbContext
    {
        public DbSet<Bike> Bike { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=BikeRental;User=sa;Password=1234;");
            }
            catch (Exception ex)
            {
                // Замените на ваш путь к файлу
                string logPath = @"D:\Work\Kusrach4\Application\BikeRental\log.txt";
                File.WriteAllText(logPath, $"Произошла ошибка при подключении к базе данных: {ex.Message}");
            }
        }
    }
}
