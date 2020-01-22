using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Experiences;
using RassavadaNew.Models;
using RassavadaNew.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Packages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackagePages : ContentPage
    {
        PackageList package;
        string requestURL;
        public PackagePages()
        {
            InitializeComponent();
            package = new PackageList()
            {
                Package = new List<Package>
                {
                    new Package
                    {

                    }
                }
            };


            try
            {
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", Application.Current.Properties["User"]);
//#if DEBUG
//                requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PagePackDisplay";
//#endif
                requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PagePackDisplay";
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                //rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);

                package = JsonConvert.DeserializeObject<PackageList>(returnResponseText);
                PackageCollectionView.ItemsSource = package.Package;
                webResponse.Close();
            }
            catch (Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }



        }

        private async void Create(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePackagePage());
        }

        private async void PlaceCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (PackageCollectionView.SelectedItem != null)
            {
                await PopupNavigation.Instance.PushAsync(new LoadingPopup());
                Package package = (Package)e.CurrentSelection[0]; 
                await Navigation.PushAsync(new PackageDetailPage(package));
            }

            PackageCollectionView.SelectedItem = null;
            await PopupNavigation.Instance.PopAsync();
        }
  
    }

    public class PackageList
    {
        public List<Package> Package { get; set; } 
    }
    
}