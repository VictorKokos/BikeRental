using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class Payment : INotifyPropertyChanged
    {
        private int id;
        private int booking_id;
        private decimal amount;
        private DateTime payment_date;

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

        [Column("booking_id")]
        public int BookingId
        {
            get { return booking_id; }
            set
            {
                booking_id = value;
                OnPropertyChanged("BookingId");
            }
        }

        [Column("amount")]
        public decimal Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        [Column("payment_date")]
        public DateTime PaymentDate
        {
            get { return payment_date; }
            set
            {
                payment_date = value;
                OnPropertyChanged("PaymentDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
