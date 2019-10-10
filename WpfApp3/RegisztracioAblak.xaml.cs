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
using System.Text.RegularExpressions;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class RegisztracioAblak : Window
    {
        string adatf;
        string adatj;
        public RegisztracioAblak(string y,string z)
        {
            InitializeComponent();
            adatf = y;
            adatj = z;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ellenoriz() == true)
            {

                
                    int i = 0;
                    string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                    MySqlConnection connection = new MySqlConnection(connString);
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * FROM felhasznalok";

                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        i++;

                    }


                    connection.Close();



                    string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                    MySqlConnection connection2 = new MySqlConnection(conn2String);
                    MySqlCommand cmd2 = connection2.CreateCommand();
                    string felhnev = fn.Text;
                    string jelsz = jsz.Text;
                    string teljesnev = jsz.Text;
                    string beosz = beosztas.Text;
                    string telszam8 = telszam.Text;
                    string nap = "2018-09-06";


                    int idszam = i + 1;
                   


                    cmd2.CommandText = "INSERT INTO felhasznalok(felhasznaloid,felhasznaloNev,jelszo,utolsoBejelentkezes,beosztas,telszam)VALUES('" + idszam + "','" + felhnev + "','" + jelsz + "','" + nap + "','" + beosz + "','" + telszam8 + "');";
                    connection2.Open();
                    cmd2.ExecuteNonQuery();

                    connection2.Close();

                    
                    MessageBox.Show("Sikeres Regisztráció");
                    this.Close();

               
            }
            else
            {
                MessageBox.Show("Kérem ellenőrizze az adatokat!!!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool ellenoriz()
        {
            bool vissza = true;
            if (fn.Text == "")
            {
                vissza = false;
                MessageBox.Show("Nem adott meg felhasználónevet!!!");
            }
            if (jsz.Text == "")
            {
                MessageBox.Show("Nem adott meg jelszavat!!!");
                vissza = false;
            }

            if (teljesnev.Text == "")
            {
                vissza = false;
                MessageBox.Show("Nem adta meg a Teljes nevét!!!");
            }
            if (beosztas.Text == "")
            {
                vissza = false;
                MessageBox.Show("Nem adta meg a beosztását!!!");
            }
            if (telszam.Text == "")
            {
                vissza = false;
                MessageBox.Show("Nem adta meg a telefonszámát!!!");
            }
            if (telEllenorzes(telszam.Text) == false)
            {
                vissza = false;
                MessageBox.Show("Rosszul adta meg a telefonszámot"+"\n Helyes formátum: +36-707896541 ");
            }
          
           
            return (vissza);
        }


        public static bool telEllenorzes(string tel)
        {
            bool a = true;
            string minta = @"[+36]-(\d+)";
            string input = tel;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }


    }
}

