using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ScorePortal.ViewModels
{
    public class MatchDetailsVm : INotifyPropertyChanged
    {
        private ObservableCollection<string> _players1;
        private ObservableCollection<string> _players2;
        private double _height;
        private ObservableCollection<TempStats> _statsData;
        private double _statsHeight;
        private ObservableCollection<TeamLineup> _lineUpDatas;
        private double _lineUpHeight;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Players2 { get => _players2; set => _players2 = value; }
        public ObservableCollection<string> Players1 { get => _players1; set => _players1 = value; }
        public ObservableCollection<TempStats> StatsData { get => _statsData; set { _statsData = value; OnPropertyChanged(); } }
        public ObservableCollection<TeamLineup> LineUpDatas { get => _lineUpDatas; set => _lineUpDatas = value; }
        public double Height { get => _height; set { _height = value; OnPropertyChanged(); } }
        public double StatsHeight { get => _statsHeight; set { _statsHeight = value; OnPropertyChanged(); } }
        public double LineUpHeight { get => _lineUpHeight; set => _lineUpHeight = value; }
        public MatchDetailsVm()
        {
            Players1 = new ObservableCollection<string>();
            Players1.Add("sfsf");
            Players1.Add("sfsf");
            Players1.Add("sfsf");

            Players2 = new ObservableCollection<string>();
            Players2.Add("sfsf");

            var a = Players1.Count > Players2.Count ? Players1.Count : Players2.Count;
            Height = 19 * a;

            string[] stats = { "shots", "Tackle", "fouls", "yellow cards", "shots", "Tackle", "fouls", "yellow cards" };
            StatsData = new ObservableCollection<TempStats>();
            for (int i = 0; i < 8; i++)
            {
                StatsData.Add(new TempStats { HomeTeamStats = (i + 4).ToString(), AwayTeamStats = 1.ToString(), Stats = stats[i] });
            }
            StatsHeight = 24 * (StatsData.Count + 2);

            LineUpDatas = new ObservableCollection<TeamLineup>();
            for (int i = 0; i < 12; i++)
            {
                LineUpDatas.Add(new TeamLineup { HomePlyName = "FSf sdf", HomePlyNum = "12", AwayPlyName = "sfsf sdfs ", AwayPlyNum = "2" });
            }
            LineUpHeight = (LineUpDatas.Count + 2) * 24;
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class TempStats
    {
        public string HomeTeamStats { get; set; }
        public string AwayTeamStats { get; set; }
        public string Stats { get; set; }
    }
    public class TeamLineup
    {
        public string HomePlyNum { get; set; }
        public string AwayPlyNum { get; set; }
        public string HomePlyName { get; set; }
        public string AwayPlyName { get; set; }
    }
}
