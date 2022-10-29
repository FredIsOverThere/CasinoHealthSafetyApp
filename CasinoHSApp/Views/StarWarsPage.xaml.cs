using CasinoHSApp.WebService.Models;
using CasinoHSApp.WebService.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarWarsPage : ContentPage
    {
        //RestService _restService;
        StarWarsViewModel starWarsViewModel;
        //StarWarsRest rest;
        //List<Generic> generic;
        public Command RefreshCommand { get; }

        public StarWarsPage()
        {
            InitializeComponent();
            //rest = new StarWarsRest();
            //generic = new List<Generic>();
            starWarsViewModel = new StarWarsViewModel();



            //CollectionView collectionView = new CollectionView();
            //collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Generics");
            //BindingContext = this;
            //RefreshCommand = new Command(Refreshing);
            //_restService = new RestService();
        }

        //bool isRefreshing;
        //public bool IsRefreshing
        //{
        //    get => isRefreshing;
        //    set
        //    {
        //        isRefreshing = value;
        //        OnPropertyChanged(nameof(IsRefreshing));
        //    }
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.isLandscape == true)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Landscape();
                }
                List<Generic> observableObject = starWarsViewModel.Refresh();
                var grid = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
                collectionView.SetValue(CollectionView.ItemsLayoutProperty, grid);
                _ = starWarsViewModel.Refresh();
            } //do something landscape
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Portrait();
                }
                List<Generic> observableObject = starWarsViewModel.Refresh();
                var grid = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
                collectionView.SetValue(CollectionView.ItemsLayoutProperty, grid);
                _ = starWarsViewModel.Refresh();
            } //do something portrait
        }


        //async void OnButtonClicked(object sender, EventArgs e)
        //{
        //    List<Repository> repositories = await _restService.GetRepositoriesAsync(Constants.GitHubReposEndpoint);
        //    collectionView.ItemsSource = repositories;
        //}
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
        private void Starships_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "Starships";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;


        }
        private void Planets_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "Planets";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;
        }
        private void People_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "People";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;

        }
        private void Vehicles_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "Vehicles";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;

        }
        private void Species_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "Species";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;
        }
        private void Films_Clicked(object sender, EventArgs e)
        {
            collectionView.ItemsSource = null;
            starWarsViewModel.type = "Films";
            List<Generic> observableObject = starWarsViewModel.Refresh();
            //ObservableRangeCollection<Generic> observableObject = starWarsViewModel.Refresh();
            collectionView.ItemsSource = observableObject;
        }

        //private double oldWidth, oldHeight;
        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    if (width != oldWidth || height != oldHeight)
        //    {
        //        oldWidth = width;
        //        oldHeight = height;

        //        if (width > height) 
        //        {
        //            var grid = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
        //            collectionView.SetValue(CollectionView.ItemsLayoutProperty, grid);
        //        return;
        //        } //do something landscape
        //        else {
        //            var grid = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
        //            collectionView.SetValue(CollectionView.ItemsLayoutProperty, grid);
        //        return;
        //        } //do something portrait
        //    }
        //}
    }
}