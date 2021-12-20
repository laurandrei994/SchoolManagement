using System.Collections.Generic;
using Tema3_GestiuneScoala.Models.BusinessLogicLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.ViewModels
{
    class EditareProfesorVM : BasePropertyChanged
    {
        ProfesorBLL profesorBLL;
        public Dictionary<Clasa, Profesor> Catalog { get; set; }

        public EditareProfesorVM()
        {
            ClasaBLL clasaBLL = new ClasaBLL();
            Catalog = new Dictionary<Clasa, Profesor>();
            foreach (Clasa clasa in clasaBLL.GetAllClase())
            {
                profesorBLL.GetProfesorForClasa(clasa);
                Catalog.Add(clasa, profesorBLL.profesor);
            }
        }

    }
}
