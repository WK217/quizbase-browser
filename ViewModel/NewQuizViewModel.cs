using QuizbaseBrowser.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace QuizbaseBrowser.ViewModel
{
    public class NewQuizViewModel : ViewModelBase, IRoutableViewModel
    {
        readonly Quizbase _quizbase;

        public NewQuizViewModel(Quizbase quizbase, IScreen screen = null)
        {
            _quizbase = quizbase;
            Quiz = new Quiz();

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
        }

        [Reactive]
        public Quiz Quiz { get; private set; }

        public IReactiveCommand ApplyChangesCommand { get; }

        public void ApplyChanges()
        {
            _quizbase.AddOrUpdate(Quiz);
            Quiz = new Quiz();
        }

        #region Routing
        public string UrlPathSegment => "newQuiz";
        public IScreen HostScreen { get; }
        #endregion
    }
}
