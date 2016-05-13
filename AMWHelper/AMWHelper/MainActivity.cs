using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
namespace AMWHelper
{
    [Activity(Label = "AMWHelper", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity
    {
        int count = 1;
        public List<string> l;
        public List<string> rozk;
        void bus(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                l = new List<string>();
                string value = reader.ReadToEnd();
                string[] response = Regex.Split(value, "<br>");
                int i = 0;
                while (i < response.Length - 1)
                {
                    l.Add(response[i]);
                    i++;
                }
            }
            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, l);
        }
        void rozklad(object sender, OpenReadCompletedEventArgs e)
        {
            using (var reader = new StreamReader(e.Result))
            {
                string value = reader.ReadToEnd();
                rozk = new List<string>();
                string[] response = Regex.Split(value, "<br>");
                for (int i = 0; i < response.Length-1; i++)
                {
                    if (response[i] != "" && response[i] != "Morska ")
                    {
                        if (response[i] == "Hipermarket Tesco ")
                        {
                            rozk.Add(response[i] + "- Morska");
                        }
                        else
                        {
                            rozk.Add(response[i]);
                        }
                    }
                }
                ListView listView = FindViewById<ListView>(Resource.Id.listView1);
                listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, rozk);
            }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += Button_Click;

            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select.php"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(bus);
            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.ItemClick += ListView_ItemClick;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, l);
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string autobus = l[e.Position];
            if (autobus[0] == 'X')
            {
                autobus = autobus[0].ToString();
            }
            else
            {
                autobus = autobus[0].ToString() + autobus[1].ToString() + autobus[2].ToString();
            }
            var webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://hein.bluequeen.tk/select2.php?a=" + "'" +  autobus + "'"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(rozklad);
        }
    }
}

