using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class ElevBLL
    {
        public ObservableCollection<Elev> ElevList { get; set; }
        public Dictionary<Clasa, ObservableCollection<Elev>> Catalog { get; set; }
        public string ErrorMessage { get; set; }
        ElevDAL elevDal = new ElevDAL();

        public Elev elev2;

        public ElevBLL()
        {
            ElevList = new ObservableCollection<Elev>();
            Catalog = new Dictionary<Clasa, ObservableCollection<Elev>>();
        }

        public ObservableCollection<Elev> GetAllElev()
        {
            return elevDal.GetAllElev();
        }

        public void GetEleviForClasa(Clasa clasa)
        {
            ElevList.Clear();
            ElevDAL telefoaneDAL = new ElevDAL();
            var elevi = telefoaneDAL.GetAllEleviForClase(clasa);
            foreach (var ph in elevi)
            {
                ElevList.Add(ph);
            }
        }

        public void GetElev(int id)
        {
            ElevList.Clear();
            ElevDAL telefoaneDAL = new ElevDAL();
            elev2 = telefoaneDAL.GetElev(id);

        }

        public void AddElev(Elev elev)
        {
            if (String.IsNullOrEmpty(elev.Nume))
            {
                //ErrorMessage = "Numele persoanei trebuie sa fie precizat";
                //throw new AgendaException("Numele persoanei trebuie sa fie precizat");
            }
            elevDal.AddElev(elev);

            ElevList.Add(elev);
        }

        public void DeleteElev(Elev elev)
        {
            if (elev == null)
            {
                //throw new AgendaException("Trebuie precizata o persoana!");
            }
            else
            {
                ElevDAL elevDAL = new ElevDAL();

            }
            elevDal.DeleteElev(elev);
            ElevList.Remove(elev);

            foreach (Clasa clasa in Catalog.Keys)
            {
                foreach (Elev elev1 in Catalog[clasa])
                {
                    if (elev1.ElevID == elev.ElevID)
                    {
                        Catalog[clasa].Remove(elev1);
                        break;
                    }
                }
            }
        }

        public void InsertInClasa(Elev elev)
        {
            if (elev == null)
            {
                //throw new AgendaException("Trebuie selectata o persoana");
            }
            elev.ClasaID = Catalog.ElementAt(EditareElev.ID_clasa).Key.ClasaID;
            elevDal.InsertInClasa(elev);

            foreach (Clasa clasa in Catalog.Keys)
            {
                if (clasa.ClasaID == elev.ClasaID)
                {
                    Catalog[clasa].Add(elev);
                    break;
                }
            }


        }

        public void DeleteFromClasa(Elev elev)
        {
            if (elev == null)
            {
                //throw new AgendaException("Trebuie selectata o persoana");
            }
            elevDal.DeleteFromClasa(elev);
            foreach (Clasa clasa in Catalog.Keys)
            {
                foreach (Elev elev1 in Catalog[clasa])
                {
                    if (elev1.ElevID == elev.ElevID)
                    {
                        Catalog[clasa].Remove(elev1);
                        break;
                    }
                }
            }
        }

        public void GetEleviForMaterie(Materie materie)
        {
            ElevList.Clear();
            ElevDAL telefoaneDAL = new ElevDAL();
            var elevi = telefoaneDAL.GetAllEleviForMaterie(materie);
            foreach (var ph in elevi)
            {
                ElevList.Add(ph);
            }
        }
    }
}
