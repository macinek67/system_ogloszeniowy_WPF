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
        Announcement announcement;
        public AnnouncementPage(MainWindow main, User user, Announcement announcement)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
            this.announcement = announcement;
            UploadData();

        }

        private async void UploadData()
        {
            positionName_TextBlock.Text = announcement.Position_name;
            companeyName_TextBlock.Text = (await App.Database.GetCompany(announcement.Company_id)).ElementAt(0).Name;
            earningsValue_TextBlock.Text = announcement.Earnings + " zł";

            adressValue_TextBlock.Text = announcement.Adress;
            TimeSpan interval = DateTime.Now - announcement.End_date;
            endDateValue_TextBlock.Text = "przez " + (Math.Abs(interval.Days)+1).ToString() + " dni";
            workTypeValue_TextBlock.Text = announcement.Work_time;
            workPlaceValue_TextBlock.Text = announcement.Work_type;
            contractValue_TextBlock.Text = announcement.Contract_type;
            positionLevelValue_TextBlock.Text = announcement.Position_level;

            string[] responsibilities = announcement.Responsibilities.Split(';');
            foreach (string s in responsibilities)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "• " + s.ToString()
                };
                responsibilitiesValue_StackPanel.Children.Add(textBlock);
            }

            string[] requirements = announcement.Requirements.Split(';');
            foreach (string s in requirements)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "• " + s.ToString()
                };
                requirementsValue_StackPanel.Children.Add(textBlock);
            }

            string[] benefits = announcement.Benefits.Split(';');
            foreach (string s in benefits)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "• " + s.ToString()
                };
                benefitsValue_StackPanel.Children.Add(textBlock);
            }
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            main.PageFrame.GoBack();
            return;
        }

        private void sendApplication_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
