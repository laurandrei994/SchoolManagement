using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Elev : BasePropertyChanged
    {
        private int? elevID;
        private string nume;
        private string prenume;
        private int? clasaID;

        public int? ElevID
        {
            get
            {
                return elevID;
            }
            set
            {
                elevID = value;
                NotifyPropertyChanged("ElevID");
            }
        }

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

        public string Prenume
        {
            get
            {
                return prenume;
            }
            set
            {
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }

        public int? ClasaID
        {
            get
            {
                return clasaID;
            }
            set
            {
                clasaID = value;
                NotifyPropertyChanged("ClasaID");
            }
        }
    }
}
