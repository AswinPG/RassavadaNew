using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using FFImageLoading.Forms.Platform;
using Plugin.CurrentActivity;
using Android.Content;
using RassavadaNew.Droid.Services;
using RassavadaNew.Services;
using RassavadaNew.Experiences;
using Java.Security;
using Plugin.FacebookClient;
using Firebase;
using RassavadaNew.Interfaces;
using RassavadaNew.Droid.Interfaces;
using Android.Gms.Auth.Api.SignIn;
using RassavadaNew.AuthPages;
using Android.Gms.Auth.Api;

namespace RassavadaNew.Droid
{
    [Activity(Label = "RassavadaNew", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(savedInstanceState);

            FacebookClientManager.Initialize(this);

            Forms.SetFlags("CollectionView_Experimental");
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            DependencyService.Register<IMultiMediaPickerService, MultiMediaPickerService>();
            DependencyService.Register<IGoogleAuthenticator, GoogleAuthenticator>();
            //DependencyService.Register<IFireBaseAuthenticator, FireBaseAuthenticator>();

            CachedImageRenderer.Init(true);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            FirebaseApp.InitializeApp(Application.ApplicationContext);
            LoadApplication(new App());



            try
            {
                PackageInfo info = Android.App.Application.Context.PackageManager.GetPackageInfo(Android.App.Application.Context.PackageName, PackageInfoFlags.Signatures);
                foreach (var signature in info.Signatures)
                {
                    MessageDigest md = MessageDigest.GetInstance("SHA");
                    md.Update(signature.ToByteArray());

                    System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(md.Digest()));
                }
            }
            catch (NoSuchAlgorithmException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //MultiMediaPickerService.SharedInstance.OnActivityResult(requestCode, resultCode, data);
            AddExperiencesPage._multiMediaPickerService.OnActivityResult(requestCode, resultCode, data);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                GoogleAuthenticator.Instance.OnAuthCompleted(result);
            }

        }

    }
}