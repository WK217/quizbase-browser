using DynamicData;
using DynamicData.Binding;
using QuizbaseBrowser.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace QuizbaseBrowser.ViewModel
{
    public class DatabaseViewModel : ViewModelBase, IRoutableViewModel
    {
        readonly Quizbase _quizbase;
        readonly ReadOnlyObservableCollection<Quiz> _quizzes = new ReadOnlyObservableCollection<Quiz>(new ObservableCollection<Quiz>());

        public DatabaseViewModel(Quizbase quizbase, IScreen screen = null)
        {
            _quizbase = quizbase;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            #region Инициализация фильтров
            var questionFilter = this.WhenAnyValue(vm => vm.FilterQuestionText)
                                     .Throttle(TimeSpan.FromMilliseconds(250))
                                     .Select(QuestionTextFilter);
            var themeFilter = this.WhenAnyValue(vm => vm.FilterThemeText)
                                  .Throttle(TimeSpan.FromMilliseconds(250))
                                  .Select(ThemeTextFilter);

            var checkIrcFilter = this.WhenAnyValue(vm => vm.CheckIrc)
                                     .Throttle(TimeSpan.FromMilliseconds(250))
                                     .Select(CheckIrcFilter);
            var checkHomeFilter = this.WhenAnyValue(vm => vm.CheckHome)
                                      .Throttle(TimeSpan.FromMilliseconds(250))
                                      .Select(CheckHomeFilter);
            var checkFriendsFilter = this.WhenAnyValue(vm => vm.CheckFriends)
                                         .Throttle(TimeSpan.FromMilliseconds(250))
                                         .Select(CheckFriendsFilter);
            #endregion

            var cancellation = _quizbase.List
              .Connect()
              .Filter(questionFilter).Filter(themeFilter).Filter(checkIrcFilter).Filter(checkHomeFilter).Filter(checkFriendsFilter)
              .Sort(SortExpressionComparer<Quiz>
                .Ascending(quiz => quiz.Id))
              .ObserveOnDispatcher()
              .Bind(out _quizzes)
              .DisposeMany()
              .Subscribe();
        }

        public ReadOnlyObservableCollection<Quiz> Quizzes => _quizzes;

        [Reactive]
        public Quiz SelectedQuiz { get; set; }

        #region Параметры фильтра
        [Reactive]
        public string FilterThemeText { get; set; }
        [Reactive]
        public string FilterQuestionText { get; set; }

        [Reactive]
        public byte CheckIrc { get; set; }
        [Reactive]
        public byte CheckHome { get; set; }
        [Reactive]
        public byte CheckFriends { get; set; }
        #endregion

        #region Фильтрация
        Func<Quiz, bool> QuestionTextFilter(string filterText) =>
            quiz => string.IsNullOrWhiteSpace(filterText) || quiz.Question.ToLowerInvariant().Contains(FilterQuestionText.ToLowerInvariant());
        Func<Quiz, bool> ThemeTextFilter(string filterText) =>
            quiz => string.IsNullOrWhiteSpace(filterText) || quiz.Theme.ToLowerInvariant().Contains(FilterQuestionText.ToLowerInvariant());

        Func<Quiz, bool> CheckIrcFilter(byte check) =>
            quiz => check == 0 || (check == 2 && quiz.CheckIrc) || (check == 1 && !quiz.CheckIrc);
        Func<Quiz, bool> CheckHomeFilter(byte check) =>
            quiz => check == 0 || (check == 2 && quiz.CheckHome) || (check == 1 && !quiz.CheckHome);
        Func<Quiz, bool> CheckFriendsFilter(byte check) =>
            quiz => check == 0 || (check == 2 && quiz.CheckFriends) || (check == 1 && !quiz.CheckFriends);
        #endregion

        #region Routing
        public string UrlPathSegment => "database";
        public IScreen HostScreen { get; }
        #endregion
    }
}
