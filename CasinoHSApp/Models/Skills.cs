using SQLite;

namespace CasinoHSApp.Models
{
    [Table("skill_code_list")]
    public class Skills
    {
        [PrimaryKey]
        [Column("staff_id")]
        public int StaffID { get; set; }

        [Column("roulette")]
        public int AmericanRoulette { get; set; }
        [Column("baccarat")]
        public int Baccarat { get; set; }
        [Column("blackjack")]
        public int BlackJack { get; set; }
        [Column("poker")]
        public int Poker { get; set; }

    }
}
