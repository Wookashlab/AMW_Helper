using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Projekt.Resources;
using System.IO;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace Projekt
{
    public partial class Ustawienia : PhoneApplicationPage
    {
        public Ustawienia()
        {
            InitializeComponent();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.Text = "Aktualizacja bazy danych";
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/aktualizuj.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(aktualizuj);
            textBlock.Text = "Prosze czekać trwa aktualizacja...";
        }
        void aktualizuj(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                textBlock.Text = "Aktualizacja skonczona";
                SystemTray.ProgressIndicator.IsVisible = false;
            }
        }

       

        private void bOnas_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Program AMW Helper został stworzny przez Macieja Hein i Łukasza Labuda. \nStudentów 3 roku informatyki na Akademi Marynarki Wojejnnej na potrzeby przedmiotu - Aplikacje internetowe i mobile");
        }

      

    }
}