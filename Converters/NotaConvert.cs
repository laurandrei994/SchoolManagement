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
    class NotaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {

                Nota nota = new Nota();
                try
                {
                    nota.Valoare = Int32.Parse(values[0].ToString());
                }
                catch
                { }

                nota.Tip = values[1].ToString();

                nota.DateTime1 = DateTime.Today;
                return nota;
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
