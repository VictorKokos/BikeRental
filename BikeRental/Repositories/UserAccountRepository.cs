using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class UserAccountRepository : IRepository<UserAccount>
    {
        private BikeRentalContext context;

        public UserAccountRepository(BikeRentalContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return context.UserAccount.ToList();
        }

        public UserAccount GetById(int id)
        {
            return context.UserAccount.FirstOrDefault(u => u.UserId == id);
        }

        public void Add(UserAccount userAccount)
        {
            context.UserAccount.Add(userAccount);
            context.SaveChanges();
        }

        public void Update(UserAccount userAccount)
        {
            context.UserAccount.Update(userAccount);
            context.SaveChanges();
        }

        public void Remove(UserAccount userAccount)
        {
            context.UserAccount.Remove(userAccount);
            context.SaveChanges();
        }
    }
}
