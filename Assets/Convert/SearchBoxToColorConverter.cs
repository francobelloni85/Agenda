using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Agenda.Assets.Convert
{

    class SearchBoxToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            if (value != null)
            {
                if (string.IsNullOrEmpty(value.ToString()) == false) {
                    return System.Windows.Media.Colors.Green;
                }
            }

            return Colors.Red;

            //return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
