using CasinoHSApp.WebService.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasinoHSApp.WebService.ViewModels
{
    public class StarWarsViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Generic> Generics { get; set; }
        public List<Generic> generic { get; set; }

        public Command RefreshCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }
        public string type;
        StarWarsRest rest;

        public StarWarsViewModel()
        {

            Title = "Star Wars";

            Generics = new ObservableRangeCollection<Generic>();

            rest = new StarWarsRest();
            generic = new List<Generic>();
            LoadMore();

            //RefreshCommand = new Command(Refresh);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);

        }



        public List<Generic> Refresh()
        {
            IsBusy = true;

            Task.Delay(2000);

            generic.Clear();
            //Clear();
            if (type != null)
            {
                LoadMore();

            }

            IsBusy = false;
            return generic;
        }

        void LoadMore()
        {
            if (type == null) return;

            switch (type)
            {
                case "Starships":
                    GetStarShipsSW();
                    break;
                case "Planets":
                    GetPlanetsSW();
                    break;
                case "People":
                    GetPeopleSW();
                    break;
                case "Films":
                    GetFilmsSW();
                    break;
                case "Vehicles":
                    GetVehiclesSW();
                    break;
                case "Species":
                    GetSpeciesSW();
                    break;
            }

        }




        void GetStarShipsSW()
        {
            List<Starship> starship = rest.GetAllStarships().results;
            foreach (Starship ships in starship)
            {
                generic.Add(new Generic()
                {
                    Generic1 = ships.name,
                    Generic2 = ships.model,
                    Generic3 = ships.vehicle_class,
                    Generic4 = ships.cost_in_credits,
                    Generic5 = ships.crew,
                    Generic6 = ships.length,
                    URL = ships.url
                });
            }
            Generics.AddRange(generic);

        }

        void GetPlanetsSW()
        {
            List<Planet> planet = rest.GetAllPlanets().results;

            foreach (Planet sphere in planet)
            {
                generic.Add(new Generic()
                {
                    Generic1 = sphere.name,
                    Generic2 = sphere.population,
                    Generic3 = sphere.diameter,
                    Generic4 = sphere.rotation_period,
                    Generic5 = sphere.orbital_period,
                    Generic6 = sphere.gravity,
                    URL = sphere.url
                });


            }
            Generics.AddRange(generic);
        }

        void GetPeopleSW()
        {
            List<People> people = rest.GetAllPeople().results;

            foreach (People person in people)
            {
                generic.Add(new Generic()
                {
                    Generic1 = person.name,
                    Generic2 = person.birth_year,
                    Generic3 = person.gender,
                    Generic4 = person.homeworld,
                    Generic5 = person.height,
                    Generic6 = person.mass,
                    URL = person.url
                });
            }
            Generics.AddRange(generic);
        }
        void GetVehiclesSW()
        {
            List<Vehicle> vehicle = rest.GetAllVehicles().results;

            foreach (Vehicle transport in vehicle)
            {
                generic.Add(new Generic()
                {
                    Generic1 = transport.name,
                    Generic2 = transport.model,
                    Generic3 = transport.vehicle_class,
                    Generic4 = transport.cost_in_credits,
                    Generic5 = transport.crew,
                    Generic6 = transport.length,
                    URL = transport.url
                });

                ;
            }
            Generics.AddRange(generic);
        }




        void GetSpeciesSW()
        {
            List<Specie> specie = rest.GetAllSpecies().results;

            foreach (Specie alien in specie)
            {
                generic.Add(new Generic()
                {
                    Generic1 = alien.name,
                    Generic2 = alien.classification,
                    Generic3 = alien.designation,
                    Generic4 = alien.average_lifespane,
                    Generic5 = alien.language,
                    Generic6 = alien.homeworld,
                    URL = alien.url
                });

            }
            Generics.AddRange(generic);
        }


        void GetFilmsSW()
        {

            List<Film> film = rest.GetAllFilms().results;

            foreach (Film movie in film)
            {

                generic.Add(new Generic()
                {
                    Generic1 = movie.title,
                    Generic2 = movie.episode_id.ToString(),
                    Generic3 = movie.opening_crawl,
                    Generic4 = movie.director,
                    Generic5 = movie.producer,
                    Generic6 = movie.url,
                    URL = movie.url
                });

                //generic.Add(genericObject);
            }
            Generics.AddRange(generic);

        }




        void DelayLoadMore()
        {


            LoadMore();
        }


        void Clear()
        {
            Generics.Clear();
        }

    }

}

