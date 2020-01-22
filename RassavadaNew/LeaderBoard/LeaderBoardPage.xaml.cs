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
            string requestURL;
            NameLabel.Text = rassavadaEntity.Name;
            PropicImage.Source = rassavadaEntity.ProfilePic;
            LevelLabel.Text = "Local Giude Level " + rassavadaEntity.level;
            PointsLabel.Text = rassavadaEntity.Points + "";


            try
            {
//#if DEBUG
//                requestURL = "https://us-central1-e0-rasvada.cloudfunctions.net/PageLeaderboard";
//#endif


                requestURL = "https://us-central1-e0-trouvailler.cloudfunctions.net/PageLeaderboard";

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

            MainCollectionView.ItemsSource = leaderList.Leaderboard;
        }
    }
}