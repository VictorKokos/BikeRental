using BikeRental;
using MVVM;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

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

        private bool _isNewBike;

        public NewBikeViewModel(BikeService bikeService, Bike bike = null)
        {
            _bikeService = bikeService;
            _isNewBike = bike == null;
            _newBike = bike ?? new Bike();
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
                        if (_isNewBike)
                        {
                            _bikeService.AddBike(NewBike);
                        }
                        else
                        {
                            _bikeService.UpdateBike(NewBike);
                        }

                        NewBike = new Bike(); // Сбрасываем NewBike после сохранения

                        // Закрываем окно
                        Application.Current.Windows.OfType<NewBikeView>().FirstOrDefault()?.Close();
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