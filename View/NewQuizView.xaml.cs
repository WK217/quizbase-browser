using QuizbaseBrowser.ViewModel;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Windows.Navigation;

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

        void UrlTextClick(object sender, RequestNavigateEventArgs e)
        {
            if (Uri.IsWellFormedUriString(e.Uri.AbsoluteUri, UriKind.Absolute) && Uri.TryCreate(e.Uri.AbsoluteUri, UriKind.Absolute, out Uri uri))
            {
                if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                {
                    var psi = new ProcessStartInfo { FileName = uri.AbsoluteUri, UseShellExecute = true };
                    Process.Start(psi);
                }
            }

            e.Handled = true;
        }
    }
}
