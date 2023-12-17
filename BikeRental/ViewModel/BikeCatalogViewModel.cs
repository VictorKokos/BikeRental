﻿using System.ComponentModel;
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
            Bikes = new ObservableCollection<Bike>(_bikeService.GetAllItems());

            // Подписываемся на событие
            _bikeService.ItemAdded += OnBikeAdded;
        }

        private void OnBikeAdded(Bike bike)
        {
            // Добавляем новый велосипед в коллекцию
            Bikes.Add(bike);
        }



        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        var bikeForm = new NewBikeView(_bikeService, null);
                        bikeForm.Show();
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
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Bike bike = obj as Bike;
                      if (bike != null)
                      {
                          Bikes.Remove(bike);
                          _bikeService.RemoveItem(bike);
                      }
                  },
                 (obj) => Bikes.Count > 0));
            }
        }

        // В BikeCatalogViewModel добавьте следующий код:
        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        var bikeForm = new NewBikeView(_bikeService, SelectedBike);
                        bikeForm.Show();
                    },
                    (obj) => SelectedBike != null));
            }
        }


        public Bike SelectedBike
{
    get { return selectedBike; }
    set
    {
        if (selectedBike != value)
        {
            selectedBike = value;
            OnPropertyChanged("SelectedBike");

         
        }
    }
}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
