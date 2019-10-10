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
using MySql.Data.MySqlClient;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window16.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ellenorizJelszo(fnev.Text, jelszo.Text) == true)
            {

                Bejelentkezes w16 = new Bejelentkezes(fnev.Text, jelszo.Text, true);
                w16.Show();
                this.Close();
            }
        }

        public bool ellenorizJelszo(string a, string b)
        {
            bool vissza = true;
            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID=" + a + ";PASSWORD=" + b + ";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);

            try
            {
                connection2.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                vissza = false;
            }

            connection2.Close();

            return (vissza);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
