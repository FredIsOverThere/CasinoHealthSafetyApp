namespace CasinoHSApp.Models
{
    //[Table("assessment_log")]
    public class Answers
    {

        public int StaffID { get; set; }
        public string GameType { get; set; }
        public string DateCompleted { get; set; }
        public string AssessorID { get; set; }
        public string FileLocation { get; set; }
        public string QuestionAnswers { get; set; }

    }
}
