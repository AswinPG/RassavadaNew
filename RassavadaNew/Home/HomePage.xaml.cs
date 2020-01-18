﻿using RassavadaNew.Experiences;
using RassavadaNew.LeaderBoard;
using RassavadaNew.Models;
using RassavadaNew.Packages;
using RassavadaNew.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(RassavadaEntity rassavadaEntity)
        {
            InitializeComponent();
            LevelLabel.Text = "Local Guide Level " + rassavadaEntity.level;
            MainProgressVBar.Progress = rassavadaEntity.Points / (rassavadaEntity.high - rassavadaEntity.low);
                PointsLabel.Text = rassavadaEntity.Points + " Points >";
            LowPointsLabel.Text = rassavadaEntity.low.ToString();
            HighPointsLabel.Text = rassavadaEntity.high.ToString();
        }

        private async void Expadded_Tapped(object sender, EventArgs e)
        {
            MainActivityIndicator.IsVisible = true;
            MainActivityIndicator.IsRunning = true;
            Loadinglabel.IsVisible = true;
            await Navigation.PushAsync(new ExperiencePage());
            MainActivityIndicator.IsVisible = false;
            MainActivityIndicator.IsRunning = false;
            Loadinglabel.IsVisible = false;

        }
        private async void Pkgcrtd_Tapped(object sender, EventArgs e)
        {
            LoadingLayout.IsVisible = true;
            await Navigation.PushAsync(new PackagePages());
            LoadingLayout.IsVisible = false;
        }
        

        private async void Profile_Tapped(object sender, EventArgs e)
        {
            LoadingLayout.IsVisible = true;
            await Navigation.PushAsync(new ProfilePage());
            LoadingLayout.IsVisible = false;
        }

        private async void LeaderBoard_Tapped(object sender, EventArgs e)
        {
            LoadingLayout.IsVisible = true;
            await Navigation.PushAsync(new LeaderBoardPage());
            LoadingLayout.IsVisible = false;
        }

        private async void Share_Tapped(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Join me on Rassavada",
                Uri = "http://RassavadaStoreuri.com",
                Title = "Rassavada",
                Subject = "Rassavada blabh blah blah"
            });
        }
    }
}