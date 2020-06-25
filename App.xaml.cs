using QuizbaseBrowser.ViewModel;
using QuizbaseBrowser.View;
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

            MainViewModel mainViewModel = new MainViewModel();
            MainView mainView = new MainView() { ViewModel = mainViewModel };

            mainView.Show();
        }
    }
}
