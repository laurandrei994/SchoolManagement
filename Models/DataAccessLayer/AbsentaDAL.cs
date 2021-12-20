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
    class AbsentaDAL
    {
        public ObservableCollection<Absenta> GetAllAbsentaForMaterie(Materie materie, Elev elev)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {

                ObservableCollection<Absenta> result = new ObservableCollection<Absenta>();
                SqlCommand cmd = new SqlCommand("GetAbsentaForMaterie", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@materieID", materie.MaterieID);
                SqlParameter paramIdElev = new SqlParameter("@elevID", elev.ElevID);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramIdElev);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Absenta()
                    {
                        AbsentaID = reader.GetInt32(0),
                        Tip = reader.GetString(1),
                        DateTime1 = reader.GetDateTime(2)

                    });
                }
                return result;
            }
        }

        public ObservableCollection<Absenta> GetAllAbsenteForElev(Elev elev)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Absenta> result = new ObservableCollection<Absenta>();
                SqlCommand cmd = new SqlCommand("GetAbsenteForElev", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@Id_elev", elev.ElevID);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    result.Add(new Absenta()
                    {
                        AbsentaID = reader.GetInt32(0),
                        Tip = reader.GetString(1),
                        DateTime1 = reader.GetDateTime(2)

                    });
                }
                return result;
            }
        }

        public void MotiveazaAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {

                SqlCommand cmd = new SqlCommand("MotiveazaAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbsenta = new SqlParameter("@id_absenta", absenta.AbsentaID);
                cmd.Parameters.Add(paramIdAbsenta);
                con.Open();
                cmd.ExecuteNonQuery();

            }


        }

        public void AddAbsenta(Absenta absenta, int ID_elev, int ID_materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTip = new SqlParameter("@Tip", absenta.Tip);

                SqlParameter paramDate = new SqlParameter("@Date", absenta.DateTime1);
                SqlParameter paramElev = new SqlParameter("@id_elev", ID_elev);
                SqlParameter paramMaterie = new SqlParameter("@id_materie", ID_materie);

                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramMaterie);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
