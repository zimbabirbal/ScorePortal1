using ScorePortal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ScorePortal.ViewModels
{
    public class EventDetailsVm : INotifyPropertyChanged
    {
        private ObservableCollection<EventDetailsItem> _eventDetailsItems;
        private ObservableCollection<string> _imgSources;
        private ObservableCollection<ClubStanding> clubStandings;

        public ObservableCollection<LastMatches> LastMatchesPlayed { get => lastMatchesPlayed; set { lastMatchesPlayed = value; OnPropertyChanged(); } }
        private double leagueTableHeight;
        private ObservableCollection<LastMatches> lastMatchesPlayed;

        public double LeagueTableHeight { get => leagueTableHeight; set { leagueTableHeight = value; OnPropertyChanged(); } }

        public ObservableCollection<ClubStanding> ClubStandings { get => clubStandings; set { clubStandings = value; OnPropertyChanged(); } }
        public ObservableCollection<EventDetailsItem> EventDetailsItems
        {
            get => _eventDetailsItems; set
            {
                _eventDetailsItems = value;
                OnPropertyChanged();
            }
        }
        public EventDetailsVm()
        {
            EventDetailsItems = new ObservableCollection<EventDetailsItem>();
            ImgSources = new ObservableCollection<string>();
            ImgSources.Add("game");
            ImgSources.Add("game");
            ImgSources.Add("game");
            ImgSources.Add("game");
            EventDetailsItems.Add(new EventDetailsItem { EventImages = new ObservableCollection<string>() { "game", "game", "game" } });

            ClubStandings = new ObservableCollection<ClubStanding>();
            for (int i = 0; i < 20; i++)
            {
                ClubStandings.Add(new ClubStanding
                {
                    Title = "Club",
                    Id = i.ToString(),
                    ClubImage = "mc.png",
                    ClubName = "Manchester City",
                    Mp = "4",
                    Win = "3",
                    Draw = "1",
                    Lose = "0",
                    Gf = "12",
                    Ga = "5",
                    Gd = "7",
                    Pts = "13"
                });
            }
            LeagueTableHeight = 28 * ClubStandings.Count;

            LastMatchesPlayed = new ObservableCollection<LastMatches>();
            for(int i=0; i< (ClubStandings.Count/2); i++)
            {
                LastMatchesPlayed.Add(new Models.LastMatches { AwayClubName = "Real Madrid", AwayClubScore = "1", AwayClubImg="real", HomeClubName = "FC Barcelona", HomeClubScore = "5", MatchTime = "13:45pm", HomeClubImge="barca" });
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<string> ImgSources { get => _imgSources; set => _imgSources = value; }

    }
}
