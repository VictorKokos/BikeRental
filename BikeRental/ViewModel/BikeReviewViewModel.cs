using MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BikeRental.ViewModel
{
    public class BikeReviewViewModel : INotifyPropertyChanged
    {
        private Bike bike;
        private ObservableCollection<Review> reviews;
        private string newReviewText;
        private ReviewService reviewService; // Добавьте это поле


        public Bike Bike
        {
            get { return bike; }
            set
            {
                bike = value;
                OnPropertyChanged("Bike");
            }
        }

        private Review newReview;
        public Review NewReview
        {
            get { return newReview; }
            set
            {
                newReview = value;
                OnPropertyChanged("NewReview");
            }
        }

        public ObservableCollection<Review> Reviews
        {
            get { return reviews; }
            set
            {
                reviews = value;
            
            }
        }

        public string NewReviewText
        {
            get { return newReviewText; }
            set
            {
                newReviewText = value;
                OnPropertyChanged("NewReviewText");
            }
        }

        public ICommand SubmitReviewCommand { get; set; }

        public BikeReviewViewModel(ReviewService reviewService, Bike bike) // Измените конструктор
        {
            this.reviewService = reviewService;
            this.bike = bike;
            SubmitReviewCommand = new RelayCommand(SubmitReview, CanSubmitReview);
            this.NewReview = new Review { BikeId = this.Bike.Id, ClientId = View.SessionState.CurrentUser.UserId };

            this.Reviews = new ObservableCollection<Review>(reviewService
                .GetAllItems().Where(r => r.BikeId == this.Bike.Id));
            NewReview.AnswerText = "No answer";
        }


        private void SubmitReview(object parameter)
        {
            this.reviewService.AddItem(NewReview);

            this.Reviews.Add(NewReview);

            // Очищаем новый обзор
            this.NewReview = new Review {
                BikeId = this.Bike.Id,
                ClientId = View.SessionState.CurrentUser.UserId,
                AnswerText = "No answer"
            };

        



        }

        private bool CanSubmitReview(object parameter)
        {
            return !string.IsNullOrEmpty(NewReview.ReviewText) &&
                   !string.IsNullOrEmpty(NewReview.ReviewHeader) &&
                   NewReview.Score > 0;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
