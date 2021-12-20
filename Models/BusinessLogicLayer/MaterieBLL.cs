using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class MaterieBLL
    {
        public ObservableCollection<Materie> MaterieList { get; set; }
        public Materie materie1 = new Materie();

        public MaterieBLL()
        {
            MaterieList = new ObservableCollection<Materie>();
        }

        public void GetAllMaterieForElev(Elev elev)
        {
            MaterieList.Clear();
            MaterieDAL materieDAL = new MaterieDAL();
            var materie = materieDAL.GetAllMaterieForElev(elev);
            foreach (var ph in materie)
            {
                MaterieList.Add(ph);
            }
        }

        public void GetAllMaterieForProfesor(Profesor profesor)
        {
            MaterieList.Clear();
            MaterieDAL materieDAL = new MaterieDAL();
            var materie = materieDAL.GetAllMaterieForProfesor(profesor);
            foreach (var ph in materie)
            {
                MaterieList.Add(ph);
            }
        }

        public void SelectMaterie(Materie materie)
        {
            ProfesorSelectMaterie.ID = (int)(materie.MaterieID);
        }

        public void GetMaterie(int id)
        {
            MaterieList.Clear();
            MaterieDAL materieDAL = new MaterieDAL();
            var materie = materieDAL.GeMaterie(id);
            materie1 = materie;
        }
    }
}
