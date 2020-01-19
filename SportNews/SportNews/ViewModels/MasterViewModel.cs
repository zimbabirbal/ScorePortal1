using SportNews.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportNews.ViewModels
{
    public class MasterViewModel
    {
        public MasterViewModel()
        {

        }
        public ICommand OnAddTournamentTapped => new Command(async async =>
        {
            
        });
    }
}
