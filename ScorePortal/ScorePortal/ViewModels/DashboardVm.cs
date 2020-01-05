using Plugin.Toast;
using ScorePortal.Model;
using ScorePortal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace ScorePortal.ViewModel
{
    public class DashboardVm : INotifyPropertyChanged
    {
        private ObservableCollection<EventItem> _eventItems;
        private bool isBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged(); } }
        public ObservableCollection<EventItem> EventItems { get => _eventItems; set { _eventItems = value; OnPropertyChanged(); } }
        public DashboardVm()
        {
            IsBusy = true;
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                fetchTournaments();
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No Internet Avaliable", Plugin.Toast.Abstractions.ToastLength.Long);
                IsBusy = false;
            }
           
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async void fetchTournaments()
        {
            EventItems = new ObservableCollection<EventItem>();
            var a = await FetchTournament.FetchTournamentsAsync();
            foreach (var b in a)
            {
                EventItems.Add(new EventItem { Title = b.Name, BackgroundImage = b.ImageUrl });
            }
             IsBusy = false;

        }
    }
}
