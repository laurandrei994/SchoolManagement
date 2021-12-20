using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.DataAccessLayer
{
    class MaterieDAL
    {
        public ObservableCollection<Materie> GetAllMaterieForElev(Elev elev)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                SqlCommand cmd = new SqlCommand("GetMateriiForElev", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@elevID", elev.ElevID);
                cmd.Parameters.Add(paramIdElev);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Materie()
                    {
                        MaterieID = reader.GetInt32(0),
                        Nume = reader.GetString(1)
                    });
                }
                return result;
            }
        }

        public ObservableCollection<Materie> GetAllMaterieForProfesor(Profesor profesor)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                SqlCommand cmd = new SqlCommand("GetMateriiForProfesor", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdProfesor = new SqlParameter("@profesorID", profesor.ProfesorID);
                cmd.Parameters.Add(paramIdProfesor);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Materie()
                    {
                        MaterieID = reader.GetInt32(0),
                        Nume = reader.GetString(1)
                    });
                }
                return result;
            }

        }

        public Materie GeMaterie(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                Materie result = new Materie();
                SqlCommand cmd = new SqlCommand("GeMaterie", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@ID", id);
                cmd.Parameters.Add(paramId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Materie()
                    {
                        MaterieID = reader.GetInt32(0),
                        Nume = reader.GetString(1)
                    };
                }
                return result;
            }
        }
    }
}
