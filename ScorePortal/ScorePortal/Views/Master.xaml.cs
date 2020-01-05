using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public ObservableCollection<MasterImageWithTextControl> MasterImageWithTextControls { get; set; }
        public Master()
        {
            InitializeComponent();
            MasterImageWithTextControls = new ObservableCollection<MasterImageWithTextControl>();
            MasterImageWithTextControls.Add(new MasterImageWithTextControl { Icon = "tournament", Title = "Tournament" });
            MasterImageWithTextControls.Add(new MasterImageWithTextControl { Icon = "tournament", Title = "Team" });
            MasterImageWithTextControls.Add(new MasterImageWithTextControl { Icon = "tournament", Title = "Tournament" });
            listview.ItemsSource = MasterImageWithTextControls;
            listview.HeightRequest = MasterImageWithTextControls.Count;
        }


        private async void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            switch (e.SelectedItemIndex)
            {
                case 0: 
                    await Navigation.PushModalAsync(new AddTournament());
                    break;
                case 1:
                    await Navigation.PushModalAsync(new AddTeam());
                    break;
                case 3:
                    await Navigation.PushModalAsync(new AddTournament());
                    break;
                default:
                    await Navigation.PushModalAsync(new AddTournament());
                    break;
            }
        }
    }
    public class MasterImageWithTextControl
    {
        public string Icon { get; set; }
        public string  Title { get; set; }
    }
}