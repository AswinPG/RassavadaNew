using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Models;
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
        public PackagePages()
        {
            InitializeComponent();

            PackageList package = new PackageList()
            {
                Package = new List<Package>
                {
                    new Package
                    {

                    }
                }
            };

            List<Pack> ViewPackage = new List<Pack>
            {
                new Pack
                {
                    Picture="Mockpic.png",
                    Package="Package 1",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                new Pack
                {
                    Picture="HomeSVG.png",
                    Package="Package 2",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                 new Pack
                {
                    Picture="Mockpic.png",
                    Package="Package 3",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                new Pack
                {
                    Picture="HomeSVG.png",
                    Package="Package 4",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                new Pack
                {
                    Picture="Mockpic.png",
                    Package="Package",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                new Pack
                {
                    Picture="Mockpic.png",
                    Package="Package",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                 new Pack
                {
                    Picture="HomeSVG.png",
                    Package="Package",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                },
                new Pack
                {
                    Picture="Mockpic.png",
                    Package="Package",
                    Cost="10,000",
                    Details="Lorem ipsum dolor sit amet, consectetur adip isc ing elit, sed do eiusmod tempor incididunt ut abore et dolore magna aliqua. Ut enim ad imniamnon."
                }


            };
            PackageCollectionView.ItemsSource = ViewPackage;


            try
            {
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", "test");
                string requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PagePackDisplay";
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                //rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);

                package = JsonConvert.DeserializeObject<PackageList>(returnResponseText);
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
                await Navigation.PushAsync(new PackageDetailPage());
            }

            PackageCollectionView.SelectedItem = null;
        }
    }

    public class PackageList
    {
        public List<Package> Package { get; set; } 
    }
}