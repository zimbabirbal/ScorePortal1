using Plugin.Media;
using RestSharp;
using ScorePortal.Models;
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
    public partial class AddTeam : ContentPage
    {
        public ObservableCollection<Player> PlayerList { get; set; }
        private int playerListRowHeight = 48;
        public AddTeam()
        {
            InitializeComponent();
            PlayerList = new ObservableCollection<Player>();
            playerList.ItemsSource = PlayerList;
            playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
        }

        private void Add_Player_Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(playerNameEntry.Text))
            {
                PlayerList.Add(new Player { Name = playerNameEntry.Text, Info = playerInfoEntry.Text });
                playerList.ItemsSource = PlayerList;
                playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
                playerInfoEntry.Text = string.Empty;
                playerNameEntry.Text = string.Empty;
            }
        }

        private void playerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PlayerList.RemoveAt(e.ItemIndex);
            playerList.ItemsSource = PlayerList;
            playerList.HeightRequest = playerListRowHeight * PlayerList.Count;
        }

        private async void addTeam_Clicked(object sender, EventArgs e)
        {
            var client = new RestClient(Constants.UrlConstant.BaserUrl);
            var request = new RestRequest(Constants.UrlConstant.TeamPostRequest, Method.POST, DataFormat.Json);
            request.AddJsonBody(new { SportId = "2", Name = "Man City", ImageUrl = "" });
            request.AddHeader("Accept", "application/json");

            request.AddHeader("Content-Type", "application/json");
            var asyncHandle = await client.PostAsync<Team>(request);

            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(@"sample.jpg")
            //};
            //var uploadResult = cloudinary.Upload(uploadParams);
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append(response.Id + "/n");
            //stringBuilder.Append(response.SportId + "/n");
            //stringBuilder.Append(response.Name + "/n");
            //stringBuilder.Append(response.ImageUrl + "/n");
            //stringBuilder.Append(response.Description + "/n");
            //httpresponse.Text = stringBuilder.ToString();
        }
        private async void GetTeamAsync()
        {
            //var response = await client.GetAsync<Team>(request);
            var a = 1;
            var client = new RestClient(Constants.UrlConstant.BaserUrl);

            var request = new RestRequest(string.Format(Constants.UrlConstant.TeamGetRequest, a), DataFormat.Json);
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
            httpresponse.Text = stringBuilder.ToString();
        }

        private async void Test_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;

            var a = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            testImage.Source = a;
        }
    }
}