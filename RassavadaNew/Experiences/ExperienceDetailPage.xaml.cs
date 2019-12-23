using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Experiences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExperienceDetailPage : ContentPage
    {
        public ExperienceDetailPage()
        {
            InitializeComponent();
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
    }
}