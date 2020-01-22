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
        string requestURL;
        public App()
        {
            string returnResponseText = "";
            InitializeComponent();
            APIHelper.InitialiseClient();
            try
            {
//#if DEBUG
//                requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/Register";
//#endif
                requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/Register";
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", Application.Current.Properties["User"]);
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                returnResponseText = responseReader.ReadToEnd();
                webResponse.Close();
            }
            catch (Exception e) { }
            //MainPage = new NavigationPage(new HomePage(new Models.RassavadaEntity() { }))
            
            if (Application.Current.Properties.ContainsKey("User"))
            {
                if(returnResponseText == "true")
                {
                    MainPage = new NavigationPage(new HomePage())
                    {
                        BarBackgroundColor = Color.FromHex("#0BBE22")
                    };
                }
                else
                {
                    MainPage = new NavigationPage(new GetStartedPage())
                    {
                        BarBackgroundColor = Color.FromHex("#0BBE22")
                    };
                }
                
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
