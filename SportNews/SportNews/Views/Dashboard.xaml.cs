using SportNews.ViewModel;
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
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            this.BindingContext = new DashboardVm();
            //Shell.Current.GoToAsync("catP");
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddTeam(false,null));
        }

        private async void ListView_ItemTapped(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddTeam(false,null));
        }
    }
}