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
        private ExperiencesList experiencesinpackage;
        private int count = 0;
        string requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageExpDisplay";
        public CreatePackagePage()
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
                postParameters.Add("UserId", "test");
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

            //List<Experiences.Exper> Places = new List<Experiences.Exper>
            //{
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //     new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //     new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },
            //    new Experiences.Exper
            //    {
            //        Picture="Mockpic.png",
            //        Name="Park View",
            //        Address="Address",
            //        Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. This means that sophisticated circuitry can be miniaturized for use in space vehicles, in large-scale computers, and in other applications where a large collection of discrete components would be impractical. In addition to offering the advantages of miniaturization, the simultaneous fabrication of many ICs on a single Si wafer greatly reduces the cost and increases the reliability of each of the finished circuits. Certainly discrete components have played an important role in the development of electronic circuits: however, most circuits are now fabricated on the Si chip rather than with a collection of individual components. Therefore, the traditional distinctions between the roles of circuit and system designers do not apply to IC development. "
            //    },



            //};
            PlaceCollectionView.ItemsSource = experiences.Experience;
        }

        private async void Next(object sender, EventArgs e)
        {
            if (experiencesinpackage.Experience.Count > 0)
            {
                await PopupNavigation.Instance.PushAsync(new AddPackagePopup(experiencesinpackage));
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
