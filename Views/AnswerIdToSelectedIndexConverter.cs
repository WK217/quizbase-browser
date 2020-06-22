using System;
using System.Globalization;
using System.Windows.Data;

namespace QuizbaseBrowser.Views
{
    public class AnswerIdToSelectedIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Min(Math.Max((int)value - 1, 0), 3);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Min(Math.Max((int)value + 1, 1), 4);
        }
    }
}
