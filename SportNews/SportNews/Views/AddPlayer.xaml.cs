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
    public partial class AddPlayer : ContentPage
    {
        private Player _player { get; set; }
        public ObservableCollection<Player> PlayerList { get; set; }
        private int playerListRowHeight = 48;
        private string imgPath { get; set; }
        private bool _isUpdate { get; set; }
        public AddPlayer(bool isUpdate, Player player)
        {
            InitializeComponent();
            PlayerList = new ObservableCollection<Player>();
            //playerList.ItemsSource = PlayerList;
            //playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
            _isUpdate = isUpdate;
            _player = player;
            if (_isUpdate)
            {
                if (_player != null)
                {
                    playerNameEntry.Text = _player.Name;
                    imgPlayer.Source = _player.ImageUrl;
                    playerInfoEntry.Text = _player.Description;
                    //estdDateEntry.Date = _player.StartsOn.Date;
                    //estdTimeEntry.Time = _player.StartsOn.TimeOfDay;
                    savePlayer.Text = "save";
                }
            }
        }

        private async void savePlayer_Clicked(object sender, EventArgs e)
        {
            //
            savePlayer.IsEnabled = false;
            uploadImg.IsEnabled = false;
            header.ShowProgressIndicator = true;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await addUpdatePlayer(_isUpdate);
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
            }
            header.ShowProgressIndicator = false;
            savePlayer.IsEnabled = true;
            uploadImg.IsEnabled = true;
        }

        private async Task addUpdatePlayer(bool isUpdate)
        {
            try
            {
                var imgSource = "";
                if (string.IsNullOrWhiteSpace(playerNameEntry.Text) || string.IsNullOrWhiteSpace(playerInfoEntry.Text))
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
                        imgSource = _player.ImageUrl;
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
                var isSuccess = false;
                if (isUpdate)
                {
                    isSuccess = await remoteUpdatePlayer(imgSource);
                }
                else
                {
                    isSuccess = await remoteAddNewPlayer(imgSource);
                }
                if (isSuccess)
                {
                    CrossToastPopUp.Current.ShowToastSuccess("Successfully save the tournament.", Plugin.Toast.Abstractions.ToastLength.Long);
                    //playerNameEntry.Text = string.Empty;
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

        private Task<bool> remoteAddNewPlayer(string imgSource)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(Constants.UrlConstant.AllPlayerRequest, Method.POST, DataFormat.Json);
                request.AddJsonBody(new
                {
                    TeamId = _player.TeamId,
                    Name = playerNameEntry.Text,
                    ImageUrl = imgSource,
                    Description = playerInfoEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PostAsync<Player>(request, (response, handle) =>
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

        private Task<bool> remoteUpdatePlayer(string imgSource)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                var client = new RestClient(Constants.UrlConstant.BaserUrl);
                var request = new RestRequest(string.Format(Constants.UrlConstant.PlayerUpdateRequest, _player.Id), Method.PUT, DataFormat.Json);
                request.AddJsonBody(new
                {
                    Id = _player.Id,
                    TeamId = _player.TeamId,
                    Name = playerNameEntry.Text,
                    ImageUrl = imgSource,
                    Description = playerInfoEntry.Text
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                client.PutAsync<Player>(request, (response, handle) =>
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
        //testImage.Source = a;

        private void Add_Player_Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(playerNameEntry.Text))
            {
                PlayerList.Add(new Player { Name = playerNameEntry.Text, Description = playerInfoEntry.Text });
                //playerList.ItemsSource = PlayerList;
                //playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
                playerInfoEntry.Text = string.Empty;
                playerNameEntry.Text = string.Empty;
            }

        }

        private void playerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PlayerList.RemoveAt(e.ItemIndex);
            //playerList.ItemsSource = PlayerList;
            //playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
        }
        private async void uploadImg_Clicked(object sender, EventArgs e)
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

            imgPlayer.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}