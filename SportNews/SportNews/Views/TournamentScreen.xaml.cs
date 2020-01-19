using Plugin.Toast;
using RestSharp;
using SportNews.Models;
using SportNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TournamentScreen : ContentPage
    {
        public Tournament SelectedTournament { get; set; }
        List<Tournament> TournamentList { get; set; }
        public TournamentScreen()
        {
            InitializeComponent();
            TournamentList= new List<Tournament>();            
        }

        private async void fetchTournament()
        {
            addBtn.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available                
                TournamentList = await FetchTournament.FetchTournamentsAsync();
                clsView.ItemsSource = TournamentList;
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
                IsBusy = false;
            }
            header.ShowProgressIndicator = false;
            addBtn.IsEnabled = true;
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
            await Navigation.PushModalAsync(new AddTournament(isEdit, SelectedTournament));
        }
        
        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            var tournament1 = new Tournament { SportId = (int)SportCategory.football };
            await Navigation.PushModalAsync(new AddTournament(false, tournament1));
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
                    TournamentList.Remove(SelectedTournament);
                    clsView.ItemsSource = null;
                    clsView.ItemsSource = TournamentList;
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
                var request = new RestRequest(string.Format(Constants.UrlConstant.TournamentRequest, SelectedTournament.Id), DataFormat.Json);
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
            SelectedTournament = (e.Item as Tournament);
            //var args = (SelectionChangedEventArgs)
            rpop.Show();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            fetchTournament();
        }
    }
    
}