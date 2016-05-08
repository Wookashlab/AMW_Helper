using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Projekt
{
    public partial class MainPageL : PhoneApplicationPage
    {
        public MainPageL()
        {
            InitializeComponent();
        }

        private void Bautobusy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Autobusy.xaml", UriKind.Relative));
        }

        private void Bdzwonki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Dzwonki.xaml", UriKind.Relative));
        }

        private void Bmapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
        }

        private void ustawieniaIng_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Ustawienia.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            // Switch the placement of the buttons based on an orientation change.
            if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            // If not in portrait, move buttonList content to visible row and column.
            else
            {
                
            }
            
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Terminate();
        }
    }
}