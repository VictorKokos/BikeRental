using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
