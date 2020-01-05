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
	public partial class FootballLineUp : Grid
	{
		public FootballLineUp ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty HomePlayerNumberProperty =
          BindableProperty.Create(
              propertyName: nameof(HomePlayerNumber),
              returnType: typeof(string),
              declaringType: typeof(FootballStats),
              defaultValue: String.Empty,
              defaultBindingMode: BindingMode.OneWay);
        public string HomePlayerNumber
        {
            get
            {
                return (string)GetValue(HomePlayerNumberProperty);
            }
            set
            {
                SetValue(HomePlayerNumberProperty, value);
            }
        }
        public static readonly BindableProperty AwayPlayerNumberProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayPlayerNumber),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayPlayerNumber
        {
            get
            {
                return (string)GetValue(AwayPlayerNumberProperty);
            }
            set
            {
                SetValue(AwayPlayerNumberProperty, value);
            }
        }
        public static readonly BindableProperty HomePlayerNameProperty =
           BindableProperty.Create(
               propertyName: nameof(HomePlayerName),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string HomePlayerName
        {
            get
            {
                return (string)GetValue(HomePlayerNameProperty);
            }
            set
            {
                SetValue(HomePlayerNameProperty, value);
            }
        }
        public static readonly BindableProperty AwayPlayerNameProperty =
           BindableProperty.Create(
               propertyName: nameof(AwayPlayerName),
               returnType: typeof(string),
               declaringType: typeof(FootballStats),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string AwayPlayerName
        {
            get
            {
                return (string)GetValue(AwayPlayerNameProperty);
            }
            set
            {
                SetValue(AwayPlayerNameProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HomePlayerNumberProperty.PropertyName)
            {
                homePlayerNum.Text = HomePlayerNumber;
            }
            else if (propertyName == HomePlayerNameProperty.PropertyName)
            {
                homePlayerName.Text = HomePlayerName;
            }
            else if (propertyName == AwayPlayerNameProperty.PropertyName)
            {
                awayPlayerName.Text = AwayPlayerName;
            }
            else if (propertyName == AwayPlayerNumberProperty.PropertyName)
            {
                awayPlayerNum.Text = AwayPlayerNumber;
            }
        }
    }
}