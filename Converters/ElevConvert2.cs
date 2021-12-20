using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Converters
{
    class ElevConvert2 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Elev elev = new Elev();
            elev = (Elev)values[1];
            elev.ClasaID = (int)values[0];
            return elev;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Clasa phone = value as Clasa;
            object[] result = new object[3] { phone.DiriginteID, phone.Nume, phone.Specializare };
            return result;
        }
    }
}
