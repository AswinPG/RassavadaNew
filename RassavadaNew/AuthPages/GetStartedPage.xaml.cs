using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RassavadaNew.API;
using RassavadaNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MediaFile = Plugin.Media.Abstractions.MediaFile;

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPage : ContentPage
    {

        string url = "https://us-central1-e0-rasvada.cloudfunctions.net/details";
        Xamarin.Essentials.Location CurrentLocation;

        private PermissionStatus status;
        public GetStartedPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {
                DisplayAlert("Found Error GSI", e.ToString(), "ok");
            }
            
            //GetPermisions();
        }

        

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                VechiclePicker.IsVisible = true;
                VLabel.IsVisible = true;
            }
            else
            {
                VechiclePicker.IsVisible = false;
                VLabel.IsVisible = false;
            }
        }

        private void Upload_Photo_Clicked(object sender, EventArgs e)
        {
            var PickedPhoto = PickPhoto();
        }


        private async Task<MediaFile> PickPhoto()
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var SelectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                return SelectedImage;
            }
            return null;
        }

        private void Upload_Id_Clicked(object sender, EventArgs e)
        {
            var PickedId = PickPhoto();
        }

        
        private async void CurrentLocEntry_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                CurrentLocEntry.Unfocus();
                MainActivityIndicator.IsVisible = true;
                ActivityLabel.IsVisible = true;
                MainActivityIndicator.IsRunning = true;
                CurrentLocation = await Geolocation.GetLocationAsync();
                CurrentLocEntry.Text = CurrentLocation.ToString();
                CurrentLocEntry.IsEnabled = false;
                ActivityLabel.IsVisible = false;
                MainActivityIndicator.IsVisible = false;
                MainActivityIndicator.IsEnabled = false;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not detect location", "Ok");
            }
            

        }



        

        private void MainMap_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            MapButton.IsVisible = false;

            if (MainMap.Pins.Count != 0)
            {
                MainMap.Pins.Clear();
            }
            DetailFrame.IsVisible = true;
            MainMap.Pins.Add(new Xamarin.Forms.Maps.Pin { Position = e.Position, Label = "HomeLocation", Address = "Add Address", Type = Xamarin.Forms.Maps.PinType.Place });
            
            
        }

        

        private void HomeTownLabel_Focused(object sender, FocusEventArgs e)
        {
            HomeTownLabel.Unfocus();
            MainMap.IsVisible = true;
            
        }

        private async void MapDetailButton_Clicked(object sender, EventArgs e)
        {
            if (LabelEntry.Text != "" && AdrressEntry.Text != "")
            {
                MainMap.Pins[0].Label = LabelEntry.Text;
                MainMap.Pins[0].Address = AdrressEntry.Text;
                DetailFrame.IsEnabled = false;
                DetailFrame.IsVisible = false;
                MapButton.IsVisible = true;
            }
            else
                await DisplayAlert("Complete Form", "Fill all the fields", "Ok");
            
        }

        private void MapButton_Clicked(object sender, EventArgs e)
        {

            HomeTownLabel.Text = MainMap.Pins[0].Label;
            MainMap.IsVisible = false;
            MapButton.IsVisible = false;
            HomeTownLabel.IsEnabled = false;

        }








        RassavadaUser rassavadaUser = new RassavadaUser()
        {
            Name = "Aswin",
            Vehicle = "Yes",
            VehicleType = "Two Wheeler",
            LocationLat = "Blah",
            LocationLong = "bhbj",
            HomeLat = "bjb",
            UserId = "fyTwkuZiDLarzSSjlP5FqiETUin2",
            Age = "21",
            CEmail = "fgdgf.jnj",
            Gender = "Male",
            HomeLong = "vbhjg",
            PhoneNo = "bhjgj"

        };





        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(PhoneNoEntry.Text != "" && PhoneNoEntry.Text.Length == 13 && CEmailEntry.Text != "" && NameEntry.Text != "" && CurrentLocEntry.Text != "" && HomeTownLabel.Text != "" && AgeEntry.Text != "" && GenderPicker.SelectedItem.ToString() != "" )
            {
                rassavadaUser.Name = NameEntry.Text;
                rassavadaUser.PhoneNo = PhoneNoEntry.Text;
                rassavadaUser.LocationLat = CurrentLocation.Latitude.ToString();
                rassavadaUser.LocationLong = CurrentLocation.Longitude.ToString();
                rassavadaUser.HomeLat = MainMap.Pins[0].Position.Latitude.ToString();
                rassavadaUser.HomeLong = MainMap.Pins[0].Position.Longitude.ToString();
                rassavadaUser.Vehicle = HasVehicleSwitch.IsToggled.ToString();
                rassavadaUser.VehicleType = VechiclePicker.ToString();
                rassavadaUser.Age = AgeEntry.Text;
                rassavadaUser.CEmail = CEmailEntry.Text;
                rassavadaUser.Gender = GenderPicker.SelectedItem.ToString();
                rassavadaUser.UserId = "fyTwkuZiDLarzSSjlP5FqiETUin2";
            }
            else
            {
                await DisplayAlert("Complete the form", "Please fill in all the details to continue registration", "Ok");
            }

            try
            {
                //var responseMessage = await APIHelper.APIClient.PostAsJsonAsync(url, rassavadaUser);
                //var res = await responseMessage.Content.ReadAsStringAsync();
                await Navigation.PushAsync(new VerificationPage());
            }
            //await Navigation.PushAsync(new VerificationPage());
            catch(Exception x)
            {
                await DisplayAlert("Oops", "We cannot reach our servers right now. Please try again later", "Ok");
            }
        }

    }
}