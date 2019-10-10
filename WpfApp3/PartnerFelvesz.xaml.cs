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
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class PartnerFelvesz : Window
    {
        string ceg;
        string adatf;
        string adatj;

        public PartnerFelvesz(string x,string y,string z)
        {
          
            InitializeComponent();
            ceg = x;
            adatf = y;
            adatj = z;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           





            string nev = Nev.Text;
            string asz = Asz.Text;
            string cim = Cim.Text;
            string cegj = Cegj.Text;
            string bank = Bank.Text;
            string banksz = Banksz.Text;
            string tel = Tel.Text;
            string email = Email.Text;
            string iban = Iban.Text;
            bool akcio = true;
            if (telEllenorzes(tel)==false)
            {
                MessageBox.Show("Hibás telefonszám:/n" +
                    "Helyes Formátum=+36-");
                akcio = false;

            }

            if (cimEllenorzes(cim) == false)
            {
                MessageBox.Show("Helytelenül adta meg a lakcímet"+
                    "Helyes Formátum : 9025,Győr,Budai Nagy antal út 15");
                akcio = false;

            }

            if (adoszamEllenorzes(asz)==false)
            {
                MessageBox.Show("Helytelenül adta meg a Adószámot!\n" +
                    "Formátum:65700734-2-08");
                akcio = false;

            }


            if (bankszamEllenorzes(banksz) == false)
            {
                MessageBox.Show("Helytelen Bankszámlaszám!" +
                    " Kérem adja meg helyenen" +
                    "Formátum:11600006-00000000-44810915");
                akcio = false;

            }

            if (emailEllenorzes(email) == false)
            {
                MessageBox.Show("Helytelenül adtam meg az email címet" +
                    "Formátum:bedross@freemail.hu");
                akcio = false;


            }

            if (azonositoEllenorzes(Id.Text)==false || azonositoLekerdezes(Id.Text) == false)
            {
                MessageBox.Show("Létező vagy helytelenül megadott azonosító+\n" +
                    "Formátum:123");
                akcio = false;

            }
            if (nev == ""|| asz=="" || cim=="" || cegj=="" ||bank=="" || banksz=="" || tel=="" || email=="" || iban=="")
            {
                MessageBox.Show("Valamelyik Mezőt nem töltötte ki ");
                akcio = false;

            }
            if (akcio==true) {
                string conn2String = "SERVER=localhost;DATABASE=" + ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                
                MySqlConnection connection2 = new MySqlConnection(conn2String);
                MySqlCommand cmd2 = connection2.CreateCommand();

                string id = Id.Text;





                cmd2.CommandText = "INSERT INTO partnerek VALUES('" + id + "','" + nev + "','" + asz + "','" + cim + "','" + cegj + "','" + bank + "','" + banksz + "','" + tel + "','" + email + "','" + iban + "');";
                connection2.Open();
                cmd2.ExecuteNonQuery();

                connection2.Close();
                MessageBox.Show("Partner felvétele sikeresen megtörtént");
                this.Close();
            }
            
           



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            string minta = @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[1-5]-[0-9][0-9]$";
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
            string input =mail;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool azonositoEllenorzes(string x)
        {
            bool a = true;
            string minta = @"[0-9]{3}$";
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


        public  bool azonositoLekerdezes(string d)
        {
            string conn2String = "SERVER=localhost;DATABASE=" + ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
           
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd2 = connection2.CreateCommand();

            cmd2.CommandText = "Select * FROM partnerek";
            try
            {
                connection2.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }



            MySqlDataReader reader = cmd2.ExecuteReader();
          
            bool idd=true;

            while (reader.Read())
            {

                if (Id.Text.ToString().Equals(reader["partnerId"].ToString()))
                {
                    idd = false;
                }

            }

            return (idd);
        }

    }
}
