using CasinoHSApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasinoHSApp.Services
{
    public static class AnswersService
    {





        public static async Task<IEnumerable<Answers>> GetAnswers()
        {
            await DatabaseService.Init();

            var answers = await DatabaseService.db.Table<Answers>().ToListAsync();
            return answers;
        }

        public static async Task AddDealerResult(int staffID, string gameType, string dateCompleted, string assessorID, string fileLocation, string questionAnswers)
        {
            await DatabaseService.Init();
            var results = new Answers
            {
                StaffID = staffID,
                GameType = gameType,
                DateCompleted = dateCompleted,
                AssessorID = assessorID,
                FileLocation = fileLocation,
                QuestionAnswers = questionAnswers
            };
            var id = await DatabaseService.db.InsertAsync(results);
        }

    }
}
