using DynamicData;
using DynamicData.Binding;
using QuizbaseBrowser.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace QuizbaseBrowser.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly Quizbase _quizbase;
        readonly SourceCache<Quiz, int> _sourceCache;
        readonly ReadOnlyObservableCollection<Quiz> _quizzes;

        public MainWindowViewModel()
        {
            _quizbase = new Quizbase();
            _quizzes = new ReadOnlyObservableCollection<Quiz>(new ObservableCollection<Quiz>());

            _sourceCache = new SourceCache<Quiz, int>(quiz => quiz.Id);

            var questionFilter = this.WhenAnyValue(viewModel => viewModel.FilterText)
                                     .Throttle(TimeSpan.FromMilliseconds(250))
                                     .Select(QuestionTextFilter);
            var checkIrcFilter = this.WhenAnyValue(viewModel => viewModel.CheckIrc)
                                     .Throttle(TimeSpan.FromMilliseconds(250))
                                     .Select(CheckIrcFilter);
            var checkHomeFilter = this.WhenAnyValue(viewModel => viewModel.CheckHome)
                                     .Throttle(TimeSpan.FromMilliseconds(250))
                                     .Select(CheckHomeFilter);
            var checkFriendsFilter = this.WhenAnyValue(viewModel => viewModel.CheckFriends)
                                         .Throttle(TimeSpan.FromMilliseconds(250))
                                         .Select(CheckFriendsFilter);

            var cancellation = _sourceCache
              .Connect()
              .Filter(questionFilter).Filter(checkIrcFilter).Filter(checkHomeFilter).Filter(checkFriendsFilter)
              .Sort(SortExpressionComparer<Quiz>
                .Ascending(quiz => quiz.Id))
              .ObserveOnDispatcher()
              .Bind(out _quizzes)
              .DisposeMany()
              .Subscribe();

            foreach (var quiz in _quizbase.List.AsObservableList().Items)
                _sourceCache.AddOrUpdate(quiz);
        }

        Func<Quiz, bool> QuestionTextFilter(string filterText)
        {
            return quiz => string.IsNullOrWhiteSpace(filterText) || quiz.Question.ToLowerInvariant().Contains(FilterText.ToLowerInvariant());
        }

        Func<Quiz, bool> CheckIrcFilter(byte check) => quiz => check == 0 || (check == 2 && quiz.CheckIrc) || (check == 1 && !quiz.CheckIrc);
        Func<Quiz, bool> CheckHomeFilter(byte check) => quiz => check == 0 || (check == 2 && quiz.CheckHome) || (check == 1 && !quiz.CheckHome);
        Func<Quiz, bool> CheckFriendsFilter(byte check) => quiz => check == 0 || (check == 2 && quiz.CheckFriends) || (check == 1 && !quiz.CheckFriends);

        public ReadOnlyObservableCollection<Quiz> Quizzes => _quizzes;

        [Reactive]
        public string FilterText { get; set; }
        [Reactive]
        public byte CheckIrc { get; set; }
        [Reactive]
        public byte CheckHome { get; set; }
        [Reactive]
        public byte CheckFriends { get; set; }
    }
}
