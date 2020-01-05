using ScorePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.UiComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchDetailsHeader : Grid
    {
        public MatchDetailsHeader()
        {
            InitializeComponent();
            // this.BindingContext = new MatchDetailsVm();
        }
        public static readonly BindableProperty HomePlayerScoresNameProperty =
           BindableProperty.Create(
               propertyName: nameof(HomePlayerScoresName),
               returnType: typeof(ObservableCollection<string>),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: null,
               defaultBindingMode: BindingMode.OneWay);
        public ObservableCollection<string> HomePlayerScoresName
        {
            get
            {
                return (ObservableCollection<string>)GetValue(HomePlayerScoresNameProperty);
            }
            set
            {
                SetValue(HomePlayerScoresNameProperty, value);
            }
        }

        public static readonly BindableProperty AwayPlayerScoresNameProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayPlayerScoresName),
               returnType: typeof(ObservableCollection<string>),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: null,
               defaultBindingMode: BindingMode.OneWay);
        public ObservableCollection<string> AwayPlayerScoresName
        {
            get
            {
                return (ObservableCollection<string>)GetValue(AwayPlayerScoresNameProperty);
            }
            set
            {
                SetValue(AwayPlayerScoresNameProperty, value);
            }
        }

        public static readonly BindableProperty HomeClubNameProperty =
          BindableProperty.Create(
              propertyName: nameof(HomeClubName),
              returnType: typeof(string),
              declaringType: typeof(MatchDetailsHeader),
              defaultValue: String.Empty,
              defaultBindingMode: BindingMode.OneWay);
        public string HomeClubName
        {
            get
            {
                return (string)GetValue(HomeClubNameProperty);
            }
            set
            {
                SetValue(HomeClubNameProperty, value);
            }
        }
        public static readonly BindableProperty AwayClubNameProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayClubName),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayClubName
        {
            get
            {
                return (string)GetValue(AwayClubNameProperty);
            }
            set
            {
                SetValue(AwayClubNameProperty, value);
            }
        }
        public static readonly BindableProperty HomeClubScoreProperty =
           BindableProperty.Create(
               propertyName: nameof(HomeClubScore),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string HomeClubScore
        {
            get
            {
                return (string)GetValue(HomeClubScoreProperty);
            }
            set
            {
                SetValue(HomeClubScoreProperty, value);
            }
        }
        public static readonly BindableProperty AwayClubScoreProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayClubScore),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayClubScore
        {
            get
            {
                return (string)GetValue(AwayClubScoreProperty);
            }
            set
            {
                SetValue(AwayClubScoreProperty, value);
            }
        }
        public static readonly BindableProperty MatchDateProperty =
           BindableProperty.Create(
               propertyName: nameof(MatchDate),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string MatchDate
        {
            get
            {
                return (string)GetValue(MatchDateProperty);
            }
            set
            {
                SetValue(MatchDateProperty, value);
            }
        }
        public static readonly BindableProperty HomeClubImgProperty =
           BindableProperty.Create(
               propertyName: nameof(HomeClubImg),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string HomeClubImg
        {
            get
            {
                return (string)GetValue(HomeClubImgProperty);
            }
            set
            {
                SetValue(HomeClubImgProperty, value);
            }
        }
        public static readonly BindableProperty AwayClubImgProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayClubImg),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayClubImg
        {
            get
            {
                return (string)GetValue(AwayClubImgProperty);
            }
            set
            {
                SetValue(AwayClubImgProperty, value);
            }
        }
        public static readonly BindableProperty GameStatusProperty =
           BindableProperty.Create(
               propertyName: nameof(GameStatus),
               returnType: typeof(string),
               declaringType: typeof(MatchDetailsHeader),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string GameStatus
        {
            get
            {
                return (string)GetValue(GameStatusProperty);
            }
            set
            {
                SetValue(AwayClubImgProperty, value);
            }
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HomePlayerScoresNameProperty.PropertyName)
            {
                homePlayerScored.ItemsSource = HomePlayerScoresName;
            }
            if (propertyName == AwayPlayerScoresNameProperty.PropertyName)
            {
                awayPlayerScored.ItemsSource = AwayPlayerScoresName;
            }
            if (propertyName == HomeClubNameProperty.PropertyName)
            {
                homeClubName.Text = HomeClubName;
            }
            if (propertyName == AwayClubNameProperty.PropertyName)
            {
                awayClubName.Text = AwayClubName;
            }
            if (propertyName == HomeClubScoreProperty.PropertyName)
            {
                firstClubScore.Text = HomeClubScore;
            }
            if (propertyName == AwayClubScoreProperty.PropertyName)
            {
                SecondClubScore.Text = AwayClubScore;
            }
            if (propertyName == MatchDateProperty.PropertyName)
            {
                matchDate.Text = MatchDate;
            }
            if (propertyName == HomeClubImgProperty.PropertyName)
            {
                homeClubImg.Source = HomeClubImg;
            }
            if (propertyName == AwayClubImgProperty.PropertyName)
            {
                awayClubImg.Source = AwayClubImg;
            }
            if (propertyName == GameStatusProperty.PropertyName)
            {
                gameStatus.Text = GameStatus;
            }

        }
    }
}