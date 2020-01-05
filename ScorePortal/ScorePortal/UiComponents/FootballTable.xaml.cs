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
	public partial class FootballTable : Grid
	{
		public FootballTable ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty IdProperty =
           BindableProperty.Create(
               propertyName: nameof(Id),
               returnType: typeof(string),
               declaringType: typeof(FootballTable),
               defaultValue: String.Empty,
               defaultBindingMode: BindingMode.OneWay);
        public string Id
        {
            get
            {
                return (string)GetValue(IdProperty);
            }
            set
            {
                SetValue(IdProperty, value);
            }
        }
        public static readonly BindableProperty ClubImageProperty =
            BindableProperty.Create(
                propertyName: nameof(ClubImage),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string ClubImage
        {
            get
            {
                return (string)GetValue(ClubImageProperty);
            }
            set
            {
                SetValue(ClubImageProperty, value);
            }
        }
        public static readonly BindableProperty ClubNameProperty =
            BindableProperty.Create(
                propertyName: nameof(ClubName),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string ClubName
        {
            get
            {
                return (string)GetValue(ClubNameProperty);
            }
            set
            {
                SetValue(ClubNameProperty, value);
            }
        }
        public static readonly BindableProperty MpProperty =
            BindableProperty.Create(
                propertyName: nameof(Mp),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Mp
        {
            get
            {
                return (string)GetValue(MpProperty);
            }
            set
            {
                SetValue(MpProperty, value);
            }
        }
        public static readonly BindableProperty WinProperty =
            BindableProperty.Create(
                propertyName: nameof(Win),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Win
        {
            get
            {
                return (string)GetValue(WinProperty);
            }
            set
            {
                SetValue(WinProperty, value);
            }
        }
        public static readonly BindableProperty DrawProperty =
            BindableProperty.Create(
                propertyName: nameof(Draw),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Draw
        {
            get
            {
                return (string)GetValue(DrawProperty);
            }
            set
            {
                SetValue(DrawProperty, value);
            }
        }
        public static readonly BindableProperty LoseProperty =
            BindableProperty.Create(
                propertyName: nameof(Lose),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Lose
        {
            get
            {
                return (string)GetValue(LoseProperty);
            }
            set
            {
                SetValue(LoseProperty, value);
            }
        }
        public static readonly BindableProperty GfProperty =
            BindableProperty.Create(
                propertyName: nameof(Gf),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Gf
        {
            get
            {
                return (string)GetValue(GfProperty);
            }
            set
            {
                SetValue(GfProperty, value);
            }
        }
        public static readonly BindableProperty GaProperty =
            BindableProperty.Create(
                propertyName: nameof(Ga),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Ga
        {
            get
            {
                return (string)GetValue(GaProperty);
            }
            set
            {
                SetValue(GaProperty, value);
            }
        }
        public static readonly BindableProperty GdProperty =
            BindableProperty.Create(
                propertyName: nameof(Gd),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Gd
        {
            get
            {
                return (string)GetValue(GdProperty);
            }
            set
            {
                SetValue(GdProperty, value);
            }
        }
        public static readonly BindableProperty PtsProperty =
            BindableProperty.Create(
                propertyName: nameof(Pts),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Pts
        {
            get
            {
                return (string)GetValue(PtsProperty);
            }
            set
            {
                SetValue(PtsProperty, value);
            }
        }
        
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(FootballTable),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.OneWay);
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }




        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IdProperty.PropertyName)
            {
                id.Text = Id;
            }
            else if (propertyName == ClubImageProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                clubImg.Source = ClubImage;
            }
            else if (propertyName == ClubNameProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                clubName.Text = ClubName;
            }
            else if (propertyName == MpProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                mp.Text = Mp;
            }
            else if (propertyName == WinProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                win.Text = Win;
            }
            else if (propertyName == DrawProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                draw.Text = Draw;
            }
            else if (propertyName == LoseProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                lose.Text = Lose;
            }
            else if (propertyName == GfProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                gf.Text = Gf;
            }
            else if (propertyName == GaProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                ga.Text = Ga;
            }
            else if (propertyName == GdProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                gd.Text = Gd;
            }
            else if (propertyName == PtsProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                pts.Text = Pts;
            }
           
        }
    }
}