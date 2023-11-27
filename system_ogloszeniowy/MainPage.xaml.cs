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
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainWindow main;
        User user;
        public MainPage(MainWindow main, User user)
        {
            InitializeComponent();
            this.main = main;
            this.user = user;
        }
    }
}
