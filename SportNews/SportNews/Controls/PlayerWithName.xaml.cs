using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportNews.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerWithName : Frame
    {
        TapGestureRecognizer rightIconClickGesture = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
        public PlayerWithName()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty LeftImageProperty =
            BindableProperty.Create(
                propertyName: nameof(LeftImage),
                returnType: typeof(string),
                declaringType: typeof(PlayerWithName),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.TwoWay);
        public string LeftImage
        {
            get
            {
                return (string)GetValue(LeftImageProperty);
            }
            set
            {
                SetValue(LeftImageProperty, value);
            }
        }
        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create(
                propertyName: nameof(TitleText),
                returnType: typeof(string),
                declaringType: typeof(PlayerWithName),
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
        public static readonly BindableProperty SubTitleTextProperty =
            BindableProperty.Create(
                propertyName: nameof(SubTitleText),
                returnType: typeof(string),
                declaringType: typeof(PlayerWithName),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.TwoWay);
        public string SubTitleText
        {
            get
            {
                return (string)GetValue(SubTitleTextProperty);
            }
            set
            {
                SetValue(SubTitleTextProperty, value);
            }
        }


        public static readonly BindableProperty RightIconClickedCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(RightIconClickedCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(PlayerWithName),
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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == LeftImageProperty.PropertyName)
            {
                img.Source = LeftImage;
            }
            else if (propertyName == TitleTextProperty.PropertyName)
            {
                title.Text = TitleText;
            }
            else if (propertyName == SubTitleTextProperty.PropertyName)
            {
                subtitle.Text = SubTitleText;
            }
            else if (propertyName == RightIconClickedCommandProperty.PropertyName)
            {
                rightIconClickGesture.Command = null;
                rightIconClickGesture.Command = RightIconClickedCommand;
            }
        }
    }
}