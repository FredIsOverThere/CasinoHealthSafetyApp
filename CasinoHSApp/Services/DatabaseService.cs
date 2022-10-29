using CasinoHSApp.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CasinoHSApp.Services
{
    public class DatabaseService
    {

        public static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            if (db != null) return;

            //  Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Dealer>();
            await db.CreateTableAsync<Roster>();
            await db.CreateTableAsync<Skills>();
            await db.CreateTableAsync<Answers>();

        }
    }
}
