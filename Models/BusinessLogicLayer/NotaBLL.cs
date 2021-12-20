using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.ViewModels;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class NotaBLL
    {
        public ObservableCollection<Nota> NotaList { get; set; }

        public NotaBLL()
        {
            NotaList = new ObservableCollection<Nota>();
        }

        public void GetAllNoteForMaterie(Materie materie, Elev elev)
        {
            NotaList.Clear();
            NotaDAL notaDAL = new NotaDAL();
            var notes = notaDAL.GetAllNoteForMaterie(materie, elev);
            foreach (var ph in notes)
            {
                NotaList.Add(ph);
            }
        }

        public void GetAllNoteForMaterieElev(Elev elev)
        {
            NotaList.Clear();
            NotaDAL notaDAL = new NotaDAL();
            MaterieBLL materieBLL = new MaterieBLL();
            materieBLL.GetMaterie(ProfesorSelectMaterie.ID);
            var notes = notaDAL.GetAllNoteForMaterie(materieBLL.materie1, elev);
            foreach (var ph in notes)
            {
                NotaList.Add(ph);
            }

        }

        public void AddNota(Nota nota)
        {
            NotaDAL notaDal = new NotaDAL();

            notaDal.AddNota(nota, 1, ProfesorVM.index);
            //notaDal.ConectNota(ProfesorVM.ID_elev, ProfesorSelectMaterie.ID);


            NotaList.Add(nota);
        }
    }
}
