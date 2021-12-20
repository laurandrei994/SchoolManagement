using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Profil : BasePropertyChanged
    {
        private int? profilID;
        public int? ProfilID
        {
            get
            {
                return profilID;
            }
            set
            {
                profilID = value;
                NotifyPropertyChanged("ProfilID");
            }
        }

        private string tip;
        public string Tip
        {
            get
            {
                return tip;
            }
            set
            {
                tip = value;
                NotifyPropertyChanged("Tip");
            }
        }
    }
}
