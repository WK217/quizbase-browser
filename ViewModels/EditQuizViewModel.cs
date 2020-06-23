using QuizbaseBrowser.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace QuizbaseBrowser.ViewModel
{
    public class EditQuizViewModel : ViewModelBase
    {
        readonly Quizbase _quizbase;

        public EditQuizViewModel(Quizbase quizbase)
        {
            _quizbase = quizbase;

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
            RemoveCommand = ReactiveCommand.Create(() => Remove());

            //_testCommand = ReactiveCommand.Create(() => Test());
        }

        /*readonly ICommand _testCommand;
        void Test()
        {
            string pattern = @"(?:(?<theme>.+?)\t)?(?<question>.+?)\t(?<a>.+?)\t(?<b>.+?)\t(?<c>.+?)\t(?<d>.+?)\t(?<correct>A|B|C|D)\t(?<comment>.+)";

            var matches = Regex.Matches(input, pattern);
        }*/

        Quiz _quiz;

        [Reactive]
        public Quiz Quiz
        {
            get => _quiz;
            set
            {
                //_selection?.Dispose();
                this.RaiseAndSetIfChanged(ref _quiz, value);
                //_selection = _quiz.WhenAnyValue(q => q.Question, q => q.A, q => q.B, q => q.C, q => q.C, q => q.D, q => q.Comment).InvokeCommand(_testCommand);
            }
        }

        public IReactiveCommand ApplyChangesCommand { get; }
        public IReactiveCommand RemoveCommand { get; }

        public void ApplyChanges() => _quizbase.AddOrUpdate(Quiz);
        public void Remove() => _quizbase.Remove(Quiz);
    }
}
