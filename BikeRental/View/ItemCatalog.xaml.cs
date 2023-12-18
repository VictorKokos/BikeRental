using BikeRental;
using BikeRental.ViewModel;
using MVVM;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BikeRental
{
    public partial class ItemCatalog : Window
    {
        private void ButtonSwitchToReview_Click(object sender, RoutedEventArgs e)
        {


            // Создать новое окно с ReviewService в качестве DataContext
            var context = new BikeRentalContext();
            var repository = new ReviewRepository(context);
            var service = new ReviewService(repository);
            var newWindow = new ItemCatalog
            {
                DataContext = new CatalogViewModel<Review, ReviewService>(service)
            };

            // Открыть новое окно
            newWindow.Show();
            // Закрыть текущее окно
            this.Close();

        
        }

        private void ButtonSwitchToBike_Click(object sender, RoutedEventArgs e)
        {


            // Создать новое окно с ReviewService в качестве DataContext
            var context = new BikeRentalContext();
            var repository = new BikeRepository(context);
            var service = new BikeService(repository);
            var newWindow = new ItemCatalog
            {
                DataContext = new CatalogViewModel<Bike, BikeService>(service)
            };

            // Открыть новое окно
            newWindow.Show();
            // Закрыть текущее окно
            this.Close();


        }

        private void ButtonSwitchToPayment_Click(object sender, RoutedEventArgs e)
        {


            // Создать новое окно с ReviewService в качестве DataContext
            var context = new BikeRentalContext();
            var repository = new PaymentRepository(context);
            var service = new PaymentService(repository);
            var newWindow = new ItemCatalog
            {
                DataContext = new CatalogViewModel<Payment, PaymentService>(service)
            };

            // Открыть новое окно
            newWindow.Show();
            // Закрыть текущее окно
            this.Close();


        }
        private void ButtonSwitchToBooking_Click(object sender, RoutedEventArgs e)
        {


            // Создать новое окно с ReviewService в качестве DataContext
            var context = new BikeRentalContext();
            var repository = new BookingRepository(context);
            var service = new BookingService(repository);
            var newWindow = new ItemCatalog
            {
                DataContext = new CatalogViewModel<Booking, BookingService>(service)
            };

            // Открыть новое окно
            newWindow.Show();
            // Закрыть текущее окно
            this.Close();


        }


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
