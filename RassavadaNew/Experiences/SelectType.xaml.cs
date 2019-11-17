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
    public partial class SelectType : Rg.Plugins.Popup.Pages.PopupPage

    {
        public SelectType()
        {
            InitializeComponent();
        }


            private async void TouristPlaces(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new AddExperiencesPage());
            }

            private async void LocalPlaces(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new AddExperiencesPage());
            }

            private async void Culture(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new AddExperiencesPage());
            }

            private async void Historical(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new AddExperiencesPage());
            }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    } 
}