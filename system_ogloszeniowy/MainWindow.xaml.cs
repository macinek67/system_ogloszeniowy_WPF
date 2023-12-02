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
            //await App.Database.InsertUser_data(new classes.User_data() { User_id=1});
            //await App.Database.InsertUser_language(new User_language() { User_id=1, Language="angielski", Level= "średnio zaawansowany" });
            //await App.Database.InsertRole(new User_role() { Name="user"});
            //await App.Database.InsertUser(new classes.User() { Role_id=1, Email= "admin@gmail.com", Password="123456" });

            //await App.Database.InsertCompany(new Company()
            //{
            //    Name = "Medicover",
            //    Adress = "Aleje Jerozolimskie 96, Warszawa"
            //});

            //await App.Database.DeleteAnnouncement((await App.Database.GetAnnouncement(1)).ElementAt(0));

            //await App.Database.InsertAnnouncement(new Announcement
            //{
            //    Company_id = 1,
            //    Position_name = "performance marketing specialist",
            //    Earnings = "165.00–185.00",
            //    Adress = "aleje jerozolimskie 125, ochota, warszawa",
            //    Position_level = "specjalista (mid / regular), starszy specjalista (senior)",
            //    Contract_type = "kontrakt b2b",
            //    Work_type = "cała polska (praca zdalna)",
            //    Work_time = "pełen etat",
            //    End_date = DateTime.Today.AddDays(2),
            //    Responsibilities = "rozwój api rest dla naszych aplikacji mobilnych;dalszy rozwój naszych platform;pisanie czystego kodu w celu tworzenia funkcjonalnych aplikacji internetowych;tworzenie kodu i bibliotek wielokrotnego użytku do wykorzystania w przyszłości",
            //    Requirements = "5 lat doświadczenia na podobnym stanowisku;doświadczenie z php;znajomość i18n, mariadb, twig, hetzner cloud;zaznajomienie z ogólnym konceptem pracy w chmurze i budowania aplikacji webowych;bardzo dobra znajomość języka angielskiego i niemieckiego (min. b2)",
            //    Benefits = "dofinansowanie zajęć sportowych;prywatna opieka medyczna;pakiet opieki księgowej (do 3 wpisów miesięcznie)"
            //});
            await App.Database.InsertCategory(new Announcement_category()
            {
                Name = "Budownictwo"
            });
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
