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
    /// Interaction logic for Window28.xaml
    /// </summary>
    public partial class ListazDolgozo : Window
    {
        string Ceg;
        string adatf;
        string adatj;

        public ListazDolgozo(string x,string y,string z)
        {
            InitializeComponent();
           
            Ceg = x;
            adatf = y;
            adatj = z;
            megJelenit(x);
            mod.IsEnabled = false;
            torl.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //kilépés
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //uj dolgozó
            FelveszDolgozo w27 = new FelveszDolgozo(Ceg,0,false,adatf,adatj);
            w27.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //törlés


            var selecteditem = dolgozoLista.SelectedItems[0];
            Dolgozok d1 = (Dolgozok)dolgozoLista.SelectedItems[0];
            dolgozoTorol(Ceg,d1.id);
            dolgozoLista.Items.Remove(selecteditem);

            




        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //módosítás

            var selecteditem = dolgozoLista.SelectedItems[0];
            if (selecteditem == null)
            {
                MessageBox.Show("Kérem jelöljön ki egyet");
            }
            else {
                Dolgozok d1 = (Dolgozok)dolgozoLista.SelectedItems[0];
                FelveszDolgozo w27 = new FelveszDolgozo(Ceg, d1.id, true,adatf,adatj);
                w27.Show();
                this.Close();
            }

        }


        public void megJelenit(string y)
        {
            string conn = "SERVER=localhost;DATABASE=" + y + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM dolgozok";

            azonosito.Binding = new Binding("id");
            nev.Binding = new Binding("nev");
            szulIdo.Binding = new Binding("dtS");
            szulHely.Binding = new Binding("szulHely");
            anyjaNev.Binding = new Binding("anyjaNeve");
           cim.Binding = new Binding("cime");
            adosz.Binding = new Binding("adoSzam");
            tajsz.Binding = new Binding("tajSzam");
         
            felvido.Binding = new Binding("dt");
            jogviszony.Binding = new Binding("jogviszony");
            haviber.Binding = new Binding("haviBer");
            szamfejtes.Binding = new Binding("szamfejtes");
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
                dolgozoLista.Items.Add(new Dolgozok
                {

                    id = int.Parse(reader["dolgozoId"].ToString()),
                    nev = reader["dolgozoNeve"].ToString(),
                    dtS = reader["dolgozoSzulIdo"].ToString(),
                    szulHely = reader["dolgozoSzulHely"].ToString(),
                    anyjaNeve = reader["anyjaNeve"].ToString(),
                    cime = reader["dolgozoCime"].ToString(),
                    adoSzam = reader["dolgozoAdoAz"].ToString(),
                tajSzam= reader["dolgozoTajszam"].ToString(),
                bankSzamla= reader["dolgozoBank"].ToString(),
                email= reader["dolgozoMail"].ToString(),
                dt = reader["dolgozoFelvIdeje"].ToString(),
                jogviszony = reader["dolgozoJogviszony"].ToString(),
                haviBer = int.Parse(reader["dolgozoBer"].ToString()),
                szamfejtes=reader["szamfejtesVolt"].ToString(),

                });
            }
            DataContext = this;
            connect.Close();

        }


        public void dolgozoTorol(string y,int azon)
        {
            string conn = "SERVER=localhost;DATABASE=" + y + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand setidegenkulcs = connect.CreateCommand();
            MySqlCommand onidegenkulcs = connect.CreateCommand();

           connect.Open();
            setidegenkulcs.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";
            setidegenkulcs.ExecuteNonQuery();

            cm.CommandText = "delete from dolgozok where dolgozoId='"+azon+"'";
          
            cm.ExecuteNonQuery();

            onidegenkulcs.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
            onidegenkulcs.ExecuteNonQuery();

            connect.Close();



        }

        private void dolgozoLista_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void dolgozoLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mod.IsEnabled = true;
            torl.IsEnabled = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BerfeladasDolgozo w30 = new BerfeladasDolgozo(Ceg,adatf,adatj);
            w30.Show();
        }
    }
}
