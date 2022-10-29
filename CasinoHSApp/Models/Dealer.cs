using SQLite;

namespace CasinoHSApp.Models
{
    [Table("staff_list")]
    public class Dealer
    {

        [PrimaryKey]
        [Column("staff_id")]
        public int StaffID { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("department")]
        public string Department { get; set; }
        [Column("position")]
        public string Position { get; set; }
        [Column("dm_id")]
        public int DMID { get; set; }

    }
}
