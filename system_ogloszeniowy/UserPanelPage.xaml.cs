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
    /// Logika interakcji dla klasy UserPanelPage.xaml
    /// </summary>
    public partial class UserPanelPage : Page
    {
        MainWindow main;
        User user;
        User_data userData;
        public UserPanelPage(MainWindow main, User user)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
            UploadData();
        }

        private async void UploadData()
        {
            userData = (await App.Database.GetUser_data(user.User_id))[0];
            if (userData.Name != null) nameTextBox.Text = userData.Name;
            if (userData.Surname != null) surnameTextBox.Text = userData.Surname;
            if (userData.Birth_date != null) birthDateTextBox.Text = userData.Birth_date;
            if (userData.Telephone_number != null) telephoneTextBox.Text = userData.Telephone_number;
            if (userData.City != null) cityTextBox.Text = userData.City;
            if (userData.Currnent_occupation != null) currentOccupationTextBox.Text = userData.Currnent_occupation;
            if (userData.Summary != null) summaryTextBox.Text = userData.Summary;

            languageListView.ItemsSource = await App.Database.GetUser_language(user.User_id);
            educationListView.ItemsSource = await App.Database.GetUser_education(user.User_id);
        }

        private async void savePersonDataButton_Click(object sender, RoutedEventArgs e)
        {
            userData.Name = nameTextBox.Text;
            userData.Surname = surnameTextBox.Text;
            userData.Currnent_occupation = currentOccupationTextBox.Text;
            userData.City = cityTextBox.Text;
            await App.Database.UpdateUser_data(userData);
            UploadData();
        }

        private async void contactDataButton_Click(object sender, RoutedEventArgs e)
        {
            userData.Birth_date = birthDateTextBox.Text;
            userData.Telephone_number = telephoneTextBox.Text;
            await App.Database.UpdateUser_data(userData);
            UploadData();
        }

        private async void summaryButton_Click(object sender, RoutedEventArgs e)
        {
            userData.Summary = summaryTextBox.Text;
            await App.Database.UpdateUser_data(userData);
            UploadData();
        }

        private async void languageAddButton_Click(object sender, RoutedEventArgs e)
        {
            await App.Database.InsertUser_language(new User_language() { User_id=user.User_id, Language=languageTextBox.Text, Level=languageLevelComboBox.Text });
            UploadData();
        }

        private async void languageDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (languageListView.SelectedItem == null) return;
            await App.Database.DeleteUser_language((User_language)languageListView.SelectedItem);
            UploadData();
        }

        private async void educationAddButton_Click(object sender, RoutedEventArgs e)
        {
            await App.Database.InsertUser_education(new User_education() { User_id = user.User_id, 
                School_name = schoolNameTextBox.Text, 
                Level = educationLevelComboBox.Text, 
                Direction = directionTextBox.Text, 
                Specialization = specializationTextBox.Text, 
                Period_start = periodStartDatePicker.SelectedDate.Value.Date, 
                Period_end = periodEndDatePicker.SelectedDate.Value.Date 
            });
            UploadData();
        }

        private async void educationDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (educationListView.SelectedItem == null) return;
            await App.Database.DeleteUser_education((User_education)educationListView.SelectedItem);
            UploadData();
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            main.PageFrame.Navigate(new AnnouncementPage(main, user));
            return;
        }
    }
}
