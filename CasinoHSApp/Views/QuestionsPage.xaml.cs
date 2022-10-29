using CasinoHSApp.Helpers;
using CasinoHSApp.Models;
using CasinoHSApp.ViewModels;
//using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsPage : ContentPage
    {
        public string gameName;
        public string firstName;
        public string lastName;
        public string questions;
        public string staffID;
        public QuestionsViewModel questionsViewModel;
        public List<QuestionBuild> listQuestions;
        public QuestionBuild selectedQB = new QuestionBuild();
        public QuestionsPage()
        {
            InitializeComponent();
            questionsViewModel = new QuestionsViewModel();

        }
        public List<QuestionBuild> QuestionsRefresh()
        {
            listQuestions = questionsViewModel.QuestionRefresh();
            return listQuestions;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CollectionView.ItemsSource = null;
            CollectionView.ItemsSource = listQuestions;

            if (App.isLandscape == true)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Landscape();
                }
            } //do something landscape
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IOrientationService>().Portrait();
                }
            } //do something portrait

            //gameName = questionsViewModel.DCU.FirstOrDefault().GameType;
            firstName = questionsViewModel.DCU.FirstOrDefault().FirstName;
            lastName = questionsViewModel.DCU.FirstOrDefault().LastName;
            staffID = questionsViewModel.DCU.FirstOrDefault().StaffID;
            //GetQuestions(questions);
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = sender as Picker;

            var index = picker.SelectedIndex;
            var list = picker.ItemsSource;
            int sQBP = 0;
            try
            {
                sQBP = int.Parse((((sender as Picker).Parent as StackLayout).Children[2] as Label).Text);
            }
            catch 
            {
            }
            //selectedQB = ((CollectionView)sender).SelectedItem as QuestionBuild;
            //int sQBP= selectedQB.Position;
            if (index != -1 && sQBP != 0)
            {
                listQuestions.ElementAt(sQBP - 1).Answer = (string)list[index];
            }
        }
        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {

            var editor = sender as Editor;

            var text = editor.Text;
            int sQBP = 0;
            //selectedQB = ((CollectionView)sender).SelectedItem as QuestionBuild;
            try
            {
                sQBP = int.Parse((((sender as Editor).Parent as StackLayout).Children[2] as Label).Text);
            }
            catch { }
            if (sQBP != 0) {
                listQuestions.ElementAt(sQBP - 1).Answer = text;
            }    
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            int questionsNumber = 0;
            foreach (QuestionBuild qB in listQuestions)
            {
                if (qB.Position == 1) { questionsNumber = qB.NumberQuestions; }
                else if (qB.Position == 2) { }
                else if (qB.Position == 7) { }
                else if (qB.NumberQuestions == 13 & qB.Position == 6) { }
                else if (qB.Question.Contains("Submit") == true) { }

                else
                {
                    if (qB.Answer == null)
                    {
                        await DisplayAlert("Alert", "Please fill out all questions!", "OK");
                        return;
                    }
                }
            }
            //string assessorID = await DisplayPromptAsync("Question", "What's your ID?");
            //string assessorFirstName = await DisplayPromptAsync("Question", "What's your First Name?");
            //string assessorLastName = await DisplayPromptAsync("Question", "What's your Last Name?");
            string assessorID = "365070";
            string assessorFirstName = "Ashleigh";
            string assessorLastName = "Licht";
            //string assessorInformation = string.Concat(assessorID, "|", assessorFirstName, "|", assessorLastName);
            //string questionsAnswers = null;
            //string personalInfo = null;
            HealthSafetyQuestionsViewModel xml = new HealthSafetyQuestionsViewModel();
            HTMLAssessmentLog assessmentLog = xml.CreateHTMLDocument(questionsNumber, listQuestions, assessorID, assessorFirstName, assessorLastName, questionsViewModel, false);

            await questionsViewModel.AddToDatabase(assessmentLog.AssessmentLog);

            string subjectLine = string.Concat("EMMaH Assessment completed for ", firstName, " ", lastName, " ", staffID, " ", gameName);
            string bodyText = string.Concat("Hello MDMT,", "\n", "\n", "Please find attached the EMMaH Assessment conducted on ", staffID, " ", 
                firstName, " ", lastName, " for their game of ", gameName, "\n", "\n", "Regards,", "\n", assessorFirstName, " ", assessorLastName);
            List<string> recipients = new List<string>();
            recipients.Add("ash.licht@gmail.com");
            //recipients.Add("chad.pearce@crownmelbourne.com");
            var message = new EmailMessage
            {
                Subject = subjectLine,
                Body = bodyText,
                To = recipients
            };

            var fn = assessmentLog.AssessmentLog.FileLocation;
            var file = Path.Combine(FileSystem.CacheDirectory, fn);
            File.WriteAllText(file, assessmentLog.HTMLString);

            message.Attachments.Add(new EmailAttachment(file));
            //message.Attachments.Add(new EmailAttachment(assessmentLog.HTMLLocationString));

            await Email.ComposeAsync(message);

            //File.Delete(file);

            await Navigation.PopModalAsync();

        }

        private async void Return_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        }


}