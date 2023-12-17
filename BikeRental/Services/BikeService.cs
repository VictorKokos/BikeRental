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

        public event Action<Bike> BikeAdded;

        public void AddBike(Bike bike)
        {
            // Добавьте велосипед в базу данных
            repository.Add(bike);

            // Оповещаем подписчиков о том, что велосипед был добавлен
            BikeAdded?.Invoke(bike);
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

