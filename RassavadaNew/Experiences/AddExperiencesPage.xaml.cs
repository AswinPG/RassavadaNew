using Newtonsoft.Json;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RassavadaNew.API;
using RassavadaNew.Models;
using RassavadaNew.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AddExperiencesPage : ContentPage
    {
        public byte[] DPbytes;
        Dictionary<string, object> postParameters { get; set; }
        public Experience experience { get; set; }
        public Experience experience2;
        Dictionary<string, object> Dict;
        public ObservableCollection<MediaFile> Media { get; set; }
        public static IMultiMediaPickerService _multiMediaPickerService = DependencyService.Get<IMultiMediaPickerService>();
        public string url = "https://us-central1-e0-rasvada.cloudfunctions.net/PageExpEnter";

        public AddExperiencesPage()
        {
            InitializeComponent();
            //_multiMediaPickerService = 
            experience2 = new Experience()
            {
                Seasons = new List<string>() { },
                //Images = new List<string>() { }
            };
            _multiMediaPickerService.OnMediaPicked += (s, a) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Media.Add(a);

                });

            };
        }


        public AddExperiencesPage(Experience experience)
        {
            experience2 = experience;

            AddressEntry.Text = experience2.Address;

            TimeEntry.Text = experience2.AvgTime;
            NameEntry.Text = experience2.Name;
            DistFMC.Text = experience2.DistMajCentre;
            DetailEntry.Text = experience2.Details;
            MajorCityEntry.Text = experience2.MajCentre;
            Season.IsVisible = experience2.Seasonal;
            DetailEntry.Text = experience2.Details;
            

            _multiMediaPickerService.OnMediaPicked += (s, a) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Media.Add(a);

                });

            };
        }




        private void Quest(object sender, EventArgs e)
        {
            if (Question.IsVisible == true)
            {
                Question.IsVisible = false;

            }
            else
            {
                Question.IsVisible = true;
            }
        }

        private void SeasonalChoose(object sender, EventArgs e)
        {
            if (Season.IsVisible == true)
            {
                Season.IsVisible = false;
                Downarrow.RotateTo(0);
            }
            else
            {
                Season.IsVisible = true;
                Downarrow.RotateTo(180);

            }

        }

        private void Seasonaltype(object sender, EventArgs e)
        {
            Option.Text = "Seasonal";
            Option.TextColor = Color.FromHex("#000000");
            Season.IsVisible = false;
            Downarrow.RotateTo(0);
            SeasonFrame.IsVisible = true;
        }

        private void Nonseasonal(object sender, EventArgs e)
        {
            Option.Text = "Non-Seasonal";
            Option.TextColor = Color.FromHex("#000000");
            Season.IsVisible = false;
            Downarrow.RotateTo(0);
            SeasonFrame.IsVisible = false;
        }

      

        private void Reviewquest(object sender, EventArgs e)
        {
            if (Questions.IsVisible == true)
            {
                Questions.IsVisible = false;

            }
            else
            {
                Questions.IsVisible = true;


            }
        }

        



        private async void Add_Photos_Tapped(object sender, EventArgs e)
        {
            var hasPermission = await CheckPermissionsAsync();
            if (hasPermission)
            {
                Media = new ObservableCollection<MediaFile>();
                await _multiMediaPickerService.PickPhotosAsync();
                CLayout.IsVisible = true;
                MainCollectionView.IsVisible = true;
                MainCollectionView.ItemsSource = null;
                MainCollectionView.ItemsSource = Media;
                
            }
        }









        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Need Storage permission to access to your photos.", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Permission Denied. Can not continue, try again.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await App.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }






        private async void Next(object sender, EventArgs e)
        {
            try
            {
                //experience = new Experience()
                //{
                //    Address = "bhbhjbj",
                //    Seasonal = true,
                //    Seasons = new List<string>
                //    {
                //        "Blah","bbhb","vgvgh"
                //    },
                //    AvgTime = "2",
                //    Name = "bhbj",
                //    DistMajCentre = "nnj",
                //    Details = "bhjbhjbhjjh",
                //    expType = ExpType.Food,
                //    docId = "",
                //    Images = new List<string>
                //    {
                //        "hbhbh","njnjn","bhbhb"
                //    },
                //    Lat = "bjbjbj",
                //    Long = "bhbh",
                //    MajCentre = "jj",
                //    Picture = "njnj"
                //};

                if (AddressEntry.Text != null && TimeEntry.Text != null && NameEntry.Text != null && DistFMC.Text != null && DetailEntry != null && MajorCityEntry.Text != null && Media.Count >= 1)
                {
                    experience2.Address = AddressEntry.Text;
                    experience2.Seasonal = SeasonFrame.IsVisible;
                    experience2.AvgTime = TimeEntry.Text;
                    experience2.Name = NameEntry.Text;
                    experience2.DistMajCentre = DistFMC.Text;
                    experience2.Details = DetailEntry.Text;
                    experience2.Lat = MainMap.Pins[0].Position.Latitude.ToString();
                    experience2.Long = MainMap.Pins[0].Position.Longitude.ToString();
                    experience2.MajCentre = MajorCityEntry.Text;
                    experience2.expType = ExpType.Cultural;
                    
                    if(experience2.Seasonal == false)
                    {
                        experience2.Seasons.Add("");
                    }
                    //experience2.Picture = "None";


                    var json = JsonConvert.SerializeObject(experience2);
                    Dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    string requestURL = url;
                    postParameters = Dict;
                    for (int i = 0; i < Media.Count; i++)
                    {
                        DPbytes = File.ReadAllBytes(Media[i].Path);
                        postParameters.Add("Image" + i, new FormUpload.FileParameter(DPbytes, Path.GetFileName(Media[i].Path), "image/png"));
                    }
                    postParameters.Add("UserId", "test");
                    HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                    // Process response  
                    StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                    var returnResponseText = responseReader.ReadToEnd();
                    //postParameters.
                    webResponse.Close();
                    await Navigation.PopAsync();
                }
                



            }
            catch (Exception z)
            {
                await DisplayAlert("There seems to be a problem", "Please check your internet connection and try again", "Ok");
            }
            //await Navigation.PopAsync();
        }

        private void MainMap_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            MapButton.IsVisible = false;

            if (MainMap.Pins.Count != 0)
            {
                MainMap.Pins.Clear();
            }
            MainMap.Pins.Add(new Xamarin.Forms.Maps.Pin { Position = e.Position, Label = "HomeLocation", Address = "Add Address", Type = Xamarin.Forms.Maps.PinType.Place });
            MapButton.IsVisible = true;

        }

        private void MapButton_Clicked(object sender, EventArgs e)
        {
            LocationEntry.Text = MainMap.Pins[0].Position.Latitude.ToString();
            MainMap.IsVisible = false;
            MapButton.IsVisible = false;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                try
                {
                    experience2.Seasons.Add("January");
                }
                catch(Exception h)
                {

                }
                
            }
            else
                experience2.Seasons.Remove("January");
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("February");
            }
            else
                experience2.Seasons.Remove("February");
        }

        private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("March");
            }
            else
                experience2.Seasons.Remove("March");
        }

        private void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("April");
            }
            else
                experience2.Seasons.Remove("April");
        }

        private void CheckBox_CheckedChanged_4(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("May");
            }
            else
                experience2.Seasons.Remove("May");
        }

        private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("June");
            }
            else
                experience2.Seasons.Remove("June");
        }

        private void CheckBox_CheckedChanged_6(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("July");
            }
            else
                experience2.Seasons.Remove("July");
        }

        private void CheckBox_CheckedChanged_7(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("August");
            }
            else
                experience2.Seasons.Remove("August");
        }

        private void CheckBox_CheckedChanged_8(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("September");
            }
            else
                experience2.Seasons.Remove("September");
        }

        private void CheckBox_CheckedChanged_9(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("October");
            }
            else
                experience2.Seasons.Remove("October");
        }

        private void CheckBox_CheckedChanged_10(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("November");
            }
            else
                experience2.Seasons.Remove("November");
        }

        private void CheckBox_CheckedChanged_11(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                experience2.Seasons.Add("December");
            }
            else
                experience2.Seasons.Remove("December");
        }

        private void LocationEntry_Focused(object sender, FocusEventArgs e)
        {
            LocationEntry.Unfocus();
            MainMap.IsVisible = true;
        }
    }
}