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

namespace RassavadaNew.LeaderBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderBoardPage : ContentPage
    {
        LeaderList leaderList = new LeaderList() { };
        public LeaderBoardPage(RassavadaEntity rassavadaEntity)
        {
            InitializeComponent();
            NameLabel.Text = rassavadaEntity.Name;
            LevelLabel.Text = "Local Giude Level " + rassavadaEntity.level;
            PointsLabel.Text = rassavadaEntity.Points + "";


            try
            {
                string requestURL = "";
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("UserId", Application.Current.Properties["User"]);
                HttpWebResponse webResponse = FormUpload.MultipartFormPost(requestURL, "someone", postParameters, "", "");
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string returnResponseText = responseReader.ReadToEnd();
                //rassavadaEntity = JsonConvert.DeserializeObject<RassavadaEntity>(returnResponseText);

                leaderList = JsonConvert.DeserializeObject<LeaderList>(returnResponseText);
                webResponse.Close();
            }
            catch (Exception e)
            {
                DisplayAlert("No Internet", "Please check your internet connection", "Ok");
            }

            MainCollectionView.ItemsSource = leaderList.Leaderdoard;
        }
    }
}