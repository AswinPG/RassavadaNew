using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RassavadaNew.Experiences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExperiencePage : ContentPage
    {
        public ExperiencePage()
        {
            InitializeComponent();
            List<Exper> Places = new List<Exper>
            {
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                 new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                 new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },
                new Exper
                {
                    Picture="Mockpic.png",
                    Name="Park View",
                    Address="Address",
                    Details="Just as the transistor revolutionized electronics by offering more flexibility, convenience, and reliability than the vacuum tube, the integrated circuit enables new applications for electronics that were not possible with discrete devices. Integration allows complex circuits consisting of many thousands of transistors, diodes, resistors, and capacitors to be included in a chip of semiconductor. "
                },



            };
            ExperienceCollectionView.ItemsSource = Places;


        }

        private async void AddExperience(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SelectType());
        }

        private async void Next(object sender, SelectionChangedEventArgs e)
        {
            

            if (ExperienceCollectionView.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExperienceDetailPage());
            }

            ExperienceCollectionView.SelectedItem = null;
        }
    }


}