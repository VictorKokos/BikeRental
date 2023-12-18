using BikeRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental
{
    public class UserAccountService : IService<UserAccount>
    {
        private UserAccountRepository repository;

        public UserAccountService(UserAccountRepository repository)
        {
            this.repository = repository;
        }

        public event Action<UserAccount> ItemAdded;

        public void AddItem(UserAccount userAccount)
        {
            // Проверка каждого поля на null
            if (string.IsNullOrEmpty(userAccount.UserLogin) ||
                string.IsNullOrEmpty(userAccount.Salt) ||
                string.IsNullOrEmpty(userAccount.FirstName) ||
                string.IsNullOrEmpty(userAccount.LastName) ||
                string.IsNullOrEmpty(userAccount.PhoneNumber) ||
                string.IsNullOrEmpty(userAccount.Email) ||
                string.IsNullOrEmpty(userAccount.Role) ||
                string.IsNullOrEmpty(userAccount.Image))
            {
                
            }
            else
            {

                repository.Add(userAccount);
                ItemAdded?.Invoke(userAccount);
            }


        }

        public void UpdateItem(UserAccount userAccount)
        {

            if (string.IsNullOrEmpty(userAccount.UserLogin) ||
                string.IsNullOrEmpty(userAccount.Salt) ||
                string.IsNullOrEmpty(userAccount.FirstName) ||
                string.IsNullOrEmpty(userAccount.LastName) ||
                string.IsNullOrEmpty(userAccount.PhoneNumber) ||
                string.IsNullOrEmpty(userAccount.Email) ||
                string.IsNullOrEmpty(userAccount.Role) ||
                string.IsNullOrEmpty(userAccount.Image))
            {

            }
            else
            {
                repository.Update(userAccount);
            }
        }


        public void RemoveItem(UserAccount userAccount)
        {
           
            repository.Remove(userAccount);
        }

        public UserAccount GetItemById(int id)
        {
            return repository.GetById(id);
        }
        public UserAccount GetUserAccount(string userLogin)
        {
            return repository.GetAll().FirstOrDefault(user => user.UserLogin == userLogin);
        }
        public IEnumerable<UserAccount> GetAllItems()
        {
            return repository.GetAll();
        }
    }
}
