using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportNews.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FootballStats : Grid
    {
        public FootballStats()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty HomeTeamStatsLblProperty =
           BindableProperty.Create(
               propertyName: nameof(HomeTeamStatsLbl),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string HomeTeamStatsLbl
        {
            get
            {
                return (string)GetValue(HomeTeamStatsLblProperty);
            }
            set
            {
                SetValue(HomeTeamStatsLblProperty, value);
            }
        }
        public static readonly BindableProperty StatsLblProperty =
           BindableProperty.Create(
               propertyName: nameof(StatsLbl),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string StatsLbl
        {
            get
            {
                return (string)GetValue(StatsLblProperty);
            }
            set
            {
                SetValue(StatsLblProperty, value);
            }
        }
        public static readonly BindableProperty AwayTeamStatsLblProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayTeamStatsLbl),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayTeamStatsLbl
        {
            get
            {
                return (string)GetValue(AwayTeamStatsLblProperty);
            }
            set
            {
                SetValue(AwayTeamStatsLblProperty, value);
            }
        }
        
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HomeTeamStatsLblProperty.PropertyName)
            {
                homeTeamLbl.Text = HomeTeamStatsLbl;
            }
            else if (propertyName == AwayTeamStatsLblProperty.PropertyName)
            {
                awayTeamLbl.Text = AwayTeamStatsLbl;
            }
            else if (propertyName == StatsLblProperty.PropertyName)
            {
                statsLbl.Text = StatsLbl;
            }
        }
    }
}