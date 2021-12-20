using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3_GestiuneScoala.Models.BusinessLogicLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.ViewModels.Commands;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.ViewModels
{
    class ProfesorVM : BasePropertyChanged
    {
        public static int ID_elev;
        public static int index = LoginWindow.id;
        public MaterieBLL materieBLL;
        public ElevBLL elevBLL;
        public NotaBLL notaBLL;
        public AbsentaBLL absentaBLL;
        public ObservableCollection<Elev> elevs { get; set; }
        public ObservableCollection<Nota> notas { get; set; }

        public ObservableCollection<Absenta> absentas { get; set; }

        public ObservableCollection<Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>> catalog { get; set; }
        public Elev elev;

        public ProfesorVM()
        {
            elev = new Elev();
            materieBLL = new MaterieBLL();
            elevBLL = new ElevBLL();
            materieBLL.GetMaterie(index);
            elevBLL.GetEleviForMaterie(materieBLL.materie1);
            elevs = elevBLL.ElevList;
            notaBLL = new NotaBLL();
            absentaBLL = new AbsentaBLL();
            notas = new ObservableCollection<Nota>();
            absentas = new ObservableCollection<Absenta>();
            notas = notaBLL.NotaList;

            absentas = absentaBLL.AbsentaList;

            catalog = new ObservableCollection<Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>>();
            catalog.Add(null);
            catalog[0] = new Tuple<ObservableCollection<Nota>, ObservableCollection<Absenta>>(notas, absentas);


        }

        private ICommand selectElev;
        public ICommand SelectElev
        {
            get
            {
                if (selectElev == null)
                {
                    selectElev = new RelayCommand<Elev>(SelectElv);
                    //selectElev = new RelayCommand<Elev>(notaBLL.GetAllNoteForMaterieElev);
                }
                return selectElev;
            }
        }
        public void SelectElv(Elev elev)
        {
            ID_elev = (int)(elev.ElevID);
            absentaBLL.GetAllAbsenteForMaterieElev(elev);
            notaBLL.GetAllNoteForMaterieElev(elev);
        }

        private ICommand addNota;
        public ICommand AddNota
        {
            get
            {
                if (addNota == null)
                {
                    addNota = new RelayCommand<Nota>(notaBLL.AddNota);
                }
                return addNota;
            }
        }

        private ICommand addAbsenta;
        public ICommand AddAbsenta
        {
            get
            {
                if (addAbsenta == null)
                {
                    addAbsenta = new RelayCommand<Absenta>(absentaBLL.AddAbsenta);
                }
                return addAbsenta;
            }
        }
    }
}
