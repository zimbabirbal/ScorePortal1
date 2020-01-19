using Plugin.Toast;
using SportNews.Model;
using SportNews.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportNews.ViewModel
{
    public class DashboardVm : INotifyPropertyChanged
    {
        private ObservableCollection<EventItem> _eventItems;
        private bool isBusy;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged(); } }
        public ObservableCollection<EventItem> EventItems { get => _eventItems; set { _eventItems = value; OnPropertyChanged(); } }
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public DashboardVm()
        {
            IsBusy = true;
            IsRefreshing = false;
            EventItems = new ObservableCollection<EventItem>();
            fetchTournaments();
            RefreshCommand = new Command(ExecuteRefreshCommand);

        }
        void ExecuteRefreshCommand()
        {
            // Stop refreshing

            IsRefreshing = true;
            //EventItems.Clear();
            fetchTournaments();
            IsRefreshing = false;
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async void fetchTournaments()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                var a = await FetchTournament.FetchTournamentsAsync();
                EventItems.Clear();
                foreach (var b in a)
                {
                    EventItems.Add(new EventItem { Title = b.Name, BackgroundImage = b.ImageUrl });
                }
                IsBusy = false;
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
                IsBusy = false;
            }

        }
        public ICommand RefreshCommand { get; }
    }
}
