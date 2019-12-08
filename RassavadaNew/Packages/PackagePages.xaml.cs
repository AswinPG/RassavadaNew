using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Pack> ViewPackage = new List<Pack>
            {
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
                }


            };
            PackageCollectionView.ItemsSource = ViewPackage;
        }

        private async void Create(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePackagePage());
        }
    }


}