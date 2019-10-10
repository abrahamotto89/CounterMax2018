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
    /// Interaction logic for Window15.xaml
    /// </summary>
    public partial class EsemenyFelvesz : Window
    {

        DateTime d1;
        DateTime dtTodayNoon;
      
        string Ceg;
        int idozitok;
        int kapcsolo = 0;
        string azonosito;
        bool modosit = false;
     
        bool isFelhasznaloi = false;
        bool isModfelh = false;
        string felhasznalonev;
        int felhasznaloId = 0;
        string adatf;
        string adatj;
        public EsemenyFelvesz(string x, string y, bool valtozas, bool isIdozit, string felh,string adat,string z)
        {
            InitializeComponent();
            idozitok = 0;
            Ceg = x;
            adatf = adat;
            adatj = z;
            azonosito = y;
            mod.IsEnabled = false;


            modosit = valtozas;
            if (modosit == true)
            {
                modositas();
            }
        
            idozito.IsChecked = isIdozit;
            felhasznalonev = felh;
            
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (vizsgalat() == true)
            {
              
                string conn2String = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                string conn3String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connection2 = new MySqlConnection(conn2String);
                MySqlConnection connection3 = new MySqlConnection(conn3String);
                MySqlCommand parancs2 = connection2.CreateCommand();
                MySqlCommand cmd = connection3.CreateCommand();
                MySqlCommand parancs = connection3.CreateCommand();
                cmd.CommandText = "Select *from felhasznalok;";

                connection3.Open();

                MySqlDataReader reader3 = cmd.ExecuteReader();
                while (reader3.Read())
                {
                    if (reader3["felhasznaloNev"].ToString() == felhasznalonev)
                    {
                        felhasznaloId = int.Parse(reader3["felhasznaloid"].ToString());
                    }
                }


                connection3.Close();

                string ujido = datum.Text + " " + ido.Text;

                d1 = DateTime.Parse(ujido);



                if (idozitok == 1)
                {
                    if (kapcsolo == 1)
                    {
                        dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day, d1.Hour - 1, d1.Minute, d1.Second);
                    }

                    if (kapcsolo == 2)
                    {
                        dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day, d1.Hour - 3, d1.Minute, d1.Second);
                    }
                    if (kapcsolo == 3)
                    {
                        dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day - 1, d1.Hour, d1.Minute, d1.Second);
                    }
                }
                else
                {
                    dtTodayNoon = new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second);
                }

                connection3.Open();
                connection2.Open();


               
                if (isFelhasznaloi == false)
                {
                    
                    Random rnd = new Random();
                    int id = rnd.Next(1, 999);
                   
                    parancs2.CommandText = "INSERT INTO esemenyek values('" + id + "','" + datum.Text + "','" + ido.Text + "','" + megnevezes.Text + "','" + helyszin.Text + "','" + kontakt.Text + "','" + idozitok + "','" + dtTodayNoon + "');";

                    parancs2.ExecuteNonQuery();
                    connection2.Close();
                    MessageBox.Show("Esemény felvéve");
                }
                else
                {
                    int idv = 0;
                    Random rnd = new Random();
                    idv = rnd.Next(1, 999);
                    parancs.CommandText = "INSERT INTO esemenyek values('" + idv + "','" + datum.Text + "','" + ido.Text + "','" + megnevezes.Text + "','" + helyszin.Text + "','" + kontakt.Text + "','" + idozitok + "','" + dtTodayNoon + "','" + felhasznaloId + "');";

                    parancs.ExecuteNonQuery();
                    connection3.Close();

                    MessageBox.Show("Felhasználói esemény felvéve");
                }





                datum.Text = "";
                ido.Text = "";
                megnevezes.Text = "";
                helyszin.Text = "";
                kontakt.Text = "";
                idozito.IsChecked = false;
                idozitoIdo.IsEnabled = true;
               
                this.Close();

            }

            else
            {
                MessageBox.Show("Kérem Adja meg új az adatokat");
            }

        }







        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            kapcsolo = 1;

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            kapcsolo = 2;
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            kapcsolo = 3;
        }

        private void idozito_Checked(object sender, RoutedEventArgs e)
        {
            idozitok = 1;
        }

        private void idozitoIdo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


          
            this.Close();
            
        }


        public void modositas()
        {
            mod.IsEnabled = true;
            felvetel.IsEnabled = false;
            string connString = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd3 = connection.CreateCommand();
            MySqlCommand cmd4 = connection2.CreateCommand();
            cmd3.CommandText = "Select * FROM esemenyek";
            cmd4.CommandText = "Select * FROM esemenyek";
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }

            try
            {
                connection2.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }

            MySqlDataReader reader1 = cmd3.ExecuteReader();

            MySqlDataReader reader2 = cmd4.ExecuteReader();
            while (reader1.Read())
            {
                if (azonosito == reader1["esemenyId"].ToString())
                {

                   

                    datum.Text = reader1["esemenyNapja"].ToString();
                    ido.Text = reader1["esemenyIdeje"].ToString();
                    megnevezes.Text = reader1["esemenyMegnevezes"].ToString();
                    helyszin.Text = reader1["esemenyHelyszin"].ToString();
                    kontakt.Text = reader1["esemenyKontakt"].ToString();
                    isModfelh = false;









                }




            }
            while (reader2.Read())
            {
                if (azonosito == reader2["esemenyId"].ToString())
                {


                    
                    datum.Text = reader2["esemenyNapja"].ToString();
                    ido.Text = reader2["esemenyIdeje"].ToString();
                    megnevezes.Text = reader2["esemenyMegnevezes"].ToString();
                    helyszin.Text = reader2["esemenyHelyszin"].ToString();
                    kontakt.Text = reader2["esemenyKontakt"].ToString();

                    isModfelh = true;








                }




            }



        }

        private void megnevezes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void helyszin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kontakt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void idozito_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string ujido = datum.Text + " " + ido.Text;
            d1 = DateTime.Parse(ujido);
            if (idozitok == 1)
            {
                if (kapcsolo == 1)
                {
                    dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day, d1.Hour - 1, d1.Minute, d1.Second);
                }

                if (kapcsolo == 2)
                {
                    dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day, d1.Hour - 3, d1.Minute, d1.Second);
                }
                if (kapcsolo == 3)
                {
                    dtTodayNoon = new System.DateTime(d1.Year, d1.Month, d1.Day - 1, d1.Hour, d1.Minute, d1.Second);
                }

                d1 = DateTime.Parse(ujido);

            }
            string conn2String = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            string conn3String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlConnection connection3 = new MySqlConnection(conn3String);
            MySqlCommand cmd2 = connection2.CreateCommand();


            MySqlCommand cmd3 = connection3.CreateCommand();



            if (isModfelh == false)
            {
               
                connection2.Open();
                
                cmd2.CommandText = "update esemenyek set esemenyNapja='" + datum.Text + "',esemenyIdeje='" + ido.Text + "',esemenyMegnevezes='" + megnevezes.Text + "',esemenyHelyszin='" + helyszin.Text + "',esemenyKontakt='" + kontakt.Text + "',esemenyIdozito='" + idozitok + "',esemenyIdozitoIdo='" + dtTodayNoon + "' where esemenyId='" + azonosito + "'";
                cmd2.ExecuteNonQuery();

                connection2.Close();
                MessageBox.Show("Esemény  Módosítva12");
            }
            else
            {
                
                connection3.Open();
                cmd3.CommandText = "update esemenyek set esemenyNapja='" + datum.Text + "',esemenyIdeje='" + ido.Text + "',esemenyMegnevezes='" + megnevezes.Text + "',esemenyHelyszin='" + helyszin.Text + "',esemenyKontakt='" + kontakt.Text + "',esemenyIdozito='" + idozitok + "',esemenyIdozitoIdo='" + dtTodayNoon + "' where esemenyId='" + azonosito + "'";
                cmd3.ExecuteNonQuery();

                connection3.Close();
                MessageBox.Show("Esemény  Módosítva13");
            }


        }

        private void felhasznaloi_Checked(object sender, RoutedEventArgs e)
        {
            isFelhasznaloi = true;
        }
        public bool vizsgalat()
        {
            bool vissza = true;
            if (datum.Text == "")
            {
                MessageBox.Show("Kérem válassza ki a napot!!!");
                vissza = false;
            }
            if (ValidateTime(ido.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul adta meg az időpontot"+"\n Helyes Formátum:00:00:00");
                vissza = false;
            }
            if (ValidatePhone(kontakt.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul adta meg a telefonszámot" + "\n" + "Helyes formátum: +3670-2343119");
                vissza = false;
            }
            return (vissza);
        }
        public bool ValidateTime(string time)
        {
            try
            {
                Regex regExp = new Regex(@"(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])");

                return regExp.IsMatch(time);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ValidatePhone(string phone)
        {
            try
            {
                Regex regExp = new Regex(@"((?:\+?3|0)6)(?:-|\()?(\d{1,2})(?:-|\))?(\d{3})-?(\d{3,4})");

                return regExp.IsMatch(phone);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
    }
