using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    class ModeToBgColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool on)
            {
                if (on)
                {
                    return new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
