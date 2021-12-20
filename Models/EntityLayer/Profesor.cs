using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Profesor : BasePropertyChanged
    {
        private int? profesorID;

        public int? ProfesorID
        {

            get
            {
                return profesorID;
            }
            set
            {
                profesorID = value;
                NotifyPropertyChanged("ProfesorID");
            }
        }

        public string nume;
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

        public string prenume;
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
    }
}
