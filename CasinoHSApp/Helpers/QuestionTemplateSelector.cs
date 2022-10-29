using CasinoHSApp.Models;
using Xamarin.Forms;

namespace CasinoHSApp.Helpers
{
    class QuestionTemplateSelector : DataTemplateSelector
    {

        public DataTemplate QuestionTemplate { get; set; }
        public DataTemplate PersonalTemplate { get; set; }
        public DataTemplate NullTemplate { get; set; }
        public DataTemplate HeadingTemplate { get; set; }
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ButtonTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var url = (QuestionBuild)item;

            if (url.NumberQuestions == 13)
            {
                if (url.Position == 6)
                {
                    return NullTemplate;
                }
            }

            switch (url)
            {

                case QuestionBuild a when a.Position.Equals(1): return PersonalTemplate;
                case QuestionBuild a when a.Position.Equals(2): return HeadingTemplate;
                case QuestionBuild a when a.Position.Equals(7): return HeadingTemplate;
                case QuestionBuild a when a.Question.Contains("Feedback"): return TextTemplate;
                case QuestionBuild a when a.Question.Contains("Agreed"): return TextTemplate;
                case QuestionBuild a when a.Question.Contains("Submit"): return ButtonTemplate;
                default: return QuestionTemplate;




            }

        }


    }
}
