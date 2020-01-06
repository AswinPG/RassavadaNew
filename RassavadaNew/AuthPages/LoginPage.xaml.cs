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

        private async void PermisionValidator()
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
                ChangeLook();
                FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(new string[] { "email", "public_profile" });
                if (response.Status == FacebookActionStatus.Completed)
                {
                    string result = await DependencyService.Get<IFireBaseAuthenticator>().LoginWithFaceBook(CrossFacebookClient.Current.ActiveToken);
                    if (result != null)
                    {
                        PermisionValidator();
                    }
                    else
                    {
                        await DisplayAlert("FaceBook Authentication Failed", "Please try again..", "Ok");
                        ChangeBackLook();
                    }
                        

                }
                else
                {
                    await DisplayAlert("FaceBook Authentication Failed", "Please try again..", "Ok");
                    ChangeBackLook();
                }
            }
            catch (Exception x)
            {
                await DisplayAlert("Authentication Failed", "Your Authentication Attempt Failed. Please try again..", "Ok");
                ChangeBackLook();
            }
        }

        private async void FB2Tapped(object sender, EventArgs e)
        {
            try
            {
                ChangeLook();
                _googleManager.Logout();
                _googleManager.Login(OnLoginComplete);
            }
            catch(Exception x)
            {
                ChangeBackLook();
                await DisplayAlert("Authentication Failed", "Your Authentication Attempt Failed. Please try again..", "Ok");
            }
        }
        private async void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                //GoogleUser = googleUser;
                try
                {
                    string result = await DependencyService.Get<IFireBaseAuthenticator>().LoginWithGoogle(googleUser.token, null);
                    PermisionValidator();
                }
                catch(Exception e)
                {
                    await DisplayAlert("Oops", "Firebase Error", "Ok");
                    ChangeBackLook();
                }
                

                //IsLogedIn = true;
            }
            else
            {
                ChangeBackLook();
                await DisplayAlert("Error", message, "Ok");
            }
        }

        private void ChangeLook()
        {
            MainLayout.Opacity = .5;
            LoadingLayout.IsVisible = true;
        }
        private void ChangeBackLook()
        {
            MainLayout.Opacity = 1;
            LoadingLayout.IsVisible = false;
        }
    }
}