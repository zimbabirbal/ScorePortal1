using ScorePortal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScorePortal.ViewModels
{
    public class TestVm
    {
        public TestVm()
        {
           
        }
        public ICommand TappedCommand => new Command(async (item) =>
        {
            var curItem = item as TestMan;
            var indexC = Test.TestMen.IndexOf(curItem);
            //var clickedIndex = CurrentlySelectedItems.IndexOf(curAction);
            //curAction = CurrentlySelectedItems[clickedIndex];
            //ReCalculateActionPositions();
            //navParams.UserClickedAction = curAction;
            //await GoToAdaptSelection();
        });

    }
}
