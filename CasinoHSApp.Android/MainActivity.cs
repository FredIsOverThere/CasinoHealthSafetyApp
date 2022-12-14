
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace CasinoHSApp.Droid
{
    [Activity(Label = "CasinoHSApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize
        )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //DeviceOrientationImplementation.Init();
            LoadApplication(new App());
        }

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    global::Xamarin.Forms.Forms.Init(this, bundle);
        //    MessagingCenter.Subscribe&amp; lt; MyPage&amp;gt; (this,"setLandscape",sender = &amp; gt;
        //    {
        //        RequestedOrientation = ScreenOrientation.Landscape;
        //    });
        //    MessagingCenter.Subscribe & amp; lt; MyPage & amp; gt; (this, "setPortrait", sender = &amp; gt;
        //    {
        //        RequestedOrientation = ScreenOrientation.Portrait;
        //    });
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        //public override void OnConfigurationChanged(global::Android.Content.Res.Configuration newConfig)
        //{
        //    base.OnConfigurationChanged(newConfig);
        //    DeviceOrientationImplementation.NotifyOrientationChange(newConfig);
        //}


    }

}