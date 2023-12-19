using BikeRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BikeRental
{
    /// <summary>
    /// Логика взаимодействия для BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        public BookingWindow(Bike bike)
        {
            InitializeComponent();

            var context = new BikeRentalContext();
            var Brepository = new BookingRepository(context);
            var Prepository = new PaymentRepository(context);
            var Bservice = new BookingService(Brepository);
            var Pservice = new PaymentService(Prepository);
            DataContext = new BookingViewModel(Bservice, Pservice,bike );
        }
    }
}
