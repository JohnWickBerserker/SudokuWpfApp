using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    class BreakingRulesToTextBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isBreakingRules = (bool)value;
            if (isBreakingRules)
            {
                return new SolidColorBrush(Colors.Orange);
            }
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
