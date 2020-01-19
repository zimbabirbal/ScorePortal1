using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Toast;
using RestSharp;
using SportNews.Models;
using SportNews.Services;
using SportNews.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    public partial class AddTournament : ContentPage
    {
        public bool IsBusy { get; set; }
        private bool _isUpdate { get; set; }
        private string imgPath { get; set; }
        private Tournament _tournament { get; set; }
        public AddTournament(bool isUpdate, Tournament tournament)
        {

            InitializeComponent();
            //this.BindingContext = new AdvancedTournamentViewModel();
            _isUpdate = isUpdate;
            _tournament = tournament;
            if (_isUpdate)
            {
                //fetchTournamentInfoFromServer();
                if (_tournament != null)
                {
                    nameEntry.Text = _tournament.Name;
                    img.Source = _tournament.ImageUrl;
                    detailsEntry.Text = _tournament.Description;
                    startDatePickerEntry.Date = _tournament.StartsOn.Date;
                    startTimePickerEntry.Time = _tournament.StartsOn.TimeOfDay;
                    endDatePickerEntry.Date = _tournament.EndsOn.Date;
                    endTimePickerEntry.Time = _tournament.EndsOn.TimeOfDay;
                    btn.Text = "save";
                }
            }
        }
        private async void fetchTournamentInfoFromServer()
        {

            var client = new RestClient(Constants.UrlConstant.BaserUrl);
            var request = new RestRequest(string.Format(Constants.UrlConstant.TournamentRequest, 4), DataFormat.Json);
            var response = await client.GetAsync<SportNews.Models.Tournament>(request);
            if (response != null)
            {
                _tournament = response;
                nameEntry.Text = response.Name;
                img.Source = response.ImageUrl;
                detailsEntry.Text = response.Description;
                startDatePickerEntry.Date = response.StartsOn.Date;
                startTimePickerEntry.Time = response.StartsOn.TimeOfDay;
                endDatePickerEntry.Date = response.EndsOn.Date;
                endTimePickerEntry.Time = response.EndsOn.TimeOfDay;
            }

        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdvancedTournament());
        }
        private async Task<string> UploadImageToCloudinary(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;

            if (!File.Exists(filePath))
                throw new Exception($"File not found at path: {filePath}");

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("ScoresPortalImg", imgPath),
                Folder = "ScoresPortal",
                Phash = true
            };
            var uploadResult = await Task.Run<ImageUploadResult>(() => App.CloudinaryInstance.Upload(uploadParams));
            //var a =UploadResult.Phash.;
            return uploadResult.SecureUri.AbsoluteUri;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            btn.IsEnabled = false;
            btnUpload.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await addUpdate(_isUpdate);
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
            }
            header.ShowProgressIndicator = false;
            btn.IsEnabled = true;
            btnUpload.IsEnabled = true;
        }
        private async Task addUpdate(bool isUpdate)
        {

            try
            {
                var imgSource = "";
                if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(detailsEntry.Text))
                {
                    CrossToastPopUp.Current.ShowToastMessage("Please Fill all the field", Plugin.Toast.Abstractions.ToastLength.Long);
                    return;
                }
                if (!string.IsNullOrEmpty(imgPath))
                {
                    imgSource = await RemoteImageUpload.UploadImageToCloudinary(imgPath);
                }
                else
                {
                    if (isUpdate)
                    {
                        imgSource = _tournament.ImageUrl;
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Please upload the image.", Plugin.Toast.Abstractions.ToastLength.Long);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(imgSource))
                {
                    //throw new Exception($"Error while uploading image");
                    CrossToastPopUp.Current.ShowToastMessage("Image upload failed try again", Plugin.Toast.Abstractions.ToastLength.Long);
                    return;
                }
                var startDateTime = new DateTime(startDatePickerEntry.Date.Year, startDatePickerEntry.Date.Month,
                    startDatePickerEntry.Date.Day, startTimePickerEntry.Time.Hours, startTimePickerEntry.Time.Minutes,
                    startTimePickerEntry.Time.Seconds);
                var endDateTime = new DateTime(endDatePickerEntry.Date.Year, endDatePickerEntry.Date.Month,
                    endDatePickerEntry.Date.Day, endTimePickerEntry.Time.Hours, endTimePickerEntry.Time.Minutes,
                    endTimePickerEntry.Time.Seconds);
                var isSuccess = false;
                if (isUpdate)
                {
                    isSuccess = await remoteUpdateTournament(imgSource, startDateTime, endDateTime);
                }
                else
                {
                    isSuccess = await remoteAddNewTournament(imgSource, startDateTime, endDateTime);
                }
                if (isSuccess)
                {
                    CrossToastPopUp.Current.ShowToastSuccess("Successfully save the tournament.", Plugin.Toast.Abstractions.ToastLength.Long);
                    //nameEntry.Text = string.Empty;
                    //detailsEntry.Text = string.Empty;
                    //img.Source = "default_cover.png";
                    await Navigation.PopModalAsync();
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage("Error occured, Please try again.", Plugin.Toast.Abstractions.ToastLength.Long);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Task<bool> remoteAddNewTournament(string imgRemotePath, DateTime startDateTime, DateTime endDateTime)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(Constants.UrlConstant.AllTournamentRequest, Method.POST, DataFormat.Json);
                request.AddJsonBody(new
                {
                    SportId = _tournament.SportId,
                    Name = nameEntry.Text,
                    ImageUrl = imgRemotePath,
                    StartsOn = startDateTime,
                    EndsOn = endDateTime,
                    Description = detailsEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PostAsync<Tournament>(request, (response, handle) =>
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
                //var asyncHandle = await client.PostAsync<Tournament>(request);
            }
            catch(Exception ex)
            {
                tcs.SetResult(false);
            }

            return tcs.Task;
        }

        private Task<bool> remoteUpdateTournament(string imgRemotePath, DateTime startDateTime, DateTime endDateTime)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.TournamentRequest, _tournament.Id), Method.PUT, DataFormat.Json);
                request.AddJsonBody(new
                {
                    Id = _tournament.Id,
                    SportId = _tournament.SportId,
                    Name = nameEntry.Text,
                    ImageUrl = imgRemotePath,
                    StartsOn = startDateTime,
                    EndsOn = endDateTime,
                    Description = detailsEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PutAsync<Tournament>(request, (response, handle) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
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
            //var asyncHandle = await client.PutAsync<Tournament>(request);
            return tcs.Task;
        }

        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;


            imgPath = file.Path;

            img.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}