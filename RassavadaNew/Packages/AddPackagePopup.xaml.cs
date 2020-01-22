using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Experiences;
using RassavadaNew.Models;
using RassavadaNew.Popups;
using RassavadaNew.RefreshLogic;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Packages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPackagePopup : Rg.Plugins.Popup.Pages.PopupPage
    {

        Package package = new Package()
        {
            ExpID = new List<string>()
        };
        private Dictionary<string, object> postParameters;
        private string requestURL;

        public AddPackagePopup(ExperiencesList experiencesList)
        {
            InitializeComponent();
//#if DEBUG
//            requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PagePackAdd";
//#endif

            requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PagePackAdd";
            for (int i = 0; i < experiencesList.Experience.Count; i++)
            {
                package.ExpID.Add(experiencesList.Experience[i].docId);
            }
            package.Picture = experiencesList.Experience[0].Picture;
        }


        public AddPackagePopup(ExperiencesList experiencesList, Package pack)
        {
            InitializeComponent();
//#if DEBUG
//            requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PagePackUpdateEntry";
//#endif
            requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PagePackUpdateEntry";
            for (int i = 0; i < experiencesList.Experience.Count; i++)
            {
                package.ExpID.Add(experiencesList.Experience[i].docId);
            }
            package.Picture = experiencesList.Experience[0].Picture;
            DetailEntry.Text = pack.Detail;
            NameEntry.Text = pack.Name;
            CostEntry.Text = pack.Cost;
            package.docId = pack.docId;
        }

        public Dictionary<string, object> Dict { get; private set; }

        private async void Next(object sender, EventArgs e)
        {

            try
            {

                if (CostEntry.Text != "" && DetailEntry.Text != "" && NameEntry.Text != "")
                { 
                    await PopupNavigation.Instance.PushAsync(new LoadingPopup());
                    SaveSvg.IsEnabled = false;
                    //package.Cost = float.Parse(CostEntry.Text);
                    package.Detail = DetailEntry.Text;
                    package.Name = NameEntry.Text;
                    package.Cost = CostEntry.Text;
                    var json = JsonConvert.SerializeObject(package);
                    Dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    
                    postParameters = Dict;

                    postParameters.Add("UserId", Application.Current.Properties["User"]);
                    HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                    // Process response  
                    StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                    var returnResponseText = responseReader.ReadToEnd();
                    //postParameters.
                    webResponse.Close();
                    await Navigation.PopToRootAsync();
                    Refresh.RefreshHome();
                    await PopupNavigation.Instance.PopAllAsync();
                }
                else
                {
                    await DisplayAlert("Complete form", "Please enter all the data to submit.", "Ok");
                }
                



                
            }
            catch(Exception w)
            {
                await DisplayAlert("Server Down", "Please try again later", "Ok");
                SaveSvg.IsEnabled = true;
                await PopupNavigation.Instance.PopAsync();
            }
            


            
            
        }
    }
}