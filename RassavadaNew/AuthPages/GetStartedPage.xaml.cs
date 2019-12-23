using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPage : ContentPage
    {
        public GetStartedPage()
        {
            InitializeComponent();
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
    }
}