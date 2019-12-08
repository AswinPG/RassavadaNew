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
    public partial class AddPackagePopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddPackagePopup()
        {
            InitializeComponent();
        }

        private async void Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPackagePage());
        }
    }
}