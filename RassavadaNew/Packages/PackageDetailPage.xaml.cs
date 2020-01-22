using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Experiences;
using RassavadaNew.Models;
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
    public partial class PackageDetailPage : ContentPage
    {
        private ExperiencesList experiences;
        private Package package;
        string requestURL;
        public PackageDetailPage(Package Pack)
        {
            InitializeComponent();
            package = Pack;
            TitleLabel.Text = package.Name;

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
                postParameters.Add("docId", Pack.docId);
//#if DEBUG
//                requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageSinglePackDisplay";
//#endif
                requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PageSinglePackDisplay";
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                //rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);

                experiences = JsonConvert.DeserializeObject<ExperiencesList>(returnResponseText);
                PlaceCollectionView.ItemsSource = experiences.Experience;
                webResponse.Close();
            }
            catch (Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new CreatePackagePage(package));
        }

        private async void PlaceCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlaceCollectionView.SelectedItem != null)
            {
                //Experience experience = (Experience)e.CurrentSelection[0];
                await Navigation.PushAsync(new ExperienceDetailPage(e.CurrentSelection[0]));
            }

            PlaceCollectionView.SelectedItem = null;
        }
    }
}
