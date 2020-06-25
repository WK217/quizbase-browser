using QuizbaseBrowser.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace QuizbaseBrowser.ViewModel
{
    public class EditQuizViewModel : ViewModelBase, IRoutableViewModel
    {
        readonly Quizbase _quizbase;

        public EditQuizViewModel(Quizbase quizbase, IScreen screen = null)
        {
            _quizbase = quizbase;

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
            RemoveCommand = ReactiveCommand.Create(() => Remove());
        }

        [Reactive]
        public Quiz Quiz { get; set; }

        [Reactive]
        public string Test { get; set; } = "TESTERINO";

        public IReactiveCommand ApplyChangesCommand { get; }
        public IReactiveCommand RemoveCommand { get; }

        public void ApplyChanges() => _quizbase.AddOrUpdate(Quiz);
        public void Remove() => _quizbase.Remove(Quiz);

        #region Routing
        public string UrlPathSegment => "editQuiz";
        public IScreen HostScreen { get; }
        #endregion
    }
}
