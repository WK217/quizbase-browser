using QuizbaseBrowser.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Логика взаимодействия для DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : ReactiveUserControl<DatabaseViewModel>
    {
        public DatabaseView()
        {
            InitializeComponent();

            this.WhenActivated(disposableRegistration =>
            {
                this.BindCommand(ViewModel,
                                 vm => vm.ExportCommand,
                                 v => v.menuExportWwtbamXml,
                                 vm => vm.SelectedQuiz)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
