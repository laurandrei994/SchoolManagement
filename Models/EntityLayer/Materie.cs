using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Materie : BasePropertyChanged
    {
        private int? materieID;

        public int? MaterieID
        {
            get
            {
                return materieID;
            }
            set
            {
                materieID = value;
                NotifyPropertyChanged("MaterieID");
            }
        }

        private string nume;
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }
    }
}
