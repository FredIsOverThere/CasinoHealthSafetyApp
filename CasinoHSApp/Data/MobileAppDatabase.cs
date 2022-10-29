using CasinoHSApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CasinoHSApp.Data
{
    public class MobileAppDatabase
    {
        public static SQLiteAsyncConnection Database;

        public MobileAppDatabase()
        {
            string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MobileAppDatabase.db");

            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedDatabaseStream = assembly.GetManifestResourceStream("CasinoHSApp.MobileAppDatabase.db");

            if (!File.Exists(DatabasePath))
            {
                FileStream filestreamToWrite = File.Create(DatabasePath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(filestreamToWrite);
                filestreamToWrite.Close();
            }

            Database = new SQLiteAsyncConnection(DatabasePath);
            //Database.CreateTableAsync<Dealer>().Wait();
        }

        public Task<List<Dealer>> GetEveryoneAsync()
        {
            return Database.Table<Dealer>().ToListAsync();

        }

        //public void InsertDealersAsync(IEnumerable<Dealer> dealers)
        //{
        //    Database.Table<Dealer>.InsertAsync(dealers);

        //}

        public Task<List<Skills>> GetSkillsAsync()
        {
            return Database.Table<Skills>().ToListAsync();

        }

        public Task<List<Skills>> GetSpecificSkillAsync(int staffID)
        {

            var list = Database.QueryAsync<Skills>("select * from skill_code_list where staff_id=?", staffID);
            return list;
        }

        public Task<List<Dealer>> GetAllDealersAsync()
        {

            var list = Database.QueryAsync<Dealer>("select * from staff_list where position='Dealer'");
            return list;
        }

        public Task<List<Dealer>> GetDealersTeamAsync(string team)
        {

            //string query = "select * from staff_list where position="Dealer"" AND department=" + team;
            var list = Database.QueryAsync<Dealer>("select * from staff_list where position='Dealer' AND department=?", team);
            //var list = Database.QueryAsync<Dealer>(query);
            return list;
        }
        public Task<List<Dealer>> SearchDealersFNameAsync(string fName,string team)
        {
            string query = "SELECT * FROM staff_list WHERE position='Dealer' AND department='" + team + "' AND first_name LIKE '" + fName + "'";
            //var list = Database.QueryAsync<Dealer>("SELECT * FROM staff_list WHERE position='Dealer' AND department=? AND first_name LIKE? ", team,fName);
            var list = Database.QueryAsync<Dealer>(query);
            return list;
        }
        public Task<List<Dealer>> SearchDealersLNameAsync(string lName, string team)
        {

            var list = Database.QueryAsync<Dealer>("select * from staff_list where position='Dealer' AND last_name LIKE? AND department=?", lName, team);
            return list;
        }
        public Task<List<Dealer>> SearchDealersStaffIDAsync(string staffID, string team)
        {

            var list = Database.QueryAsync<Dealer>("select * from staff_list where position='Dealer' AND staff_id LIKE? AND department=?", staffID, team);
            return list;
        }
        public Task<List<AssessmentLog>> GetLastAssessedAsync(int staffID)
        {
            //var today = DateTime.Today.ToString("yyyy-MM-dd");
            //var yearAgo = DateTime.Today.AddDays(-365).ToString("yyyy-MM-dd");
            //var list = Database.QueryAsync<AssessmentLog>("SELECT * FROM assessment_log WHERE staff_id=? AND (date_completed BETWEEN date(\'now\', \'-365 day\') AND date(\'now\'))", staffID); //
            var list = Database.QueryAsync<AssessmentLog>("SELECT * FROM assessment_log WHERE staff_id=?", staffID);

            return list;
        }

        public Task<List<Questions>> GetQuestionsAsync(string gameCode)
        {

            var list = Database.QueryAsync<Questions>("select * from game_questions where game_code=?", gameCode);
            return list;
        }

        public async Task AddAnswersAsync(object assessment)
        {

            await Database.InsertAsync(assessment);
            return;
        }

    }
}
