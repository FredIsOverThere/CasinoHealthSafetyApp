using CasinoHSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CasinoHSApp.Services
{
    public static class DealerService
    {
        public static async Task<IEnumerable<Dealer>> GetDealer()
        {
            //await DatabaseService.Init();

            var dealers = await App.MobileAppDatabase.GetEveryoneAsync();
            //var dealers = await DatabaseService.db.Table<Dealer>().ToListAsync();
            return dealers;
        }

        //public static async Task AddDealer(int staffID, string firstName, string lastName, string department, string position, int dmID)
        //{
        //    await DatabaseService.Init();
        //    var results = new Dealer
        //    {
        //        StaffID = staffID,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Department = department,
        //        Position = position,
        //        DMID = dmID
        //    };
        //    //var id = await DatabaseService.db.InsertAsync(results);
        //    var id = await App.MobileAppDatabase.InsertDealersAsync(results);
        //}
        //public static async Task AddDealer(IEnumerable<Dealer> deal)
        //{
        //    await DatabaseService.Init();
        //    var id = await DatabaseService.db.InsertAsync(deal);
        //}

    }
}
