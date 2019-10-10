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
using System.Threading;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window10.xaml
    /// </summary>
    public partial class KivalasztSzamla : Window
    {

        public List<SzamlaK> lista { get; set; }
        string felhasznalo;
        string szamla;
        string adatf;
        string adatj;
        bool szukit;
        public KivalasztSzamla(string x, string y, bool z,string adatfnev,string adatjelszo)
        {
            InitializeComponent();
         
            szukit = z;
            adatf = adatfnev;
            adatj = adatjelszo;

            szamla = y;

            felhasznalo = x;


            string conn = "SERVER=localhost;DATABASE=" + felhasznalo + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(conn);
            MySqlCommand cmd = connection.CreateCommand();
            if (szukit == true && szamla == "381") {
                cmd.CommandText = "select *from szamlatukor where szamlaId between 3800 And 3900;";
            }


            if (szukit == true && szamla =="384")
            {
                cmd.CommandText = "select *from szamlatukor where szamlaId='384';";
            }

            if (szukit == false)
            {
                cmd.CommandText = "select *from szamlatukor;";
            }

            connection.Open();


            MySqlDataReader reader = cmd.ExecuteReader();

            lista = new List<SzamlaK>();
            while (reader.Read())
            {



                SzamlaK k1 = new SzamlaK();
                k1.Szamlaszam = int.Parse(reader["szamlaId"].ToString());
                k1.SzamlaNev = reader["szamlaTipus"].ToString();
                lista.Add(k1);








            }
            

            DataContext = this;  
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SzamlaK c1 = (SzamlaK)Lista1.SelectedItems[0];
            


            string kapcs = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
           

            string s = "INSERT INTO szamlak(szamlaszam,szamlanev)VALUES('" + c1.Szamlaszam + "','" + c1.SzamlaNev + "')";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
          
            
           





        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
