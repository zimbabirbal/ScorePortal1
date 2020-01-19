using Plugin.Toast;
using RestSharp;
using SportNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamScreen : ContentPage
    {
        private Team SelectedTeam { get; set; }
        private List<Team> TeamList { get; set; }
        public TeamScreen()
        {
            InitializeComponent();
            TeamList = new List<Team>();
            fetchTeam();
        }
        private async void fetchTeam()
        {
            addBtn.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available 
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.TeamRequest,2), DataFormat.Json);
                var response = await client.GetAsync<List<Team>>(request);
                clsView.ItemsSource = response;
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
                IsBusy = false;
            }
            header.ShowProgressIndicator = false;
            addBtn.IsEnabled = true;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Team aa = new Team { Id = 1, SportId = (int)SportCategory.football };
            await Navigation.PushModalAsync(new AddTeam(false, aa));
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //popupLayout.Show();
            //Syncfusion.XForms.PopupLayout.SfPopupLayout).show();

            rpop.Show();
        }
        private async void Edit_Tapped(object sender, EventArgs e)
        {
            rpop.IsOpen = false;
            var isEdit = true;
            //await Shell.Current.GoToAsync("AddTournament");
            await Navigation.PushModalAsync(new AddTeam(isEdit, SelectedTeam));
        }

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            var team = new Team { SportId = (int)SportCategory.football };
            await Navigation.PushModalAsync(new AddTeam(false, team));
        }

        private async void Delete_Tapped(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available
                addBtn.IsEnabled = false;
                header.ShowProgressIndicator = true;
                rpop.IsOpen = false;
                var success = await remoteDelete();
                if (success)
                {
                    CrossToastPopUp.Current.ShowToastSuccess("Tournament Successfully Deleted", Plugin.Toast.Abstractions.ToastLength.Long);
                    TeamList.Remove(SelectedTeam);
                    clsView.ItemsSource = null;
                    clsView.ItemsSource = TeamList;
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage("Error Occured", Plugin.Toast.Abstractions.ToastLength.Long);
                }
                header.ShowProgressIndicator = false;
                addBtn.IsEnabled = true;
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
                IsBusy = false;
            }
        }

        private Task<bool> remoteDelete()
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.TeamRequest, SelectedTeam.Id), DataFormat.Json);
                //var response = await client.DeleteAsync<SportNews.Models.Tournament>(request);                
                client.DeleteAsync<Team>(request, (response, handle) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.Created)
                    {
                        tcs.SetResult(true);
                    }
                    else
                    {
                        tcs.SetResult(false);
                        //tcs.SetException(new Exception(response.StatusDescription));
                    }
                });
            }
            catch (Exception ex)
            {
                tcs.SetResult(false);
            }

            return tcs.Task;
        }

        private void clsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedTeam = (e.Item as Team);
            //var args = (SelectionChangedEventArgs)
            rpop.Show();
        }

        private async void Players_Tapped(object sender, EventArgs e)
        {
            rpop.IsOpen = false;
            await Navigation.PushModalAsync(new PlayerScreen(SelectedTeam.Id));
        }
    }
}