using CasinoHSApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CasinoHSApp.ViewModels
{
    public class HealthSafetyQuestionsViewModel : BaseViewModel
    {


        public ObservableRangeCollection<Answers> Answers { get; set; }
        public AsyncCommand RefreshCommand { get; }

        public HealthSafetyQuestionsViewModel()
        {

            Title = "List of Answers";
            Answers = new ObservableRangeCollection<Answers>();
        }

        public string GetHTMLTemplate(string embededHTML)
        {

            string htmlEmbededPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), embededHTML);
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embeddedHTMLStream = assembly.GetManifestResourceStream(string.Concat("CasinoHSApp.", embededHTML));

            if (!File.Exists(htmlEmbededPath))
            {
                FileStream filestreamToWrite = File.Create(htmlEmbededPath);
                embeddedHTMLStream.Seek(0, SeekOrigin.Begin);
                embeddedHTMLStream.CopyTo(filestreamToWrite);
                filestreamToWrite.Close();
            }

            return htmlEmbededPath;
        }

        public HTMLAssessmentLog CreateHTMLDocument(int questionsNumber, List<QuestionBuild> listQuestions, string assessorID, string assessorFirstName, string assessorLastName, QuestionsViewModel questionsViewModel, Boolean rebuild)
        {
            string embededHTML = null;
            if (questionsNumber == 13)
            {
                embededHTML = "thirteenHTML.txt";
            }
            else
            {
                embededHTML = "fourteenHTML.txt";
            }

            string htmlEmbedPath = GetHTMLTemplate(embededHTML);
            StreamReader htmlStreamReader = new StreamReader(htmlEmbedPath);
            string htmlString = htmlStreamReader.ReadToEnd().ToString();
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(htmlString);
            string htmlName = null;
            htmlStreamReader.Dispose();
            DateTime dateToday = DateTime.Now;
            DateTime dateTodayNY = dateToday.AddDays(365);
            string todayDate = dateToday.ToString("dd/MM/yyyy");
            string todayDateNY = dateTodayNY.ToString("dd/MM/yyyy");
            string sTodayDate = dateToday.ToString("dd_MM_yyyy");
            string totalAnswers = "";
            AssessmentLog assessmentLog = new AssessmentLog();
            int count = 65;
            foreach (QuestionBuild qB in listQuestions)
            {
                if (qB.Position == 1)
                {
                    htmlBuilder.Replace("StaffIDHere", qB.StaffID);
                    htmlBuilder.Replace("FirstNameHere", qB.FirstName);
                    htmlBuilder.Replace("LastNameHere", qB.LastName);
                    htmlBuilder.Replace("GameNameHere", qB.GameName);
                    htmlBuilder.Replace("HereAStaffID", assessorID);
                    htmlBuilder.Replace("HereAFirstName", assessorFirstName);
                    htmlBuilder.Replace("HereALastName", assessorLastName);
                    htmlBuilder.Replace("DateCompletedHere", todayDate);
                    htmlBuilder.Replace("DateReassessHere", todayDateNY);
                    assessmentLog.StaffID = int.Parse(qB.StaffID);
                    assessmentLog.GameType = "";
                    assessmentLog.DateCompleted = todayDate;
                    assessmentLog.AssessorID = int.Parse(assessorID);
                    htmlName = string.Concat(qB.GameName, " ", qB.StaffID, " ", qB.FirstName, " ", qB.LastName, " ", sTodayDate, ".html");
                    totalAnswers = string.Concat(qB.StaffID, "|", qB.FirstName, "|", qB.LastName, "|", qB.GameName, "|",
                                                 assessorID, "|", assessorFirstName, "|", assessorLastName, "|", todayDate, "|", todayDateNY, "|");
                }
                else if (qB.Position == 2)
                {
                    assessmentLog.GameType = qB.GameName;
                }
                else if (qB.Position == 7) { }
                else if (qB.NumberQuestions == 13 & qB.Position == 6) { }
                else if (qB.Question.Contains("Submit") == true) { }
                else
                {

                    string question = "Question" + ((char)count).ToString();
                    string answer = "Answer" + ((char)count).ToString();
                    htmlBuilder.Replace(question, qB.Question);
                    htmlBuilder.Replace(answer, qB.Answer);
                    totalAnswers = string.Concat(totalAnswers, qB.Answer, "|");
                    count++;
                }

            }

            assessmentLog.AnswersQuestions = totalAnswers;

            string htmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), htmlName);

            htmlString = htmlBuilder.ToString();

            


            using (FileStream fs = File.Create(htmlPath))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(htmlString);
                }
            }

            assessmentLog.FileLocation = htmlName;

            HTMLAssessmentLog log = new HTMLAssessmentLog 
            { 
                AssessmentLog = assessmentLog,
                HTMLString = htmlString,
                HTMLLocationString = htmlPath
            };

            return log;

        }



    }
}

