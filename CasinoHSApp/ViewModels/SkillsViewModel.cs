using CasinoHSApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoHSApp.ViewModels
{
    public class SkillsViewModel : BaseViewModel
    {


        public ObservableRangeCollection<Skills> Skill { get; set; }
        public ObservableRangeCollection<DealerCloseUp> DealerCloseUp { get; set; }
        public ObservableRangeCollection<AssessmentLog> AssessmentLogs { get; set; }
        public ObservableRangeCollection<Grouping<string, AssessmentLog>> AssessmentLogsGroups { get; set; }
        public ObservableRangeCollection<AssessmentLog> AllBA { get; set; }
        public ObservableRangeCollection<AssessmentLog> AllBJ { get; set; }
        public ObservableRangeCollection<AssessmentLog> AllPK { get; set; }
        public ObservableRangeCollection<AssessmentLog> AllAR { get; set; }
        public AsyncCommand SkillRefreshCommand { get; }
        public AsyncCommand CloseUpRefreshCommand { get; }
        public object CollectionViewSource { get; private set; }
        public List<DealerCloseUp> DealerSkills { get; set; }

        public int staffID;
        public string firstName;
        public string lastName;
        public int codeBA;
        public int codeAR;
        public int codeBJ;
        public int codePK;
        //public event PropertyChangedEventHandler ObservableObject;

        public SkillsViewModel()
        {
            Title = "List of Dealer skills";
            Skill = new ObservableRangeCollection<Skills>();
            AssessmentLogs = new ObservableRangeCollection<AssessmentLog>();
            //DealerGroups = new ObservableRangeCollection<Grouping<string, Dealer>>();
            // AddCommand = new AsyncCommand(Add);
            SkillRefreshCommand = new AsyncCommand(SkillRefresh);
            //CloseUpRefreshCommand = new AsyncCommand(CloseUpRefresh);
            DealerCloseUp = new ObservableRangeCollection<DealerCloseUp>();
            AllAR = new ObservableRangeCollection<AssessmentLog>();
            AssessmentLogsGroups = new ObservableRangeCollection<Grouping<string, AssessmentLog>>();
            AllBJ = new ObservableRangeCollection<AssessmentLog>();
            AllPK = new ObservableRangeCollection<AssessmentLog>();
            AllBA = new ObservableRangeCollection<AssessmentLog>();
            DealerSkills = new List<DealerCloseUp>();
            // DealerGroups.Add(new Grouping<string, Dealer>("MAIN", new[] { Dealer[2] }));
        }

        public async Task SkillRefresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            Skill.Clear();
            //var dealers = await DealerService.GetDealer();
            //var dealers = await App.MobileAppDatabase.GetDealersAsync();
            //Skills.AddRange(dealers);

            IsBusy = false;
        }
        public List<DealerCloseUp> CloseUpRefresh()
        {
            IsBusy = true;
            ObservableRangeCollection<DealerCloseUp> Temp = new ObservableRangeCollection<DealerCloseUp>();
            Temp.AddRange(DealerCloseUp);
            DealerCloseUp.Clear();
            Task.Delay(2000);
            DealerSkills.AddRange(Temp);
            IsBusy = false;
            return DealerSkills;

        }
        public ObservableRangeCollection<AssessmentLog> FindLatest(ObservableRangeCollection<AssessmentLog> assessed)
        {
            ObservableRangeCollection<AssessmentLog> sortedField;
            sortedField = new ObservableRangeCollection<AssessmentLog>(assessed.OrderBy(i => i.DateCompleted));
            return sortedField;

        }



        public async Task DoTheThing()
        {
            var skills = await App.MobileAppDatabase.GetSpecificSkillAsync(staffID);
            Skill.Clear();
            Skill.AddRange(skills);
            Skills skilled = new Skills();
            skilled = Skill.FirstOrDefault();
            var assessed = await App.MobileAppDatabase.GetLastAssessedAsync(staffID);
            ObservableRangeCollection<AssessmentLog> temp = new ObservableRangeCollection<AssessmentLog>();
            temp.AddRange(assessed);
            AssessmentLogs.Clear();
            AssessmentLogs = FindLatest(temp);
            AssessmentLogsGroups.Add(new Grouping<string, AssessmentLog>("AR", AssessmentLogs.Where(c => c.GameType == "AR")));
            AssessmentLogsGroups.Add(new Grouping<string, AssessmentLog>("BA", AssessmentLogs.Where(c => c.GameType == "BA")));
            AssessmentLogsGroups.Add(new Grouping<string, AssessmentLog>("BJ", AssessmentLogs.Where(c => c.GameType == "BJ")));
            AssessmentLogsGroups.Add(new Grouping<string, AssessmentLog>("PK", AssessmentLogs.Where(c => c.GameType == "PK")));
            foreach (Grouping<string, AssessmentLog> a in AssessmentLogsGroups)
            {
                if (a.Key == "AR")
                {
                    AllAR.AddRange(a);
                }
                if (a.Key == "BJ")
                {
                    AllBJ.AddRange(a);
                }
                if (a.Key == "BA")
                {
                    AllBA.AddRange(a);
                }
                if (a.Key == "PK")
                {
                    AllPK.AddRange(a);
                }
            }

            DealerCloseUp dealerCloseUp = new DealerCloseUp();
            dealerCloseUp.StaffID = staffID.ToString();
            dealerCloseUp.FirstName = firstName;
            dealerCloseUp.LastName = lastName;
            DealerCloseUp.Add(new DealerCloseUp()
            {
                StaffID = dealerCloseUp.StaffID,
                FirstName = dealerCloseUp.FirstName,
                LastName = dealerCloseUp.LastName,
                GameType = "Name",
                GameLastAssessed = "NA"
            });
            if (skilled.AmericanRoulette != 0)
            {
                dealerCloseUp.GameType = "American Roulette";

                if (AllAR.LastOrDefault() == null)
                {
                    dealerCloseUp.GameLastAssessed = "No Assessment on Record";
                    dealerCloseUp.WasAssessed = false;
                }
                else
                {
                    dealerCloseUp.GameLastAssessed = AllAR.FirstOrDefault().DateCompleted;
                    dealerCloseUp.WasAssessed = true;
                }
                DealerCloseUp.Add(new DealerCloseUp()
                {
                    StaffID = dealerCloseUp.StaffID,
                    FirstName = dealerCloseUp.FirstName,
                    LastName = dealerCloseUp.LastName,
                    GameType = dealerCloseUp.GameType,
                    GameLastAssessed = dealerCloseUp.GameLastAssessed,
                    WasAssessed = dealerCloseUp.WasAssessed
                });
            }
            if (skilled.Baccarat != 0)
            {
                dealerCloseUp.GameType = "Baccarat";
                if (AllBA.LastOrDefault() == null)
                {
                    dealerCloseUp.GameLastAssessed = "No Assessment on Record";
                    dealerCloseUp.WasAssessed = false;
                }
                else
                {
                    dealerCloseUp.GameLastAssessed = AllBA.FirstOrDefault().DateCompleted;
                    dealerCloseUp.WasAssessed = true;
                }
                DealerCloseUp.Add(new DealerCloseUp()
                {
                    StaffID = dealerCloseUp.StaffID,
                    FirstName = dealerCloseUp.FirstName,
                    LastName = dealerCloseUp.LastName,
                    GameType = dealerCloseUp.GameType,
                    GameLastAssessed = dealerCloseUp.GameLastAssessed,
                    WasAssessed = dealerCloseUp.WasAssessed
                });
            }
            if (skilled.BlackJack != 0)
            {
                dealerCloseUp.GameType = "BlackJack";
                if (AllBJ.LastOrDefault() == null)
                {
                    dealerCloseUp.GameLastAssessed = "No Assessment on Record";
                    dealerCloseUp.WasAssessed = false;
                }
                else
                {
                    dealerCloseUp.GameLastAssessed = AllBJ.FirstOrDefault().DateCompleted;
                    dealerCloseUp.WasAssessed = true;
                }
                DealerCloseUp.Add(new DealerCloseUp()
                {
                    StaffID = dealerCloseUp.StaffID,
                    FirstName = dealerCloseUp.FirstName,
                    LastName = dealerCloseUp.LastName,
                    GameType = dealerCloseUp.GameType,
                    GameLastAssessed = dealerCloseUp.GameLastAssessed,
                    WasAssessed = dealerCloseUp.WasAssessed
                });
            }
            if (skilled.Poker != 0)
            {
                dealerCloseUp.GameType = "Poker";
                if (AllPK.LastOrDefault() == null)
                {
                    dealerCloseUp.GameLastAssessed = "No Assessment on Record";
                    dealerCloseUp.WasAssessed = false;
                }
                else
                {
                    dealerCloseUp.GameLastAssessed = AllPK.FirstOrDefault().DateCompleted;
                    dealerCloseUp.WasAssessed = true;
                }
                DealerCloseUp.Add(new DealerCloseUp()
                {
                    StaffID = dealerCloseUp.StaffID,
                    FirstName = dealerCloseUp.FirstName,
                    LastName = dealerCloseUp.LastName,
                    GameType = dealerCloseUp.GameType,
                    GameLastAssessed = dealerCloseUp.GameLastAssessed,
                    WasAssessed = dealerCloseUp.WasAssessed
                });
            }
            //DCU.Clear();


            //DealerCloseUp.Add(dealerCloseUp);
            return;
        }


    }
}
