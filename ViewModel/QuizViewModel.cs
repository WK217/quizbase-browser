using DynamicData;
using QuizbaseBrowser.Model;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

namespace QuizbaseBrowser.ViewModel
{
    public abstract class QuizViewModel : ViewModelBase
    {
        readonly protected Quizbase _quizbase;
        protected Quiz _quiz;
        protected IDisposable _notifier;

        public QuizViewModel(Quizbase quizbase, IScreen screen = null)
        {
            _quizbase = quizbase;

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            ApplyChangesCommand = ReactiveCommand.Create(() => ApplyChanges());
        }

        public Quiz Quiz
        {
            get => _quiz;
            protected set
            {
                _notifier?.Dispose();

                this.RaiseAndSetIfChanged(ref _quiz, value);
                _notifier = this.WhenAnyValue(vm => vm.Quiz.Question, q => HandleImport(q))
                                .Subscribe();
            }
        }

        bool HandleImport(string question)
        {
            Regex regex = null;

            var regex1 = new Regex(@"(?:(?<theme>.+)\t)?(?<question>.+)\t(?<a>.+)\t(?<b>.+)\t(?<c>.+)\t(?<d>.+)\t(?<correct>A|B|C|D)(?:\t(?<comment>.+))?");
            var regex2 = new Regex(@"(?:(?<theme>.+)\n)?(?<question>.+)\n(?<a>.+)\n(?<b>.+)\n(?<c>.+)\n(?<d>.+)\n(?<correct>A|B|C|D)(?:\n(?<comment>.+))?");
            var regexWiki = new Regex(@"(?<question>.+)\nA.*? (?<a>.+)\nB.*? (?<b>.+)\nC.*? (?<c>.+)\nD.*? (?<d>.+)\n.* (?<correct>A|B|C|D)");

            if (string.IsNullOrWhiteSpace(question))
                return false;

            var regexprs = new Regex[] { regex1, regex2, regexWiki };

            foreach (var item in regexprs)
                if (item.IsMatch(question))
                    regex = item;

            if (regex is null)
                return false;

            var match = regex.Match(question);
            Quiz.Theme = match.Groups["theme"]?.Value.Trim('\r', '\n');
            Quiz.Question = match.Groups["question"]?.Value.Trim('\r', '\n');
            Quiz.A = match.Groups["a"]?.Value.Trim('\r', '\n');
            Quiz.B = match.Groups["b"]?.Value.Trim('\r', '\n');
            Quiz.C = match.Groups["c"]?.Value.Trim('\r', '\n');
            Quiz.D = match.Groups["d"]?.Value.Trim('\r', '\n');
            Quiz.Correct = (Answer)((new string[] { "A", "B", "C", "D" }).IndexOf(match.Groups["correct"]?.Value.Trim('\r', '\n')) + 1);
            Quiz.Comment = match.Groups["comment"]?.Value.Trim('\r', '\n');

            return true;
        }

        public abstract string Header { get; }

        public IReactiveCommand ApplyChangesCommand { get; }

        public virtual void ApplyChanges() => _quizbase.AddOrUpdate(Quiz);

        #region Routing
        public virtual string UrlPathSegment => "quiz";
        public IScreen HostScreen { get; }
        #endregion
    }
}
