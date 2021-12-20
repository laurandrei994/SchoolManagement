﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3_GestiuneScoala.Models.EntityLayer
{
    class Nota : BasePropertyChanged
    {
        private int? notaID;

        public int? NotaID
        {
            get
            {
                return notaID;
            }
            set
            {
                notaID = value;
                NotifyPropertyChanged("NotaID");
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

        private int? valoare;

        public int? Valoare
        {
            get
            {
                return valoare;
            }
            set
            {
                valoare = value;
                NotifyPropertyChanged("Valoare");
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
