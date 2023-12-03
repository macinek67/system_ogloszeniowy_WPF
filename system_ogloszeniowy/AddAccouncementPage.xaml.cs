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
    /// Logika interakcji dla klasy AddAccouncementPage.xaml
    /// </summary>
    public partial class AddAccouncementPage : Page
    {
        MainWindow main;
        User user;
        public AddAccouncementPage(MainWindow main, User user)
        {
            InitializeComponent();
            this.main = main;
            this.user = user;
            UploadData();
        }

        private async void UploadData()
        {
            companyComboBox.ItemsSource = await App.Database.GetCompanies();
            categoryComboBox.ItemsSource = await App.Database.GetAllCategories();
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Announcement newAccouncement = new Announcement()
            {
                Company_id = ((Company)companyComboBox.SelectedItem).Company_id,
                Category_id = ((Announcement_category)categoryComboBox.SelectedItem).AnnouncementCategory_id,
                Position_name = positionNameTextBox.Text,
                Earnings = earningsTextBox.Text,
                Adress = adressTextBox.Text,
                Position_level = ((ComboBoxItem)positionLevelComboBox.SelectedItem).Content.ToString(),
                Contract_type = ((ComboBoxItem)contractTypeComboBox.SelectedItem).Content.ToString(),
                Work_type = ((ComboBoxItem)workTypeComboBox.SelectedItem).Content.ToString(),
                Work_time = ((ComboBoxItem)workTimeComboBox.SelectedItem).Content.ToString(),
                End_date = (DateTime)endDatePicker.SelectedDate,
                Responsibilities = responsibilitiesTextBox.Text,
                Requirements = requirementsTextBox.Text,
                Benefits = benefitsTextBox.Text
            };
            await App.Database.InsertAnnouncement(newAccouncement);
            main.PageFrame.GoBack();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            main.PageFrame.GoBack();
        }
    }
}
