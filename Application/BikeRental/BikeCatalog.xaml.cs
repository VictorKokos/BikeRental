using BikeRental;
using System;
using System.IO;
using System.Windows;

namespace BikeRental
{
    public partial class BikeCatalog : Window
    {
        public BikeCatalog()
        {
            InitializeComponent();

            try
            {
                var context = new BikeRentalContext();
                var repository = new BikeRepository(context);
                var service = new BikeService(repository);
                DataContext = new BikeCatalogViewModel(service);
            }
            catch (Exception ex)
            {

                string logPath = @"D:\Work\Kusrach4\Application\BikeRental\log.txt";
                File.WriteAllText(logPath, $"Произошла ошибка: {ex.Message}");
                // Если подключение к базе данных не удалось, используйте конструктор без параметров
                DataContext = new BikeCatalogViewModel();
            }
        }
    }
}
