using RassavadaNew.Models;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(RassavadaEntity rassavadaEntity)
        {
            InitializeComponent();
            LevelLabel.Text = "Local Guide Level " + rassavadaEntity.level;
            MainProgressVBar.Progress = rassavadaEntity.Points / (rassavadaEntity.high - rassavadaEntity.low);
            PointsLabel.Text = rassavadaEntity.Points + " Points >";
            LowPointsLabel.Text = rassavadaEntity.low.ToString();
            HighPointsLabel.Text = rassavadaEntity.high.ToString();
            EmailLabel.Text = "Email : " + rassavadaEntity.CEmail;
            PhoneNumberLabel.Text = "Phone Number : " + rassavadaEntity.PhoneNo;
            AddressLabel.Text = "Address : " + rassavadaEntity.HomeAddress;
            Vehiclelabel.Text = "Vehicle Status : " + rassavadaEntity.Vehicle;
        }

        private async void Edit_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }
    }
}