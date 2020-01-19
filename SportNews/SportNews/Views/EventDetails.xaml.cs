using SportNews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportNews.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetails : ContentPage
	{
		public EventDetails ()
		{
			InitializeComponent ();
            this.BindingContext = new EventDetailsVm();
		}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new Dashboard());
        }
    }
}