using BikeRental;
using Microsoft.Win32;
using MVVM;
using System.ComponentModel;
using System.IO;
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

        private RelayCommand selectImageCommand;
        public RelayCommand SelectImageCommand
        {
            get
            {
                return selectImageCommand ??
                    (selectImageCommand = new RelayCommand(obj =>
                    {
                        var dialog = new OpenFileDialog
                        {
                            Filter = "Image files (*.png;*.jpg)|*.png;*.jpg"
                        };
                        if (dialog.ShowDialog() == true)
                        {
                            string imagePath = dialog.FileName;
                            NewBike.Image = $"http://localhost:3000/images/Bikes/{Path.GetFileName(imagePath)}";
                        }
                    }));
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