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
    class ElevDAL
    {
        public ObservableCollection<Elev> GetAllElev()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetElevi", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev p = new Elev();
                    p.ElevID = (int)(reader[0]);//reader.GetInt(0);
                    p.Nume = reader.GetString(1);//reader[1].ToString();
                    p.Prenume = reader.GetString(2);
                    if (reader.IsDBNull(3)) p.ClasaID = null; else p.ClasaID = (int)(reader[3]);
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

        public ObservableCollection<Elev> GetAllEleviForClase(Clasa clasa)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                SqlCommand cmd = new SqlCommand("GetEleviForClase", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_clasa", clasa.ClasaID);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int clasa1;
                    if (reader.IsDBNull(3)) clasa1 = -1; else clasa1 = reader.GetInt32(3);

                    result.Add(new Elev()
                    {
                        ElevID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),
                        ClasaID = clasa1


                    });
                }
                return result;
            }
        }


        public Elev GetElev(int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                Elev result = new Elev();
                SqlCommand cmd = new SqlCommand("GetElev", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_elev", id);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int clasa1;
                    if (reader.IsDBNull(3)) clasa1 = -1; else clasa1 = reader.GetInt32(3);

                    result = (new Elev()
                    {
                        ElevID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),
                        ClasaID = clasa1


                    });
                }
                return result;
            }
        }
        public void AddElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddElev", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", elev.Nume);
                SqlParameter paramPrenume;
                if (String.IsNullOrEmpty(elev.Prenume))
                {
                    paramPrenume = new SqlParameter("@Prenume", DBNull.Value);
                }
                else
                {
                    paramPrenume = new SqlParameter("@Prenume", elev.Prenume);
                }
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DellElev", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id", elev.ElevID);
                cmd.Parameters.Add(paramIdElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertInClasa(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Insert_in_Class", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@idElev", elev.ElevID);
                SqlParameter paramIdClasa = new SqlParameter("@idClasa", elev.ClasaID);

                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFromClasa(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Delete_from_Class", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@idElev", elev.ElevID);
                SqlParameter paramIdClasa = new SqlParameter("@idClasa", DBNull.Value);

                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Elev> GetAllEleviForMaterie(Materie materie)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                SqlCommand cmd = new SqlCommand("GetAllEleviForMaterie", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@Id_materie", materie.MaterieID);
                cmd.Parameters.Add(paramIdMaterie);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int clasa1;
                    if (reader.IsDBNull(3)) clasa1 = -1; else clasa1 = reader.GetInt32(3);

                    result.Add(new Elev()
                    {
                        ElevID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),
                        ClasaID = clasa1
                    });
                }
                return result;
            }
        }
    }
}
