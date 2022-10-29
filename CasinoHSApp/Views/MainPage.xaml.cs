using CasinoHSApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage/DealerResultsPage", typeof(DealerResultPage));

            Routing.RegisterRoute("MainPage/DealerCloseUpPage", typeof(DealerCloseUpPage));

            Routing.RegisterRoute("MainPage/QuestionsPage", typeof(QuestionsPage));

            Routing.RegisterRoute("MainPage/DealerSearchPage", typeof(DealerSearchPage));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

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
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Login)}");
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void Button_Clicked_CP(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new DealerResultPage());
            await Shell.Current.GoToAsync($"//{nameof(DealerResultPage)}");
        }
        private async void Button_Clicked_SP(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new DealerResultPage());
            await Shell.Current.GoToAsync($"//{nameof(DealerSearchPage)}");
        }
        private void Button_Clicked_DS(object sender, EventArgs e)
        {
            //HealthSafetyQuestionsViewModel healthSafetyQuestionsViewModel = new HealthSafetyQuestionsViewModel();

            //string xsltName = "thirteenQuestionsStyle.xslt";
            //string tempXMLPath = Path.Combine(FileSystem.AppDataDirectory, "temp.xml");
            //string htmlName = "Anica_Hoxey_AR_05-01-2022.html";
            //healthSafetyQuestionsViewModel.TransformXML(xsltName, tempXMLPath, htmlName);
        }

        private async void Button_Clicked_IC(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
        }
    }
}
