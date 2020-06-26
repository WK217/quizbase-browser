using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Логика взаимодействия для QuizView.xaml
    /// </summary>
    public partial class QuizView : UserControl
    {
        public QuizView()
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

        void TextBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox
                && e.Key == Key.V
                && (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
                && (e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift)))
            {
                /*textBox.AcceptsReturn = true;
                textBox.AcceptsTab = true;
                textBox.Text = Clipboard.GetText();
                textBox.AcceptsReturn = false;
                textBox.AcceptsTab = false;*/
                textBox.Text = Clipboard.GetText();
            }
        }
    }
}
