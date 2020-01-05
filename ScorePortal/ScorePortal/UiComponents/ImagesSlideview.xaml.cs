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
	public partial class ImagesSlideview : StackLayout
	{
		public ImagesSlideview ()
		{
			InitializeComponent ();
		}
        
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create(
                propertyName: nameof(ItemSource),
                returnType: typeof(ObservableCollection<string>),
                declaringType: typeof(ImagesSlideview),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay);
        public ObservableCollection<string> ItemSource
        {
            get
            {
                return (ObservableCollection<string>)GetValue(ItemSourceProperty);
            }
            set
            {
                SetValue(ItemSourceProperty, value);
            }
        }



        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            
            if (propertyName == ItemSourceProperty.PropertyName)
            {
                //ai.IsVisible = ShowProgressIndicator;
                carouselview.ItemsSource = ItemSource;
            }
        }
    }
}