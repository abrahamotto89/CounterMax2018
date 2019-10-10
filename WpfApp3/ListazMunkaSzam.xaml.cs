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
    /// Interaction logic for Window21.xaml
    /// </summary>
    public partial class ListazMunkaSzam : Window
    {

        string Ceg;
        List<Munka> munkaSzamLista { get; set; }
        string adatf;
        string adatj;
        public ListazMunkaSzam(string x,string y,string z)
        {
            InitializeComponent();
            munkaSzamLista = new List<Munka>();
            Ceg = x;
            adatf = y;
            adatj = z;
            munkaSzamLekerdezes(Ceg);
            beillesztes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Munka m1 = (Munka)munkaSzamTetelek.SelectedItems[0];


            string kapcs = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
        

            string s = "INSERT INTO munkaszamok values('"+m1.munkaSzam+"','"+m1.munkaMegnevezes+"')";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FelveszMunkaSzam w22 = new FelveszMunkaSzam(Ceg,adatf,adatj);
            w22.Show();
            this.Close();
        }


        public void munkaSzamLekerdezes(string x)
        {


            string conn = "SERVER=localhost;DATABASE=" + x + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select * FROM munkaSzam";
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

                munkaSzamLista.Add(new Munka
                {
                    munkaSzam = int.Parse(reader["munkaSzam"].ToString()),
                    munkaMegnevezes = reader["munkaMegnevezes"].ToString(),

                }
                );



            }




        }




        public void beillesztes()
        {
            munkasz.Binding = new Binding("munkaSzam");
            megnevezes.Binding = new Binding("munkaMegnevezes");

            int i = 0;

            for (i = 0; i < munkaSzamLista.Count; i++)
            {
                munkaSzamTetelek.Items.Add(new Munka { munkaSzam = munkaSzamLista[i].munkaSzam, munkaMegnevezes = munkaSzamLista[i].munkaMegnevezes });


            }

            DataContext = this;




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string kapcs = "SERVER=localhost;DATABASE="+Ceg+";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection conn = new MySqlConnection(kapcs);
            MySqlCommand cmd=conn.CreateCommand();
          
            conn.Open();
            var selecteditem = (Munka)munkaSzamTetelek.SelectedItems[0];
            Munka m1 = (Munka)munkaSzamTetelek.SelectedItems[0];

            cmd.CommandText = "delete from munkaszam where munkaSzam='"+m1.munkaSzam+"';";
            cmd.ExecuteNonQuery();

            conn.Close();
            munkaSzamTetelek.Items.Remove(selecteditem);


        }
    }
}
