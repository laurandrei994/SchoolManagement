using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class ClasaBLL
    {
        public ObservableCollection<Clasa> PersonsList { get; set; }
        public string ErrorMessage { get; set; }

        ClasaDAL clasaDAL = new ClasaDAL();

        public ObservableCollection<Clasa> GetAllClase()
        {
            return clasaDAL.GetAllClase();
        }

        public Clasa GetClasa(Profesor profesor)
        {
            return clasaDAL.GetClasa(profesor);
        }
    }
}
