using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Experiences;
using RassavadaNew.LeaderBoard;
using RassavadaNew.Models;
using RassavadaNew.Packages;
using RassavadaNew.Popups;
using RassavadaNew.Profile;
using RassavadaNew.RefreshLogic;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RassavadaEntity entity;
        public string requestURL;
        private RassavadaEntity rassavadaEntity;

        public HomePage()
        {
            InitializeComponent();
            Refresh.SetHome(this);
            //#if DEBUG
            //            requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageHome";
            //#endif 
            requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PageHome ";
            rassavadaEntity = new RassavadaEntity() { };
            GetUser();
        }



        public async void GetUser()
        {
           
            
            try
            {
                bool success = GetDetails();
                if (success)
                {
                    NameLabel.Text = rassavadaEntity.Name;
                    ProPicImage.Source = rassavadaEntity.ProfilePic;
                    LevelLabel.Text = "Local Guide Level " + rassavadaEntity.level;
                    MainProgressVBar.Progress = rassavadaEntity.Points / (rassavadaEntity.high - rassavadaEntity.low);
                    PointsLabel.Text = rassavadaEntity.Points + " Points >";
                    LowPointsLabel.Text = rassavadaEntity.low.ToString();
                    HighPointsLabel.Text = rassavadaEntity.high.ToString();
                    entity = rassavadaEntity;

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("No Internet", "Check your internet connection and try again. If the problem persists please restart the app", "Ok");
                    GetUser();
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("No Internet", "Check your internet connection", "Ok");
                GetUser();
            }


        }



        private bool GetDetails()
        {
            try
            {
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", Application.Current.Properties["User"]);
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);
                webResponse.Close();
                return true;
            }
            catch (Exception e)
            {
                DisplayAlert("Server Error", "Please check your internet connection and try again", "Ok");
                return false;
            }
        }


        private async void Expadded_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoadingPopup());
            await Navigation.PushAsync(new ExperiencePage());
            await PopupNavigation.Instance.PopAsync();

        }
        private async void Pkgcrtd_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoadingPopup());
            await Navigation.PushAsync(new PackagePages());
            await PopupNavigation.Instance.PopAsync();
        }
        

        private async void Profile_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoadingPopup());
            await Navigation.PushAsync(new ProfilePage(entity));
            await PopupNavigation.Instance.PopAsync();
        }

        private async void LeaderBoard_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoadingPopup());
            await Navigation.PushAsync(new LeaderBoardPage(rassavadaEntity));
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Share_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new LoadingPopup());
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Join me on Rassavada",
                Uri = "http://RassavadaStoreuri.com",
                Title = "Rassavada",
                Subject = "Rassavada blabh blah blah"
            });
            await PopupNavigation.Instance.PopAsync();
        }
    }
}