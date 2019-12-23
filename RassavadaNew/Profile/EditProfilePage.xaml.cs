using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
        }

        private async void Change_Dp_Clicked(object sender, EventArgs e)
        {
            var PickedPhoto = await PickPhoto();
            if (PickedPhoto != null)
            {
                ProfileImage.Source = ImageSource.FromStream(() => PickedPhoto.GetStream());
            }
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

        private async void Submit_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Profile Updated", "Your Profile has been Updated", "Ok");
            await Navigation.PopAsync();
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
    }
}