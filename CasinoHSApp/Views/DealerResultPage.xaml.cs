using CasinoHSApp.Models;
using CasinoHSApp.ViewModels;
using MvvmHelpers;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DealerResultPage : ContentPage
    {
        
        public DealerResultPage()
        {
            InitializeComponent();
        }

        public SkillsViewModel skillsViewModel;
        public Dealer selectedDealer = new Dealer();
        public bool selection = false;
        public string firstName;
        public string lastName;
        public string staffID;

 

        //private async void SendON()
        //{
        //        DealerCloseUpPage dealerCloseUpPage = new DealerCloseUpPage();
        //        dealerCloseUpPage.firstName = selectedDealer.FirstName;
        //        dealerCloseUpPage.lastName = selectedDealer.LastName;
        //        dealerCloseUpPage.staffID = selectedDealer.StaffID.ToString();
        //        await Navigation.PushAsync(dealerCloseUpPage);

        //}

        //private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    selectedDealer = ((ListView)sender).SelectedItem as Dealer;
        //    if (selectedDealer == null)
        //        return;

        //    firstName = selectedDealer.FirstName;
        //    lastName = selectedDealer.LastName;
        //    staffID = selectedDealer.StaffID.ToString();
        //    bool answer = await DisplayAlert("Dealer Selected", string.Concat(selectedDealer.FirstName, ", has been selected would you like to see their skills?"), "Yes", "No");
        //    if (answer == true)
        //    {

        //        skillsViewModel = new SkillsViewModel();
        //        skillsViewModel.staffID = int.Parse(staffID);
        //        await skillsViewModel.DoTheThing();
        //        DealerCloseUpPage dealerCloseUpPage = new DealerCloseUpPage();
        //        dealerCloseUpPage.firstName = firstName;
        //        dealerCloseUpPage.skillsViewModel = skillsViewModel;
        //        dealerCloseUpPage.lastName = lastName;
        //        dealerCloseUpPage.staffID = staffID;
        //        dealerCloseUpPage.UpPage = dealerCloseUpPage;

        //        await Navigation.PushAsync(dealerCloseUpPage);
        //    }
        //    else return;
        //}

        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.isLandscape == true)
            {
                //if (Device.RuntimePlatform == Device.Android)
                //{
                //    DependencyService.Get<IOrientationService>().Landscape();
                //}
                var grid = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
                CollectionViewDealerResults.SetValue(CollectionView.ItemsLayoutProperty, grid);
                DealerDisplayViewModel dealerDisplayViewModel = new DealerDisplayViewModel();
                dealerDisplayViewModel.AwaitlessRefresh();
            } //do something landscape
            else
            {
                //if (Device.RuntimePlatform == Device.Android)
                //{
                //    DependencyService.Get<IOrientationService>().Portrait();
                //}
                var grid = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
                CollectionViewDealerResults.SetValue(CollectionView.ItemsLayoutProperty, grid);
                DealerDisplayViewModel dealerDisplayViewModel = new DealerDisplayViewModel();
                dealerDisplayViewModel.AwaitlessRefresh();
            } //do something portrait
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    var test = await DealerDisplayViewModel.Refresh();

        //}
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDealer = ((CollectionView)sender).SelectedItem as Dealer;
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection, selectedDealer);
        }

        async void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems, Dealer selectedDealer)
        {

            if (selectedDealer == null)
                return;

            firstName = selectedDealer.FirstName;
            lastName = selectedDealer.LastName;
            staffID = selectedDealer.StaffID.ToString();
            bool answer = await DisplayAlert("Dealer Selected", string.Concat(selectedDealer.FirstName, ", has been selected would you like to see their skills?"), "Yes", "No");
            if (answer == true)
            {

                skillsViewModel = new SkillsViewModel();
                skillsViewModel.staffID = int.Parse(staffID);
                skillsViewModel.firstName = firstName;
                skillsViewModel.lastName = lastName;
                await skillsViewModel.DoTheThing();
                DealerCloseUpPage dealerCloseUpPage = new DealerCloseUpPage
                {
                    firstName = firstName,
                    skillsViewModel = skillsViewModel,
                    lastName = lastName,
                    staffID = staffID
                };
                dealerCloseUpPage.UpPage = dealerCloseUpPage;
                dealerCloseUpPage.CloseUpRefresh();
                //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                await Navigation.PushModalAsync(dealerCloseUpPage);

            }

            else return;

            // string previous = (previousSelectedItems.FirstOrDefault() as Dealer)?.FirstName;
            // string current = (currentSelectedItems.FirstOrDefault() as Dealer)?.FirstName;
            //string previousSelectedItemLabel = string.IsNullOrWhiteSpace(previous) ? "[none]" : previous;
            //string currentSelectedItemLabel = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
        }


        //private async void Back_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PopModalAsync();
        //}


    }


    //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

}