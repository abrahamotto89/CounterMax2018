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
using System.Text.RegularExpressions;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class NaploNyito : Window
    {
        string a;
        int tartozikOsszeg=0;
        int kovetelOsszeg=0;
     
        string adatbazisfelhnev;
        string adatbazisjelszo;
        public List<Mydata> tetelLista { get; set; }
        public NaploNyito(string x,string y,bool z,string af,string aj)
        
        {
            InitializeComponent();
            a = x;
            adatbazisfelhnev = af;
            adatbazisjelszo = aj;
            tetelLista = new List<Mydata>();
            ment.IsEnabled = false;
            torl.IsEnabled = false;

        }
        //Kiválasztás 1
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            hozzad1.IsEnabled = true;
            KivalasztSzamla w10 = new KivalasztSzamla(a,"",false,adatbazisfelhnev,adatbazisjelszo);
            w10.Show();


          
        }
        // Tétel felvétel
        private void Button_Click_1(object sender, RoutedEventArgs e)


        
        {



            bool mehet = true;
       
            if(szamEllenorzes(tosszeg.Text)==false || szamEllenorzes(kosszeg.Text) == false)
            {
                mehet = false;
               
                    MessageBox.Show("Rosszul megadott könyvelési érték");
                


                
            }
            else
            {
                if (tosszeg.Text != kosszeg.Text)
                {
                    MessageBox.Show("A tartozik érték nem egyenlő a követel értékkel");
                    mehet = false;
                }
               
            }
       
           
            

            if (elso.Text != "" && harmadik.Text != "" && tosszeg.Text.ToString() != "" && kosszeg.Text.ToString() != "" && date.Text != "" && mehet==true)
            {
                tetelLista.Add(new Mydata
                {
                    tartozik = elso.Text,
                    kovetel = harmadik.Text,
                    partnerkod = pkod.Text,
                    partner = pnev.Text,
                    megnevezes = "Nyitás",
                    tosszeg = int.Parse(tosszeg.Text),
                    kosszeg = int.Parse(kosszeg.Text),
                    dt = date.Text,



                }

                        );



                beillesztes();

            }
            else
            {
                if (date.Text == "")
                {
                    MessageBox.Show("Dátum kitöltése Kötelező");
                }
                if (elso.Text == "")
                {
                    MessageBox.Show("Nem töltötte ki a Tartozik Számlát");
                }

                if (harmadik.Text == "")
                {
                    MessageBox.Show("Nem Töltötte ki a Követel Számlát");

                }

                if (tosszeg.Text.ToString() == "")
                {
                    MessageBox.Show("Tartozik Összeg Hiányzik");

                }
                if (kosszeg.Text.ToString() == "")
                {
                    MessageBox.Show("Követel Összeg Hiányzik");


                }

                
                    
          
                
             

            }

                
           




        }
        //Kilépés
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
       
        
    public void beillesztes()
        {

            ment.IsEnabled = true;
            torl.IsEnabled = true;
            int a = 0;
         
            int c = 0;
            t.Binding = new Binding("tartozik");
            k.Binding = new Binding("kovetel");

            partkod.Binding = new Binding("partnerkod");
            part.Binding = new Binding("partner");

            megn.Binding = new Binding("megnevezes");
            Tossz.Binding = new Binding("tosszeg");
            Kossz.Binding = new Binding("kosszeg");

            datum.Binding = new Binding("dt");
            a = int.Parse(tosszeg.Text);
        
            c = int.Parse(kosszeg.Text);

            tetelek.Items.Add(new Mydata { tartozik = elso.Text, kovetel = harmadik.Text,partnerkod=pkod.Text, partner=pnev.Text ,megnevezes="Nyitás",tosszeg=a,kosszeg=c,dt=date.Text});

            elso.Text = "";
            masodik.Text = "";
            harmadik.Text = "";
            negyedik.Text = "";
            tosszeg.Text = "";
            kosszeg.Text="";
            pkod.Text = "";
            pnev.Text = "";

            tartozikOsszeg = a+tartozikOsszeg;
            kovetelOsszeg = c+kovetelOsszeg;



            VegosszegT.Text = tartozikOsszeg.ToString();
            VegosszegK.Text = kovetelOsszeg.ToString();
        }
        //Kiválasztás 2
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            hozzad2.IsEnabled = true;
            KivalasztSzamla w10 = new KivalasztSzamla(a,"",false,adatbazisfelhnev,adatbazisjelszo);
            w10.Show();
        }
        //Hozzáadás 1
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
            string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbazisfelhnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                elso.Text = reader["szamlaszam"].ToString();
                masodik.Text = reader["szamlanev"].ToString();

            }

            connection.Close();
            hozzad1.IsEnabled = false;

        }
        //HOzzáadás 2
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
           
            string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbazisfelhnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                harmadik.Text = reader["szamlaszam"].ToString();
                negyedik.Text = reader["szamlanev"].ToString();

            }

            connection.Close();
            hozzad2.IsEnabled = false;
        }

       
       //Partner kiválasztás
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PartnerKivalaszt w12 = new PartnerKivalaszt(a,false,adatbazisfelhnev,adatbazisjelszo);
            w12.Show();

        }
        //Partner Hozzáadása
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbazisfelhnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd = connection2.CreateCommand();
            cmd.CommandText = "Select * FROM partner";
            try
            {
                connection2.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }



            MySqlDataReader reader = cmd.ExecuteReader();
        


            while (reader.Read())
            {
                pkod.Text = reader["partnerkod"].ToString();
                pnev.Text = reader["partnernev"].ToString();
                



            
            }


           string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbazisfelhnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd3 = connect.CreateCommand();

            connect.Open(); ;




            cmd3.CommandText = "Delete from partner;";
            cmd3.ExecuteNonQuery();

            connection2.Close();
        }
        //Mentés
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {


          
            if (tartozikOsszeg != kovetelOsszeg)
            {
                MessageBox.Show("A Tartozik és Követel összeg nem egyezik");

            }


            else
            {
                if (tetelLista.Count == 0)
                {
                    MessageBox.Show("Kérem vigyen fel tételeket");


                }

                if (tetelLista.Count != 0)
                {



                    string conn2String = "SERVER=localhost;DATABASE=" + a + ";UID="+adatbazisfelhnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
                    Console.WriteLine(conn2String);
                    MySqlConnection connec = new MySqlConnection(conn2String);
                    MySqlCommand cmd2 = connec.CreateCommand();
                    MySqlCommand cmd3 = connec.CreateCommand();
                    MySqlCommand cmd4 = connec.CreateCommand();
                    MySqlCommand cmd5 = connec.CreateCommand();
                    MySqlCommand cmd6 = connec.CreateCommand();
                    MySqlCommand cmd7 = connec.CreateCommand();
                    cmd3.CommandText = "Select * FROM tetelek";
                    

                    connec.Open();

                    MySqlDataReader reader = cmd3.ExecuteReader();
                    int aa = 0;
                    int i = 0;

                    while (reader.Read())
                    {


                        aa++;


                    }




                    connec.Close();




                    connec.Open();





                   












                    int ii = 0;
                    for (i = 0; i < tetelLista.Count; i++)

                    {
                        int t = 0;
                        int p = 0;
                        ii = aa + 1;

                        cmd6.CommandText = "Select tartozik from szamlatukor where szamlaId='"+tetelLista[i].tartozik+"'";
                        int tartozikAkt = 0;
                        int kovetelAkt = 0;
                        MySqlDataReader reader2 = cmd6.ExecuteReader();
                        while (reader2.Read())
                        {

                            tartozikAkt = int.Parse(reader2["tartozik"].ToString());

                        }

                        cmd2.CommandText = "INSERT INTO tetelek Values('" + ii + "','" + tetelLista[i].tartozik + "','" + tetelLista[i].kovetel + "','" + tetelLista[i].partnerkod + "','" + tetelLista[i].partner + "','Nyitás','" + tetelLista[i].tosszeg + "','" + tetelLista[i].kosszeg + "','" + date.Text + "');";
                        connec.Close();

                        connec.Open();
                        cmd2.ExecuteNonQuery();
                        t = tartozikAkt + tetelLista[i].tosszeg;

                        cmd4.CommandText = "update szamlatukor set tartozik='" + t + "' where szamlaId='"+tetelLista[i].tartozik+"' ";


                        cmd7.CommandText = "Select kovetel from szamlatukor where szamlaId='" + tetelLista[i].kovetel + "'";

                        connec.Close();



                        connec.Open();

                        MySqlDataReader reader3 = cmd7.ExecuteReader();
                        while (reader3.Read())
                        {

                            kovetelAkt = int.Parse(reader3["kovetel"].ToString());

                        }



                      
                        p = kovetelAkt + tetelLista[i].kosszeg;


                        connec.Close();



                        connec.Open();
                        cmd5.CommandText = "update szamlatukor set kovetel='" +p+ "' where szamlaId='" + tetelLista[i].kovetel + "' ";
                        cmd4.ExecuteNonQuery();

                        cmd5.ExecuteNonQuery();
                        aa++;
                    }
                    connec.Close();

                for(int h = 0; h < tetelLista.Count(); h++)
                    {
                        tetelLista.RemoveAt(h);
                     
                    }

                    tetelek.Items.Clear();

                    VegosszegT.Text = "";
                    VegosszegK.Text = "";
                    date.Text = "";
                    MessageBox.Show("Sikeres Rögzítése");
                    

                }

            }
        



        }
        //Törlés
        private void torl_Click(object sender, RoutedEventArgs e)
        {

            int i = 0;
            var selecteditem = tetelek.SelectedItem;
            int csokkkentotart = 0;
            int csokkkentokov = 0;
            Mydata c1 = (Mydata)tetelek.SelectedItems[0];
            for (i = 0; i < tetelLista.Count; i++)
            {
                if (tetelLista[i].tartozik == c1.tartozik)
                {
                    csokkkentotart = int.Parse(tetelLista[i].tosszeg.ToString());
                    csokkkentokov = int.Parse(tetelLista[i].kosszeg.ToString());
                    Console.WriteLine(csokkkentotart);
                    Console.WriteLine(csokkkentokov);
                    tetelLista.RemoveAt(i);
                }
            }
            tetelek.Items.Remove(selecteditem);


            int a = 0;
            a = int.Parse(VegosszegT.Text);
            int b = 0;
            b = int.Parse(VegosszegK.Text);

            int torlesUtanTart = 0;
            int torlesUtanKov = 0;
           
            torlesUtanTart = a - csokkkentotart;
            torlesUtanKov = b - csokkkentokov;

            VegosszegT.Text = torlesUtanTart.ToString();
            VegosszegK.Text = torlesUtanKov.ToString();
            date.Text = "";
            
            
        }

        private void tetelek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public static bool szamEllenorzes(string x)
        {
            bool a = true;
            string minta = @"^[1-9][\.\d]*(,\d+)?$";
            string input = x;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;
            Console.WriteLine("hibabababa");

            return (a);
        }
    }
    }

