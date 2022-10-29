//using DeviceOrientation.Forms.Plugin.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;

//namespace CasinoHSApp.Properties
//{
//    public class OrientationPage : ContentPage
//    {
//        Label orientationLabel;

//        public OrientationPage()
//        {
//            orientationLabel = new Label();
//            orientationLabel.VerticalOptions = LayoutOptions.Center;
//            orientationLabel.HorizontalOptions = LayoutOptions.Center;
//            Content = orientationLabel;


//            var svc = DependencyService.Get<IDeviceOrientationService>();

//            if(svc!=null) RecongfigureUI(svc.GetOrientation());


//        }

//            protected override void OnAppearing()
//            {
//                MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
//                        {
//                            ReconfigureUI(message.Orientation);
//                        });
//                base.OnAppearing();

//            }

//            private void ReconfigureUI(DeviceOrientations orientation)
//            {
//                throw new NotImplementedException();
//            }


//            protected override void OnDisappearing()
//            {
//                MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);

//                base.OnDisappearing();

//            }



//    }
//}
