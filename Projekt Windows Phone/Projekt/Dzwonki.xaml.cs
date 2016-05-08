using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Projekt
{
    public partial class Dzwonki : PhoneApplicationPage
    {
        public Dzwonki()
        {
            InitializeComponent();
            sprawdz();
            

        }
        void sprawdz()
        {
            reset();
            string czas = DateTime.Now.ToString("HHmm");
            int dzwonek = 0;
            int test = Int32.Parse(czas);
            if (test < 850)
            {
                godzina1.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 850;
            }
            else if (test < 940)
            {
                godzina2.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 940;
            }
            else if (test < 1035)
            {
                godzina3.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1035;
            }
            else if (test < 1125)
            {
                godzina4.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1125;
            }
            else if (test < 1220)
            {
                godzina5.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1220;
            }
            else if (test < 1310)
            {
                godzina6.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1310;
            }
            else if (test < 1405)
            {
                godzina7.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1405;
            }
            else if (test < 1455)
            {
                godzina8.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1455;
            }
            else if (test < 1550)
            {
                godzina9.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1550;
            }
            else if (test < 1645)
            {
                godzina10.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1645;
            }
            else if (test < 1735)
            {
                godzina11.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1735;
            }
            else if (test < 1825)
            {
                godzina12.Foreground = new SolidColorBrush(Colors.Red);
                dzwonek = 1825;

            }
            else 
            {
                licznik.Text = "Nie ma już więcej zajęć :) ";
                return;
            }
            string pomoc1 = dzwonek.ToString();
            string pomoc2 = test.ToString();
            if (pomoc1[pomoc1.Length - 3] == pomoc2[pomoc2.Length - 3])
            {
                licznik.Text += (dzwonek - test).ToString() + "min";
            }
            else
            {
               int a= 60-(test % 100) + dzwonek % 100;
               licznik.Text += a.ToString() + "min";
            }


        }
        void reset()
        {
            licznik.Text = "Do dzwonka zostało ~";
            godzina1.Foreground = new SolidColorBrush(Colors.White);
            godzina2.Foreground = new SolidColorBrush(Colors.White);
            godzina3.Foreground = new SolidColorBrush(Colors.White);
            godzina4.Foreground = new SolidColorBrush(Colors.White);
            godzina5.Foreground = new SolidColorBrush(Colors.White);
            godzina6.Foreground = new SolidColorBrush(Colors.White);
            godzina7.Foreground = new SolidColorBrush(Colors.White);
            godzina8.Foreground = new SolidColorBrush(Colors.White);
            godzina9.Foreground = new SolidColorBrush(Colors.White);
            godzina10.Foreground = new SolidColorBrush(Colors.White);
            godzina11.Foreground = new SolidColorBrush(Colors.White);
            godzina12.Foreground = new SolidColorBrush(Colors.White);
        }

        private void bRefresh_Click(object sender, RoutedEventArgs e)
        {
            sprawdz();
        }

    }
}