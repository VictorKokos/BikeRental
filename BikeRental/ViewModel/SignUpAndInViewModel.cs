using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BikeRental;
using BikeRental.View;
using MVVM;

namespace BikeRental.ViewModel
{
    public class SignUpAndInViewModel : INotifyPropertyChanged
    {
        private UserAccount userAccount;
        private UserAccountService userAccountService;

        public SignUpAndInViewModel(UserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
            userAccount = new UserAccount();
        }

        public UserAccount UserAccount
        {
            get { return userAccount; }
            set
            {
                userAccount = value;
                OnPropertyChanged("UserAccount");
            }
        }

     


        public ICommand SignUpCommand
        {
            get
            {
                return new RelayCommand(
                    execute: parameter =>
                    {
                        var passwordBox = parameter as PasswordBox;
                        var password = passwordBox.Password;

                        // Проверка, что все поля UserAccount не равны null
                        if (!string.IsNullOrEmpty(UserAccount.UserLogin) &&
                            !string.IsNullOrEmpty(UserAccount.FirstName) &&
                            !string.IsNullOrEmpty(UserAccount.LastName) &&
                            !string.IsNullOrEmpty(UserAccount.PhoneNumber) &&
                            !string.IsNullOrEmpty(UserAccount.Email) &&   
                            password.Length > 4)
                        {
                            var rng = new RNGCryptoServiceProvider();
                            byte[] saltBytes = new byte[32];
                            rng.GetBytes(saltBytes);
                            string salt = Convert.ToBase64String(saltBytes);

                            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
                            byte[] hashBytes = rfc2898DeriveBytes.GetBytes(32);
                            string hashedPassword = Convert.ToBase64String(hashBytes);

                            UserAccount.Salt = salt;
                            UserAccount.Password = hashedPassword;

                            UserAccount.Role = "client";
                            UserAccount.Image = "placeholder_image";
                            userAccountService.AddItem(UserAccount);

                            // Если все поля UserAccount не равны null, установить IsLoggedIn в true
                            SessionState.IsLoggedIn = true;
                            SessionState.CurrentUser = userAccount;
                        }
                        else
                        {
                            // Если любое поле UserAccount равно null, установить IsLoggedIn в false
                            SessionState.IsLoggedIn = false;
                            MessageBox.Show("Вы не заполнили все поля",
            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    },
                    canExecute: parameter =>
                    {
                        if (!SessionState.IsLoggedIn)
                        {
                            return true;
                        }// Замените это на вашу логику проверки
                        return false;
                    });
            }
        }



        public ICommand SignInCommand
        {
            get
            {
                return new RelayCommand(
                    execute: parameter =>
                    {
                        var passwordBox = parameter as PasswordBox;
                        var password = passwordBox.Password;

                        // Извлечение UserAccount из базы данных
                        var userAccount = userAccountService.GetUserAccount(UserAccount.UserLogin);

                        if (userAccount != null)
                        {
                            // Генерация хэша для введенного пароля с использованием salt из базы данных
                            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(userAccount.Salt), 10000);
                            byte[] hashBytes = rfc2898DeriveBytes.GetBytes(32);
                            string hashedPassword = Convert.ToBase64String(hashBytes);

                            // Проверка, совпадает ли хэш введенного пароля с хэшем в базе данных
                            if (hashedPassword == userAccount.Password)
                            {
                                SessionState.IsLoggedIn = true;
                                SessionState.CurrentUser = userAccount;
                            }
                            else
                            {
                                SessionState.IsLoggedIn = false;
                                MessageBox.Show("Неверное имя пользователя или пароль",
       "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверное имя пользователя",
            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    },
                    canExecute: parameter =>
                    {
                        return true; // Замените это на вашу логику проверки
                    });
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
