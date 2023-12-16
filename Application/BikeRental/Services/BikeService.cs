using BikeRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class BikeService
{
    private BikeRepository repository;

    public BikeService(BikeRepository repository)
    {
        this.repository = repository;
    }

    public void AddBike(Bike bike)
    {
        // Add business logic here (e.g., validation)
        repository.Add(bike);
    }

    public void UpdateBike(Bike bike)
    {
        // Add business logic here (e.g., validation)
        repository.Update(bike);
    }
        public void RemoveBike(Bike bike)
        {
            // Add business logic here (e.g., validation)
            repository.Remove(bike);
        }

        public Bike GetBikeById(int id)
    {
        return repository.GetById(id);
    }

    public IEnumerable<Bike> GetAllBikes()
    {
        return repository.GetAll();
    }
}
}

