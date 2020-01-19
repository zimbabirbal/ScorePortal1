using Plugin.Media;
using Plugin.Toast;
using RestSharp;
using SportNews.Models;
using SportNews.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AddTeam : ContentPage
    {
        private int playerListRowHeight = 48;
        private string imgPath { get; set; }
        private Team _team { get; set; }
        private bool _isUpdate { get; set; }
        public AddTeam(bool isUpdate, Team team)
        {
            InitializeComponent();
            _isUpdate = isUpdate;
            _team = team;
            if(_isUpdate)
            {
                if (_team != null)
                {
                    nameEntry.Text = _team.Name;
                    imgLogo.Source = _team.ImageUrl;
                    addInfoEntry.Text = _team.Description;
                    //estdDateEntry.Date = _team.StartsOn.Date;
                    //estdTimeEntry.Time = _team.StartsOn.TimeOfDay;
                    addTeam.Text = "save";
                }
            }
        }

        private async void addTeam_Clicked(object sender, EventArgs e)
        {
            //
            addTeam.IsEnabled = false;
            uploadLogo.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await addUpdateTeam(_isUpdate);
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
            }
            header.ShowProgressIndicator = false;
            addTeam.IsEnabled = true;
            uploadLogo.IsEnabled = true;
        }

        private async Task addUpdateTeam(bool isUpdate)
        {
            try
            {
                var imgSource = "";
                if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(addInfoEntry.Text))
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
                        imgSource = _team.ImageUrl;
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
                var estdDateTime = new DateTime(estdDateEntry.Date.Year, estdDateEntry.Date.Month,
                    estdDateEntry.Date.Day, estdTimeEntry.Time.Hours, estdTimeEntry.Time.Minutes,
                    estdTimeEntry.Time.Seconds);
                var isSuccess = false;
                if (isUpdate)
                {
                    isSuccess = await remoteUpdateTeam(imgSource);
                }
                else
                {
                    isSuccess = await remoteAddNewTeam(imgSource);
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

        private Task<bool> remoteAddNewTeam(string imgSource)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(Constants.UrlConstant.AllTeamRequest, Method.POST, DataFormat.Json);
                request.AddJsonBody(new
                {
                    SportId = _team.SportId,
                    Name = nameEntry.Text,
                    ImageUrl = imgSource,
                    Description = addInfoEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PostAsync<Team>(request, (response, handle) =>
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
            catch (Exception ex)
            {
                tcs.SetResult(false);
            }

            return tcs.Task;
        }

        private Task<bool> remoteUpdateTeam(string imgSource)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.TeamRequest, _team.Id), Method.PUT, DataFormat.Json);
                request.AddJsonBody(new
                {
                    Id = _team.Id,
                    SportId = _team.SportId,
                    Name = nameEntry.Text,
                    ImageUrl = imgSource,
                    Description = addInfoEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PutAsync<Team>(request, (response, handle) =>
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

        private async void GetTeamAsync()
        {
            //var response = await client.GetAsync<Team>(request);
            var a = 1;
            var client = new RestClient(Constants.UrlConstant.BaserUrl);

            var request = new RestRequest(string.Format(Constants.UrlConstant.TeamRequest, a), DataFormat.Json);
            request.AddParameter("SportId", 1);
            request.AddParameter("Name", "");
            request.AddParameter("ImageUrl", "");
            request.AddParameter("Description", "ssfd");

            var response = await client.PostAsync<Team>(request);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(response.Id + "/n");
            stringBuilder.Append(response.SportId + "/n");
            stringBuilder.Append(response.Name + "/n");
            stringBuilder.Append(response.ImageUrl + "/n");
            stringBuilder.Append(response.Description + "/n");
            //httpresponse.Text = stringBuilder.ToString();
        }

        //testImage.Source = a;


        private async void uploadLogo_Clicked(object sender, EventArgs e)
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

            imgLogo.Source = ImageSource.FromStream(() => file.GetStream());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //advanced clikced
            //await Navigation.PushModalAsync(new AddPlayer());
        }
    }
}