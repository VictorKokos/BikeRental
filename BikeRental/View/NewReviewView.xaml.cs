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
    /// Логика взаимодействия для NewBikeView.xaml
    /// </summary>
    public partial class NewReviewView : Window
    {
        public NewReviewView(ReviewService reviewService)
        {
            InitializeComponent();
            DataContext = new NewItemViewModel<Review, ReviewService>(reviewService);
        }

        public NewReviewView(ReviewService reviewService, Review review)
        {
            InitializeComponent();
            DataContext = new NewItemViewModel<Review, ReviewService>(reviewService, review);
        }

    }
}
