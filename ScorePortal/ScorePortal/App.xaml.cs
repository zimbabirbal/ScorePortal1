using CloudinaryDotNet;
using ScorePortal.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ScorePortal
{
    public partial class App : Application
    {
        public static Cloudinary CloudinaryInstance;
        private const string _cloudinaryUsername = "zimba";
        private const string _cloudinaryApiKey = "571126387921339";
        private const string _cloudinaryApiSecret = "xE1mWU-4CN3Hg8Qwl81ZUX-MtFo";
        public App()
        {
            InitializeComponent();
            InitializeCloudinary(_cloudinaryUsername, _cloudinaryApiKey, _cloudinaryApiSecret);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTgzMjYzQDMxMzcyZTM0MmUzMGgvcHkzMURNRDhMVzZCUnd6TmhUUVFPalVUNVFIb0ZIWDNiQkRucmNYSWM9");
            MainPage = new Test();
        }

        private void InitializeCloudinary(string cloudinaryUserName, string apiKey, string apiSecret)
        {
            CloudinaryInstance = new Cloudinary(new Account(cloudinaryUserName, apiKey, apiSecret));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
