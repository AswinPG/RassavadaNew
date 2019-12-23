using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RassavadaNew.Models;
using RassavadaNew.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Experiences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExperiencesPage : ContentPage
    {

        public ObservableCollection<MediaFile> Media { get; set; }
        public static IMultiMediaPickerService _multiMediaPickerService = DependencyService.Get<IMultiMediaPickerService>();
        public AddExperiencesPage()
        {
            InitializeComponent();
            //_multiMediaPickerService = 
            _multiMediaPickerService.OnMediaPicked += (s, a) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Media.Add(a);

                });

            };
        }

        private void Quest(object sender, EventArgs e)
        {
            if (Question.IsVisible == true)
            {
                Question.IsVisible = false;

            }
            else
            {
                Question.IsVisible = true;


            }
        }

        private void SeasonalChoose(object sender, EventArgs e)
        {
            if (Season.IsVisible == true)
            {
                Season.IsVisible = false;
                Downarrow.RotateTo(0);
            }
            else
            {
                Season.IsVisible = true;
                Downarrow.RotateTo(180);

            }

        }

        private void Seasonaltype(object sender, EventArgs e)
        {
            Option.Text = "Seasonal";
            Option.TextColor = Color.FromHex("#000000");
            Season.IsVisible = false;
            Downarrow.RotateTo(0);
            SeasonFrame.IsVisible = true;
        }

        private void Nonseasonal(object sender, EventArgs e)
        {
            Option.Text = "Non-Seasonal";
            Option.TextColor = Color.FromHex("#000000");
            Season.IsVisible = false;
            Downarrow.RotateTo(0);
            SeasonFrame.IsVisible = false;
        }

      

        private void Reviewquest(object sender, EventArgs e)
        {
            if (Questions.IsVisible == true)
            {
                Questions.IsVisible = false;

            }
            else
            {
                Questions.IsVisible = true;


            }
        }

        private async void Next(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Add_Photos_Tapped(object sender, EventArgs e)
        {
            var hasPermission = await CheckPermissionsAsync();
            if (hasPermission)
            {
                Media = new ObservableCollection<MediaFile>();
                await _multiMediaPickerService.PickPhotosAsync();
                CLayout.IsVisible = true;
                MainCollectionView.IsVisible = true;
                MainCollectionView.ItemsSource = null;
                MainCollectionView.ItemsSource = Media;
                
            }
        }









        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Need Storage permission to access to your photos.", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Permission Denied. Can not continue, try again.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await App.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }
    }
}