using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MVVM;

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
                      if (item != null)
                      {
                          Items.Remove(item);
                          _service.RemoveItem(item);
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
                            var bikeForm = new NewBikeView(_service as BikeService, selectedItem as Bike);
                            bikeForm.Show();
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
