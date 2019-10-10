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
    /// Interaction logic for Window27.xaml
    /// </summary>
    public partial class FelveszDolgozo : Window
    {
        string Ceg;
        bool kapcs;
        string adatf;
        string adatj;
        int yy = 0;
        int dolgAzon = 0;
        bool v = false;
        
        public FelveszDolgozo(string x,int y,bool zs,string adat,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = adat;
            adatj = z;
            yy = y;
            kapcs = zs;
            mod.IsEnabled = false;

            if (kapcs == true)
            {
                beill(Ceg,yy);
                mod.IsEnabled = true;
                felv.IsEnabled = false;

            }
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           






        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void beillesztDolgozo()
        {
            string connectt = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcsolat = new MySqlConnection(connectt);
            DateTime d1 = DateTime.Parse(szulIdo.Text.ToString());
            MySqlCommand parancs;
            string s10 = "INSERT INTO dolgozok VALUES('"+dolgAzon+"','"+dolgozoNeve.Text+"','"+d1+"','"+szulHely.Text+"','"+anyjaNeve.Text+"','"+cime.Text+"','"+adoszama.Text+"','"+tajszama.Text+"','"+banksz.Text+"','"+email.Text+"','"+felvetelIdeje.Text+"','"+jogviszonyValaszt.Text+"','"+haviber.Text+"','Nem Volt');";

            parancs = new MySqlCommand(s10, kapcsolat);

            kapcsolat.Open();



            parancs.ExecuteNonQuery();

            kapcsolat.Close();


            MessageBox.Show("Dolgozó Felvéve");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            dolgAzon = rnd.Next(100, 1000);

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select * FROM dolgozok";
            try
            {
                connect.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }



            MySqlDataReader reader = cm.ExecuteReader();


            while (reader.Read())
            {
                if (int.Parse(reader["dolgozoId"].ToString()) == dolgAzon)
                {
                    dolgAzon = rnd.Next(100, 1000);
                }




            }

            vizsgalat();

            if (v == true && elleorizAdatok()==true)
            {
                beillesztDolgozo();

            }
            else
                MessageBox.Show("Hibásan kitöltött adatlap");
                
            //torolKepernyo();
        }

        private void jogviszonyValaszt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void torolKepernyo()
        {
            dolgozoNeve.Text = "";
            cime.Text = "";
            anyjaNeve.Text = "";
            szulHely.Text = "";
            szulIdo.Text = "";
            adoszama.Text = "";
            email.Text = "";
            tajszama.Text = "";
            felvetelIdeje.Text = "";
            haviber.Text = "";
            banksz.Text = "";

        }



        public void beill(string d,int f)
        {
            string conn = "SERVER=localhost;DATABASE=" + d + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select * FROM dolgozok";
            try
            {
                connect.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }



            MySqlDataReader reader = cm.ExecuteReader();


            while (reader.Read())
            {

                if (int.Parse(reader["dolgozoId"].ToString()) == f)
                {

                    dolgozoNeve.Text = reader["dolgozoNeve"].ToString();
                    szulIdo.Text = (reader["dolgozoSzulido"].ToString());
                    szulHely.Text = reader["dolgozoSzulHely"].ToString();
                    anyjaNeve.Text = reader["anyjaNeve"].ToString();
                    cime.Text = reader["dolgozoCime"].ToString();
                    adoszama.Text = reader["dolgozoAdoAz"].ToString();
                    tajszama.Text = reader["dolgozoTajSzam"].ToString();
                    banksz.Text = reader["dolgozoBank"].ToString();
                    email.Text = reader["dolgozoMail"].ToString();
                    felvetelIdeje.Text = reader["dolgozoFelvIdeje"].ToString();
                    jogviszonyValaszt.Text = reader["dolgozoJogviszony"].ToString();
                    haviber.Text = reader["dolgozoBer"].ToString();

                }

            }

            connect.Close();

        }

        private void mod_Click(object sender, RoutedEventArgs e)
        {
             string conn2String = "SERVER=localhost;DATABASE="+Ceg+";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
         
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd2 = connection2.CreateCommand();






            cmd2.CommandText = "update dolgozok set dolgozoId='" + yy + "',dolgozoNeve='" + dolgozoNeve.Text + "',dolgozoSzulIdo='" + szulIdo.Text + "',dolgozoSzulHely='" + szulHely.Text + "',anyjaNeve='" + anyjaNeve.Text + "',dolgozoCime='" + cime.Text + "',dolgozoAdoAz='" + adoszama.Text + "',dolgozoTajSzam='" + tajszama.Text + "',dolgozoBank='" + banksz.Text + "',dolgozoMail='" + email.Text + "',dolgozoFelvIdeje='" + felvetelIdeje.Text + "',dolgozoJogviszony='" + jogviszonyValaszt.Text + "',dolgozoBer='" + haviber.Text + "' where dolgozoId='" + yy + "';";
            connection2.Open();
            cmd2.ExecuteNonQuery();

            connection2.Close();
            MessageBox.Show("Dolgozó Adatok Módosítva");
        }


        public bool vizsgalat()
        {
                v = true;

            if (dolgozoNeve.Text == "" || cime.Text == "" || anyjaNeve.Text == "" || szulHely.Text == "" || szulIdo.Text == "" || adoszama.Text == "" || email.Text == "" || tajszama.Text == "" || felvetelIdeje.Text == "" || haviber.Text == "" || banksz.Text == "")
            {
                v = false;
            }
            

            
            
                return (v);
        }
        public bool elleorizAdatok()
        {
            bool vissza = true;
            bool berellenor = true;
            if (cimEllenorzes(cime.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki a cím mezőt" + "\n Helyes Formátum : 9025, Győr, Budai Nagy Antal utca 15.");


                    vissza = false;
           }

            if (adoszamEllenorzes(adoszama.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki az adószám mezőt"+"\n Helyes formátum : 8747784578");
                vissza = false;
            }

            if (bankszamEllenorzes(banksz.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki a bankszámlaszám mezőt" + "\n Helyes formátum: 00000000-00000000-00000000");
                vissza = false;
            }

            if (emailEllenorzes(email.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki az email- mezőt!!!" + "\n Helyes formátum: fsfsdf@gmail.com");
                vissza = false;
            }
            if (szuletesi(szulIdo.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki a születési időt!!!" + "\n Helyes Formátum : 1989-04-06");
                vissza = false;
            }
            if (tajszamEllenorzes(tajszama.Text.ToString())==false)
            {
                MessageBox.Show("Rosszul töltötte ki a TAJ szám mezőt!!!" + "\n Helyes Formátum: 034054033");
                vissza = false;
            }

            char[] array = haviber.ToString().ToCharArray();
            for (int i = 0; i < array.Length; i++) {
                berellenor = Char.IsDigit(array[i]);
                
            }

            if (berellenor == false)
            {
                MessageBox.Show("Helytelenül adta meg abér adaatokat!!!");
                vissza = false;
            }
            return (vissza);
        }

        public static bool szuletesi(string t)
        {
            bool a = true;
            string minta = @"^[1-2][0-9][0-9][0-9]-[0-9]{2}-[0-9]{2}$";
            string input = t;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }

        public static bool cimEllenorzes(string lakcim)
        {
            bool a = true;
            string minta = @"^[1-9][0-9]{3},[0-9a-zA-Zá-éíóöőúüűÁÉÍŐÖÚÜ\s\\,\-].{10,95}$";
            string input = lakcim;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool adoszamEllenorzes(string ado)
        {
            bool a = true;
            string minta = @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$";
            string input = ado;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool bankszamEllenorzes(string bsz)
        {
            bool a = true;
            string minta = @"^[0-9]{8}-[0-9]{8}-[0-9]{8}$";
            string input = bsz;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool emailEllenorzes(string mail)
        {
            bool a = true;
            string minta = @"[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$";
            string input = mail;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool tajszamEllenorzes(string x)
        {
            bool a = true;
            string minta = @"^[0-9]{9}$";
            string input = x;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
