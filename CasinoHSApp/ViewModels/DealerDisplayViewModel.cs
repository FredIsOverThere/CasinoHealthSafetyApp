using CasinoHSApp.Models;
using CasinoHSApp.Views;
using CasinoHSApp.Data;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Windows.Input;

namespace CasinoHSApp.ViewModels
{
    public class DealerDisplayViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Dealer> Dealer { get; set; }
        public ObservableRangeCollection<Grouping<string, Dealer>> DealerGroups { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand RefreshAllDealersCommand { get; }
        public AsyncCommand RefreshEveryoneCommand { get; }
        public AsyncCommand RefreshTeamACommand { get; }
        public AsyncCommand RefreshTeamBCommand { get; }
        public string firstName;
        public string lastName;
        public string staffID;
        public SkillsViewModel skillsViewModel;
        public AsyncCommand<object> SelectedCommand { get; }
        public IList<TeamPicker> TeamPickers { get { return PickerStrings.TeamPickers; } }
        public IList<SearchPicker> SearchPickers { get { return PickerStrings.SearchPickers; } }
        public AsyncCommand SearchSubmitCommand { get; }
        public AsyncCommand SearchRefreshCommand { get; }
        public Query QueryModel { get; set; }
        public DealerDisplayViewModel()
        {
            Title = "List of Dealers";
            Dealer = new ObservableRangeCollection<Dealer>();
            DealerGroups = new ObservableRangeCollection<Grouping<string, Dealer>>();
            // AddCommand = new AsyncCommand(Add);
            SelectedCommand = new AsyncCommand<object>(Selected);
            RefreshCommand = new AsyncCommand(Refresh);
            RefreshAllDealersCommand = new AsyncCommand(RefreshAllDealers);
            RefreshEveryoneCommand = new AsyncCommand(RefreshEveryone);
            RefreshTeamACommand = new AsyncCommand(RefreshTeamADealers);
            RefreshTeamBCommand = new AsyncCommand(RefreshTeamBDealers);
            QueryModel = new Query();
            SearchSubmitCommand = new AsyncCommand(SearchDealer);
            SearchRefreshCommand = new AsyncCommand(RefreshSearch);

            // DealerGroups.Add(new Grouping<string, Dealer>("MAIN", new[] { Dealer[2] }));

        }
        //Dealer previousDealer;


        Dealer selectedDealer;
        public Dealer SelectedDealer
        {
            get => selectedDealer;

            set => SetProperty(ref selectedDealer, value);
        }


        async Task Selected(object args)
        {
            Dealer dealer = args as Dealer;
            if (dealer == null)
                return;

            SelectedDealer = null;

            await Application.Current.MainPage.DisplayAlert("Selected", dealer.FirstName, "OK");

        }

        SearchPicker selectedCriteria;
        public SearchPicker SelectedCriteria
        {
            get { return selectedCriteria; }
            set
            {
                if (selectedCriteria != value)
                {
                    selectedCriteria = value;
                    QueryModel.SearchCriteria = selectedCriteria;
                    OnPropertyChanged();
                }
            }
        }
        TeamPicker selectedTeam;
        public TeamPicker SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (selectedTeam != value)
                {
                    selectedTeam = value;
                    QueryModel.TeamPicker = selectedTeam;
                    OnPropertyChanged();
                }
            }
        }

        SearchInput selectedInput;
        public SearchInput SelectedInput
        {
            get { return selectedInput; }
            set
            {
                if (selectedInput != value)
                {
                    selectedInput = value;
                    QueryModel.Input = selectedInput.ToString();
                    OnPropertyChanged();
                }
            }
        }

        public string SearchInput { get; set; }
        public async Task SearchDealer()
        {
            string typeSelect;
            string teamSelect;
            string searchText;
            
            try
            {
                typeSelect = QueryModel.SearchCriteria.SearchCriteria;
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please select search criteria!", "OK");
                return;
            }
            try
            {
                teamSelect = QueryModel.TeamPicker.Team;
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please select a team!", "OK");
                return;
            }
                searchText = string.Concat("%", SearchInput, "%");
            //string searchText = string.Concat("%",QueryModel.Input,"%");

            
            if (teamSelect == "Main Floor")
            {
                teamSelect = "MAIN";
            }
            
            if (teamSelect == "Premium")
            {
                teamSelect = "PREMIUM";
            }

            List<Dealer> dealers = new List<Dealer>();
            DealerSearchResultPage dealerSearchResultPage = new DealerSearchResultPage();
            if (typeSelect == "First Name")
            {
                dealerSearchResultPage.searchDealers = await App.MobileAppDatabase.SearchDealersFNameAsync(searchText, teamSelect);
            }
            if (typeSelect == "Last Name")
            {
                //IsBusy = true;

                //await Task.Delay(2000);
                dealerSearchResultPage.searchDealers = await App.MobileAppDatabase.SearchDealersLNameAsync(searchText, teamSelect);
                //await Shell.Current.GoToAsync($"//{nameof(DealerResultPage)}?searchDealers={dealers}");
                //Dealer.Clear();
                //Dealer.AddRange(dealers);
                //IsBusy = false;
            }
            if (typeSelect == "Staff ID")
            {
                //IsBusy = true;

                //await Task.Delay(2000);
                dealerSearchResultPage.searchDealers = await App.MobileAppDatabase.SearchDealersStaffIDAsync(searchText, teamSelect);
                //await Shell.Current.GoToAsync($"//{nameof(DealerResultPage)}?searchDealers={dealers}");
                //Dealer.Clear();
                //Dealer.AddRange(dealers);
                //IsBusy = false;
            }
            await App.Current.MainPage.Navigation.PushAsync(dealerSearchResultPage);
            //if (dealers != null)
            //{
            // await RefreshSearch();

            //}
        }


        async Task QuestionAysnc()
        {
            bool answer = Application.Current.MainPage.DisplayAlert("Dealer Selected", string.Concat(firstName, ", has been selected would you like to see their skills?"), "Yes", "No").Result;



            if (answer == true)
            {
                skillsViewModel = new SkillsViewModel();
                skillsViewModel.staffID = int.Parse(staffID);
                await skillsViewModel.DoTheThing();
                DealerCloseUpPage dealerCloseUpPage = new DealerCloseUpPage
                {
                    firstName = firstName,
                    skillsViewModel = skillsViewModel,
                    lastName = lastName,
                    staffID = staffID
                };
                dealerCloseUpPage.UpPage = dealerCloseUpPage;

                //await AppShell.Current.GoToAsync(dealerCloseUpPage);
                await App.Current.MainPage.Navigation.PushAsync(dealerCloseUpPage);

            }
            else return;


        }
        //async Task Add()
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    var resourceName = "staff_list.csv";

        //    string csvPath;
        //    Stream stream;
        //    using (stream = assembly.GetManifestResourceStream(resourceName))
        //    using (StreamReader reader = new StreamReader(stream))
        //    {
        //        csvPath = reader.ReadToEnd();
        //    }


        //    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        //    {
        //        Delimiter = "|",
        //    };
        //    //StreamReader readerCSV;
        //    using (StreamReader readerCSV = new StreamReader(csvPath))
        //    {
        //        using (var csv = new CsvReader(readerCSV, config))
        //        {
        //            var records = csv.GetRecords<Dealer>().ToList();

        //            foreach (IEnumerable<Dealer> deal in records)
        //            {
        //               await DealerService.AddDealer(deal);
        //            }
        //        }

        //    }

        //    await Refresh();
        //}
        public void AwaitlessRefresh()
        {
            IsBusy = true;


            Dealer.Clear();

            IsBusy = false;
        }
        public async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            var dealers = await App.MobileAppDatabase.GetAllDealersAsync();
            Dealer.AddRange(dealers);

            IsBusy = false;
        }
        public async Task RefreshEveryone()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            var dealers = await App.MobileAppDatabase.GetEveryoneAsync();
            Dealer.AddRange(dealers);

            IsBusy = false;
        }
        public async Task RefreshAllDealers()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            var dealers = await App.MobileAppDatabase.GetAllDealersAsync();
            Dealer.AddRange(dealers);

            IsBusy = false;
        }
        public async Task RefreshTeamADealers()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            var dealers = await App.MobileAppDatabase.GetDealersTeamAsync("MAIN");
            Dealer.AddRange(dealers);

            IsBusy = false;
        }
        public async Task RefreshTeamBDealers()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            var dealers = await App.MobileAppDatabase.GetDealersTeamAsync("PREMIUM");
            Dealer.AddRange(dealers);

            IsBusy = false;
        }
        public async Task RefreshSearch()
        {
            IsBusy = true;

            await Task.Delay(2000);
            ObservableRangeCollection<Dealer> temp = new ObservableRangeCollection<Dealer>();
            temp.AddRange(Dealer);
            Dealer.Clear();
            //var dealers = await DealerService.GetDealer();
            Dealer.AddRange(temp);

            IsBusy = false;
        }

    }
}
