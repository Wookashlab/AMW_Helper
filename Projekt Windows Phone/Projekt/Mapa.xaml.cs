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
    public partial class Mapa : PhoneApplicationPage
    {
        public Mapa()
        {
            InitializeComponent();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Przystanek autobusowy: AKADEMIA MARYNARKI WOJENNEJ (->Obłuże)");
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Przystanek autobusowy: AKADEMIA MARYNARKI WOJENNEJ (->Oksywie)");
        }

        private void Image_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Wejscie główne");
        }

        private void Image_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Wejscie od strony ul. Grudzińskiego");
        }

        private void Image_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Przystanek autobusowy: OKSYWIE DOLNE (->Obłuże)");
        }

        private void Image_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Przystanek autobusowy: OKSYWIE DOLNE (->Oksywie)");
        }

        private void Image_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Biblioteka i Audytorium AMW ");
        }

        private void Image_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Przystanek autobusowy: OKSYWIE DOLNE (->Obłuże)");
        }

        private void Image_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Sklep ODIDO \nGodziny otwarcia:\nPon-Pt:\nSob:\nND:");
        }

        private void Image_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Malta & Pub 69\nGodziny otwarcia:\nCodziennie: 11:00 - 21:15\nTelefon: 58 625-37-47");
        }

        private void Image_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Tawerna pod Kordem\nGodziny otwarcia:\nCodziennie: 08:00–15:30\nTelefon: 58 626-25-33");
        }

        private void Image_Tap_11(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Klub Studencki SPINAKER");
        }

        private void Image_Tap_12(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Akademiki AMW");
        }
    }
}