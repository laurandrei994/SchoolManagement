using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;
using Tema3_GestiuneScoala.ViewModels;
using Tema3_GestiuneScoala.Views;

namespace Tema3_GestiuneScoala.Models.BusinessLogicLayer
{
    class AbsentaBLL
    {
        public ObservableCollection<Absenta> AbsentaList { get; set; }

        public AbsentaBLL()
        {
            AbsentaList = new ObservableCollection<Absenta>();
        }

        public void GetAllAbsentaForMaterie(Materie materie, Elev elev)
        {
            AbsentaList.Clear();
            AbsentaDAL absentaDAL = new AbsentaDAL();
            var absente = absentaDAL.GetAllAbsentaForMaterie(materie, elev);
            foreach (var ph in absente)
            {
                AbsentaList.Add(ph);
            }
        }
        public void GetAllAbsenteForElev(Elev elev)
        {
            AbsentaList.Clear();
            AbsentaDAL absentaDAL = new AbsentaDAL();
            var absente = absentaDAL.GetAllAbsenteForElev(elev);
            foreach (var ph in absente)
            {
                AbsentaList.Add(ph);
            }
        }

        public void MotiveazaAbsenta(Absenta absenta)
        {
            if (absenta.Tip == "Motivabila")
            {
                AbsentaDAL absentaDAL1 = new AbsentaDAL();
                if (absenta == null)
                {
                    //throw new AgendaException("Trebuie precizata o persoana!");
                }
                else
                {
                    AbsentaDAL absentaDAL = new AbsentaDAL();
                }
                absentaDAL1.MotiveazaAbsenta(absenta);
                AbsentaList.Remove(absenta);
            }
            else
            {
                MessageBox.Show("Nu puteti motiva o absenta nemotivabila !!");
            }

        }

        public void GetAllAbsenteForMaterieElev(Elev elev)
        {
            AbsentaList.Clear();
            MaterieBLL materieBLL = new MaterieBLL();
            materieBLL.GetMaterie(ProfesorSelectMaterie.ID);
            AbsentaDAL absentaDAL = new AbsentaDAL();
            var absente = absentaDAL.GetAllAbsentaForMaterie(materieBLL.materie1, elev);
            foreach (var ph in absente)
            {
                AbsentaList.Add(ph);
            }

        }

        public void AddAbsenta(Absenta absenta)
        {
            AbsentaDAL absentaDal = new AbsentaDAL();

            absentaDal.AddAbsenta(absenta, 1, ProfesorVM.index);

            AbsentaList.Add(absenta);
        }
    }
}
