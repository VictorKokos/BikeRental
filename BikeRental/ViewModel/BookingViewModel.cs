using BikeRental.View;
using MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BikeRental.ViewModel
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private Bike _selectedBike;
        private DateTime _rentalStartDate = DateTime.Now;
        private DateTime _rentalEndDate = DateTime.Now;
        private BookingService _bookingService;
        private PaymentService _paymentService;
        private Booking booking = new Booking
        {
            RentalStartDate = DateTime.Now,
            RentalEndDate = DateTime.Now
        };
        public Bike SelectedBike
        {
            get { return _selectedBike; }
            set
            {
                _selectedBike = value;
                OnPropertyChanged();
            }
        }

        public DateTime RentalStartDate
        {
            get { return _rentalStartDate; }
            set
            {
                _rentalStartDate = value;
                booking.RentalStartDate = value; // Обновляем свойство StartDate объекта Booking
                OnPropertyChanged();
            }
        }
        public Booking Booking
        {
            get { return booking; }
            set
            {
                booking = value;
                OnPropertyChanged();
            }
        }

        public DateTime RentalEndDate
        {
            get { return _rentalEndDate; }
            set
            {
                _rentalEndDate = value;
                booking.RentalEndDate = value; // Обновляем свойство EndDate объекта Booking
                OnPropertyChanged();
            }
        }

        public ICommand BookCommand { get; }

        public BookingViewModel(BookingService bookingService, PaymentService paymentService, Bike selectedBike)
        {
            _bookingService = bookingService;
            _paymentService = paymentService;
            SelectedBike = selectedBike;

            BookCommand = new RelayCommand(obj =>
            {
           
                var paymentWindow = new PaymentView(new PaymentViewModel(_bookingService, _paymentService, SelectedBike, booking));
                paymentWindow.Show();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
