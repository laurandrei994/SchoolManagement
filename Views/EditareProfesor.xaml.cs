using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tema3_GestiuneScoala.Views
{
    /// <summary>
    /// Interaction logic for EditareProfesor.xaml
    /// </summary>
    public partial class EditareProfesor : Window
    {
        public EditareProfesor()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            EditareElev editareElevi = new EditareElev();
            editareElevi.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            EditareProfesor editareProfesori = new EditareProfesor();
            editareProfesori.Show();
            this.Close();
        }
    }
}
