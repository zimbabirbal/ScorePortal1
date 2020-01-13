using ScorePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScorePortal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        public static List<TestMan> TestMen { get; set; }
        public Test()
        {
            InitializeComponent();
            this.BindingContext = new TestVm();
            TestMen = new List<TestMan>();
            TestMen.Add(new TestMan { Id = 1, Name = "Birbal", Practice = "sfsfsdfs" });
            TestMen.Add(new TestMan { Id = 2, Name = "Birbal1", Practice = "sfsfsdfs" });
            TestMen.Add(new TestMan { Id = 3, Name = "Birbal2", Practice = "sfsfsdfs" });
            TestMen.Add(new TestMan { Id = 4, Name = "Birbal3", Practice = "sfsfsdfs" });
            TestMen.Add(new TestMan { Id = 5, Name = "Birbal4", Practice = "sfsfsdfs" });
            lst.ItemsSource = TestMen;
        }
        

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            
            TestMan myObject = (TestMan)args.Parameter;
        }
    }
    public class TestMan
    {
        public string Name { get; set; }
        public string Practice { get; set; }
        public int Id { get; set; }
    }
}