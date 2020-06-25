using QuizbaseBrowser.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Input;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ReactiveWindow<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel,
                                 vm => vm.GoDatabase,
                                 v => v.goDatabaseButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel,
                                 vm => vm.GoNewQuiz,
                                 v => v.goNewQuizButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel,
                                 vm => vm.GoEditQuiz,
                                 v => v.goEditQuizButton)
                    .DisposeWith(disposables);
            });
        }
    }
}
