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
    /// Interaction logic for Window29.xaml
    /// </summary>
    public partial class BerszamDolgozo : Window
    {
        string Ceg;
        double dolgNapSzam = 0.00;
        double tappenz = 0.00;
        double szabadNapok = 0.00;
        double munkaNapokSzama = 0.00;
        double fizetettUnnep = 0.00;
        double szja = 0.00;
        double nyugdij = 0.00;
        double eb = 0.00;
        double munkaeropiaci = 0.00;
        double szochozz = 0.00;
        double kepzesi = 0.00;
        double oraber = 0.00;
        double bruttoBerAlap = 0.00;
       
        double haviber = 0.00;
        double nettoBer = 0.00;
        double betegszabadsagraJutoBer = 0.00;
        double tappenzreJutoBer = 0.00;
     
        double berkoltseg = 0.00;
       
       
        string adatf;
        string adatj;
      
        
        
        public BerszamDolgozo(string x,string y,string z)

        {


            InitializeComponent();


            Ceg = x;
            adatf = y;
            adatj = z;
            megjelenitDolgozok(Ceg);
            kiv.IsEnabled = false;
            ment.IsEnabled = false;
            nettober.IsEnabled = false;

        }



        public void megjelenitDolgozok(string s)
        {


            string conn = "SERVER=localhost;DATABASE=" + s + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM dolgozok";

            azon.Binding = new Binding("id");
            nev.Binding = new Binding("nev");
            szulIdo.Binding = new Binding("dtS");

            try {
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

                    id = int.Parse(reader["dolgozoid"].ToString()),
                    nev = reader["dolgozoNeve"].ToString(),
                    dtS = reader["dolgozoSzulido"].ToString(),
                    szulHely = reader["dolgozoSzulHely"].ToString(),
                    anyjaNeve = reader["anyjaNeve"].ToString(),
                    cime = reader["dolgozoCime"].ToString(),
                    adoSzam = reader["dolgozoAdoAz"].ToString(),
                    tajSzam = reader["dolgozoTajSzam"].ToString(),
                    bankSzamla = reader["dolgozoBank"].ToString(),
                    email = reader["dolgozoMail"].ToString(),
                    dt = reader["dolgozoFelvIdeje"].ToString(),
                    jogviszony = reader["dolgozoJogviszony"].ToString(),
                    haviBer = int.Parse(reader["dolgozoBer"].ToString()),


                });
            }
            DataContext = this;
            connect.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selecteditem = dolgozoLista.SelectedItems[0];
            Dolgozok d1 = (Dolgozok)dolgozoLista.SelectedItems[0];

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
                if (d1.id == int.Parse(reader["dolgozoId"].ToString()))
                {
                    azonText.Text = reader["dolgozoId"].ToString();
                    nevText.Text = reader["dolgozoNeve"].ToString();
                    jogvText.Text = reader["dolgozoJogviszony"].ToString();
                    haviberText.Text = reader["dolgozoBer"].ToString();
                }
            }
            connect.Close();
            nettober.IsEnabled = true;
        }

        private void dolgozoLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kiv.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (ellenorzes() == true)
            {

                haviber = double.Parse(haviberText.Text);
             
                    dolgNapSzam = Double.Parse(dolgNap.Text);
                    tappenz = Double.Parse(tapNap.Text);
                    szabadNapok = Double.Parse(szabadNap.Text);
                    oraber = (haviber / 22) / 8;


                    string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID=" + adatf + ";PASSWORD=" + adatj + ";SSL Mode=None";
                    MySqlConnection connect = new MySqlConnection(conn);
                    MySqlCommand cm = connect.CreateCommand();

                    cm.CommandText = "Select * FROM honapok";



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
                        if (reader["honapNev"].ToString() == honap.Text.ToString())
                        {
                            fizetettUnnep = int.Parse(reader["fizetettUnnep"].ToString());
                            munkaNapokSzama = int.Parse(reader["munkaNapSzam"].ToString());
                        }
                    }


                    fizUnnep.Text = fizetettUnnep.ToString();
                    haviMunkanap.Text = munkaNapokSzama.ToString();

                    if (tappenz == 0 && szabadNapok == 0)
                    {
                        bruttoBerAlap = (munkaNapokSzama + fizetettUnnep) * 8 * (oraber);
                    }

                    else
                        if (tappenz < 15)
                    {

                        bruttoBerAlap = ((dolgNapSzam + fizetettUnnep + szabadNapok) * 8 * oraber) + (((tappenz) * 8) * oraber) * (0.70);
                        betegszabadsagraJutoBer = (tappenz) * (8) * (oraber) * (0.70);
                        bruttoBerAlap = bruttoBerAlap - betegszabadsagraJutoBer;


                    }
                    if (tappenz > 15)
                    {
                        bruttoBerAlap = ((dolgNapSzam + fizetettUnnep + szabadNapok) * 8 * oraber) + (((tappenz) * 8) * oraber) * (0.70);
                        betegszabadsagraJutoBer = (tappenz) * (8) * (oraber) * (0.70);

                        tappenzreJutoBer = (tappenz - 15) * (8) * (oraber) * (0.70);
                        bruttoBerAlap = bruttoBerAlap - tappenzreJutoBer - betegszabadsagraJutoBer;

                    }
                    oraberText.Text = Convert.ToInt32(oraber).ToString();



                    connect.Close();


                    szja = bruttoBerAlap * 0.15;
                    szjaText.Text = Convert.ToInt32(szja).ToString();
                    nyugdij = bruttoBerAlap * 0.1;
                    nyugdijText.Text = Convert.ToInt32(nyugdij).ToString();
                    eb = bruttoBerAlap * 0.07;
                    ebText.Text = Convert.ToInt32(eb).ToString();
                    munkaeropiaci = bruttoBerAlap * 0.015;
                    munkaeropiaciText.Text = Convert.ToInt32(munkaeropiaci).ToString();
                    szochozz = bruttoBerAlap * 0.19;
                    szochozzText.Text = Convert.ToInt32(szochozz).ToString();
                    kepzesi = bruttoBerAlap * 0.015;
                    kepzesiText.Text = Convert.ToInt32(kepzesi).ToString();


                    nettoBer = bruttoBerAlap - (szja + nyugdij + eb + munkaeropiaci);
                    nettoBerText.Text = Convert.ToInt32(nettoBer).ToString();
                    berkoltseg = nettoBer + szochozz + kepzesi;
                    berkoltsegText.Text = Convert.ToInt32(berkoltseg).ToString();
                    ment.IsEnabled = true;

              
                  
               


            }
            else
            {
                MessageBox.Show("Hibásan töltötte ki az jelenléti adatokat");
            }
        }
        

        private void honap_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {


           

        }




        public void jatek(string x)
        {


            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();

            cm.CommandText = "Select * FROM honapok";



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
                if (reader["honapNev"].ToString() == x)
                {
                    fizetettUnnep = int.Parse(reader["fizetettUnnep"].ToString());
                    munkaNapokSzama = int.Parse(reader["munkaNapSzam"].ToString());
                }
            }


            
            fizUnnep.Text = fizetettUnnep.ToString();
            haviMunkanap.Text = munkaNapokSzama.ToString();
            connect.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            jatek(honap.Text.ToString());
        }

        private void honap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            bool voltmar = false;
            int i = 0;
            string connectt = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcsolat = new MySqlConnection(connectt);
            MySqlCommand lekerdezes = kapcsolat.CreateCommand();
            MySqlCommand parancs;
            MySqlCommand parancs2;
            lekerdezes.CommandText = "Select *from bernyilvantartas;";

            kapcsolat.Open();
            MySqlDataReader reader = lekerdezes.ExecuteReader();
            
            while (reader.Read())
            {
                i++;
                if ((azonText.Text.ToString() == reader["dolgozok_dolgozoId"].ToString()) && ((honap.Text).ToString() == (reader["honap"].ToString()))){


                    voltmar = true;


                }
               

            }
            i = i + 1;
            kapcsolat.Close();
            if (voltmar == false)
            {
                string s10 = "INSERT INTO bernyilvantartas VALUES('" + i.ToString() + "','" + jogvText.Text + "','" + honap.Text + "','" + haviberText.Text + "','" + dolgNap.Text + "','" + szabadNap.Text + "','" + fizUnnep.Text + "','" + szjaText.Text + "','" + nyugdijText.Text + "','" + ebText.Text + "','" + munkaeropiaciText.Text + "','" + szochozzText.Text + "','" + kepzesiText.Text + "','" + berkoltsegText.Text + "','" + nettoBerText.Text + "','" + Convert.ToInt32(bruttoBerAlap).ToString() + "','" + (Convert.ToInt32(oraber)).ToString() + "','" + azonText.Text + "','nem könyvelt');";
                string s11 = "update dolgozok set szamfejtesVolt='volt' where dolgozoId='" + azonText.Text + "' ";
                kapcsolat.Open();

                parancs = new MySqlCommand(s10, kapcsolat);
                parancs2 = new MySqlCommand(s11, kapcsolat);


                parancs.ExecuteNonQuery();

                kapcsolat.Close();


                kapcsolat.Open();
                parancs2.ExecuteNonQuery();

                kapcsolat.Close();

                MessageBox.Show("Bérszámfejtés Mentve");
            }
            else
            {
                MessageBox.Show("A dolgozónak volt már az aktuális hónapra bérszámfejtése!!"+"\n Kérem válasszon másik dolgozót!!!");
                azonText.Text = "";
                haviberText.Text = "";
                nevText.Text = "";
                jogvText.Text = "";
                haviMunkanap.Text = "";
                dolgNap.Text = "";
                szabadNap.Text = "";
                tapNap.Text = "";
                fizUnnep.Text = "";
                szjaText.Text = "";
                nyugdijText.Text = "";
                munkaeropiaciText.Text = "";
                szochozzText.Text = "";
                kepzesiText.Text = "";
                nettoBerText.Text = "";
                berkoltsegText.Text = "";
                oraberText.Text = "";
                ebText.Text = "";
            }
        }

        private void konyvel_Click(object sender, RoutedEventArgs e)
        {
            ListazDolgozo w28 = new ListazDolgozo(Ceg,adatf,adatj);
            w28.Show();
        }

        public bool ellenorzes()
        {
            bool vissza = true;

            if (haviMunkanap.Text == "")
            {
                vissza = false;
            }
            if (fizUnnep.Text == "")
            {
                vissza = false;
            }
            if (dolgNap.Text== "")
            {
                vissza = false;
            }
            if (szabadNap.Text == "")
            {
                vissza = false;
            }
            if (tapNap.Text == "")
            {
                vissza = false;
            }

            return (vissza);
        }
    }
}
