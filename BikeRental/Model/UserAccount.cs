using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class UserAccount : INotifyPropertyChanged
    {
        private int userId;
        private string user_login;
        private string salt;
        private string first_name;
        private string last_name;
        private string phone_number;
        private string email;
        private string role;
        private string image;

        [Key]
        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        [Column("user_login")]
        public string UserLogin
        {
            get { return user_login; }
            set
            {
                user_login = value;
                OnPropertyChanged("UserLogin");
            }
        }

        [Column("salt")]
        public string Salt
        {
            get { return salt; }
            set
            {
                salt = value;
                OnPropertyChanged("Salt");
            }
        }

        [Column("first_name")]
        public string FirstName
        {
            get { return first_name; }
            set
            {
                first_name = value;
                OnPropertyChanged("FirstName");
            }
        }

        [Column("last_name")]
        public string LastName
        {
            get { return last_name; }
            set
            {
                last_name = value;
                OnPropertyChanged("LastName");
            }
        }

        [Column("phone_number")]
        public string PhoneNumber
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        [Column("email")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        [Column("role")]
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }

        [Column("image")]
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        private string password;

        [Column("password")]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
