using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.IO;
using System.Text.RegularExpressions;
namespace Projekt
{
    public partial class Autobusy : PhoneApplicationPage
    {
        public Autobusy()
        {
            InitializeComponent();
        }
        public class Przystanek
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string forgroundColor { get;  set;}
            public string fontsize { get; set; }
        }
        public string jakiprzystanek = "";
        private void AMWObl(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
            jakiprzystanek = "AMWOBLUZE";
        }
        private void AMWOksywie_Click(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select3.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
            jakiprzystanek = "AMWOKSYWIE";
        }
        private void OksywieObluze(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select5.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
            jakiprzystanek = "OKSOBLUZE";
        }

        private void OksywieOksywie(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select7.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
            jakiprzystanek = "OKSOKSYWIE";
        }
        void bus(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                List.Items.Clear();
                string value = reader.ReadToEnd();
                string[] response = Regex.Split(value, "<br>");
                int i = 0;
                while (i < response.Length - 1)
                {
                    Przystanek p = new Przystanek() { Name = " " +  response[i], ImagePath = "/Assets/add.png", forgroundColor = "White", fontsize = "35" };
                    List.Items.Add(p);
                    i++;
                }
            }
        }
        int ile_dodano;
        void rozklad(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                string value = reader.ReadToEnd();
                string[] response = Regex.Split(value, "<br>");
                ile_dodano = 0;
                for(int i = 0; i < response.Length; i++)
                {
                    if (response[i] != "" && response[i] != "Morska ")
                    {
                        if (response[i] == "Hipermarket Tesco ")
                        {
                            Przystanek p = new Przystanek() { Name = " " +  response[i] + "- Morska", ImagePath = "/Assets/BusS.png", forgroundColor = "Green", fontsize = "20"};
                            List.Items.Insert(selected + ile_dodano + 1, p);
                        }
                        else
                        {
                            Przystanek p = new Przystanek() { Name = " " + response[i], ImagePath = "/Assets/BusS.png", forgroundColor = "Green" , fontsize = "20" };
                            List.Items.Insert(selected + ile_dodano + 1, p);
                        }
                        
                        ile_dodano++;
                    }
                }
                ile.Add(ile_dodano);
            }
        }
        List<int> l = new List<int>(); //lista przechowujaca informacje o tym czy dany element jest rozwiniety 
        List<int> ile = new List<int>();
        bool check;
        int selected;
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Przystanek rozp = new Przystanek();
            try
            {
                rozp = (Przystanek)List.SelectedItem;
            }
            catch
            {
                rozp.ImagePath = "asdsadasda";
            }
            if (List.SelectedIndex != -1)  //dzieki temu mozemy odznaczyc zaznaczony element umozliwia to zwijanie i rozwijanie tego samego elementu 
            {
                if (rozp.ImagePath == "/Assets/add.png" || rozp.ImagePath == "/Assets/sub.png")
                {
                    check = false;
                    for (int i = 0; i < l.Count; i++) //sprawdzenie czy wybrany element jest rozwiniety 
                    {
                        if (l[i] == List.SelectedIndex) //jestli jest rozwiniety zwiniecie go 
                        {
                            for (int k = 1; k <= ile[i]; k++)
                            {
                                List.Items.RemoveAt(l[i] + 1);
                            }
                            // List.Items.RemoveAt(l[i] + 1); //usuniecie z listy jednego elemenut 
                            l.Remove(l[i]); // usuniecie z listy rozwinietych elementow 
                            check = true;
                            for (int j = 0; j < l.Count; j++)
                            {
                                if (l[j] > List.SelectedIndex)
                                {
                                    l[j] = l[j] - ile[i]; // przesuniecie indeksów elementow 
                                }
                            }
                            ile.Remove(ile[i]);
                            //element opodzialn za ddanie + na poczatku 
                            int index1 = List.SelectedIndex;
                            Przystanek widok2 = new Przystanek();
                            Przystanek widok3 = new Przystanek();
                            widok2 = (Przystanek)List.SelectedItem;
                            widok2 = (Przystanek)List.SelectedItem;
                            widok3.Name = "";
                            for (int k = 0; k < widok2.Name.Length; k++)
                            {
                                widok3.Name += widok2.Name[k];
                            }
                            widok2.ImagePath = "/Assets/add.png";
                            widok2.Name = widok3.Name;
                            List.Items.Insert(index1 + 1, widok2);
                            List.Items.RemoveAt(index1);
                            // koniec elementu 

                            List.SelectedIndex = -1;
                        }
                    }
                    if (check == false)
                    {
                        //nowe
                        Przystanek  autobus = new Przystanek();
                        autobus = (Przystanek)List.SelectedItem;
                        string autobus1 = autobus.Name;
                        if (autobus.Name[1] == 'X')
                        {
                            autobus1 = autobus.Name[0].ToString();
                        }
                        else
                        {
                            autobus1 = autobus.Name[1].ToString() + autobus.Name[2].ToString() + autobus.Name[3].ToString();
                        }
                        //koniec
                        //element odpowiedzialny za wstawienie -
                        int index = List.SelectedIndex;
                        Przystanek widok = (Przystanek)List.SelectedItem;
                        Przystanek widok1 = new Przystanek();
                        widok1.Name = "";
                        for (int i = 0; i < widok.Name.Length; i++)
                        {
                            widok1.Name += widok.Name[i];
                        }
                        widok.ImagePath = "/Assets/sub.png";
                        widok.Name = widok1.Name;
                        //koniec elementu 

                        //nowe
                        selected = List.SelectedIndex;
                        if (jakiprzystanek == "AMWOBLUZE")
                        {
                            var webClient = new WebClient();
                            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select2.php?a='" + autobus1 + "'"));
                            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
                        }
                        if(jakiprzystanek == "AMWOKSYWIE")
                        {
                            var webClient = new WebClient();
                            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select4.php?a='" + autobus1 + "'"));
                            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
                        }
                        if (jakiprzystanek == "OKSOBLUZE")
                        {
                            var webClient = new WebClient();
                            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select6.php?a='" + autobus1 + "'"));
                            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
                        }
                        if (jakiprzystanek == "OKSOKSYWIE")
                        {
                            var webClient = new WebClient();
                            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select8.php?a='" + autobus1 + "'"));
                            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
                        }
                        //koniec
                        l.Add(List.SelectedIndex);
                        for (int i = 0; i < l.Count; i++) //przesuniecie indeksow elementow 
                        {
                            if (l[i] > List.SelectedIndex)
                            {
                                l[i] = l[i] + ile_dodano;
                            }
                        }
                        //dokonczenie elementu odpowiedzialnego za wsawienie -
                        List.Items.Insert(index + 1, widok);
                        List.Items.RemoveAt(index);
                        //koniec elmentu 
                        List.SelectedIndex = -1;
                    }
                }
                else
                {
                    List.SelectedIndex = -1;
                }
            }
        }
    }
}