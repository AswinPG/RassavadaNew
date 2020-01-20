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
        string requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageExpDisplay";
        ExperiencesList experiences { get; set; }
        public ExperiencePage()
        {
            InitializeComponent();
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
                postParameters.Add("UserId", "test");
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



            //List<Exper> Places = new List<Exper>
            //{
            //    new Exper
            //    {
            //        Picture="dvbg.png", 
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="dvbg.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="dvbg.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //     new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //     new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },
            //    new Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
            //    },



            //};
            ExperienceCollectionView.ItemsSource = experiences.Experience;


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