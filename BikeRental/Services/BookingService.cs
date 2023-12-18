using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class BookingService : IService<Booking>
    {
        private BookingRepository repository;

        public BookingService(BookingRepository repository)
        {
            this.repository = repository;
        }

        public event Action<Booking> ItemAdded;

        public void AddItem(Booking booking)
        {
            // Добавьте бронирование в базу данных
            repository.Add(booking);

            // Оповещаем подписчиков о том, что бронирование было добавлено
            ItemAdded?.Invoke(booking);
        }

        public void UpdateItem(Booking booking)
        {
            // Add business logic here (e.g., validation)
            repository.Update(booking);
        }

        public void RemoveItem(Booking booking)
        {
            // Add business logic here (e.g., validation)
            repository.Remove(booking);
        }

        public Booking GetItemById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Booking> GetAllItems()
        {
            return repository.GetAll();
        }
    }
}
