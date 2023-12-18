using BikeRental;
using BikeRental.ViewModel;
using System;
using System.IO;
using System.Windows;

namespace BikeRental
{
    public partial class ItemCatalog : Window
    {
        public ItemCatalog()
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
                DataContext = new CatalogViewModel<Bike, BikeService>();
            }
        }
    }

}
