using SQLite;

namespace CasinoHSApp.Models
{
    [Table("assessment_log")]
    public class AssessmentLog
    {

        [PrimaryKey]
        [Column("staff_id")]
        public int StaffID { get; set; }

        [Column("game_type")]
        public string GameType { get; set; }

        [Column("date_completed")]
        public string DateCompleted { get; set; }

        [Column("assessor_id")]
        public int AssessorID { get; set; }

        [Column("file_location")]
        public string FileLocation { get; set; }

        [Column("answers_questions")]
        public string AnswersQuestions { get; set; }
    }
}
