using DynamicData;
using System;
using System.Globalization;
using System.Windows.Data;

namespace QuizbaseBrowser.View
{
    /// <summary>
    /// Конвертирование цифрового идентификатора варианта ответа в буквенное обозначение.
    /// </summary>
    public class AnswerIdToLetterConverter : IValueConverter
    {
        readonly string[] _ids = { "A", "B", "C", "D" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return _ids[0];

            return _ids[Math.Max(Math.Min((int)value - 1, 0), 3)];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _ids.IndexOf(value.ToString()) + 1;
        }
    }
}
