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
    public partial class PlayerScreen : ContentPage
    {
        private int _teamId { get; set; }
        private Player SelectedPlayer { get; set; }
        private List<Player> PlayerList { get; set; }
        public PlayerScreen(int teamId)
        {
            InitializeComponent();
            PlayerList = new List<Player>();
            _teamId = teamId;
            //fetchPlayer(_teamId);
            clsView.ItemsSource = new List<Player>() { new Player { Id=1, Description="Hello k chakhabe sancahai chani ake khanea kahne jana andfse sdkfsdf",
            Name="Marcus Rashford" , TeamId=1, ImageUrl="http://images.performgroup.com/di/library/omnisport/75/15/marcusrashford-cropped_rco7m3gbofz01tpm9oaem3jhm.jpg?t=-304161330&w=1200&h=630"},
            new Player { Id=2, Description="Hello k chakhabe sancahai chani ake khanea kahne jana andfse sdkfsdf",
            Name="Marcus Rashford" , TeamId=2, ImageUrl="http://images.performgroup.com/di/library/omnisport/75/15/marcusrashford-cropped_rco7m3gbofz01tpm9oaem3jhm.jpg?t=-304161330&w=1200&h=630" },
            new Player { Id=3, Description="Hello k chakhabe sancahai chani ake khanea kahne jana andfse sdkfsdf",
            Name="Marcus Rashford" , TeamId=3, ImageUrl="http://images.performgroup.com/di/library/omnisport/75/15/marcusrashford-cropped_rco7m3gbofz01tpm9oaem3jhm.jpg?t=-304161330&w=1200&h=630" } };
        }
        private async void fetchPlayer(int teamId)
        {
            addBtn.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available 
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.PlayerRequest, teamId), DataFormat.Json);
                var response = await client.GetAsync<List<Player>>(request);
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
            Player player = new Player { Id = 1, TeamId = _teamId };
            await Navigation.PushModalAsync(new AddPlayer(false, player));
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
            await Navigation.PushModalAsync(new AddPlayer(isEdit, SelectedPlayer));
        }

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            var player = new Player { TeamId = _teamId };
            await Navigation.PushModalAsync(new AddPlayer(false, player));
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
                    PlayerList.Remove(SelectedPlayer);
                    clsView.ItemsSource = null;
                    clsView.ItemsSource = PlayerList;
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
                var request = new RestRequest(string.Format(Constants.UrlConstant.AllTeamRequest, SelectedPlayer.Id), DataFormat.Json);
                //var response = await client.DeleteAsync<SportNews.Models.Tournament>(request);                
                client.DeleteAsync<Tournament>(request, (response, handle) =>
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
            SelectedPlayer = (e.Item as Player);
            //var args = (SelectionChangedEventArgs)
            rpop.Show();
        }
    }
}