using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tema3_GestiuneScoala.Models.BusinessLogicLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.ViewModels.Commands;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.ViewModels
{
    class DiriginteVM : BasePropertyChanged
    {
        public ProfesorBLL profesorBLL = new ProfesorBLL();

        public ElevBLL elevBLL3 = new ElevBLL();
        public ClasaBLL clasaBLL = new ClasaBLL();
        public AbsentaBLL absentabll = new AbsentaBLL();
        public Dictionary<Elev, ObservableCollection<Absenta>> Catalog { get; set; }
        public ObservableCollection<Absenta> absentas { get; set; }
        public Profesor profesor { get; set; }
        private int index = LoginWindow.id;

        Elev elev1;

        public DiriginteVM()
        {
            absentas = new ObservableCollection<Absenta>();
            absentas = absentabll.AbsentaList;
            profesorBLL.GetProfesor(index);
            profesor = profesorBLL.profesor;
            Catalog = new Dictionary<Elev, ObservableCollection<Absenta>>();
            elevBLL3.GetEleviForClasa(clasaBLL.GetClasa(profesor));
            foreach (Elev elev in elevBLL3.ElevList)
            {
                AbsentaBLL absentaBLL = new AbsentaBLL();
                absentaBLL.GetAllAbsenteForElev(elev);
                Catalog.Add(elev, absentaBLL.AbsentaList);

            }
            elev1 = new Elev();
            elevBLL3.GetElev(25);
            elev1 = elevBLL3.elev2;
        }

        private ICommand selectElev;
        public ICommand SelectElev
        {
            get
            {
                if (selectElev == null)
                {
                    selectElev = new RelayCommand<Elev>(absentabll.GetAllAbsenteForElev);
                }
                return selectElev;
            }
        }

        private ICommand motiveazaAbsenta;
        public ICommand MotiveazaAbsenta
        {
            get
            {
                if (motiveazaAbsenta == null)
                {
                    motiveazaAbsenta = new RelayCommand<Absenta>(absentabll.MotiveazaAbsenta);
                }
                return motiveazaAbsenta;
            }
        }
    }
}
