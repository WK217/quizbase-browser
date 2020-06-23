using QuizbaseBrowser.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace QuizbaseBrowser.ViewModel
{
    public class NewQuizViewModel : ViewModelBase
    {
        readonly Quizbase _quizbase;

        public NewQuizViewModel(Quizbase quizbase)
        {
            _quizbase = quizbase;
            Quiz = new Quiz()
            {
                A = "Вариант A",
                B = "Вариант B",
                C = "Вариант C",
                D = "Вариант D",
            };

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
        }

        [Reactive]
        public Quiz Quiz { get; private set; }

        public IReactiveCommand ApplyChangesCommand { get; }

        public void ApplyChanges()
        {
            _quizbase.AddOrUpdate(Quiz);
            Quiz = new Quiz()
            {
                A = "Вариант A",
                B = "Вариант B",
                C = "Вариант C",
                D = "Вариант D",
            };
        }
    }
}
