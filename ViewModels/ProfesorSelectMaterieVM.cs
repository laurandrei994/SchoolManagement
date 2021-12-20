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
    class ProfesorSelectMaterieVM : BasePropertyChanged
    {
        public ObservableCollection<Materie> materii { get; set; }

        ProfesorBLL profesorBLL = new ProfesorBLL();
        MaterieBLL materieBLL = new MaterieBLL();

        public ProfesorSelectMaterieVM()
        {
            materii = new ObservableCollection<Materie>();
            profesorBLL.GetProfesor(LoginWindow.id);
            materieBLL.GetAllMaterieForProfesor(profesorBLL.profesor);
            materii = materieBLL.MaterieList;

        }

        private ICommand selectMaterie;
        public ICommand SelectMaterie
        {
            get
            {
                if (selectMaterie == null)
                {
                    selectMaterie = new RelayCommand<Materie>(materieBLL.SelectMaterie);
                }
                return selectMaterie;
            }
        }
    }
}
