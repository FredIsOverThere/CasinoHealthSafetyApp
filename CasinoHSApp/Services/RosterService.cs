using CasinoHSApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace CasinoHSApp.Services
{
    public static class RosterService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null) return;

            //  Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Roster>();

        }



        public static async Task<IEnumerable<Roster>> GetRoster()
        {
            await Init();

            var answers = await db.Table<Roster>().ToListAsync();
            return answers;
        }
    }
}
