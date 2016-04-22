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
    public partial class Ustawienia : PhoneApplicationPage
    {
        public Ustawienia()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
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
            }
        }


}
}