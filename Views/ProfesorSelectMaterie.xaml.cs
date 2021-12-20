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
    /// Interaction logic for ProfesorSelectMaterie.xaml
    /// </summary>
    public partial class ProfesorSelectMaterie : Window
    {
        public static int ID;
        public ProfesorSelectMaterie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ProfesorWindow profesorV = new ProfesorWindow();
            profesorV.Show();
            this.Close();
        }
    }
}
