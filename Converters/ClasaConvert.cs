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
    class ClasaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int personId;
            if (!int.TryParse(values[0].ToString(), out personId))
            {
                return null;
            }
            return new Clasa()
            {
                DiriginteID = personId,
                Nume = values[1].ToString(),
                Specializare = values[2].ToString()
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Clasa phone = value as Clasa;
            object[] result = new object[3] { phone.DiriginteID, phone.Nume, phone.Specializare };
            return result;
        }
    }
}
