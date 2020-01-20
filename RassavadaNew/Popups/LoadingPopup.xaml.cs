using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public LoadingPopup()
        {
            InitializeComponent();
        }
    }
}