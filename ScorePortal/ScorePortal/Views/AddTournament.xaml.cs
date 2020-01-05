using Plugin.Toast;
using RestSharp;
using ScorePortal.Models;
using ScorePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTournament : ContentPage
    {
        public bool IsBusy { get; set; }
        public AddTournament()
        {
            InitializeComponent();
            this.BindingContext = new AdvancedTournamentViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdvancedTournament());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            btn.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var startDateTime = new DateTime(startDatePickerEntry.Date.Year, startDatePickerEntry.Date.Month,
                startDatePickerEntry.Date.Day, startTimePickerEntry.Time.Hours, startTimePickerEntry.Time.Minutes,
                startTimePickerEntry.Time.Seconds);
                    var endDateTime = new DateTime(endDatePickerEntry.Date.Year, endDatePickerEntry.Date.Month,
                        endDatePickerEntry.Date.Day, endTimePickerEntry.Time.Hours, endTimePickerEntry.Time.Minutes,
                        endTimePickerEntry.Time.Seconds);

                    var client = new RestClient(Constants.UrlConstant.BaserUrl);


                    var request = new RestRequest(Constants.UrlConstant.AllTournamentRequest, Method.POST, DataFormat.Json);
                    request.AddJsonBody(new
                    {
                        SportId = SportCategory.football,
                        Name = nameEntry.Text,
                        ImageUrl = imageUrlEntry.Text,
                        StartsOn = startDateTime,
                        EndsOn = endDateTime,
                        Description = detailsEntry.Text
                    });
                    request.AddHeader("Accept", "application/json");
                    request.AddHeader("Content-Type", "application/json");
                    var asyncHandle = await client.PostAsync<Team>(request);

                    CrossToastPopUp.Current.ShowToastSuccess("Tournament Successfully Created", Plugin.Toast.Abstractions.ToastLength.Long);
                    nameEntry.Text = string.Empty;
                    imageUrlEntry.Text = string.Empty;
                    detailsEntry.Text = string.Empty;
                    addInfoEntry.Text = string.Empty;
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
            }
            header.ShowProgressIndicator = false;
            btn.IsEnabled = true;
        }
    }
}