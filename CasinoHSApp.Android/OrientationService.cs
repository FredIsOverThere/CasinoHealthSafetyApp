using Android.App;
using Android.Content.PM;
using CasinoHSApp.Droid;
using System;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OrientationService))]
namespace CasinoHSApp.Droid
{
    public class OrientationService : IOrientationService
    {
        [Obsolete]
        public void Landscape()
        {
            ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Landscape;
        }

        [Obsolete]
        public void Portrait()
        {
            ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Portrait;
        }

    }
}