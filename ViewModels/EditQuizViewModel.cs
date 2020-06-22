using QuizbaseBrowser.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace QuizbaseBrowser.ViewModels
{
    public class EditQuizViewModel : ViewModelBase
    {
        readonly Quizbase _quizbase;

        public EditQuizViewModel(Quizbase quizbase)
        {
            _quizbase = quizbase;

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
            RemoveCommand = ReactiveCommand.Create(() => Remove());
        }

        [Reactive]
        public Quiz Quiz { get; set; }

        public IReactiveCommand ApplyChangesCommand { get; }
        public IReactiveCommand RemoveCommand { get; }

        public void ApplyChanges() => _quizbase.AddOrUpdate(Quiz);
        public void Remove() => _quizbase.Remove(Quiz);
    }
}
