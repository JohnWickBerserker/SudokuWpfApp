using SudokuWpfApp.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(HintViewModel), typeof(SolidColorBrush))]
    class HintViewModelToBgBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hint = value as HintViewModel;
            if (hint != null)
            {
                if (hint.IsHighlighted)
                {
                    return new SolidColorBrush(Color.FromArgb(90, 0, 0, 0));
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
