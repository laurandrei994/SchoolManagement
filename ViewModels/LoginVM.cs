using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.ViewModels
{
    class LoginVM
    {
        public static IList<string> ComboList { get; set; }
        public LoginVM()
        {
            ComboList = new ObservableCollection<string>();
            ComboList.Add("Profesor");
            ComboList.Add("Elev");
            ComboList.Add("Administrator");
            ComboList.Add("Diriginte");
        }
    }
}
