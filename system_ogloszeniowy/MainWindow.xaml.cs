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
using system_ogloszeniowy.classes;
using system_ogloszeniowy.Tables;

namespace system_ogloszeniowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user = null;
        public MainWindow()
        {
            InitializeComponent();
            PageFrame.Navigate(new RegistrationPage(this));
            //e();
        }
        public async void e()
        {
            await App.Database.InsertUser_data(new classes.User_data() { User_id=1});
            //await App.Database.InsertUser_language(new User_language() { User_id=1, Language="angielski", Level= "średnio zaawansowany" });
            //await App.Database.InsertRole(new User_role() { Name="user"});
            //await App.Database.InsertUser(new classes.User() { Role_id=1, Email= "admin@gmail.com", Password="123456" });
        }

        private void mainPageNavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (user == null) return;
            PageFrame.Navigate(new MainPage(this, user));
        }

        private void userProfileNavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (user == null) return;
            PageFrame.Navigate(new UserPanelPage(this, user));
        }
    }
}
