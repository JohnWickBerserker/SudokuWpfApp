using SudokuWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuWpfApp.WpfConverters
{
    [ValueConversion(typeof(CellViewModel), typeof(SolidColorBrush))]
    class CellViewModelToBgBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = value as CellViewModel;
            if (cell != null)
            {
                if (cell.IsHighlighted)
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
