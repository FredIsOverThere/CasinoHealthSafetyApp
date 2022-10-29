namespace CasinoHSApp.Models
{
    public class QuestionBuild
    {
        public string StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Position { get; set; }
        public int NumberQuestions { get; set; }
    }
    public class DealerFocusQuestion
    {


    }
    public class SpecificQuestions
    {
        public string Questions { get; set; }

    }
}
