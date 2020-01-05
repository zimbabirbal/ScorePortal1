using ScorePortal.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.UiComponents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardHeader : Grid
	{
        TapGestureRecognizer rightIconClickGesture = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
        TapGestureRecognizer leftIconClickGesture = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
        public DashboardHeader ()
		{
			InitializeComponent ();

            iconRight.IsVisible = true;
            rightIconClickArea.IsVisible = true;
            //ai.IsVisible = false;
            rightIconFile.File = ShowMenuIcon ? IconConstants.IconMenu : IconConstants.IconCross;
            iconRight.GestureRecognizers.Add(rightIconClickGesture);
            rightIconClickArea.GestureRecognizers.Add(rightIconClickGesture);
            rightIconClickGesture.Command = new Command(async () => await DefaultRightIconClickBehavior());

            // set defaults
            iconLeft.IsVisible = false;
            leftIconClickArea.IsVisible = false;
            iconLeft.GestureRecognizers.Add(leftIconClickGesture);
            leftIconClickArea.GestureRecognizers.Add(leftIconClickGesture);
            leftIconClickGesture.Command = new Command(async () => await DefaultLeftIconClickBehavior());
        }
        public static readonly BindableProperty ShowProgressIndicatorProperty =
           BindableProperty.Create(
               propertyName: nameof(ShowProgressIndicator),
               returnType: typeof(bool),
               declaringType: typeof(DashboardHeader),
               defaultValue: false,
               defaultBindingMode: BindingMode.OneWay);
        public bool ShowProgressIndicator
        {
            get
            {
                return (bool)GetValue(ShowProgressIndicatorProperty);
            }
            set
            {
                SetValue(ShowProgressIndicatorProperty, value);
            }
        }

        public static readonly BindableProperty ShowMenuIconProperty =
            BindableProperty.Create(
                propertyName: nameof(ShowMenuIcon),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);
        public bool ShowMenuIcon
        {
            get
            {
                return (bool)GetValue(ShowMenuIconProperty);
            }
            set
            {
                SetValue(ShowMenuIconProperty, value);
            }
        }


        public static readonly BindableProperty HasBlackForegroundProperty =
            BindableProperty.Create(
                propertyName: nameof(HasBlackForeground),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);
        public bool HasBlackForeground
        {
            get
            {
                return (bool)GetValue(HasBlackForegroundProperty);
            }
            set
            {
                SetValue(HasBlackForegroundProperty, value);
            }
        }


        public static readonly BindableProperty TitleColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TitleColor),
                returnType: typeof(Color),
                declaringType: typeof(DashboardHeader),
                defaultValue: Color.Black,
                defaultBindingMode: BindingMode.OneWay);
        public Color TitleColor
        {
            get
            {
                return (Color)GetValue(TitleColorProperty);
            }
            set
            {
                SetValue(TitleColorProperty, value);
            }
        }


        public static readonly BindableProperty ShowBackButtonProperty =
            BindableProperty.Create(
                propertyName: nameof(ShowBackButton),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);
        public bool ShowBackButton
        {
            get
            {
                return (bool)GetValue(ShowBackButtonProperty);
            }
            set
            {
                SetValue(ShowBackButtonProperty, value);
            }
        }

        public static readonly BindableProperty ShowMenuButtonProperty =
            BindableProperty.Create(
                propertyName: nameof(ShowMenuButton),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: true,
                defaultBindingMode: BindingMode.OneWay);
        public bool ShowMenuButton
        {
            get
            {
                return (bool)GetValue(ShowMenuButtonProperty);
            }
            set
            {
                SetValue(ShowMenuButtonProperty, value);
            }
        }

        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create(
                propertyName: nameof(TitleText),
                returnType: typeof(string),
                declaringType: typeof(DashboardHeader),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string TitleText
        {
            get
            {
                return (string)GetValue(TitleTextProperty);
            }
            set
            {
                SetValue(TitleTextProperty, value);
            }
        }
        public static readonly BindableProperty SubHeaderTitleTextProperty =
            BindableProperty.Create(
                propertyName: nameof(SubHeaderTitleText),
                returnType: typeof(string),
                declaringType: typeof(DashboardHeader),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.TwoWay);
        public string SubHeaderTitleText
        {
            get
            {
                return (string)GetValue(SubHeaderTitleTextProperty);
            }
            set
            {
                SetValue(SubHeaderTitleTextProperty, value);
            }
        }


        public static readonly BindableProperty RightIconClickedCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(RightIconClickedCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(DashboardHeader),
                defaultValue: default(ICommand),
                defaultBindingMode: BindingMode.OneWay);

        public ICommand RightIconClickedCommand
        {
            get
            {
                return (ICommand)GetValue(RightIconClickedCommandProperty);
            }
            set
            {
                SetValue(RightIconClickedCommandProperty, value);
            }
        }

        public static readonly BindableProperty LeftIconClickedCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(LeftIconClickedCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(DashboardHeader),
                defaultValue: default(ICommand),
                defaultBindingMode: BindingMode.OneWay);

        public ICommand LeftIconClickedCommand
        {
            get
            {
                return (ICommand)GetValue(LeftIconClickedCommandProperty);
            }
            set
            {
                SetValue(LeftIconClickedCommandProperty, value);
            }
        }
        public static readonly BindableProperty SubHeaderTitleVisibleProperty =
            BindableProperty.Create(
                propertyName: nameof(SubHeaderTitleVisible),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);
        public bool SubHeaderTitleVisible
        {
            get
            {
                return (bool)GetValue(SubHeaderTitleVisibleProperty);
            }
            set
            {
                SetValue(SubHeaderTitleVisibleProperty, value);
            }
        }
        public static readonly BindableProperty RightIconDisableProperty =
            BindableProperty.Create(
                propertyName: nameof(RightIconDisable),
                returnType: typeof(bool),
                declaringType: typeof(DashboardHeader),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay);
        public bool RightIconDisable
        {
            get
            {
                return (bool)GetValue(RightIconDisableProperty);
            }
            set
            {
                SetValue(RightIconDisableProperty, value);
                OnPropertyChanged();
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleTextProperty.PropertyName)
            {
                lblTitle.Text = TitleText;
            }
            if (propertyName == TitleColorProperty.PropertyName)
            {
                lblTitle.TextColor = TitleColor;
            }
            if (propertyName == SubHeaderTitleTextProperty.PropertyName)
            {
                if (!string.IsNullOrWhiteSpace(SubHeaderTitleText))
                {
                    lblSubHeaderText.Text = SubHeaderTitleText;
                }
            }
            else if (propertyName == ShowProgressIndicatorProperty.PropertyName)
            {
                ai.IsVisible = ShowProgressIndicator;
            }
            else if (propertyName == ShowBackButtonProperty.PropertyName)
            {
                iconLeft.IsVisible = ShowBackButton;
                leftIconClickArea.IsVisible = ShowBackButton;
            }
            else if (propertyName == ShowMenuButtonProperty.PropertyName)
            {
                iconRight.IsVisible = ShowMenuIcon;
                rightIconClickArea.IsVisible = ShowMenuIcon;
            }
            else if (propertyName == RightIconClickedCommandProperty.PropertyName)
            {
                rightIconClickGesture.Command = null;
                rightIconClickGesture.Command = RightIconClickedCommand;
            }
            else if (propertyName == LeftIconClickedCommandProperty.PropertyName)
            {
                leftIconClickGesture.Command = null;
                leftIconClickGesture.Command = LeftIconClickedCommand;
                
            }
            else if (propertyName == ShowMenuIconProperty.PropertyName)
            {
                rightIconFile.File = ShowMenuIcon ? (HasBlackForeground ? IconConstants.IconMenu : IconConstants.IconMenuWhite) : IconConstants.IconCross;
            }
            else if (propertyName == HasBlackForegroundProperty.PropertyName)
            {
                rightIconFile.File = HasBlackForeground ? IconConstants.IconMenu : IconConstants.IconMenuWhite;
            }
            else if (propertyName == SubHeaderTitleVisibleProperty.PropertyName)
            {
                lblSubHeaderText.IsVisible = SubHeaderTitleVisible;
            }
            else if (propertyName == RightIconDisableProperty.PropertyName)
            {
                rightIconClickArea.Opacity = RightIconDisable ? (double)App.Current.Resources["DisabledViewOpacity"] : 1D;
                iconRight.Opacity = RightIconDisable ? (double)App.Current.Resources["DisabledViewOpacity"] : 1D;
            }
        }

        private async Task DefaultRightIconClickBehavior()
        {
            //await App.AppManager.NavManager.GoAsModalWithoutHistoryTo(typeof(ViewModels.TwoBtnPopupsVm), new ViewModels.NavDataModels.SettingsFlowCancelPopupNavData());
            // await App.AppManager.NavManager.GoWithoutHistoryTo(typeof(ViewModels.TwoBtnPopupsVm));
        }

        private async Task DefaultLeftIconClickBehavior()
        {
            if (ShowBackButton)
            {
               // await _currentBindingContext?.Nav.GoBack();
            }
        }
    }
}