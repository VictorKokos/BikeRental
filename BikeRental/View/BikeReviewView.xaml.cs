using BikeRental.ViewModel;
using BikeRental;
using System.Windows;
using BikeRental.View;
using BikeRental.ViewModel;

namespace BikeRental
{
    public partial class BikeReviewView : Window
    {
        public BikeReviewView(Bike bike)
        {
            InitializeComponent();

            var context = new BikeRentalContext();
            var repository = new ReviewRepository(context);
            var service = new ReviewService(repository);
            DataContext = new BikeReviewViewModel(service, bike);
        }
    }
}