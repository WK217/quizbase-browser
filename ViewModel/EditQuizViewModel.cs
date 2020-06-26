using QuizbaseBrowser.Model;
using ReactiveUI;

namespace QuizbaseBrowser.ViewModel
{
    public class EditQuizViewModel : QuizViewModel, IRoutableViewModel
    {
        public override string Header => "Редактирование вопроса";

        public EditQuizViewModel(Quizbase quizbase, IScreen screen = null)
            : base(quizbase, screen)
        {
            RemoveCommand = ReactiveCommand.Create(() => Remove());
        }

        public IReactiveCommand RemoveCommand { get; }
        public void Remove() => _quizbase.Remove(Quiz);

        public override string UrlPathSegment => "editQuiz";
    }
}
