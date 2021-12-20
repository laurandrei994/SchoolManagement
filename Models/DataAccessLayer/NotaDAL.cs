using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Models.DataAccessLayer
{
    class NotaDAL
    {
        public ObservableCollection<Nota> GetAllNoteForMaterie(Materie materie, Elev elev)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                SqlCommand cmd = new SqlCommand("GetNoteForMaterie", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@materieID", materie.MaterieID);
                SqlParameter paramIdElev = new SqlParameter("@elevID", elev.ElevID);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramIdElev);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Nota()
                    {
                        NotaID = reader.GetInt32(0),
                        Tip = reader.GetString(1),
                        Valoare = reader.GetInt32(2),
                        DateTime1 = reader.GetDateTime(3)

                    });
                }
                return result;
            }
        }

        public void AddNota(Nota nota, int ID_elev, int ID_materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddNota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTip = new SqlParameter("@Tip", nota.Tip);
                SqlParameter paramValoate = new SqlParameter("@Valoare", nota.Valoare);
                SqlParameter paramDate = new SqlParameter("@Date", nota.DateTime1);
                SqlParameter paramElev = new SqlParameter("@id_elev", ID_elev);
                SqlParameter paramMaterie = new SqlParameter("@id_materie", ID_materie);

                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramValoate);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramMaterie);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void ConectNota(int ID_elev, int ID_materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ConectNota", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramElev = new SqlParameter("@id_elev", ID_elev);
                SqlParameter paramMaterie = new SqlParameter("@id_materie", ID_materie);

                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show(ID_elev.ToString() + "Da" + ID_materie.ToString());
        }
    }
}
