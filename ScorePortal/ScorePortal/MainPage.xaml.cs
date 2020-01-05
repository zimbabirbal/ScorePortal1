using ScorePortal.ViewModel;
using ScorePortal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScorePortal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new DashboardVm();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new EventDetails());
        }

        private async void ListView_ItemTapped(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new EventDetails());
        }
    }
}
