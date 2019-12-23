﻿using RassavadaNew.Experiences;
using RassavadaNew.LeaderBoard;
using RassavadaNew.Packages;
using RassavadaNew.Profile;
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
        

        private async void Profile_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void LeaderBoard_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeaderBoardPage());
        }
    }
}