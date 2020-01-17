using Plugin.Media;
using Plugin.Media.Abstractions;
using RassavadaNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MediaFile = Plugin.Media.Abstractions.MediaFile;

namespace RassavadaNew.Experiences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExperienceDetailPage : ContentPage
    {

        Experience experience;
        public ExperienceDetailPage(Object oexperience)
        {
            InitializeComponent();
            
            experience = (Experience)oexperience;
            HeadingLabel.Text = experience.Name;
            TopImage.Source = experience.Picture;
            PhotoFrame.Source = experience.Picture;
            AddressLabel.Text = experience.Address;
            ExpTypeLabel.Text = experience.expType.ToString();
            AddressLabel2.Text = experience.Address;
            TimeLabel.Text = experience.AvgTime;
            if (experience.Seasonal)
            {
                SeasonalLabel.Text = "Seasonal Spot";
            }
            else
                SeasonalLabel.Text = "Non Seasonal";
            ReviewLabel.Text = experience.Details;
        }

        private void Add_Photos_Tapped(object sender, EventArgs e)
        {
            var Pic = PickPhoto();
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExperiencesPage(experience));
        }
    }
}