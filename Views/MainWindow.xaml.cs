using QuizbaseBrowser.ViewModel;
using System.Windows;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditQuizWindow editQuizWindow = new EditQuizWindow { DataContext = (DataContext as MainWindowViewModel).NewQuizViewModel };
            editQuizWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditQuizWindow editQuizWindow = new EditQuizWindow { DataContext = (DataContext as MainWindowViewModel).EditQuizViewModel };
            editQuizWindow.ShowDialog();
        }
    }
}
