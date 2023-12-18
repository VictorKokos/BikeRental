using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class Booking : INotifyPropertyChanged
    {
        private int id;
        private int client_id;
        private int bike_id;
        private DateTime booking_date;
        private string status;
        private DateTime rental_start_date;
        private DateTime rental_end_date;

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

        [Column("client_id")]
        public int ClientId
        {
            get { return client_id; }
            set
            {
                client_id = value;
                OnPropertyChanged("ClientId");
            }
        }

        [Column("bike_id")]
        public int BikeId
        {
            get { return bike_id; }
            set
            {
                bike_id = value;
                OnPropertyChanged("BikeId");
            }
        }

        [Column("booking_date")]
        public DateTime BookingDate
        {
            get { return booking_date; }
            set
            {
                booking_date = value;
                OnPropertyChanged("BookingDate");
            }
        }

        [Column("status")]
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        [Column("rental_start_date")]
        public DateTime RentalStartDate
        {
            get { return rental_start_date; }
            set
            {
                rental_start_date = value;
                OnPropertyChanged("RentalStartDate");
            }
        }

        [Column("rental_end_date")]
        public DateTime RentalEndDate
        {
            get { return rental_end_date; }
            set
            {
                rental_end_date = value;
                OnPropertyChanged("RentalEndDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
