using CasinoHSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasinoHSApp.Services
{
    public class SkillsService
    {
        public static async Task<IEnumerable<Skills>> GetDealerSkills()
        {
            // await Init();

            var skills = await App.MobileAppDatabase.GetSkillsAsync();
            return skills;
        }

        public static async Task AddSkills(int staffID, int roulette, int baccarat, int blackjack, int poker)
        {
            await DatabaseService.Init();
            var results = new Skills
            {
                StaffID = staffID,
                AmericanRoulette = roulette,
                Baccarat = baccarat,
                BlackJack = blackjack,
                Poker = poker
            };
            var id = await DatabaseService.db.InsertAsync(results);
        }
    }
}
