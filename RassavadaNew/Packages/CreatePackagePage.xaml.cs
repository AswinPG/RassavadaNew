using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Experiences;
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

namespace RassavadaNew.Packages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePackagePage : ContentPage
    {
        private ExperiencesList experiences;
        private Package packag;
        private ExperiencesList experiencesinpackage;
        private int count = 0;
        private bool edit = false;
        string requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PageExpDisplay";
        public CreatePackagePage()
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
            experiencesinpackage = new ExperiencesList
            {
                Experience = new List<Experience>
                {
                    new Experience()
                    {
                        Seasons = new List<string>(){}
                    }
                }
            };
            experiencesinpackage.Experience.Clear();
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
            catch (Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }

            
            PlaceCollectionView.ItemsSource = experiences.Experience;
        }








        public CreatePackagePage( Package package )
        {
            InitializeComponent();
            edit = true;
            packag = package;
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
            experiencesinpackage = new ExperiencesList
            {
                Experience = new List<Experience>
                {
                    new Experience()
                    {
                        Seasons = new List<string>(){}
                    }
                }
            };
            experiencesinpackage.Experience.Clear();
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
            catch (Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }


            PlaceCollectionView.ItemsSource = experiences.Experience;
        }






        private async void Next(object sender, EventArgs e)
        {
            if (experiencesinpackage.Experience.Count > 0 && !edit)
            {
                await PopupNavigation.Instance.PushAsync(new AddPackagePopup(experiencesinpackage));
            }
            else if(experiencesinpackage.Experience.Count > 0 && edit)
            {
                await PopupNavigation.Instance.PushAsync(new AddPackagePopup(experiencesinpackage, packag));
            }
            else
            {
                await DisplayAlert("No Experiences selected", "Please slect at least one experience", "Ok");
            }
            
        }

        private void PlaceCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //for(int i = 0; i < e.CurrentSelection.Count; i++)


                if(e.CurrentSelection.Count > count)
                {
                    count = e.CurrentSelection.Count;
                    Experience experience = (Experience)e.CurrentSelection[count-1];
                    experiencesinpackage.Experience.Add(experience);
                }
                else if (e.CurrentSelection.Count < count)
                {
                    experiencesinpackage.Experience.Clear();
                    count = e.CurrentSelection.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Experience experience = (Experience)e.CurrentSelection[i];
                        experiencesinpackage.Experience.Add(experience);
                    }
                }
                        
            }
            catch(Exception z)
            {

            }
            
        }
    }

}
