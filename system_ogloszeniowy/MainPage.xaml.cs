﻿using System;
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
            accounmentQuantityLabel.Content = App.Database.CountAnnouncements() + " sprawdzonych ofert pracy";
            Update();
        }

        public async void Update()
        {
            offers_ListView.ItemsSource = await App.Database.GetAllAnnouncements();
        }

        private async void viewAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            var announcement_id = int.Parse(((Button)sender).CommandParameter.ToString());
            var announcement = (await App.Database.GetAnnouncement(announcement_id)).ElementAt(0);
            main.PageFrame.Navigate(new AnnouncementPage(main, user, announcement));
        }
    }
}
