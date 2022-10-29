using CasinoHSApp.Models;
using CasinoHSApp.ViewModels;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DealerCloseUpPage : ContentPage
    {
        public DealerCloseUpPage()
        {
            InitializeComponent();
            skillsViewModel = new SkillsViewModel();
            questionsPage = new QuestionsPage();
            questionsPage.questionsViewModel = new QuestionsViewModel();
            questionsViewModels = questionsPage.questionsViewModel;
        }
        public string gameName;
        public string firstName;
        public string lastName;
        public string staffID;
        string gameCode;
        public SkillsViewModel skillsViewModel;
        public DealerCloseUpPage UpPage;
        public AsyncCommand RefreshCommand;
        public List<DealerCloseUp> CloseUps;
        public QuestionsPage questionsPage;
        public QuestionsViewModel questionsViewModels;

        public async void SendCodeBehind(string gameName, string gameCode)
        {
            questionsViewModels.DCU = CloseUps;
            await questionsViewModels.GetTheQuestions(gameName, gameCode);
            questionsPage.QuestionsRefresh();
            questionsPage.gameName = gameName;
            await Navigation.PushModalAsync(questionsPage);

        }

        private void Roulette_Clicked(object sender, EventArgs e)
        {
            //string ifCoded = ARCoded.Text;
            //if (ifCoded == "NA") {ARButton.IsEnabled = false; return;
            //}

            gameName = "American Roulette";
            gameCode = "AR";
            SendCodeBehind(gameName, gameCode);

        }
        private void Baccarat_Clicked(object sender, EventArgs e)
        {
            //    string ifCoded = BACoded.Text;
            //    if (ifCoded == "NA") {BAButton.IsEnabled = false; return;
            //}
            gameName = "Baccarat";
            gameCode = "BA";
            SendCodeBehind(gameName, gameCode);
        }
        private void BlackJack_Clicked(object sender, EventArgs e)
        {
            //    string ifCoded = BJCoded.Text;
            //    if (ifCoded == "NA") {BJButton.IsEnabled = false; return;
            //}
            gameName = "BlackJack";
            gameCode = "BJ";
            SendCodeBehind(gameName, gameCode);
        }
        private void Poker_Clicked(object sender, EventArgs e)
        {
            //string ifCoded = PKCoded.Text;
            //if (ifCoded == "NA") { PKButton.IsEnabled = false;
            //    return;
            //}
            gameName = "Poker";
            gameCode = "PK";
            SendCodeBehind(gameName, gameCode);
        }
        private async void Last_Roulette_Clicked(object sender, EventArgs e)
        {
            AssessmentLog assessmentAR = skillsViewModel.AllAR.FirstOrDefault();
            string embededHTML = "thirteenHTML.txt";
            gameCode = "AR";
            List<Questions> ListQuestions = await App.MobileAppDatabase.GetQuestionsAsync(gameCode);
            Questions questions = ListQuestions.FirstOrDefault();
            string html = questionsViewModels.RebuildAssessment(assessmentAR, embededHTML, questions);
            WebPageBrowserPage webPage = new WebPageBrowserPage();
            webPage.html = html;
            await Navigation.PushModalAsync(webPage);

        }
        private async void Last_Baccarat_Clicked(object sender, EventArgs e)
        {
            //    string ifCoded = BACoded.Text;
            //    if (ifCoded == "NA") {BAButton.IsEnabled = false; return;
            //}
            AssessmentLog assessmentBA = skillsViewModel.AllBA.FirstOrDefault();
            string embededHTML = "fourteenHTML.txt";
            gameCode = "BA";
            List<Questions> ListQuestions = await App.MobileAppDatabase.GetQuestionsAsync(gameCode);
            Questions questions = ListQuestions.FirstOrDefault();
            string html = questionsViewModels.RebuildAssessment(assessmentBA, embededHTML, questions);
            WebPageBrowserPage webPage = new WebPageBrowserPage();
            webPage.html = html;
            await Navigation.PushModalAsync(webPage);
        }
        private async void Last_BlackJack_Clicked(object sender, EventArgs e)
        {
            AssessmentLog assessmentBJ = skillsViewModel.AllBJ.FirstOrDefault();
            string embededHTML = "thirteenHTML.txt";
            gameCode = "BJ";
            List<Questions> ListQuestions = await App.MobileAppDatabase.GetQuestionsAsync(gameCode);
            Questions questions = ListQuestions.FirstOrDefault();
            string html = questionsViewModels.RebuildAssessment(assessmentBJ, embededHTML, questions);
            WebPageBrowserPage webPage = new WebPageBrowserPage();
            webPage.html = html;
            await Navigation.PushModalAsync(webPage);
        }
        private async void Last_Poker_Clicked(object sender, EventArgs e)
        {
            AssessmentLog assessmentPK = skillsViewModel.AllPK.FirstOrDefault();
            string embededHTML = "fourteenHTML.txt";
            gameCode = "PK";
            List<Questions> ListQuestions = await App.MobileAppDatabase.GetQuestionsAsync(gameCode);
            Questions questions = ListQuestions.FirstOrDefault();
            string html = questionsViewModels.RebuildAssessment(assessmentPK, embededHTML, questions);
            WebPageBrowserPage webPage = new WebPageBrowserPage();
            webPage.html = html;
            await Navigation.PushModalAsync(webPage);
        }
        public List<DealerCloseUp> CloseUpRefresh()
        {
            CloseUps = skillsViewModel.CloseUpRefresh();
            return CloseUps;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = null;
            listView.ItemsSource = CloseUps;


            //GameName.Text = gameName;
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

            //var skills = App.MobileAppDatabase.GetSpecificSkillAsync(temp);
            ////Skill.AddRange(skills);
            //StaffID.Text = staffID;
            //FirstName.Text = firstName;
            //LastName.Text = lastName;
            //SkillCodes(skillsViewModel);
            //SkillsViewModel.Refresh();


        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            
            CloseUps = CloseUpRefresh();
            listView.ItemsSource = null;
            listView.ItemsSource = CloseUps;

        }

    }
}