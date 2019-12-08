using RassavadaNew.Experiences;
using RassavadaNew.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void Expadded_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExperiencePage());

        }
        private async void Pkgcrtd_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new PackagePages());

        }
        private void Compro_Tapped(object sender, EventArgs e)
        {

        }
        private void Secset_Tapped(object sender, EventArgs e)
        {

        }
    }
}