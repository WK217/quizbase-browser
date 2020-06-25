using QuizbaseBrowser.ViewModel;
using ReactiveUI;

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
        }
    }
}
