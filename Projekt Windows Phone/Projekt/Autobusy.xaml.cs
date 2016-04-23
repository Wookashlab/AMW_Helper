using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Projekt.Resources;
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
        List<int> l = new List<int>(); //lista przechowujaca informacje o tym czy dany element jest rozwiniety 
        bool check;
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedIndex != -1) //dzieki temu mozemy odznaczyc zaznaczony element umozliwia to zwijanie i rozwijanie tego samego elementu 
            {
                check = false;
                for (int i = 0; i < l.Count; i++) //sprawdzenie czy wybrany element jest rozwiniety 
                {
                    if (l[i] == List.SelectedIndex) //jestli jest rozwiniety zwiniecie go 
                    {
                        List.Items.RemoveAt(l[i] + 1); //usuniecie z listy jednego elemenut 
                        l.Remove(l[i]); // usuniecie z listy rozwinietych elementow 
                        check = true;
                        for (int j = 0; j < l.Count; j++)
                        {
                            if (l[j] > List.SelectedIndex)
                            {
                                l[j] = l[j] - 1; // przesuniecie indeksów elementow 
                            }
                        }
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
                    List.Items.Insert(List.SelectedIndex + 1, "dzzdz");
                    l.Add(List.SelectedIndex);
                    for (int i = 0; i < l.Count; i++) //przesuniecie indeksow elementow 
                    {
                        if (l[i] > List.SelectedIndex)
                        {
                            l[i] = l[i] + 1;
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