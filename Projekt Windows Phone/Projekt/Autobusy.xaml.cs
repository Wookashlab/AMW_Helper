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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
        }
        void bus(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                string value = reader.ReadToEnd();
                string[] response = Regex.Split(value, "<br>");
                int i = 0;
                while (i < response.Length - 1)
                {
                    List.Items.Add("+ " + response[i]);
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
                            List.Items.Insert(selected + ile_dodano + 1, "   _|_ " + response[i] + "- Morska");

                        }
                        else
                        {
                            List.Items.Insert(selected + ile_dodano + 1, "   _|_ " + response[i]);
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
        string autobus;
        int selected;
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedIndex != -1) //dzieki temu mozemy odznaczyc zaznaczony element umozliwia to zwijanie i rozwijanie tego samego elementu 
            {
                check = false;
                for (int i = 0; i < l.Count; i++) //sprawdzenie czy wybrany element jest rozwiniety 
                {
                    if (l[i] == List.SelectedIndex) //jestli jest rozwiniety zwiniecie go 
                    {
                        for(int k = 1; k <= ile[i]; k++)
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
                        string widok2 = List.SelectedItem.ToString();
                        string widok3 = "";
                        for (int k = 1; k < widok2.Length; k++)
                        {
                            widok3 += widok2[k];
                        }
                        widok2 = "+" + widok3;
                        List.Items.Insert(index1 + 1, widok2);
                        List.Items.RemoveAt(index1);
                        // koniec elementu 

                        List.SelectedIndex = -1;
                    }
                }
                if (check == false)
                {
                    //nowe
                    autobus = List.SelectedItem.ToString();
                    if(autobus[2] == 'X')
                    {
                        autobus = autobus[2].ToString();
                    }
                    else
                    {
                        autobus = autobus[2].ToString() + autobus[3].ToString() + autobus[4].ToString();
                    }
                    //koniec
                    //element odpowiedzialny za wstawienie -
                    int index = List.SelectedIndex;
                    string widok = List.SelectedItem.ToString();
                    string widok1 = "";
                    for (int i = 1; i < widok.Length; i++)
                    {
                        widok1 += widok[i];
                    }
                    widok = "-" + widok1;
                    //koniec elementu 

                    //nowe
                    selected = List.SelectedIndex;
                    var webClient = new WebClient();
                    webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select2.php?a='" + autobus + "'"));
                    webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
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
        }
    }
}