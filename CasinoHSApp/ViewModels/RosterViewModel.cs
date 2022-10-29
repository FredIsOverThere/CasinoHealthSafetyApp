using CasinoHSApp.Models;
using CasinoHSApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace CasinoHSApp.ViewModels
{
    public class RosterViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Roster> Roster { get; set; }
        public ObservableRangeCollection<Grouping<string, Roster>> RosterGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }

        public RosterViewModel()
        {
            Title = "List of Dealers on the Roster";
            Roster = new ObservableRangeCollection<Roster>();
            RosterGroups = new ObservableRangeCollection<Grouping<string, Roster>>();

        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Roster.Clear();

            var rosters = await RosterService.GetRoster();

            Roster.AddRange(rosters);

            IsBusy = false;
        }
    }
}
