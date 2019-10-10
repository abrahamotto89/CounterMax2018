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
    /// Interaction logic for Window26.xaml
    /// </summary>
    public partial class OsszesVegyesNaplo : Window
    {
        string Ceg;
        string adatf;
        string adatj;
        public OsszesVegyesNaplo(string x,string y,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;

            megJelenit(Ceg, true);
        }
        public void megJelenit(string y, bool x)
        {
            string conn = "SERVER=localhost;DATABASE=" + y + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM vegyesnaploosszegzes";

            sorsz.Binding = new Binding("sorSzam");
            megj.Binding = new Binding("megjegyzes");
            bizsz.Binding = new Binding("bizonylatSzam");
            munka.Binding = new Binding("munkaKod");
            partner.Binding = new Binding("partnerKod");
            osszeg.Binding = new Binding("naploOsszeg");
            datum.Binding = new Binding("DaT");


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
                VegyesListaz.Items.Add(new VegyesNaplo
                {
                    sorSzam = reader["sorSzam"].ToString(),
                    megjegyzes = reader["megjegyzes"].ToString(),
                    bizonylatSzam = reader["bizonylatSzam"].ToString(),
                    munkaKod = int.Parse(reader["munkaKod"].ToString()),
                    partnerKod = int.Parse(reader["partnerKod"].ToString()),
                    DaT = DateTime.Parse(reader["datum"].ToString()),
                    naploOsszeg = int.Parse(reader["naploOsszeg"].ToString()),




                });
            }
            DataContext = this;
            connect.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VegyesListaz.Items.Clear();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            string dt = tol.Text.ToString();
            string di = ig.Text.ToString();






            cm.CommandText = "Select * FROM vegyesnaploosszegzes where datum between '" + dt + "' AND '" + di + "';";
            sorsz.Binding = new Binding("sorSzam");
            megj.Binding = new Binding("megjegyzes");
            bizsz.Binding = new Binding("bizonylatSzam");
            munka.Binding = new Binding("munkaKod");
            partner.Binding = new Binding("partnerKod");
            osszeg.Binding = new Binding("naploOsszeg");
            datum.Binding = new Binding("DaT");
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
                VegyesListaz.Items.Add(new VegyesNaplo
                {
                    sorSzam = reader["sorSzam"].ToString(),
                    megjegyzes = reader["megjegyzes"].ToString(),
                    bizonylatSzam = reader["bizonylatSzam"].ToString(),
                    munkaKod = int.Parse(reader["munkaKod"].ToString()),
                    partnerKod = int.Parse(reader["partnerKod"].ToString()),
                    DaT = DateTime.Parse(reader["datum"].ToString()),
                    naploOsszeg = int.Parse(reader["naploOsszeg"].ToString()),
                });
            }
            DataContext = this;
            connect.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();





        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NaploVevoSzallito w8 = new NaploVevoSzallito(Ceg,adatf,adatj);
            w8.Show();
        }
    }

}
