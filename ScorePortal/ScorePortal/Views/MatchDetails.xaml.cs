using ScorePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchDetails : ContentPage
	{
		public MatchDetails ()
		{
			InitializeComponent ();
            this.BindingContext = new MatchDetailsVm();
		}
	}
}