using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using Tema3_GestiuneScoala.Models.DataAccessLayer;
using Tema3_GestiuneScoala.Models.EntityLayer;

namespace Tema3_GestiuneScoala.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static int id;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Check_Connection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        if (connection.State == ConnectionState.Open) // if connection.Open was successful
                        {
                            MessageBox.Show("You have been successfully connected to the database!");
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.");
                        }
                    }
                    catch (SqlException) { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            finally
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Combo.SelectedValue.Equals("Profesor"))
            {
                if (UserNameText.Text.Contains("@profesor.ro"))
                {
                    if (PasswordText.Password.Equals("prof"))
                    {
                        id = Int32.Parse(IDText.Text);
                        Window profWindow = new ProfesorWindow();
                        profWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Date incorecte pentru logare !!");
                    }
                }
                else
                {
                    MessageBox.Show("Date incorecte pentru logare !!");
                }
            }
            else if (Combo.SelectedValue.Equals("Administrator"))
            {
                if (UserNameText.Text.Contains("@admin.ro"))
                {
                    if (PasswordText.Password.Equals("admin"))
                    {
                        Window adminWindow = new AdministratorWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Date incorecte pentru logare !!");
                    }
                }
                else
                {
                    MessageBox.Show("Date incorecte pentru logare !!");
                }
            }
            else if (Combo.SelectedValue.Equals("Diriginte"))
            {
                if (UserNameText.Text.Contains("@diriginte.ro"))
                {
                    if (PasswordText.Password.Equals("dirig"))
                    {
                        id = Int32.Parse(IDText.Text);
                        Window dirigWindow = new DiriginteWindow();
                        dirigWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Date incorecte pentru logare !!");
                    }
                }
                else
                {
                    MessageBox.Show("Date incorecte pentru logare !!");
                }
            }
            else if (Combo.SelectedValue.Equals("Elev"))
            {
                if (UserNameText.Text.Contains("@elev.ro"))
                {
                    id = Int32.Parse(IDText.Text);
                    ElevWindow elevWindow = new ElevWindow();
                    elevWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Date incorecte pentru logare !!");
                }
            }
            else
            {
                MessageBox.Show("Date incorecte pentru logare !!");
            }
        }
    }
}

