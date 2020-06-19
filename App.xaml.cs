using QuizbaseBrowser.ViewModels;
using QuizbaseBrowser.Views;
using System.Windows;

namespace QuizbaseBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainWindowViewModel();
            var mainView = new MainWindow() { DataContext = mainViewModel };

            mainView.Show();
        }
    }
}
