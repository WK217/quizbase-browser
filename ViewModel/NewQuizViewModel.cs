using QuizbaseBrowser.Model;
using ReactiveUI;

namespace QuizbaseBrowser.ViewModel
{
    public class NewQuizViewModel : QuizViewModel, IRoutableViewModel
    {
        public override string Header => "Добавление вопроса";

        public NewQuizViewModel(Quizbase quizbase, IScreen screen = null)
            : base(quizbase, screen)
        {
            Quiz = new Quiz();
        }

        public override void ApplyChanges()
        {
            base.ApplyChanges();
            Quiz = new Quiz();
        }

        public override string UrlPathSegment => "newQuiz";
    }
}
