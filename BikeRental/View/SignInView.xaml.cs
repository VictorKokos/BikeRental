using BikeRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BikeRental.View
{
    /// <summary>
    /// Логика взаимодействия для SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        private ItemCatalog itemCatalog;
        private SignUpView SignUpView;
        public SignInView()
        {



            InitializeComponent();



            var context = new BikeRentalContext();
            var repository = new UserAccountRepository(context);
            var service = new UserAccountService(repository);
            DataContext = new SignUpAndInViewModel(service);
        }


        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {



            // Открыть окно входа
            SignUpView = new SignUpView();
            SignUpView.Show();
            // Закрыть окно регистрации
            this.Close();


        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (button != null)
            {
                var command = button.Command as ICommand;
                if (command != null)
                    command.Execute(button.CommandParameter);
            }


            var viewModel = this.DataContext as SignUpAndInViewModel;
            if (viewModel != null && viewModel.IsLoggedIn)
            {
                itemCatalog = new ItemCatalog();
                itemCatalog.Show();
                this.Close();
            }
        }
    }
}
