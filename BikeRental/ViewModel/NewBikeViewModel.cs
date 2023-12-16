using BikeRental;
using MVVM;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class NewBikeViewModel : INotifyPropertyChanged
    {
        private BikeService _bikeService;
        private Bike _newBike;

        public NewBikeViewModel(BikeService bikeService)
        {
            _bikeService = bikeService;
            _newBike = new Bike();
        }
        public NewBikeViewModel( )
        {
          
        }

        public Bike NewBike
        {
            get { return _newBike; }
            set
            {
                _newBike = value;
                OnPropertyChanged("NewBike");
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(obj =>
                    {
                        _bikeService.AddBike(NewBike);
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}