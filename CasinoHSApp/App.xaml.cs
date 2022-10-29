using CasinoHSApp.Data;
using CasinoHSApp.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CasinoHSApp
{
    public partial class App : Application
    {
        private static MobileAppDatabase mobileAppDatabase;

        public static bool isLandscape { get; set; }

        public static MobileAppDatabase MobileAppDatabase
        {
            get
            {
                if (mobileAppDatabase == null)
                {
                    mobileAppDatabase = new MobileAppDatabase();
                }


                return mobileAppDatabase;
            }
        }


        public App()
        {
            InitializeComponent();

            TheTheme.SetTheme();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;

        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
