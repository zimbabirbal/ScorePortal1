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
        private const string _cloudinaryUsername = "";
        private const string _cloudinaryApiKey = "";
        private const string _cloudinaryApiSecret = "";
        public App()
        {
            InitializeComponent();
            InitializeCloudinary(_cloudinaryUsername, _cloudinaryApiKey, _cloudinaryApiSecret);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTgzMjYzQDMxMzcyZTM0MmUzMGgvcHkzMURNRDhMVzZCUnd6TmhUUVFPalVUNVFIb0ZIWDNiQkRucmNYSWM9");
            MainPage = new HomePage();
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
