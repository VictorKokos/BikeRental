using BikeRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class ReviewService : IService<Review>
    {
        private ReviewRepository repository;

        public ReviewService(ReviewRepository repository)
        {
            this.repository = repository;
        }

        public event Action<Review> ItemAdded;

        public void AddItem(Review review)
        {
            // Добавьте отзыв в базу данных
            repository.Add(review);

            // Оповещаем подписчиков о том, что отзыв был добавлен
            ItemAdded?.Invoke(review);
        }

        public void UpdateItem(Review review)
        {
            // Add business logic here (e.g., validation)
            repository.Update(review);
        }

        public void RemoveItem(Review review)
        {
            // Add business logic here (e.g., validation)
            repository.Remove(review);
        }

        public Review GetItemById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Review> GetAllItems()
        {
            return repository.GetAll();
        }
    }
}
