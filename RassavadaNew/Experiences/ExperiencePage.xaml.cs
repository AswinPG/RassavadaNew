using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Models;
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

namespace RassavadaNew.Experiences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExperiencePage : ContentPage
    {
        string requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PageExpDisplay";

        ExperiencesList experiences { get; set; }
        public ExperiencePage()
        {
            InitializeComponent();
//#if DEBUG
//            requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageExpDisplay";
//#endif
            experiences = new ExperiencesList
            {
                Experience = new List<Experience>
                {
                    new Experience()
                    {
                        Seasons = new List<string>(){}
                    }
                }
            };
            try
            {
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", Application.Current.Properties["User"]);
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                //rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);

                experiences = JsonConvert.DeserializeObject<ExperiencesList>(returnResponseText);
                webResponse.Close();
            }
            catch(Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }
            ExperienceCollectionView.ItemsSource = experiences.Experience;


        }

        private async void PopPopup()
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private async void AddExperience(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SelectType());
        }

        private async void Next(object sender, SelectionChangedEventArgs e)
        {
            
            
            if (ExperienceCollectionView.SelectedItem != null)
            {
                //string ex = e.CurrentSelection[0].ToString();

                await Navigation.PushAsync(new ExperienceDetailPage(e.CurrentSelection[0]));
            }

            ExperienceCollectionView.SelectedItem = null;
        }
    }

    public class ExperiencesList
    {
        public List<Experience> Experience { get; set; }
    }


}