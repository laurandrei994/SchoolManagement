using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class ProfesorBLL
    {
        public ProfesorDAL profesorDal = new ProfesorDAL();
        public Profesor profesor = new Profesor();
        public void GetProfesor(int id)
        {

            ProfesorDAL profesorDAL = new ProfesorDAL();
            profesor = profesorDAL.GetProfesor(id);
        }

        public void GetProfesorForClasa(Clasa clasa)
        {

            ProfesorDAL telefoaneDAL = new ProfesorDAL();
            profesor = telefoaneDAL.GetProfesorForClase(clasa);
        }
    }
}
