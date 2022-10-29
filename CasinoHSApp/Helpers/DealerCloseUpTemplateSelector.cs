using CasinoHSApp.Models;
using Xamarin.Forms;

namespace CasinoHSApp.Helpers
{
    public class DealerCloseUpTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PKTemplate { get; set; }
        public DataTemplate BATemplate { get; set; }
        public DataTemplate BJTemplate { get; set; }
        public DataTemplate ARTemplate { get; set; }
        public DataTemplate PKNATemplate { get; set; }
        public DataTemplate BANATemplate { get; set; }
        public DataTemplate BJNATemplate { get; set; }
        public DataTemplate ARNATemplate { get; set; }
        public DataTemplate PersonalTemplate { get; set; }
        public DataTemplate NullTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var url = (DealerCloseUp)item;

            switch (url)
            {

                case DealerCloseUp a when a.GameType.Contains("Baccarat") && a.WasAssessed: return BATemplate;
                case DealerCloseUp a when a.GameType.Contains("BlackJack") && a.WasAssessed: return BJTemplate;
                case DealerCloseUp a when a.GameType.Contains("Poker") && a.WasAssessed: return PKTemplate;
                case DealerCloseUp a when a.GameType.Contains("American Roulette") && a.WasAssessed: return ARTemplate;
                case DealerCloseUp a when a.GameType.Contains("Baccarat") && a.WasAssessed == false: return BANATemplate;
                case DealerCloseUp a when a.GameType.Contains("BlackJack") && a.WasAssessed == false: return BJNATemplate;
                case DealerCloseUp a when a.GameType.Contains("Poker") && a.WasAssessed == false: return PKNATemplate;
                case DealerCloseUp a when a.GameType.Contains("American Roulette") && a.WasAssessed == false: return ARNATemplate;
                case DealerCloseUp a when a.GameType.Contains("Name"): return PersonalTemplate;
                default: return NullTemplate;

            }


        }
    }
}
