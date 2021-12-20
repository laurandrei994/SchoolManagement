using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.DataAccessLayer
{
    class ProfesorDAL
    {
        public Profesor GetProfesor(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                Profesor result = new Profesor();
                SqlCommand cmd = new SqlCommand("GetProfesor", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_Profesor", id);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    result = (new Profesor()
                    {
                        ProfesorID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),



                    });
                }
                return result;
            }
        }

        public Profesor GetProfesorForClase(Clasa clasa)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                Profesor result = new Profesor();
                SqlCommand cmd = new SqlCommand("GetProfesorForClase", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_clasa", clasa.ClasaID);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int clasa1;
                    if (reader.IsDBNull(3)) clasa1 = -1; else clasa1 = reader.GetInt32(3);

                    result.ProfesorID = (int)(reader[0]);
                    result.Nume = reader[1].ToString();
                    result.Prenume = reader[2].ToString();
                }
                return result;
            }
        }
    }
}
