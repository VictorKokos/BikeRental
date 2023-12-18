using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class BookingRepository : IRepository<Booking>
    {
        private BikeRentalContext context;

        public BookingRepository(BikeRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Booking> GetAll()
        {
            return context.Booking.ToList();
        }

        public Booking GetById(int id)
        {
            return context.Booking.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Booking booking)
        {
            context.Booking.Add(booking);
            context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            context.Booking.Update(booking);
            context.SaveChanges();
        }

        public void Remove(Booking booking)
        {
            booking.Status = "Отменено";
            Update(booking);
        }
    }
}
