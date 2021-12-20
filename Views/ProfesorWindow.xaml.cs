using System.Windows;

namespace Tema3_GestiuneScoala.Views
{
    /// <summary>
    /// Interaction logic for ProfesorWindow.xaml
    /// </summary>
    public partial class ProfesorWindow : Window
    {
        public ProfesorWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
