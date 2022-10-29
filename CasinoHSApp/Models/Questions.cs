using SQLite;

namespace CasinoHSApp.Models
{
    [Table("game_questions")]
    public class Questions
    {

        [PrimaryKey]
        [Column("game_code")]
        public string GameCode { get; set; }
        [Column("game_name")]
        public string GameName { get; set; }
        [Column("questions_one")]
        public string QuestionOne { get; set; }
        [Column("questions_two")]
        public string QuestionTwo { get; set; }
        [Column("questions_three")]
        public string QuestionThree { get; set; }
        [Column("questions_four")]
        public string QuestionFour { get; set; }
        [Column("questions_five")]
        public string QuestionFive { get; set; }
        [Column("questions_six")]
        public string QuestionSix { get; set; }
        [Column("questions_seven")]
        public string QuestionSeven { get; set; }
        [Column("questions_eight")]
        public string QuestionEight { get; set; }
        [Column("questions_nine")]
        public string QuestionNine { get; set; }
        [Column("questions_ten")]
        public string QuestionTen { get; set; }
        [Column("questions_eleven")]
        public string QuestionEleven { get; set; }
        [Column("questions_twelve")]
        public string QuestionTwelve { get; set; }
        [Column("questions_thirteen")]
        public string QuestionThirteen { get; set; }
        [Column("questions_fourteen")]
        public string QuestionFourteen { get; set; }
        [Column("number_question")]
        public int NumberQuestions { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StaffID { get; set; }

        //public IList<string> YesNo
        //{
        //    get
        //    {
        //        return new List<string> { "Yes", "No" };
        //    }
        //}

    }

    public class RouletteQuestions
    {
        public int totalQuestions = 13;
        public string question = "1.1 Does the dealer stand with head up in a relaxed upright posture?@1.2 Are the dealers shoulders relaxed and elbows beside their body when in a neutral position?@1.3 Does the dealer reset their posture and look up between rounds of play?@@2.1 Does the dealer cruise the table and move their body between segments of the layout to minimise reach when clearing the layout?@2.2 Does the dealer cruise the table to minimise reach when paying outside bets and passing chips across the layout?@2.3 Does the dealer pay the appropriate chip denomination to prevent unnecessary colour changes?@2.4 Does the dealer use a golfer’s kick when spinning the ball and paying outside bets as necessary?@2.5 Does the dealer face the wheel and reach into the wheel for an appropriate amount of time when spinning the ball?@2.6 Does the dealer spin the ball correctly (no wrist movement)?@2.7 Does the dealer utilize/access the chipper appropriately? (Does not reach in sideways etc)@2.8 Does the dealer place an appropriate amount of pressure on the shoulder when performing the fist on the table technique?@2.9 Does the dealer maintain a smooth and fluent motion when performing all actions? – (not jerky/sharp)@2.10 Is the dealer setting an appropriate pace for the game?";
    }
    public class BaccaratQuestions
    {
        public int totalQuestions = 14;
        public string question = "1.1 Does the dealer set up their chair with full back support with hips and knees at 90 degrees?@1.2 Are the dealers shoulders relaxed and elbows beside their body with a 90-100? bend when in a neutral position (may need to raise chair and use a step)@1.3 Is the dealer tucked in and sitting upright without leaning on the table?@1.4 Does the dealer reset posture and look up between hands and other times when possible?@2.1 Does the dealer keep their elbows tucked in where possible?(avoiding a chicken wing posture)@2.2 Does the dealer move their chair when able to such that they cruise, minimise reach and face their task?@2.3 When paying and taking does the dealer stay in a neutral position where possible? Eg doesn’t lean on elbow@2.4 Does the dealer reach across their body to perform any dealing task?@2.5 Does the dealer leave their hand on the dealing shoe when not required?@2.6 Does the dealer reasonably request that players pass cards and cash/chip changes to be within their reach?@2.7 Does the dealer sit with an appropriate relaxed posture when players are squeezing the cards and other inactive times?@2.8 Does the dealer move/swivel their chair when accessing the drop box?@2.9 Does the dealer maintain a smooth and fluent motion overall? – not jerky/sharp@2.10 Does the dealer pass the relevant cards out in a smooth motion without unnecessarily bending forward?";
    }
    public class BlackJackQuestions
    {
        public int totalQuestions = 13;
        public string question = "1.1 Does the dealer stand with head up in a relaxed upright posture@1.2 Are the dealers shoulders relaxed and elbows beside body with 90-100? bend (less than 90? may require a step)@1.3 Does the dealer reset their posture and look up between every hand?@@2.1 Does the dealer cruise the table to minimise reaching for all dealing tasks?@2.2 Where possible does the dealer work with their elbows in close to their body?@2.3 Does the dealer only use right hand for paying/taking box 7 and primarily use  the left hand for box 1?@2.4 Does the dealer leave their hand on the shoe when not required?@2.5 Does the dealer reach across their body to perform any dealing task?@2.6 Does the dealer pay the appropriate chip denomination to prevent unnecessary colour changes?@2.7 Does the dealer perform unnecessary movements? Eg. double touch the cards@2.8 Does the dealer step to or pull the ATOM to themselves to swipe cards into the ATOM?@2.9 Does the dealer maintain a smooth and fluent motion? - (not jerky/sharp)@2.10 Is the dealer setting an appropriate pace for the game?";
    }
    public class PokerQuestions
    {
        public int totalQuestions = 14;
        public string question = "1.1 Does the dealer set up their chair with hips and knees at 90 degrees?@1.2 Are the dealers shoulders relaxed and elbows beside their body with a 90-100? bend when in a neutral position (may need to raise chair and use a step)@1.3 Is the dealer tucked in and sitting upright without leaning on the table?@1.4 Does the dealer reset posture and look up between hands and other times when possible?  eg: when waiting for action@2.1 Does the dealer keep their elbows tucked in where possible? (avoiding a chicken wing posture)@2.2 Does the dealer move their chair when able to such that they cruise, minimise reach as able?@2.3 Does the dealer keep elbows close to the body when pitching the cards?@2.4 Does the dealer pitch the cards with correct technique? eg: not throwing@2.5 Does the dealer enforce the courtesy line?@2.6 Does the dealer reach across their body to perform any dealing task?@2.7 Does the dealer sit with an appropriate relaxed posture when waiting for action?@2.8 Does the dealer move their chair and pull back on the drop slide slowly when dropping commission?@2.9 Does the dealer maintain a smooth and fluent motion? – not jerky/sharp@2.10 Does the dealer when bringing in bets/folded cards utilize a sweeping motion with their deck hand that keeps their wrist straight, hand facing upwards while also moving the chair towards the task?";
    }

    //public class Answers
    //{
    //    public string GameName { get; set; }
    //    public string AnswerOne { get; set; }
    //    public string AnswerTwo { get; set; }
    //    public string AnswerThree { get; set; }
    //    public string AnswerFour { get; set; }
    //    public string AnswerFive { get; set; }
    //    public string AnswerSix { get; set; }
    //    public string AnswerSeven { get; set; }
    //    public string AnswerEight { get; set; }
    //    public string AnswerNine { get; set; }
    //    public string AnswerTen { get; set; }
    //    public string AnswerEleven { get; set; }
    //    public string AnswerTwelve { get; set; }
    //    public string AnswerThirteen { get; set; }
    //    public string AnswerFourteen { get; set; }
    //    public string AnswerOneName { get; set; }
    //    public string AnswerTwoName { get; set; }
    //    public string AnswerThreeName { get; set; }
    //    public string AnswerFourName { get; set; }
    //    public string AnswerFiveName { get; set; }
    //    public string AnswerSixName { get; set; }
    //    public string AnswerSevenName { get; set; }
    //    public string AnswerEightName { get; set; }
    //    public string AnswerNineName { get; set; }
    //    public string AnswerTenName { get; set; }
    //    public string AnswerElevenName { get; set; }
    //    public string AnswerTwelveName { get; set; }
    //    public string AnswerThirteenName { get; set; }
    //    public string AnswerFourteenName { get; set; }
    //    public int NumberQuestions { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public string StaffID { get; set; }

    //    public string date { get; set; }
    //}

}
