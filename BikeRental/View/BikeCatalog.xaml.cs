using BikeRental;
using BikeRental.ViewModel;
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
                DataContext = new CatalogViewModel<Bike, BikeService>(service);
            }
            catch (Exception ex)
            {
                string logPath = @"D:\Work\Kusrach4\Application\BikeRental\log.txt";
                File.WriteAllText(logPath, $"Произошла ошибка: {ex.Message}");

                // Если вы хотите создать CatalogViewModel без сервиса,
                // вам нужно добавить конструктор без параметров в CatalogViewModel
                DataContext = new CatalogViewModel<Bike, BikeService>();
            }
        }
    }

}
