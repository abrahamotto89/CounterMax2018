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
    /// Interaction logic for Window33.xaml
    /// </summary>
    public partial class BerfizetesAblak : Window
    {
        string Ceg;
        string adatf;
        string adatj;
        public BerfizetesAblak(string x,string y,string z)
        {
           
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            egyenleg471.Text = lekerdez(Ceg,471).ToString();
            egyenleg384.Text = lekerdez(Ceg, 384).ToString();
            egyenleg3811.Text = lekerdez(Ceg, 3811).ToString();


            valaszt.Text = "384";
            atvezet.IsEnabled = false;
            
        }





        public int lekerdez(string x,int y)
        {
            int count = 0;
            string conn = "SERVER=localhost;DATABASE=" + x + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM szamlatukor where szamlaId='"+y+"';";


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
                count = int.Parse(reader["egyenleg"].ToString());
            }

            return (count);
        }

        private void valaszt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            atvezet.IsEnabled = true;
        }

        private void atvezet_Click(object sender, RoutedEventArgs e)
        {
       
            Konyvel(Ceg, "3811", "389", int.Parse(egyenleg471.Text.ToString()));
            Konyvel(Ceg, "389", "384", int.Parse(egyenleg471.Text.ToString()));
            egyenleg384.Text = lekerdez(Ceg, 384).ToString();
            egyenleg3811.Text = lekerdez(Ceg, 3811).ToString();


        }
        public void Konyvel(string x, string tartozik, string kovetel, int osszeg)
            {
                int tartozikOldalTartozik = 0;
                int tartozikOldalKovetel = 0;
                int kovetelOldalTartozik = 0;
                int kovetelOldalKovetel = 0;
                int tartozikEgyenleg = 0;
                int kovetelEgyenleg = 0;
                int konyvelTartozikT = 0;
            
                int konyvelKovetelK = 0;
                int konyvelEgyenlegT = 0;
                int konyvelEgyenlegK = 0;
                string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection kapcsolat = new MySqlConnection(conn);
                MySqlCommand parancs = kapcsolat.CreateCommand();
                MySqlCommand parancs2 = kapcsolat.CreateCommand();
                MySqlCommand konyvelTartozik = kapcsolat.CreateCommand();
                MySqlCommand konyvelKovetel = kapcsolat.CreateCommand();
                parancs.CommandText = "select *from szamlatukor where szamlaId='" + tartozik + "';";
                parancs2.CommandText = "select *from szamlatukor where szamlaId='" + kovetel + "';";
                try
                {
                    kapcsolat.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader olvaso = parancs.ExecuteReader();
                while (olvaso.Read())
                {
                    tartozikOldalTartozik = int.Parse(olvaso["tartozik"].ToString());
                    tartozikOldalKovetel = int.Parse(olvaso["kovetel"].ToString());
                    tartozikEgyenleg = int.Parse(olvaso["egyenleg"].ToString());

                                }
                konyvelTartozikT = tartozikOldalTartozik + osszeg;
                kapcsolat.Close();
                if (konyvelTartozikT < tartozikOldalKovetel)
                {
                    konyvelEgyenlegT = tartozikOldalKovetel - konyvelTartozikT;

                }
                else
                {
                    konyvelEgyenlegT = konyvelTartozikT - tartozikOldalKovetel;
                }
                konyvelTartozik.CommandText = "update szamlatukor set tartozik='" + konyvelTartozikT + "',egyenleg='" + konyvelEgyenlegT + "' where szamlaId='" + tartozik + "';";
                kapcsolat.Open();
                konyvelTartozik.ExecuteNonQuery();
                kapcsolat.Close();
                try
                {
                    kapcsolat.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MySqlDataReader olvaso2 = parancs2.ExecuteReader();
                while (olvaso2.Read())
                {
                    kovetelOldalTartozik = int.Parse(olvaso2["tartozik"].ToString());
                    kovetelOldalKovetel = int.Parse(olvaso2["kovetel"].ToString());
                    kovetelEgyenleg = int.Parse(olvaso2["egyenleg"].ToString());


                }
                kapcsolat.Close();
                konyvelKovetelK = kovetelOldalKovetel + osszeg;
                if (kovetelOldalTartozik < konyvelKovetelK)
                {
                    konyvelEgyenlegK = konyvelKovetelK - kovetelOldalTartozik;
                }

                else
                {
                    konyvelEgyenlegK = kovetelOldalTartozik - konyvelKovetelK;
                }
                konyvelKovetel.CommandText = "update szamlatukor set kovetel='" + konyvelKovetelK + "', egyenleg='" + konyvelEgyenlegK + "'where szamlaId='" + kovetel + "';";
                kapcsolat.Open();
                konyvelKovetel.ExecuteNonQuery();
                kapcsolat.Close();
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Konyvel(Ceg, "471", valaszt.Text.ToString(), int.Parse(egyenleg471.Text.ToString()));
           
            egyenleg471.Text = lekerdez(Ceg, 471).ToString();
            egyenleg3811.Text = lekerdez(Ceg, 3811).ToString();
            egyenleg384.Text = lekerdez(Ceg, 384).ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}