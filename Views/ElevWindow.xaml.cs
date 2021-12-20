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
using Tema3_GestiuneScoala.ViewModels;

namespace Tema3_GestiuneScoala.Views
{
    /// <summary>
    /// Interaction logic for ElevWindow.xaml
    /// </summary>
    public partial class ElevWindow : Window
    {
        //public int ID { get; set; }
        public ElevWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
