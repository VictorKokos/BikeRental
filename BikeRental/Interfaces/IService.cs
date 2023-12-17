using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public interface IService<T> where T : class
    {
        event Action<T> ItemAdded;
        void AddItem(T item);
        void UpdateItem(T item);
        void RemoveItem(T item);
        T GetItemById(int id);
        IEnumerable<T> GetAllItems();
    }

}
