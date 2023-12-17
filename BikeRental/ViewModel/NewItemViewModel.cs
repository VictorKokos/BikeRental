using Microsoft.Win32;
using MVVM;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace BikeRental.ViewModel
{
    public class NewItemViewModel<TItem, TService> : INotifyPropertyChanged
        where TItem : class, new()
        where TService : IService<TItem>
    {
        private TService _service;
        private TItem _newItem;

        public NewItemViewModel(TService service)
        {
            _service = service;
            _newItem = new TItem();
        }

        public NewItemViewModel()
        {

        }

        private bool _isNewItem;

        public NewItemViewModel(TService service, TItem item = null)
        {
            _service = service;
            _isNewItem = item == null;
            _newItem = item ?? new TItem();
        }

        public TItem NewItem
        {
            get { return _newItem; }
            set
            {
                _newItem = value;
                OnPropertyChanged("NewItem");
            }
        }

        // Ваш код для загрузки изображений здесь

        private RelayCommand selectImageCommand;
        public RelayCommand SelectImageCommand
        {
            get
            {
                return selectImageCommand ??
                    (selectImageCommand = new RelayCommand(async obj =>
                    {
                        var dialog = new OpenFileDialog
                        {
                            Filter = "Image files (*.png;*.jpg)|*.png;*.jpg"
                        };
                        if (dialog.ShowDialog() == true)
                        {
                            string imagePath = dialog.FileName;
                            await UploadImageAsync(imagePath);
                        }
                    }));
            }
        }


        public async Task UploadImageAsync(string imagePath)
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "file", Path.GetFileName(imagePath));
            var response = await client.PostAsync("http://localhost:3000/images/Bikes", content);
            if (response.IsSuccessStatusCode)
            {
                // Сохраните URL изображения в базе данных
                (NewItem as Bike).Image = $"http://localhost:3000/images/Bikes/{Path.GetFileName(imagePath)}";
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
                        if (_isNewItem)
                        {
                            _service.AddItem(NewItem);
                        }
                        else
                        {
                            _service.UpdateItem(NewItem);
                        }

                        NewItem = new TItem(); // Сбрасываем NewItem после сохранения

                        // Закрываем окно
                        Application.Current.Windows.OfType<Window>().Last()?.Close();
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
