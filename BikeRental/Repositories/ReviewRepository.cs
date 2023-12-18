using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class ReviewRepository : IRepository<Review>
    {
        private BikeRentalContext context;

        public ReviewRepository(BikeRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return context.Review.ToList();
        }

        public Review GetById(int id)
        {
            return context.Review.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Review review)
        {
            context.Review.Add(review);
            context.SaveChanges();
        }

        public void Update(Review review)
        {
            context.Review.Update(review);
            context.SaveChanges();
        }

        public void Remove(Review review)
        {
            context.Review.Remove(review);
            context.SaveChanges();
        }
    }
}
