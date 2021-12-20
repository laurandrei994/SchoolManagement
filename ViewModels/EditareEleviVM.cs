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

namespace Tema3_GestiuneScoala.ViewModels
{
    class EditareEleviVM : BasePropertyChanged
    {
        ElevBLL elevBLL2 = new ElevBLL();
        public Dictionary<Clasa, ObservableCollection<Elev>> Catalog //{ get; set; }
        {
            get
            {
                return elevBLL2.Catalog;
            }
            set
            {
                elevBLL2.Catalog = value;
            }
        }
        public ObservableCollection<Elev> ListaElevi
        {
            get
            {
                return elevBLL2.ElevList;
            }
            set
            {
                elevBLL2.ElevList = value;
            }
        }


        public EditareEleviVM()
        {
            ClasaBLL clasaBLL = new ClasaBLL();
            Catalog = new Dictionary<Clasa, ObservableCollection<Elev>>();
            foreach (Clasa clasa in clasaBLL.GetAllClase())
            {
                ElevBLL elevBLL = new ElevBLL();
                elevBLL.GetEleviForClasa(clasa);
                Catalog.Add(clasa, elevBLL.ElevList);
            }

            ElevBLL elevBLL1 = new ElevBLL();
            ListaElevi = new ObservableCollection<Elev>();
            ListaElevi = elevBLL1.GetAllElev();
        }

        public string ErrorMessage
        {
            get
            {
                return elevBLL2.ErrorMessage;
            }
            set
            {
                elevBLL2.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Elev>(elevBLL2.AddElev);
                }
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Elev>(elevBLL2.DeleteElev);
                }
                return deleteCommand;
            }
        }


        private ICommand insertInClas;
        public ICommand InsertInClas
        {
            get
            {
                if (insertInClas == null)
                {
                    insertInClas = new RelayCommand<Elev>(elevBLL2.InsertInClasa);
                }
                return insertInClas;
            }
        }

        private ICommand deleteFromClas;
        public ICommand DeleteFromClas
        {
            get
            {
                if (deleteFromClas == null)
                {
                    deleteFromClas = new RelayCommand<Elev>(elevBLL2.DeleteFromClasa);
                }
                return deleteFromClas;
            }
        }
    }
}
