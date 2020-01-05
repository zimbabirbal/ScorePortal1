using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.UiComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastMatch : Grid
    {
        public LastMatch()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty HomeClubNameProperty =
           BindableProperty.Create(
               propertyName: nameof(HomeClubName),
               returnType: typeof(string),
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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
               declaringType: typeof(LastMatch),
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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HomeClubNameProperty.PropertyName)
            {
                firstClubName.Text = HomeClubName;
            }
            if (propertyName == AwayClubNameProperty.PropertyName)
            {
                SecondClubName.Text = AwayClubName;
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
                matchDateTime.Text = MatchDate;
            }
            if (propertyName == HomeClubImgProperty.PropertyName)
            {
                homeClubImg.Source = HomeClubImg;
            }
            if (propertyName == AwayClubImgProperty.PropertyName)
            {
                awayClubImg.Source = AwayClubImg;
            }
        }
    }
}