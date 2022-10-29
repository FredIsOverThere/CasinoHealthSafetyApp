using CasinoHSApp.Models;
using CasinoHSApp.ViewModels;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DealerSearchPage : ContentPage
    {
        public DealerSearchPage()
        {
            InitializeComponent();
        }

        //private async void Submit_Clicked(object sender, EventArgs e)
        //{
            //var indexTS = TypeSelect.SelectedIndex;
            //var listTS = TypeSelect.ItemsSource;
            //var indexTeam = TeamSelect.SelectedIndex;
            //var listTeam = TeamSelect.ItemsSource;
            //string typeSelect = (string)listTS[indexTS];
            //string teamSelect = (string)listTeam[indexTeam];
            //string searchText = SearchInput.Text;

            //if (typeSelect != "First Name" ||typeSelect != "Staff ID" ||typeSelect != "Last Name" )
            //{
            //    await DisplayAlert("Alert", "Please select search criteria!", "OK");
            //}

            //if (teamSelect != "Main" ||teamSelect != "Premium" )
            //{
            //    await DisplayAlert("Alert", "Please select a team!", "OK");
            //}
            //CollectionView collectionView = new CollectionView();
            //List<Dealer> dealers = new List<Dealer>();
            //if (typeSelect == "First Name")
            //{
            //    dealers = await App.MobileAppDatabase.SearchDealersFNameAsync(searchText, teamSelect);
            //}
            //if (typeSelect == "Last Name")
            //{
            //    dealers = await App.MobileAppDatabase.SearchDealersLNameAsync(searchText, teamSelect);
            //}
            //if (typeSelect == "Staff ID")
            //{
            //    dealers = await App.MobileAppDatabase.SearchDealersStaffIDAsync(searchText, teamSelect);
            //}

            //if (dealers != null)
            //{
            //    await Shell.Current.GoToAsync($"//{nameof(DealerResultPage)}?searchDealers={dealers}");
            //}
        //}
        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

            //private async void Button_Clicked(object sender, EventArgs e)
            //{
            //    await;
            //    var b = new DealerDisplayViewModel();
            //    b.Refresher();
            //    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            //}
        }
    }