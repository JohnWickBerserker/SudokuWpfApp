using SudokuWpfApp.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(HintViewModel), typeof(SolidColorBrush))]
    class HintViewModelToTextBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hint = value as HintViewModel;
            if (hint != null)
            {
                if (hint.IsBreakingRules)
                {
                    return new SolidColorBrush(Colors.Orange);
                }
            }
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
