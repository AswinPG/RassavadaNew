using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions.Abstractions;

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private PermissionStatus status;

        public LoginPage()
        {
            InitializeComponent();
            GetPermisions();

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            if (status == PermissionStatus.Granted )
            {
                await Navigation.PushAsync(new GetStartedPage());
            }
            else
            {
                GetPermisions();
            }
        }
            

        public async void GetPermisions()
        {
            try
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    // This is not the actual permission request
                    await DisplayAlert("Need your permission", "We need to access your location", "Ok");
                }

                // This is the actual permission request
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

                
                
            }
            catch (Exception e)
            {
                await DisplayAlert("Heads Up", "Please Grand loction Permisions. Ignore if granted", "Ok");
            }

        }
    }
}