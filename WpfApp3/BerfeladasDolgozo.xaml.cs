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
    /// Interaction logic for Window30.xaml
    /// </summary>
    public partial class BerfeladasDolgozo : Window
    {
        string Ceg;
        string adatf;
        string adatj;
        public BerfeladasDolgozo(string x,string y,string z)
        {
            Ceg = x;
            adatf = y;
            adatj = z;
            InitializeComponent();
            megJelenit(Ceg);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




      
            public void megJelenit(string y)
            {
                string conn = "SERVER=localhost;DATABASE=" + y + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cm = connect.CreateCommand();

                cm.CommandText = "Select * FROM dolgozok";
              

                azonosito.Binding = new Binding("id");
                nev.Binding = new Binding("nev");
       

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
                    szamfejtesLista.Items.Add(new Dolgozok
                    {
                        
                        id = int.Parse(reader["dolgozoid"].ToString()),
                        nev = reader["dolgozoNeve"].ToString(),
                        szamfejtes=reader["szamfejtesVolt"].ToString(),
                

                    });
                }
            connect.Close();

         
           
                DataContext = this;
                connect.Close();

            }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int betegszabi = 0;
            var selecteditem = szamfejtesLista.SelectedItems[0];
            Dolgozok d1 = (Dolgozok)szamfejtesLista.SelectedItems[0];

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM bernyilvantartas";
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

                if (d1.id == int.Parse(reader["dolgozok_dolgozoId"].ToString()))
                {
                    bruttoBer.Text = reader["bruttoBer"].ToString();

                    betegszabi = int.Parse(reader["oraBer"].ToString()) * 8 * (22-(int.Parse(reader["ledolgNapok"].ToString())+(int.Parse(reader["szabadNapok"].ToString()))+int.Parse(reader["unnepNapok"].ToString())));
                    betegszBer.Text = betegszabi.ToString();
                    szjaLev.Text = reader["szja"].ToString();
                    nyugdijLev.Text = reader["nyugdij"].ToString();
                    szochozzLev.Text = reader["szocHozza"].ToString();
                    szakkepzesiLev.Text = reader["kepzesiHozza"].ToString();
                    honapX.Text = reader["honap"].ToString();

                }



            }




        }

        private void szochozzLev_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Konyvel(Ceg, "541", "471", int.Parse(bruttoBer.Text.ToString()));
            Konyvel(Ceg, "551", "471", int.Parse(betegszBer.Text.ToString()));
            Konyvel(Ceg, "471", "462", int.Parse(szjaLev.Text.ToString()));
            Konyvel(Ceg, "471", "463", int.Parse(nyugdijLev.Text.ToString()));
            Konyvel(Ceg, "561", "463", int.Parse(szochozzLev.Text.ToString()));
            Konyvel(Ceg, "561", "463", int.Parse(szakkepzesiLev.Text.ToString()));
            var selecteditem = szamfejtesLista.SelectedItems[0];
            Dolgozok d1 = (Dolgozok)szamfejtesLista.SelectedItems[0];
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcsolat = new MySqlConnection(conn);
            MySqlCommand parancs = kapcsolat.CreateCommand();
            kapcsolat.Open();
            parancs.CommandText = "update bernyilvantartas set allapot='könyvelt' where dolgozok_dolgozoId='"+d1.id+"' && honap='"+honapX.Text+"';";
            parancs.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Sikeres bérfeladás");

        }



        public void Konyvel(string x,string tartozik,string kovetel,int osszeg)
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
            parancs.CommandText = "select *from szamlatukor where szamlaId='"+tartozik+"';";
            parancs2.CommandText = "select *from szamlatukor where szamlaId='" + kovetel + "';";
           
            try
            {
                kapcsolat.Open();
            }
            catch(Exception ex)
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
                konyvelEgyenlegT = konyvelTartozikT -tartozikOldalKovetel;
            }


            konyvelTartozik.CommandText = "update szamlatukor set tartozik='" + konyvelTartozikT + "',egyenleg='" + konyvelEgyenlegT + "' where szamlaId='"+tartozik+"';";
            

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



            konyvelKovetel.CommandText = "update szamlatukor set kovetel='" + konyvelKovetelK + "', egyenleg='" + konyvelEgyenlegK + "'where szamlaId='"+kovetel+"';";
            kapcsolat.Open();


            konyvelKovetel.ExecuteNonQuery();

            kapcsolat.Close();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
