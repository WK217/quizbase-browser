using QuizbaseBrowser.ViewModel;
using ReactiveUI;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Логика взаимодействия для NewQuizView.xaml
    /// </summary>
    public partial class NewQuizView : ReactiveUserControl<NewQuizViewModel>
    {
        public NewQuizView()
        {
            InitializeComponent();
        }
    }
}
