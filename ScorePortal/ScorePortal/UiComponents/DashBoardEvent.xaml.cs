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
    public partial class DashBoardEvent : Frame
    {
       
        public DashBoardEvent()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty TitleTextProperty =
           BindableProperty.Create(
               propertyName: nameof(TitleText),
               returnType: typeof(string),
               declaringType: typeof(DashBoardEvent),
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
                declaringType: typeof(DashBoardEvent),
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
        public static readonly BindableProperty BackgroundImageProperty =
            BindableProperty.Create(
                propertyName: nameof(BackgroundImage),
                returnType: typeof(string),
                declaringType: typeof(DashBoardEvent),
                defaultValue: String.Empty,
                defaultBindingMode: BindingMode.TwoWay);
        public string BackgroundImage
        {
            get
            {
                return (string)GetValue(BackgroundImageProperty);
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
            }
        }

       

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleTextProperty.PropertyName)
            {
                titleText.Text = TitleText;
            }
            else if (propertyName == BackgroundImageProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                img.Source = BackgroundImage;
            }
        }
    }
}