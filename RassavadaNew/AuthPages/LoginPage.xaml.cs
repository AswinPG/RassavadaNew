using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions.Abstractions;
using Plugin.FacebookClient;
using RassavadaNew.Interfaces;
using RassavadaNew.Models;

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private PermissionStatus status;
        

        public static IGoogleAuthenticator _googleManager = DependencyService.Get<IGoogleAuthenticator>();
        public GoogleUser GoogleUser { get; private set; }

        public LoginPage()
        {
            InitializeComponent();
            GetPermisions();


        }

        private async void PermisionValidator(object sender, EventArgs e)
        {
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            if (status == PermissionStatus.Granted )
            {
                await Navigation.PushAsync(new GetStartedPage());

            }
            else
            {
                await DisplayAlert("Need Permissions", "You must grant us location permissions to use this app", "ok");
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
                //await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationAlways);

                
                
            }
            catch (Exception e)
            {
                await DisplayAlert("Heads Up", "Please Grand location Permisions. Ignore if granted", "Ok");
            }

        }

        private async void FBTapped(object sender, EventArgs e)
        {
            try
            {
                FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(new string[] { "email", "public_profile" });
                if (response.Status == FacebookActionStatus.Completed)
                {
                    string result = await DependencyService.Get<IFireBaseAuthenticator>().LoginWithFaceBook(CrossFacebookClient.Current.ActiveToken);
                    if (result != null)
                    {
                        PermisionValidator(sender, e);
                    }
                    else
                        await DisplayAlert("FaceBook Authentication Failed", "Please try again..", "Ok");
                }
                else
                {
                    await DisplayAlert("FaceBook Authentication Failed", "Please try again..", "Ok");
                }
            }
            catch (Exception x)
            {
                await DisplayAlert("Authentication Failed", "Your Authentication Attempt Failed. Please try again..", "Ok");
            }
        }

        private async void FB2Tapped(object sender, EventArgs e)
        {
            try
            {
                _googleManager.Logout();
                _googleManager.Login(OnLoginComplete);
            }
            catch(Exception x)
            {
                await DisplayAlert("Authentication Failed", "Your Authentication Attempt Failed. Please try again..", "Ok");
            }
        }
        private async void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;

                string result = await DependencyService.Get<IFireBaseAuthenticator>().LoginWithGoogle(googleUser.token,null)    ;

                //IsLogedIn = true;
            }
            else
            {
                //_dialogService.DisplayAlertAsync("Error", message, "Ok");
            }
        }
    }
}