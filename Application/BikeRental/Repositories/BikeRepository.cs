using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;


namespace BikeRental
{
    public class BikeRepository
    {
        private BikeRentalContext context;

        public BikeRepository(BikeRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bike> GetAll()
        {
            return context.Bike.ToList();
        }

        public Bike GetById(int id)
        {
            return context.Bike.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Bike bike)
        {
            context.Bike.Add(bike);
            context.SaveChanges();
        }

        public void Update(Bike bike)
        {
            context.Bike.Update(bike);
            context.SaveChanges();
        }

        public void Remove(Bike bike)
        {
            context.Bike.Remove(bike);
            context.SaveChanges();
        }
    }
}

