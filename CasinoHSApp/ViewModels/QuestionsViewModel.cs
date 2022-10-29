using CasinoHSApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoHSApp.ViewModels
{
    public class QuestionsViewModel : BaseViewModel
    {
        public DealerFocusQuestion HeaderModel { get; set; }
        public List<SpecificQuestions> ListItems { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public List<Questions> ListQuestions { get; set; }
        public List<DealerCloseUp> DCU { get; set; }
        public ObservableRangeCollection<Questions> Questions { get; set; }
        public List<QuestionBuild> QuestionBuild { get; set; }
        public ObservableRangeCollection<QuestionBuild> QuestionBuilder { get; set; }


        public QuestionsViewModel()
        {

            HeaderModel = new DealerFocusQuestion();

            ListItems = new List<SpecificQuestions>();

            ListQuestions = new List<Questions>();
            Questions = new ObservableRangeCollection<Questions>();
            RefreshCommand = new AsyncCommand(Refresh);
            DCU = new List<DealerCloseUp>();
            QuestionBuild = new List<QuestionBuild>();
            QuestionBuilder = new ObservableRangeCollection<QuestionBuild>();
        }

        public async Task GetTheQuestions(string gameName, string gameCode)
        {
            ListQuestions = await App.MobileAppDatabase.GetQuestionsAsync(gameCode);
            Questions questions = new Questions();
            QuestionBuild questionBuild = new QuestionBuild();
            questions = ListQuestions.FirstOrDefault();
            questionBuild.FirstName = DCU.FirstOrDefault().FirstName;
            questionBuild.LastName = DCU.FirstOrDefault().LastName;
            questionBuild.StaffID = DCU.FirstOrDefault().StaffID;
            questionBuild.NumberQuestions = questions.NumberQuestions;
            int count = 1;
            questionBuild.Position = count;
            questionBuild.GameName = gameName;
            questionBuild.Question = "";
            QuestionBuilderList(questionBuild);
            count++; //2
            questionBuild.Question = "Non-Dealing/Between Hands";
            questionBuild.Position = count;
            questionBuild.GameName = gameCode;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionOne;
            questionBuild.Position = count;
            questionBuild.GameName = gameName;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionTwo;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionThree;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionFour;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++; //7
            questionBuild.Question = "Key areas of concern that may cause Injury";
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;

            questionBuild.Question = questions.QuestionFive;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionSix;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionSeven;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionEight;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionNine;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionTen;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionEleven;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionTwelve;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionThirteen;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++;
            questionBuild.Question = questions.QuestionFourteen;
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++; //18
            questionBuild.Question = "Feedback Given to Dealer";
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++; //19
            questionBuild.Question = "Agreed Outcomes";
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            count++; //20
            questionBuild.Question = "Submit";
            questionBuild.Position = count;
            QuestionBuilderList(questionBuild);

            //count++; //21
            //questionBuild.Question = "Return";
            //questionBuild.Position = count;
            //QuestionBuilderList(questionBuild);

        }
        public void QuestionBuilderList(QuestionBuild questionBuild)
        {
            QuestionBuilder.Add(new QuestionBuild()
            {
                StaffID = questionBuild.StaffID,
                FirstName = questionBuild.FirstName,
                LastName = questionBuild.LastName,
                GameName = questionBuild.GameName,
                Position = questionBuild.Position,
                NumberQuestions = questionBuild.NumberQuestions,
                Question = questionBuild.Question
            });
        }

        public List<QuestionBuild> QuestionRefresh()
        {
            IsBusy = true;
            ObservableRangeCollection<QuestionBuild> Temp = new ObservableRangeCollection<QuestionBuild>();
            Temp.AddRange(QuestionBuilder);
            QuestionBuilder.Clear();
            Task.Delay(2000);
            QuestionBuild.AddRange(Temp);
            IsBusy = false;
            return QuestionBuild;

        }

        public async Task AddToDatabase(object assessmentLog)
        {
            await App.MobileAppDatabase.AddAnswersAsync(assessmentLog);
        }


        public async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }

        public string RebuildAssessment(AssessmentLog assessmentLog, string embededHTML, Questions quest)
        {
            HealthSafetyQuestionsViewModel hsqVM = new HealthSafetyQuestionsViewModel();
            string htmlEmbedPath = hsqVM.GetHTMLTemplate(embededHTML);
            StreamReader htmlStreamReader = new StreamReader(htmlEmbedPath);
            string htmlString = htmlStreamReader.ReadToEnd().ToString();
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(htmlString);
            string htmlName = "tempLastAssessed.html";
            htmlStreamReader.Dispose();
            string temp = assessmentLog.AnswersQuestions;
            List<string> answers = temp.Split('|').ToList();

            htmlBuilder.Replace("StaffIDHere", answers[0]);
            htmlBuilder.Replace("FirstNameHere", answers[1]);
            htmlBuilder.Replace("LastNameHere", answers[2]);
            htmlBuilder.Replace("GameNameHere", answers[3]);
            htmlBuilder.Replace("HereAStaffID", answers[4]);
            htmlBuilder.Replace("HereAFirstName", answers[5]);
            htmlBuilder.Replace("HereALastName", answers[6]);
            htmlBuilder.Replace("DateCompletedHere", answers[7]);
            htmlBuilder.Replace("DateReassessHere", answers[8]);
            int count = 65;
            int countAnswers = 9;
            string temp2 = "Feedback Given to Dealer";
            string temp3 = "Agreed Outcomes";
            List<string> questions = new List<string>();
            questions.Add(quest.QuestionOne);
            questions.Add(quest.QuestionTwo);
            questions.Add(quest.QuestionThree);
            questions.Add(quest.QuestionFour);
            questions.Add(quest.QuestionFive);
            questions.Add(quest.QuestionSix);
            questions.Add(quest.QuestionSeven);
            questions.Add(quest.QuestionEight);
            questions.Add(quest.QuestionNine);
            questions.Add(quest.QuestionTen);
            questions.Add(quest.QuestionEleven);
            questions.Add(quest.QuestionTwelve);
            questions.Add(quest.QuestionThirteen);
            questions.Add(quest.QuestionFourteen);
            questions.Add(temp2);
            questions.Add(temp3);

            for (int i = 0; i < 16; i++)
            {
                if (questions[i] == null) { }
                else
                {
                    string question = "Question" + ((char)count).ToString();
                    string answer = "Answer" + ((char)count).ToString();
                    htmlBuilder.Replace(question, questions[i]);
                    htmlBuilder.Replace(answer, answers[countAnswers]);

                    countAnswers++;
                    count++;
                }
            }

            string htmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), htmlName);
            htmlString = htmlBuilder.ToString();

            using (FileStream fs = File.Create(htmlPath))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(htmlString);
                }
            }

            return htmlString;


        }

    }
}
