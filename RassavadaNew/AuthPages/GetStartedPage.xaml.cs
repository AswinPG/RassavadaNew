using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPage : ContentPage
    {

        private PermissionStatus status;
        public GetStartedPage()
        {
            InitializeComponent();
            //GetPermisions();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerificationPage());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                VPicker.IsVisible = true;
                VLabel.IsVisible = true;
            }
            else
            {
                VPicker.IsVisible = false;
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
                var loc = await Geolocation.GetLocationAsync();
                CurrentLocEntry.Text = loc.ToString();
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

            if (MainMap.Pins.Count != 0)
            {
                MainMap.Pins.Clear();
            }
            DetailFrame.IsVisible = true;
            MainMap.Pins.Add(new Xamarin.Forms.Maps.Pin { Position = e.Position, Label = "HomeLocation", Address = "Add Address", Type = Xamarin.Forms.Maps.PinType.Place });
            
            
        }

        private void MapButton_Clicked(object sender, EventArgs e)
        {
            
            HomeTownLabel.Text = MainMap.Pins[0].Label;
            MainMap.IsVisible = false;
            MapButton.IsVisible = false;
            HomeTownLabel.IsEnabled = false;
            
        }

        private void HomeTownLabel_Focused(object sender, FocusEventArgs e)
        {
            HomeTownLabel.Unfocus();
            MainMap.IsVisible = true;
            
        }

        private void MapDetailButton_Clicked(object sender, EventArgs e)
        {
            MainMap.Pins[0].Label = LabelEntry.Text;
            MainMap.Pins[0].Address = AdrressEntry.Text;
            DetailFrame.IsEnabled = false;
            DetailFrame.IsVisible= false;
            MapButton.IsVisible = true;
        }
    }
}