using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.DataAccessLayer
{
    class ClasaDAL
    {
        public ObservableCollection<Clasa> GetAllClase()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClase", con);
                ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa p = new Clasa();
                    p.ClasaID = (int)(reader[0]);//reader.GetInt(0);
                    if (reader.IsDBNull(1)) p.DiriginteID = null; else p.DiriginteID = (int)(reader[1]);
                    p.Nume = reader[2].ToString();
                    p.Specializare = reader[3].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }


        public Clasa GetClasa(Profesor profesor)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClasa", con);
                Clasa result = new Clasa();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_profesor", profesor.ProfesorID);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa p = new Clasa();
                    p.ClasaID = (int)(reader[0]);//reader.GetInt(0);
                    if (reader.IsDBNull(1)) p.DiriginteID = null; else p.DiriginteID = (int)(reader[1]);
                    p.Nume = reader[2].ToString();
                    p.Specializare = reader[3].ToString();
                    result = p;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
