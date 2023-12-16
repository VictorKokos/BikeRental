using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class Bike : INotifyPropertyChanged
    {
        private int id;
        private string model;
        private decimal price_per_day;
        private string description;
        private string image;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [Column("model")]
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        [Column("price_per_day")]
        public decimal PricePerDay
        {
            get { return price_per_day; }
            set
            {
                price_per_day = value;
                OnPropertyChanged("PricePerDay");
            }
        }

        [Column("description")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        [Column("image")]
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
