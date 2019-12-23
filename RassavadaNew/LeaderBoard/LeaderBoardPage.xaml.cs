using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.LeaderBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderBoardPage : ContentPage
    {
        public LeaderBoardPage()
        {
            InitializeComponent();
            List<LeaderGuide> leaderGuides = new List<LeaderGuide>()
            {
                new LeaderGuide()
                {
                    Name = "Aswin PG",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "1"
                },
                new LeaderGuide()
                {
                    Name = "Haris Wilson",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "2"
                },
                new LeaderGuide()
                {
                    Name = "Rajath KS",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "3"
                },
                new LeaderGuide()
                {
                    Name = "Stan Wert",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "4"
                },
                new LeaderGuide()
                {
                    Name = "Michael Jordan",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "5"
                },
                new LeaderGuide()
                {
                    Name = "Aswin PG",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "6"
                },
                new LeaderGuide()
                {
                    Name = "Haris Wilson",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "7"
                },
                new LeaderGuide()
                {
                    Name = "Rajath KS",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "8"
                },
                new LeaderGuide()
                {
                    Name = "Stan Wert",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "9"
                },
                new LeaderGuide()
                {
                    Name = "Michael Jordan",
                    ImgUrl = "HomeSVG.png",
                    Points = "5656",
                    Position = "10"
                }
            };

            MainCollectionView.ItemsSource = leaderGuides;
        }
    }
}