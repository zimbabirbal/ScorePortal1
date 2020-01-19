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
    public partial class AddPlayerPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddPlayerPopup()
        {
            InitializeComponent();
        }

        private void addPlayer_Clicked(object sender, EventArgs e)
        {

        }
    }
}