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
    /// Interaction logic for Window24.xaml
    /// </summary>
    public partial class OsszesVevoSzallitoNaplo : Window
    {
        string ceg;
        string adatf;
        string adatj;
        public OsszesVevoSzallitoNaplo(string x,string y,string z)
        {
            ceg = x;
            adatf = y;
            adatj = z;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vevoszallitonaploOsszesito.Items.Clear();



            if (valaszt.Text.ToString() == "311")
            {
                sorszam.Binding = new Binding("sorszam");
                szamlaszam.Binding = new Binding("fokonyviszam");
                nyito.Binding = new Binding("nyitoErtek");
                bizszam.Binding = new Binding("bizszam");
                partner.Binding = new Binding("partnerKod");
                munka.Binding = new Binding("munkaKod");
                megjegyzes.Binding = new Binding("megjegyzes");
                osszeg.Binding = new Binding("osszeg");
                datumf.Binding = new Binding("idoTime");

                string conn = "SERVER=localhost;DATABASE=" + ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cm = connect.CreateCommand();
                cm.CommandText = "Select * FROM vevoszallitonaploosszegzes where fokonyviSzam='311'";
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

                    DateTime d1 = DateTime.Parse(reader["datum"].ToString());



                    vevoszallitonaploOsszesito.Items.Add(new SzallitoVevoNaplo { sorszam = reader["sorszam"].ToString(), fokonyviszam = reader["fokonyviszam"].ToString(), nyitoErtek = int.Parse(reader["nyitoErtek"].ToString()), bizszam = reader["bizonylatSzam"].ToString(), partnerKod = int.Parse(reader["partnerKod"].ToString()), munkaKod = int.Parse(reader["munkaKod"].ToString()), megjegyzes = reader["megjegyzes"].ToString(), osszeg = int.Parse(reader["osszeg"].ToString()), idoTime = new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second) });


                }


                DataContext = this;



            }
            else
               if ( valaszt.Text.ToString() == "4541")
            {
                sorszam.Binding = new Binding("sorszam");
                szamlaszam.Binding = new Binding("fokonyviszam");
                nyito.Binding = new Binding("nyitoErtek");
                bizszam.Binding = new Binding("bizszam");
                partner.Binding = new Binding("partnerKod");
                munka.Binding = new Binding("munkaKod");
                megjegyzes.Binding = new Binding("megjegyzes");
                osszeg.Binding = new Binding("osszeg");
                datumf.Binding = new Binding("idoTime");

                string conn = "SERVER=localhost;DATABASE=" + ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cm = connect.CreateCommand();
                cm.CommandText = "Select * FROM vevoszallitonaploosszegzes where fokonyviSzam='4541'";
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
                    if (valaszt.Text.ToString() == reader["fokonyviSzam"].ToString())
                    {





                        DateTime d1 = DateTime.Parse(reader["datum"].ToString());



                        vevoszallitonaploOsszesito.Items.Add(new SzallitoVevoNaplo { sorszam = reader["sorszam"].ToString(), fokonyviszam = reader["fokonyviszam"].ToString(), nyitoErtek = int.Parse(reader["nyitoErtek"].ToString()), bizszam = reader["bizonylatSzam"].ToString(), partnerKod = int.Parse(reader["partnerKod"].ToString()), munkaKod = int.Parse(reader["munkaKod"].ToString()), megjegyzes = reader["megjegyzes"].ToString(), osszeg = int.Parse(reader["osszeg"].ToString()), idoTime = new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second) });

                    }
                }


                DataContext = this;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NaploVevoSzallito w8 = new NaploVevoSzallito(ceg,adatf,adatj);
            w8.Show();
        }
    }
}
