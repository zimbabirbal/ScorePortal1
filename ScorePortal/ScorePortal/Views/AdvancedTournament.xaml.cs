using ScorePortal.Services;
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
    public partial class AdvancedTournament : ContentPage
    {
        ObservableCollection<string> TeamAList { get; set; }
        public AdvancedTournament()
        {
            InitializeComponent();
            TeamAList = new ObservableCollection<string>();
            innerListTeamA.HeightRequest = 48 * TeamAList.Count;
        }

        private void searchBarTeamA_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBarTeamAList.ItemsSource = FetchTeam.GetSearchResults(e.NewTextValue);
        }

        private void searchBarTeamA_Unfocused(object sender, FocusEventArgs e)
        {
            
            searchBarTeamAList.IsVisible = false;
        }

        private void searchBarTeamA_Focused(object sender, FocusEventArgs e)
        {
            searchBarTeamAList.ItemsSource = FetchTeam.GetSearchResults("a");
            searchBarTeamAList.IsVisible = true;
        }

        

        private async void addTeam_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new AddTeam());
        }

        private async void searchBarTeamAList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TeamAList.Add(e.SelectedItem.ToString());
            innerListTeamA.ItemsSource = TeamAList;
            innerListTeamA.HeightRequest = 48 * TeamAList.Count;
        }

        private async void innerListSearchBarTeamA_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TeamAList.RemoveAt(e.SelectedItemIndex);
            innerListTeamA.ItemsSource = TeamAList;
            innerListTeamA.HeightRequest = 48 * TeamAList.Count;
        }

        
    }
}