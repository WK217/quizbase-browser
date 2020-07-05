using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QuizbaseBrowser.View
{
    public class LevelWwtbamToBackgroundConverter : IValueConverter
    {
        //readonly string[] _colorCodes = new string[] { "#ffffff", "#6394ed", "#5985e5", "#507add", "#466fd6", "#3d62ce", "#3655c6", "#2d4abe", "#273eb6", "#1f35ae", "#1929a7", "#13219f", "#0e1797", "#080f8f", "#040687", "#000080" };
        readonly string[] _colorCodes = new string[] { "#ffffff", "#5985e5", "#5985e5", "#5985e5", "#5985e5", "#5985e5", "#3655c6", "#2d4abe", "#273eb6", "#1f35ae", "#1929a7", "#13219f", "#0e1797", "#080f8f", "#040687", "#000080" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(value?.ToString(), out int level);
            var colorConverter = new ColorConverter();
            var colorCode = _colorCodes[0];

            if (level >= 1 && level <= 15)
                colorCode = _colorCodes[level];

            return new SolidColorBrush((Color)colorConverter.ConvertFromInvariantString(colorCode));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
