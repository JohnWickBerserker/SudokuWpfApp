using SudokuWpfApp.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(CellViewModel), typeof(SolidColorBrush))]
    public class CellViewModelToTextBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = value as CellViewModel;
            if (cell != null)
            {
                if (cell.IsFixed)
                {
                    return new SolidColorBrush(Colors.White);
                }
                if (cell.IsBreakingRules)
                {
                    return new SolidColorBrush(Colors.Orange);
                }
                return new SolidColorBrush(Color.FromRgb(150, 150, 150));
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
