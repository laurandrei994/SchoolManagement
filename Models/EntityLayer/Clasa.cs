using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Clasa : BasePropertyChanged
    {
        private int? clasaID;
        private int? diriginteID;
        private string nume;
        private string specializare;

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

        public int? DiriginteID
        {
            get
            {
                return diriginteID;
            }
            set
            {
                diriginteID = value;
                NotifyPropertyChanged("DiriginteID");
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

        public string Specializare
        {
            get
            {
                return specializare;
            }
            set
            {
                specializare = value;
                NotifyPropertyChanged("Specializare");
            }
        }
    }
}
