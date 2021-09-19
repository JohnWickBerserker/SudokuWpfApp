using SudokuWpfApp.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(CellViewModel), typeof(SolidColorBrush))]
    public class CellViewModelToTextBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var isFixed = (bool)value[0];
            var isBreakingRules = (bool)value[1];
            if (isFixed)
            {
                return new SolidColorBrush(Colors.White);
            }
            if (isBreakingRules)
            {
                return new SolidColorBrush(Colors.Orange);
            }
            return new SolidColorBrush(Color.FromRgb(150, 210, 150));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
