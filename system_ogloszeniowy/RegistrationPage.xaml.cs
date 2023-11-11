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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace system_ogloszeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        MainWindow main;
        public RegistrationPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private async void signInButton_Click(object sender, RoutedEventArgs e)
        {
            passwordErrorLabel.Visibility = Visibility.Hidden;
            emailErrorLabel.Visibility = Visibility.Hidden;

            if ((await App.Database.GetUsers(emailTextBox.Text, passwordBox.Password)).Count == 1)
            {
                main.PageFrame.Navigate(new UserPanelPage());
                return;
            }

            emailErrorLabel.Content = "Podano nieprawidlowy email";
            emailErrorLabel.Visibility = Visibility.Visible;
            passwordErrorLabel.Content = "Podano nieprawidlowe haslo";
            passwordErrorLabel.Visibility = Visibility.Visible;
        }

        private async void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            passwordErrorLabel.Visibility = Visibility.Hidden;
            emailErrorLabel.Visibility = Visibility.Hidden;

            if (!(emailTextBox.Text.Contains("@") && emailTextBox.Text.Contains(".")) || emailTextBox.Text.Length > 35)
            {
                emailErrorLabel.Content = "Podano nieprawidlowy email";
                emailErrorLabel.Visibility = Visibility.Visible;
                return;
            }
            if (passwordBox.Password.Length < 6 || passwordBox.Password.Length > 25)
            {
                passwordErrorLabel.Content = "Podano nieprawidlowe haslo";
                passwordErrorLabel.Visibility = Visibility.Visible;
                return;
            }
            if ((await App.Database.GetUsers(emailTextBox.Text)).Count == 1)
            {
                emailErrorLabel.Content = "Ten email jest juz uzywany";
                emailErrorLabel.Visibility = Visibility.Visible;
                return;
            }

            await App.Database.InsertUser(new classes.User() { 
                Role_id=2, 
                Email=emailTextBox.Text, 
                Password=passwordBox.Password 
            });
            MessageBox.Show("Pomyslnie utworzono konto");
        }
    }
}
