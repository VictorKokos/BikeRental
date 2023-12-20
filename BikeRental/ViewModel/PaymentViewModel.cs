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
    public class PaymentViewModel : INotifyPropertyChanged
    {
        private string _cardNumber;
        private string _cardHolderName;
        private string _expiryDate;
        private string _cvv;



        private BookingService _bookingService;
        private PaymentService _paymentService;
        private Bike _selectedBike;
        private DateTime _rentalStartDate;
        private DateTime _rentalEndDate;
        private decimal _totalCost;
        private Booking _newBooking;

        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string CardHolderName
        {
            get { return _cardHolderName; }
            set
            {
                _cardHolderName = value;
                OnPropertyChanged();
            }
        }

        public string ExpiryDate
        {
            get { return _expiryDate; }
            set
            {
                _expiryDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime RentalStartDate
        {
            get { return _rentalStartDate; }
            set
            {
                _rentalStartDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime RentalEndDate
        {
            get { return _rentalEndDate; }
            set
            {
                _rentalEndDate = value;
                OnPropertyChanged();
            }
        }
        public Booking NewBooking
        {
            get { return _newBooking; }
            set
            {
                _newBooking = value;
                OnPropertyChanged();
            }
        }


        public PaymentViewModel(BookingService bookingService, PaymentService paymentService, Bike selectedBike, Booking newBooking)
        {
            _bookingService = bookingService;
            _paymentService = paymentService;
            _selectedBike = selectedBike;
            _newBooking = newBooking;

          
        }


        private RelayCommand _payCommand;
        public RelayCommand PayCommand
        {
            get
            {
                return _payCommand ??
                    (_payCommand = new RelayCommand(obj =>
                    {
                        var booking = new Booking
                        {
                            BikeId = _selectedBike.Id,
                            ClientId = SessionState.CurrentUser.UserId, // предполагая, что у вас есть текущий пользователь в SessionState
                            RentalStartDate = NewBooking.RentalStartDate,
                            RentalEndDate = NewBooking.RentalEndDate,
                            Status = "Pending" // или любой другой начальный статус
                        };

                        // Добавляем бронирование в базу данных
                        _bookingService.AddItem(booking);

                        // Создаем новый платеж
                        var payment = new Payment
                        {
                            BookingId = booking.Id,
                            Amount = _selectedBike.PricePerDay * (NewBooking.RentalEndDate - NewBooking.RentalStartDate).Days,
                            PaymentDate = DateTime.Now
                        };

                        // Добавляем платеж в базу данных
                        _paymentService.AddItem(payment);

                        AlarmWindow alarm = new AlarmWindow();
                        alarm.Show();
                    },

                    (obj) => (true)));
            }
        }


        public string CVV
        {
            get { return _cvv; }
            set
            {
                _cvv = value;
                OnPropertyChanged();
            }
        }

       

        public PaymentViewModel()
        {
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
