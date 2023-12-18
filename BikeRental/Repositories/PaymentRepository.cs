using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class PaymentRepository : IRepository<Payment>
    {
        private BikeRentalContext context;

        public PaymentRepository(BikeRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Payment> GetAll()
        {
            return context.Payment.ToList();
        }

        public Payment GetById(int id)
        {
            return context.Payment.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Payment payment)
        {
            context.Payment.Add(payment);
            context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            context.Payment.Update(payment);
            context.SaveChanges();
        }

        public void Remove(Payment payment)
        {
            context.Payment.Remove(payment);
            context.SaveChanges();
        }
    }
}
