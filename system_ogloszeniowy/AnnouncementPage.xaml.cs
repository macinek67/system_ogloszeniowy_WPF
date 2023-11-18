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

namespace system_ogloszeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy AnnouncementPage.xaml
    /// </summary>
    public partial class AnnouncementPage : Page
    {
        MainWindow main;
        User user;
        public AnnouncementPage(MainWindow main, User user)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
            UploadData();
        }

        private async void UploadData()
        {

        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            main.PageFrame.Navigate(new AnnouncementPage(main, user));
            return;
        }
    }
}
