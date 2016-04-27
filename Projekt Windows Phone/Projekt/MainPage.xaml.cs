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
using System.Text.RegularExpressions;
namespace Projekt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Bmapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
        }

        private void Bdziwonki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Dzwonki.xaml", UriKind.Relative));
        }

        private void Bautobusy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Autobusy.xaml", UriKind.Relative));
        }

        private void ustawieniaImg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Ustawienia.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            // Switch the placement of the buttons based on an orientation change.
            if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            {
               
            }
            // If not in portrait, move buttonList content to visible row and column.
            else
            {
                NavigationService.Navigate(new Uri("/MainPageL.xaml", UriKind.Relative));
            }
            
        }

/*        private void button_Click(object sender, RoutedEventArgs e)                     //Zakomentowałem to bo narazie nie używamy tego 
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(przystanki);
        }
        void przystanki(object sender, OpenReadCompletedEventArgs e)
        {
                using (var reader = new StreamReader(e.Result))
                {
                string value = reader.ReadToEnd();
                string[] response = Regex.Split(value, "</br>");
                int i = 0;
                    while ( i < response.Length - 1)
                    {
                        List.Items.Add(response[i]);
                        i++;
                    }
             }
        } */
    }
}