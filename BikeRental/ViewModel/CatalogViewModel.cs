using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MVVM;
using System.Windows;
using System.Windows.Input;
using BikeRental.View;

namespace BikeRental.ViewModel
{
    public class CatalogViewModel<TItem, TService> : INotifyPropertyChanged
     where TItem : class
     where TService : IService<TItem>
    {
        private TItem selectedItem;
        private TService _service;

        public ObservableCollection<TItem> Items { get; set; }

        public CatalogViewModel(TService service)
        {
            _service = service;
            Items = new ObservableCollection<TItem>(_service.GetAllItems());

            // Подписываемся на событие
            _service.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(TItem item)
        {
            // Добавляем новый элемент в коллекцию
            Items.Add(item);
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        if (typeof(TItem) == typeof(Bike))
                        {
                            var bikeForm = new NewBikeView(_service as BikeService, null);
                            bikeForm.Show();
                        }
                        else if (typeof(TItem) == typeof(Review) && selectedItem != null)
                        {
                            var reviewForm = new NewReviewView(_service as ReviewService, selectedItem as Review);
                            reviewForm.Show();
                        }
                        else {
                            MessageBox.Show("Вы не можете добавить этот объект",
            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }


                    }));
            }
        }

        public CatalogViewModel()
        {
            if (_service == null)
            {
                Items = new ObservableCollection<TItem>();
            }
        }


        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      TItem item = obj as TItem;
                      if (item != null && !(item is Bike))
                      {
                          if (!(item is Booking))
                          {
                              Items.Remove(item);
                          }
                          _service.RemoveItem(item);
                      }
                      else 
                      {
                          MessageBox.Show("Невозможно удалить велосипед",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                      }
                  },
                 (obj) => Items.Count > 0));
            }
        }

  
  


        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        if (typeof(TItem) == typeof(Bike) && _service is BikeService bikeService)
                        {
                            var newForm = new NewBikeView(_service as BikeService, selectedItem as Bike);
                            newForm.Show();
                        }
                        if (typeof(TItem) == typeof(Review))
                        {
                            var newForm = new NewReviewView(_service as ReviewService, selectedItem as Review);
                            newForm.Show();
                        }
                        if (typeof(TItem) == typeof(Booking))
                        {
                            var newForm = new NewBookingView(_service as BookingService, selectedItem as Booking);
                            newForm.Show();
                        }
                         if (typeof(TItem) == typeof(Payment) && selectedItem!=null)
                        {
                            var newForm = new NewPaymentView(_service as PaymentService, selectedItem as Payment);
                            newForm.Show();
                        }
                         
                    },

                    (obj) => SelectedItem != null));
            }
        }



        private RelayCommand _bookCommand;
        public RelayCommand BookCommand
        {
            get
            {
                return _bookCommand ??
                    (_bookCommand = new RelayCommand(obj =>
                    {
                        if (SessionState.CurrentUser.Role == "client")
                        {
                            var bookingWindow = new BookingWindow(selectedItem as Bike);
                            bookingWindow.Show();
                        }

                    },

                    (obj) => SelectedItem != null));
            }
        }

        private RelayCommand _reviewCommand;
        public RelayCommand ReviewCommand
        {
            get
            {
                return _reviewCommand ??
                    (_reviewCommand = new RelayCommand(obj =>
                    {
                        if (SessionState.CurrentUser.Role == "client")
                        {
                            var reviewWindow = new BikeReviewView(selectedItem as Bike);
                            reviewWindow.Show();
                        }

                    },

                    (obj) => SelectedItem != null));
            }
        }



        public TItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
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
