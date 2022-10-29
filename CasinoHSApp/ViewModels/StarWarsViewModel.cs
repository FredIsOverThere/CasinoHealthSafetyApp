//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MvvmHelpers;
//using MvvmHelpers.Commands;
//using StarWarsAPI;
//using StarWarsAPI.Model;

//namespace CasinoHSApp.ViewModels
//{
//    public class StarWarsViewModel : BaseViewModel
//    {
//        public StarWarsEntityList<People> Peoples;
//        public StarWarsEntityList<Planet> Planets;
//        public StarWarsEntityList<Specie> Species;
//        public StarWarsEntityList<Starship> Starships;
//        public StarWarsEntityList<Film> Films;
//        public StarWarsEntityList<Vehicle> Vehicles;
//        public AsyncCommand RefreshCommand { get; }


//        public StarWarsViewModel()
//        {
//            var api = new StarWarsAPIClient();
//            Starships = new StarWarsEntityList<Starship>();
//            Peoples = new StarWarsEntityList<People>();
//            Planets = new StarWarsEntityList<Planet>();
//            Species = new StarWarsEntityList<Specie>();
//            Films = new StarWarsEntityList<Film>();
//            Vehicles = new StarWarsEntityList<Vehicle>();
//            RefreshCommand = new AsyncCommand(Refresh);
//            Vehicles = api.GetAllVehicle().Result;
//            Starships = api.GetAllStarship().Result;
//            Peoples = api.GetAllPeople().Result;
//            Planets = api.GetAllPlanet().Result;
//            Species = api.GetAllSpecie().Result;
//            Films = api.GetAllFilm().Result;

//        }

//        public List<string> GetStarship()
//        {
//            List<string> ships;
//            string[] star = null;
//            int count = 0;
//            foreach (var v in Starships.results)
//            {
//                star[count] = (v.name.ToString());
//                count++;
//            }
//            ships = star.ToList();
//            return ships;

//        }
//        //public async void GetPeople()
//        //{

//        //}
//        //public async void GetPlanet()
//        //{

//        //}
//        //public async void GetSpecie()
//        //{

//        //}

//        //public async void GetFilm()
//        //{

//        //}
//        //public async void GetVehicle()
//        //{

//        //}
//        public async Task Refresh()
//        {
//            IsBusy = true;

//            await Task.Delay(2000);

//            //var dealers = await DealerService.GetDealer();
//            //var dealers = await App.MobileAppDatabase.GetDealersAsync();
//            //Dealer.AddRange(dealers);

//            IsBusy = false;
//        }
//    }

//}
