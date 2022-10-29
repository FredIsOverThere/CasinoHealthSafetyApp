using CasinoHSApp.WebService.Models;

using Xamarin.Forms;

namespace CasinoHSApp.WebService.Helpers
{
    public class StarWarsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PeopleTemplate { get; set; }
        public DataTemplate FilmTemplate { get; set; }
        public DataTemplate SpeciesTemplate { get; set; }
        public DataTemplate PlanetTemplate { get; set; }
        public DataTemplate VehicleTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var url = (Generic)item;

            switch (url.URL)
            {
                case string a when a.Contains("https://swapi.dev/api/people"): return PeopleTemplate;
                case string a when a.Contains("https://swapi.dev/api/film"): return FilmTemplate;
                case string b when b.Contains("https://swapi.dev/api/species"): return SpeciesTemplate;
                case string b when b.Contains("https://swapi.dev/api/planet"): return PlanetTemplate;
                default: return VehicleTemplate;




            }


        }
    }

}

