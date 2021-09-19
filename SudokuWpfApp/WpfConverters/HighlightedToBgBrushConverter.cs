using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    class HighlightedToBgBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            if (b)
            {
                return new SolidColorBrush(Color.FromArgb(90, 0, 0, 0));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
