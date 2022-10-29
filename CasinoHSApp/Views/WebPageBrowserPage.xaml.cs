using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPageBrowserPage : ContentPage
    {
        public string html;
        public HtmlWebViewSource HTMLSource;
        public WebPageBrowserPage()
        {
            InitializeComponent();
            HTMLSource = new HtmlWebViewSource();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Browser.Source = null;
            //WebView = Browser;
            HTMLSource.Html = html;
            Browser.Source = HTMLSource;


            //GameName.Text = gameName;
            if (App.isLandscape == true)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Landscape();
                }
            } //do something landscape
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Portrait();
                }
            } //do something portrait


        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}