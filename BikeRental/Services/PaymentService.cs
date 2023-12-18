using BikeRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class PaymentService : IService<Payment>
    {
        private PaymentRepository repository;

        public PaymentService(PaymentRepository repository)
        {
            this.repository = repository;
        }

        public event Action<Payment> ItemAdded;

        public void AddItem(Payment payment)
        {
            // Добавьте платеж в базу данных
            repository.Add(payment);

            // Оповещаем подписчиков о том, что платеж был добавлен
            ItemAdded?.Invoke(payment);
        }

        public void UpdateItem(Payment payment)
        {
            // Add business logic here (e.g., validation)
            repository.Update(payment);
        }

        public void RemoveItem(Payment payment)
        {
            // Add business logic here (e.g., validation)
            repository.Remove(payment);
        }

        public Payment GetItemById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Payment> GetAllItems()
        {
            return repository.GetAll();
        }
    }
}
