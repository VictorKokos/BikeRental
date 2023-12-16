using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MVVM;

namespace BikeRental
{
    public class BikeCatalogViewModel : INotifyPropertyChanged
    {
        private Bike selectedBike;
        private BikeService _bikeService;

        public ObservableCollection<Bike> Bikes { get; set; }

        public BikeCatalogViewModel(BikeService bikeService)
        {
            _bikeService = bikeService;
            Bikes = new ObservableCollection<Bike>(_bikeService.GetAllBikes());
        }

        private BikeCatalogRelayCommand addCommand;
        public BikeCatalogRelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new BikeCatalogRelayCommand(obj =>
                    {
                        Bike bike = new Bike();
                        Bikes.Insert(0, bike);
                        SelectedBike = bike;
                        _bikeService.AddBike(bike);
                    }));
            }
        }

        public BikeCatalogViewModel()
        {
            Bikes = new ObservableCollection<Bike>
    {
        new Bike { Id = 1, Model = "Mountain Bike", PricePerDay = 20.00m, Description = "A bike suitable for mountain terrain" },
        new Bike { Id = 2, Model = "Road Bike", PricePerDay = 15.00m, Description = "A bike designed for road cycling" },
        new Bike { Id = 3, Model = "Hybrid Bike", PricePerDay = 18.00m, Description = "A bike that combines features of mountain and road bikes" }
    };
        }
        private BikeCatalogRelayCommand removeCommand;
        public BikeCatalogRelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new BikeCatalogRelayCommand(obj =>
                  {
                      Bike bike = obj as Bike;
                      if (bike != null)
                      {
                          Bikes.Remove(bike);
                          _bikeService.RemoveBike(bike);
                      }
                  },
                 (obj) => Bikes.Count > 0));
            }
        }

        public Bike SelectedBike
        {
            get { return selectedBike; }
            set
            {
                selectedBike = value;
                OnPropertyChanged("SelectedBike");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
