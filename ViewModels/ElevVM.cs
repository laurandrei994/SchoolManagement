using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tema3_GestiuneScoala.Models.BusinessLogicLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.ViewModels
{
    class ElevVM : BasePropertyChanged
    {
        ElevBLL elevBLL3 = new ElevBLL();
        NotaBLL notaBLL = new NotaBLL();
        public Dictionary<Materie, Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>> Catalog { get; set; }
        int index = LoginWindow.id;

        public Elev elev { get; set; }


        public ElevVM()
        {
            elevBLL3.GetElev(index);
            elev = elevBLL3.elev2;
            MaterieBLL materieBLL = new MaterieBLL();
            materieBLL.GetAllMaterieForElev(elev);
            Catalog = new Dictionary<Materie, Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>>();
            foreach (Materie materie in materieBLL.MaterieList)
            {
                NotaBLL notaBLL = new NotaBLL();
                notaBLL.GetAllNoteForMaterie(materie, elev);
                AbsentaBLL absentaBLL = new AbsentaBLL();
                absentaBLL.GetAllAbsentaForMaterie(materie, elev);


                Catalog.Add(materie, new Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>(notaBLL.NotaList, absentaBLL.AbsentaList));
            }

        }
    }
}
