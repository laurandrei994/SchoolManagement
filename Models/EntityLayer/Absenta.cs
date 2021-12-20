using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Absenta : BasePropertyChanged
    {
        private int? absentaID;

        public int? AbsentaID
        {
            get
            {
                return absentaID;
            }
            set
            {
                absentaID = value;
                NotifyPropertyChanged("AbsentaID");
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


        private DateTime dateTime1;

        public DateTime DateTime1
        {
            get
            {
                return dateTime1;
            }
            set
            {
                dateTime1 = value;
                NotifyPropertyChanged("DateTime1");
            }
        }
    }
}
