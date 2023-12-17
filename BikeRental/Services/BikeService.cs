using BikeRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class BikeService: IService<Bike>
    {
    private BikeRepository repository;

    public BikeService(BikeRepository repository)
    {
        this.repository = repository;
    }

        public event Action<Bike> ItemAdded;

        public void AddItem(Bike bike)
        {
            // Добавьте велосипед в базу данных
            repository.Add(bike);

            // Оповещаем подписчиков о том, что велосипед был добавлен
            ItemAdded?.Invoke(bike);
        }

        public void UpdateItem(Bike bike)
    {
        // Add business logic here (e.g., validation)
        repository.Update(bike);
    }
        public void RemoveItem(Bike bike)
        {
            // Add business logic here (e.g., validation)
            repository.Remove(bike);
        }

        public Bike GetItemById(int id)
    {
        return repository.GetById(id);
    }

    public IEnumerable<Bike> GetAllItems()
    {
        return repository.GetAll();
    }
}
}

