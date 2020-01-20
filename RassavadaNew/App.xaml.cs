using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.AuthPages;
using RassavadaNew.Experiences;
using RassavadaNew.Home;
using RassavadaNew.Models;
using RassavadaNew.Packages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew
{
    public partial class App : Application
    {
        private RassavadaEntity rassavadaEntity;

        public App()
        {
            InitializeComponent();
            APIHelper.InitialiseClient();

            //MainPage = new NavigationPage(new HomePage(new Models.RassavadaEntity() { }))

            if (Application.Current.Properties.ContainsKey("User"))
            {
                MainPage = new NavigationPage(new HomePage())
                {
                    BarBackgroundColor = Color.FromHex("#0BBE22")
                };
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#0BBE22")
                };
            }
        }
        





        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
