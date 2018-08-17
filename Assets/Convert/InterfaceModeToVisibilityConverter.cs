using Agenda.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Agenda.Assets.Convert
{    

    public class InterfaceModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value != null)
            {
                InterfaceMode mode = (InterfaceMode)value;
                InterfaceComponents components = (InterfaceComponents)parameter;


                switch(mode){
                    case InterfaceMode.Default:

                        if (components == InterfaceComponents.Rectangle)
                            return System.Windows.Visibility.Hidden;

                        if(components == InterfaceComponents.ModalBox)
                            return System.Windows.Visibility.Hidden;

                        break;

                    case InterfaceMode.ModelON:

                        if (components == InterfaceComponents.Rectangle)
                            return System.Windows.Visibility.Visible;

                        if (components == InterfaceComponents.ModalBox)
                            return System.Windows.Visibility.Visible;

                        break;

                }



            }

            return System.Windows.Visibility.Hidden;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
