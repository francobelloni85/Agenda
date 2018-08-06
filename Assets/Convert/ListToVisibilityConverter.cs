using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Agenda.Assets.Convert
{

    public class ListToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            if (value != null)
            {
                ObservableCollection<Person> t = (ObservableCollection<Person>)value;
                if (t.Count>0) {
                    return System.Windows.Visibility.Visible;
                }
            }

            return System.Windows.Visibility.Hidden;

            //return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
