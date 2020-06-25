using QuizbaseBrowser.Model;
using QuizbaseBrowser.View;
using ReactiveUI;
using Splat;
using System.Reactive;
using System.Reactive.Linq;

namespace QuizbaseBrowser.ViewModel
{
    public class MainViewModel : ViewModelBase, IScreen
    {
        readonly Quizbase _quizbase;

        public MainViewModel()
        {
            _quizbase = new Quizbase();

            DatabaseViewModel = new DatabaseViewModel(_quizbase, this);
            NewQuizViewModel = new NewQuizViewModel(_quizbase, this);
            EditQuizViewModel = new EditQuizViewModel(_quizbase, this);

            DatabaseViewModel.WhenAnyValue(db => db.SelectedQuiz).BindTo(EditQuizViewModel, edit => edit.Quiz);

            var canRemove = this
                .WhenAnyObservable(vm => vm.Router.CurrentViewModel)
                .Select(current => current is DatabaseViewModel);
            RemoveCommand = ReactiveCommand.Create(() => Remove(), canRemove);

            #region Routing
            Router = new RoutingState();

            var databaseView = new DatabaseView() { ViewModel = DatabaseViewModel, DataContext = DatabaseViewModel };
            var newQuizView = new NewQuizView() { ViewModel = NewQuizViewModel, DataContext = NewQuizViewModel };
            var editQuizView = new EditQuizView() { ViewModel = EditQuizViewModel, DataContext = EditQuizViewModel };

            Locator.CurrentMutable.Register(() => databaseView, typeof(IViewFor<DatabaseViewModel>));
            Locator.CurrentMutable.Register(() => newQuizView, typeof(IViewFor<NewQuizViewModel>));
            Locator.CurrentMutable.Register(() => editQuizView, typeof(IViewFor<EditQuizViewModel>));

            GoDatabase = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(DatabaseViewModel));
            GoNewQuiz = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(NewQuizViewModel));
            GoEditQuiz = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(EditQuizViewModel));

            Router.Navigate.Execute(DatabaseViewModel);
            #endregion
        }

        void Remove()
        {
            _quizbase.Remove(DatabaseViewModel.SelectedQuiz);
        }

        public IReactiveCommand RemoveCommand { get; }

        public DatabaseViewModel DatabaseViewModel { get; }
        public NewQuizViewModel NewQuizViewModel { get; }
        public EditQuizViewModel EditQuizViewModel { get; }

        #region Routing
        public RoutingState Router { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoDatabase { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoNewQuiz { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoEditQuiz { get; }
        #endregion
    }
}
