using Newtonsoft.Json;
using RassavadaNew.API;
using RassavadaNew.Home;
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

namespace RassavadaNew.AuthPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {

        RassavadaEntity rassavadaEntity = new RassavadaEntity();
        public string requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageHome";
        public VerificationPage()
        {
            InitializeComponent();

            try
            {
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", "test");
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);
                webResponse.Close();
            }
            catch(Exception e)
            {
                DisplayAlert("Server Error", "Please restart the app", "Ok");
            }

            //Type type = Type.GetType(returnResponseText);
            //object oClass = Activator.CreateInstance(type);
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage(rassavadaEntity));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}