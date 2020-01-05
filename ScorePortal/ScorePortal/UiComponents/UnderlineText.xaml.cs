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
    public partial class UnderlineText : StackLayout
    {
        private TapGestureRecognizer gestureRecognizer;
        public UnderlineText()
        {
            InitializeComponent();
            gestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
            stk.GestureRecognizers.Add(gestureRecognizer);

        }
        public enum UnderlineTextFontSizeValues
        {
            Default,
            Micro,
            Small,
            Medium,
            Large,
            Custom
        }

        public static readonly BindableProperty CustomFontsizeProperty =
            BindableProperty.Create(
                propertyName: nameof(CustomFontsize),
                returnType: typeof(UnderlineTextFontSizeValues),
                declaringType: typeof(UnderlineText),
                defaultValue: UnderlineTextFontSizeValues.Default,
                defaultBindingMode: BindingMode.OneWay);

        public UnderlineTextFontSizeValues CustomFontsize
        {
            get
            {
                return (UnderlineTextFontSizeValues)GetValue(CustomFontsizeProperty);
            }
            set
            {
                SetValue(CustomFontsizeProperty, value);
            }
        }
        public static readonly BindableProperty TappedCommandProperty =
           BindableProperty.Create(
               propertyName: nameof(TappedCommand),
               returnType: typeof(ICommand),
               declaringType: typeof(UnderlineText),
               defaultValue: default(ICommand),
               defaultBindingMode: BindingMode.OneWay);
        public ICommand TappedCommand
        {
            get
            {
                return (ICommand)GetValue(TappedCommandProperty);
            }
            set
            {
                SetValue(TappedCommandProperty, value);
            }
        }


        public static readonly BindableProperty UnderlineTextProperty =
            BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(UnderlineText),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.OneWay);

        public string Text
        {
            get
            {
                return (string)GetValue(UnderlineTextProperty);
            }
            set
            {
                SetValue(UnderlineTextProperty, value);
            }
        }


        public static readonly BindableProperty UnderlineColorProperty =
            BindableProperty.Create(
                propertyName: nameof(UnderlineColor),
                returnType: typeof(Color),
                declaringType: typeof(UnderlineText),
                defaultValue: Color.White,// ((Color)App.Current.Resources["AppBackgroundColor"]),
                defaultBindingMode: BindingMode.OneWay
                );

        public Color UnderlineColor
        {
            get
            {
                return (Color)GetValue(UnderlineColorProperty);
            }
            set
            {
                SetValue(UnderlineColorProperty, value);
            }
        }
        public static readonly BindableProperty UnderlineTextColorProperty =
            BindableProperty.Create(
                propertyName: nameof(UnderlineTextColor),
                returnType: typeof(Color),
                declaringType: typeof(UnderlineText),
                defaultValue: Color.White,// ((Color)App.Current.Resources["AppBackgroundColor"]),
                defaultBindingMode: BindingMode.OneWay
                );

        public Color UnderlineTextColor
        {
            get
            {
                return (Color)GetValue(UnderlineTextColorProperty);
            }
            set
            {
                SetValue(UnderlineTextColorProperty, value);
            }
        }
        public static readonly BindableProperty UnderlineFontSizeProperty =
            BindableProperty.Create(
                propertyName: nameof(UnderlineFontSize),
                returnType: typeof(double),
                declaringType: typeof(UnderlineText),
                defaultValue: 14D,
                defaultBindingMode: BindingMode.OneWay);

        public double UnderlineFontSize
        {
            get
            {
                return (double)GetValue(UnderlineFontSizeProperty);
            }
            set
            {
                SetValue(UnderlineFontSizeProperty, value);
            }
        }
        public static readonly BindableProperty UnderlineHeightProperty =
           BindableProperty.Create(
               propertyName: nameof(UnderlineHeight),
               returnType: typeof(double),
               declaringType: typeof(UnderlineText),
               defaultValue: 1D,
               defaultBindingMode: BindingMode.OneWay
               );

        public double UnderlineHeight
        {
            get
            {
                return (double)GetValue(UnderlineHeightProperty);
            }
            set
            {
                SetValue(UnderlineHeightProperty, value);
            }
        }
        public ICommand OpenBrowserCommand => new Command(() =>
        {
            if (IsHyperlink)
            {
                Uri uri;
                if (Uri.TryCreate(TargetUrl, UriKind.RelativeOrAbsolute, out uri))
                {
                    Device.OpenUri(new Uri(TargetUrl));
                }
            }
        });
        public static readonly BindableProperty IsHyperlinkProperty =
            BindableProperty.Create(
                propertyName: nameof(IsHyperlink),
                returnType: typeof(bool),
                declaringType: typeof(UnderlineText),
                defaultValue: true,
                defaultBindingMode: BindingMode.OneWay
                );

        public bool IsHyperlink
        {
            get
            {
                return (bool)GetValue(IsHyperlinkProperty);
            }
            set
            {
                SetValue(IsHyperlinkProperty, value);
            }
        }

        public static readonly BindableProperty TargetUrlProperty =
            BindableProperty.Create(
                propertyName: nameof(TargetUrl),
                returnType: typeof(string),
                declaringType: typeof(UnderlineText),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.TwoWay);

        public string TargetUrl
        {
            get
            {
                return (string)GetValue(TargetUrlProperty);
            }
            set
            {
                SetValue(TargetUrlProperty, value);
            }
        }
        public static readonly BindableProperty UnderlineVisibleProperty =
           BindableProperty.Create(
               propertyName: nameof(UnderlineVisible),
               returnType: typeof(bool),
               declaringType: typeof(UnderlineText),
               defaultValue: true,
               defaultBindingMode: BindingMode.OneWay);

        public bool UnderlineVisible
        {
            get
            {
                return (bool)GetValue(UnderlineVisibleProperty);
            }
            set
            {
                SetValue(UnderlineVisibleProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == UnderlineTextProperty.PropertyName)
            {
                lbl.Text = Text;
            }

            if (propertyName == UnderlineColorProperty.PropertyName)
            {
                line.BackgroundColor = UnderlineColor;

            }
            if (propertyName == UnderlineTextColorProperty.PropertyName)
            {
                lbl.TextColor = UnderlineTextColor;

            }
            if (propertyName == UnderlineFontSizeProperty.PropertyName)
            {
                if (CustomFontsize == UnderlineTextFontSizeValues.Custom)
                {
                    lbl.FontSize = UnderlineFontSize;
                }
            }
            if (propertyName == UnderlineHeightProperty.PropertyName)
            {
                line.HeightRequest = UnderlineHeight;
            }
            if (propertyName == TappedCommandProperty.PropertyName)
            {
                gestureRecognizer.Command = TappedCommand;
            }
            if (propertyName == UnderlineVisibleProperty.PropertyName)
            {
                line.IsVisible = UnderlineVisible;
            }
            if (propertyName == CustomFontsizeProperty.PropertyName)
            {
                if (CustomFontsize == UnderlineTextFontSizeValues.Micro)
                {
                    lbl.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                }
                else if (CustomFontsize == UnderlineTextFontSizeValues.Small || CustomFontsize == UnderlineTextFontSizeValues.Default)
                {
                    lbl.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                }
                else if (CustomFontsize == UnderlineTextFontSizeValues.Medium)
                {
                    lbl.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                }
                else if (CustomFontsize == UnderlineTextFontSizeValues.Large)
                {
                    lbl.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                }
                if (CustomFontsize == UnderlineTextFontSizeValues.Custom)
                {
                    lbl.FontSize = UnderlineFontSize;
                }


            }
        }


    }
}