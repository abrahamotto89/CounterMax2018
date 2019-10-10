
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Bejelentkezes : Window
    {
        string adatbazisfelhasznev;
        string adatbazisjelszo;
        bool irany;
        public Bejelentkezes(string adatbfnev, string adatbjelsz, bool valto)
        {
            InitializeComponent();
            adatbazisfelhasznev = adatbfnev;
            adatbazisjelszo = adatbjelsz;
            irany = valto;
            Bejelentkezés.IsEnabled = false;
            Regisztacio.IsEnabled = false;
            if (irany == true)
            {
                Bejelentkezés.IsEnabled = true;
                Regisztacio.IsEnabled = true;
            }

        }

        private void Bejelentkez(object sender, RoutedEventArgs e)
        {

            if (felhasznalo.Text != "" && jelszo.Password.ToString() != "")
            {

                string connString = "SERVER=localhost;DATABASE=konyvelok;UID=" + adatbazisfelhasznev + ";PASSWORD=" + adatbazisjelszo + ";SSL Mode=None";
                MySqlConnection connection = new MySqlConnection(connString);
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * FROM felhasznalok";
                try
                {
                    connection.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }



                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {

                    string fn = felhasznalo.Text;
                    string pw = jelszo.Password.ToString();
                    if (fn == reader["felhasznaloNev"].ToString() && pw == reader["jelszo"].ToString())
                    {



                        i = 1;


                        ListazCegek w3 = new ListazCegek(fn,adatbazisfelhasznev,adatbazisjelszo);
                        w3.Show();





                    }

                }
                if (i == 1)
                {
                    MessageBox.Show("Sikeres Bejelentkezés");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Sikertelen Bejelentkezés" + "\nKérem Adja meg újra az adatokat");
                    felhasznalo.Text = "";
                    jelszo.Clear();
                    jelszo.IsEnabled = true;

                }










            }
            else
                MessageBox.Show("Nem töltte ki a bejelentkezési adatokat");




        }

        private void Regisztacio_Click(object sender, RoutedEventArgs e)
        {
            Window sw = new RegisztracioAblak(adatbazisfelhasznev,adatbazisjelszo);
            sw.Show();




        }

        private void felhasznalo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }




    }


}
