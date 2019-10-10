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
    /// Interaction logic for Window34.xaml
    /// </summary>
    public partial class ZaroNaploAblak : Window
    {
        string Ceg;
        string adatf;
        string adatj;
        List<SzamlaSzamok> merleg = new List<SzamlaSzamok>();
        List<SzamlaSzamok> szamlatukor = new List<SzamlaSzamok>();
        bool eszkozZaras = false;
        public ZaroNaploAblak(string x ,string y,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            //frissitSzamlatukor();
           

        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBox.Show("Tétel sikeresen rögzítettük");
            tart.Text = "";
            kov.Text = "";
            ossz.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



      

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (otos.IsChecked == true)
            {
                AnyagSzamlak();
                igenybeVettSzolg();
                egyebKoltseg();
                berkoltseg();
                szemelyiJellegu();
                berJarulek();
                ertekcsokkenes();
            }

            if (nyolc.IsChecked == true)
            {
                Console.WriteLine("8as");
            }
            if (adokot.IsChecked == true)
            {
                Console.WriteLine("Adokot");

            }
            if (osztalek.IsChecked == true)
            {
                Console.WriteLine("osztalék");

            }

            if (egynegy.IsChecked == true)
            {
                eszkozzaras();
            }
            MessageBox.Show("A zárás megtörtént");

        }


        public void AnyagSzamlak()
        {
            //Anyagkoltsegátvezetése
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();
           
            int tartozik51 = 0;
            int kovetel51 = 0;
            int egyenleg51 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik811 = 0;
            int kovetel811 = 0;
            int egyenleg811 = 0;
            
            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 51)
                {
                    tartozik51 = int.Parse(reader["tartozik"].ToString());
                    kovetel51= int.Parse(reader["kovetel"].ToString());
                    egyenleg51= int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) ==59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) ==811)
                {
                    tartozik811 = int.Parse(reader["tartozik"].ToString());
                    kovetel811 = int.Parse(reader["kovetel"].ToString());
                    egyenleg811 = int.Parse(reader["egyenleg"].ToString());
                }

               



            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='"+(tartozik51+tartozik59)+"',kovetel='"+(tartozik51+kovetel59)+"',egyenleg='"+egyenleg59+"' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='"+tartozik51+"', egyenleg=0 where szamlaId=51;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='"+(tartozik51+tartozik811)+"',egyenleg='"+(egyenleg811+tartozik51)+"' where szamlaId=811;";
            konyvel.ExecuteNonQuery();

            connect.Close();




     
        }

        public void igenybeVettSzolg()
        {

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik52 = 0;
            int kovetel52 = 0;
            int egyenleg52 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik812 = 0;
            int kovetel812 = 0;
            int egyenleg812 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 52)
                {
                    tartozik52= int.Parse(reader["tartozik"].ToString());
                    kovetel52 = int.Parse(reader["kovetel"].ToString());
                    egyenleg52 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 812)
                {
                    tartozik812 = int.Parse(reader["tartozik"].ToString());
                    kovetel812 = int.Parse(reader["kovetel"].ToString());
                    egyenleg812 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik52 + tartozik59) + "',kovetel='" + (tartozik52 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik52 + "', egyenleg=0 where szamlaId=52;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik52 + tartozik812) + "',egyenleg='" + (egyenleg812 + tartozik52) + "' where szamlaId=812;";
            konyvel.ExecuteNonQuery();

            connect.Close();






        }




        public void egyebKoltseg()
        {





            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik53 = 0;
            int kovetel53 = 0;
            int egyenleg53 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik813 = 0;
            int kovetel813 = 0;
            int egyenleg813 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 53)
                {
                    tartozik53 = int.Parse(reader["tartozik"].ToString());
                    kovetel53 = int.Parse(reader["kovetel"].ToString());
                    egyenleg53 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 813)
                {
                    tartozik813 = int.Parse(reader["tartozik"].ToString());
                    kovetel813 = int.Parse(reader["kovetel"].ToString());
                    egyenleg813 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik53 + tartozik59) + "',kovetel='" + (tartozik53 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik53 + "', egyenleg=0 where szamlaId=53;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik53 + tartozik813) + "',egyenleg='" + (egyenleg813 + tartozik53) + "' where szamlaId=813;";
            konyvel.ExecuteNonQuery();

            connect.Close();
        }
        public void berkoltseg()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik54 = 0;
            int kovetel54 = 0;
            int egyenleg54 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik821 = 0;
            int kovetel821 = 0;
            int egyenleg821 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 54)
                {
                    tartozik54 = int.Parse(reader["tartozik"].ToString());
                    kovetel54 = int.Parse(reader["kovetel"].ToString());
                    egyenleg54 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 821)
                {
                    tartozik821 = int.Parse(reader["tartozik"].ToString());
                    kovetel821 = int.Parse(reader["kovetel"].ToString());
                    egyenleg821 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik54 + tartozik59) + "',kovetel='" + (tartozik54 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik54 + "', egyenleg=0 where szamlaId=54;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik54 + tartozik821) + "',egyenleg='" + (egyenleg821 + tartozik54) + "' where szamlaId=821;";
            konyvel.ExecuteNonQuery();

            connect.Close();
        }


        public void szemelyiJellegu()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik55 = 0;
            int kovetel55 = 0;
            int egyenleg55 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik822 = 0;
            int kovetel822 = 0;
            int egyenleg822 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 55)
                {
                    tartozik55 = int.Parse(reader["tartozik"].ToString());
                    kovetel55 = int.Parse(reader["kovetel"].ToString());
                    egyenleg55 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 822)
                {
                    tartozik822 = int.Parse(reader["tartozik"].ToString());
                    kovetel822 = int.Parse(reader["kovetel"].ToString());
                    egyenleg822 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik55 + tartozik59) + "',kovetel='" + (tartozik55 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik55 + "', egyenleg=0 where szamlaId=55;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik55 + tartozik822) + "',egyenleg='" + (egyenleg822 + tartozik55) + "' where szamlaId=822;";
            konyvel.ExecuteNonQuery();

            connect.Close();
        }

        public void berJarulek()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik56 = 0;
            int kovetel56 = 0;
            int egyenleg56 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik823 = 0;
            int kovetel823 = 0;
            int egyenleg823 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 56)
                {
                    tartozik56 = int.Parse(reader["tartozik"].ToString());
                    kovetel56 = int.Parse(reader["kovetel"].ToString());
                    egyenleg56 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 823)
                {
                    tartozik823= int.Parse(reader["tartozik"].ToString());
                    kovetel823 = int.Parse(reader["kovetel"].ToString());
                    egyenleg823 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik56 + tartozik59) + "',kovetel='" + (tartozik56 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik56 + "', egyenleg=0 where szamlaId=56;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik56 + tartozik823) + "',egyenleg='" + (egyenleg823 + tartozik56) + "' where szamlaId=823;";
            konyvel.ExecuteNonQuery();

            connect.Close();
        }


        public void ertekcsokkenes()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand konyvel = connect.CreateCommand();
            cm.CommandText = "select *from szamlatukor;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();

            int tartozik57 = 0;
            int kovetel57 = 0;
            int egyenleg57 = 0;

            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;
            int tartozik83 = 0;
            int kovetel83 = 0;
            int egyenleg83 = 0;

            while (reader.Read())
            {
                if (int.Parse(reader["szamlaId"].ToString()) == 57)
                {
                    tartozik57 = int.Parse(reader["tartozik"].ToString());
                    kovetel57 = int.Parse(reader["kovetel"].ToString());
                    egyenleg57 = int.Parse(reader["egyenleg"].ToString());

                }
                if (int.Parse(reader["szamlaId"].ToString()) == 59)
                {
                    tartozik59 = int.Parse(reader["tartozik"].ToString());
                    kovetel59 = int.Parse(reader["kovetel"].ToString());
                    egyenleg59 = int.Parse(reader["egyenleg"].ToString());
                }
                if (int.Parse(reader["szamlaId"].ToString()) == 83)
                {
                    tartozik83 = int.Parse(reader["tartozik"].ToString());
                    kovetel83 = int.Parse(reader["kovetel"].ToString());
                    egyenleg83 = int.Parse(reader["egyenleg"].ToString());
                }





            }


            connect.Close();




            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik57 + tartozik59) + "',kovetel='" + (tartozik57 + kovetel59) + "',egyenleg='" + egyenleg59 + "' where szamlaId=59;";

            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set kovetel='" + tartozik57 + "', egyenleg=0 where szamlaId=57;";
            konyvel.ExecuteNonQuery();

            connect.Close();

            connect.Open();

            konyvel.CommandText = "update szamlatukor set tartozik='" + (tartozik57 + tartozik83) + "',egyenleg='" + (egyenleg83 + tartozik57) + "' where szamlaId=83;";
            konyvel.ExecuteNonQuery();

            connect.Close();
        }

        public void frissitSzamlatukor()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();

            MySqlCommand frissittartozik = connect.CreateCommand();
            MySqlCommand frissitkovetel = connect.CreateCommand();
            MySqlCommand frissitegyenleg = connect.CreateCommand();
            cm.CommandText = "Select *from fokonyv;";
            parancs.CommandText = "Select *from szamlatukor;";
            connect.Open();

            MySqlDataReader reader = cm.ExecuteReader();
            

            while (reader.Read())
            {
                merleg.Add(new SzamlaSzamok
                {
                    szamlaSzam = int.Parse(reader["fokonyviSzam"].ToString()),
                    szamlaNev=reader["nev"].ToString(),
                    tartozik=int.Parse(reader["tforgalom"].ToString()),
                    kovetel=int.Parse(reader["kforgalom"].ToString()),
                    egyenleg=int.Parse(reader["egyenleg"].ToString()),

                });



            }

            connect.Close();
            connect.Open();
            MySqlDataReader reader2 = parancs.ExecuteReader();
            while (reader2.Read())
            {
               szamlatukor.Add(new SzamlaSzamok
                {
                    szamlaSzam = int.Parse(reader2["szamlaId"].ToString()),
                    szamlaNev = reader2["szamlaTipus"].ToString(),
                    tartozik = int.Parse(reader2["tartozik"].ToString()),
                    kovetel = int.Parse(reader2["kovetel"].ToString()),
                    egyenleg = int.Parse(reader2["egyenleg"].ToString()),

                });



            }
            connect.Close();
            connect.Open();
           
            for(int i = 0; i < szamlatukor.Count(); i++)
            {
               
                for(int f = 0; f < merleg.Count(); f++)
                {
                    if (szamlatukor[i].szamlaSzam == merleg[f].szamlaSzam)
                    {
                        frissittartozik.CommandText = "update szamlatukor set tartozik='" + merleg[f].tartozik + "',kovetel='" + merleg[f].kovetel + "',egyenleg='" + merleg[f].egyenleg + "' where szamlaId='" + szamlatukor[i].szamlaSzam + "';";
                        frissittartozik.ExecuteNonQuery();

                    }
                }


            }
        }

        private void egynegy_Checked(object sender, RoutedEventArgs e)
        {
            eszkozZaras = true;
        }





        public void eszkozzaras()
        {
            string connString = "SERVER=localhost;DATABASE="+Ceg+";UID="+adatf+";PASSWORD="+adatj+"; Ssl Mode=none";
            MySqlConnection connect = new MySqlConnection(connString);
            MySqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = "Select *from fokonyv;";
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
        
            while (reader.Read())
            {
                if (int.Parse(reader["szamlalo"].ToString()) < 256)
                {
                    if(int.Parse(reader["tforgalom"].ToString()) > int.Parse(reader["kforgalom"].ToString()))
                    {
                        konyvelVegyes(Ceg, "492", reader["fokonyviSzam"].ToString(), Convert.ToDouble(int.Parse(reader["egyenleg"].ToString())),0.00, true);
                    }
                }
            }



        }

        public void konyvelVegyes(string ceg, string t, string k, double a, double b, bool irany)
        {

            int tartozik = 0;

            int kovetel = 0;
            int levAfatartozik = 0;
            int levAfakovetel = 0;
            int levAfaEgyenleg = 0;
            int fizAfatartozik = 0;
            int fizAfakovetel = 0;
            int fizAfaEgyenleg = 0;
            int tartegyenleg = 0;
            int kovegyenleg = 0;
            string conn = "SERVER=localhost;DATABASE=" + ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand cm2 = connect.CreateCommand();
            MySqlCommand cm3 = connect.CreateCommand();
            MySqlCommand cm4 = connect.CreateCommand();
            MySqlCommand cm5 = connect.CreateCommand();
            MySqlCommand cm6 = connect.CreateCommand();

            MySqlCommand cm7 = connect.CreateCommand();

            MySqlCommand cm8 = connect.CreateCommand();

            MySqlCommand cm9 = connect.CreateCommand();
            MySqlCommand cm10 = connect.CreateCommand();


            cm.CommandText = "select tartozik, egyenleg from szamlatukor where szamlaId='" + t + "';";

            cm2.CommandText = "select kovetel, egyenleg from szamlatukor where szamlaId='" + k + "';";

            cm5.CommandText = "Select *from szamlatukor where szamlaId='466';";
            cm6.CommandText = "Select *from szamlatukor where szamlaId='467';";




            connect.Open();



            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                tartozik = int.Parse(reader["tartozik"].ToString());
                tartegyenleg = int.Parse(reader["egyenleg"].ToString());
                Console.WriteLine(tartegyenleg);
            }


            connect.Close();

            connect.Open();

            MySqlDataReader reader2 = cm2.ExecuteReader();
            while (reader2.Read())
            {
                kovetel = int.Parse(reader2["kovetel"].ToString());
                kovegyenleg = int.Parse(reader2["egyenleg"].ToString());

            }

            connect.Close();

            if (irany == true)
            {
                tartozik = tartozik + Convert.ToInt32(a);
                kovetel = kovetel + (Convert.ToInt32(a) - Convert.ToInt32(b));
                tartegyenleg = tartegyenleg + Convert.ToInt32(a);
                Console.WriteLine("tartozikegyenleg" + tartegyenleg);
                kovegyenleg = kovegyenleg + (Convert.ToInt32(a) - Convert.ToInt32(b));
            }


            else
            {
                tartozik = tartozik + (Convert.ToInt32(a) - Convert.ToInt32(b));
                kovetel = kovetel + Convert.ToInt32(a);
                kovegyenleg = kovegyenleg - Convert.ToInt32(a);
                tartegyenleg = tartegyenleg + (Convert.ToInt32(a) - Convert.ToInt32(b));
            }
            connect.Open();



            MySqlDataReader reader5 = cm5.ExecuteReader();
            while (reader5.Read())
            {
                levAfatartozik = int.Parse(reader5["tartozik"].ToString());
                levAfakovetel = int.Parse(reader5["kovetel"].ToString());
                levAfaEgyenleg = int.Parse(reader5["egyenleg"].ToString());


            }
            levAfatartozik = levAfatartozik + Convert.ToInt32(b);
            levAfakovetel = levAfakovetel + Convert.ToInt32(b);
            levAfaEgyenleg = levAfaEgyenleg + Convert.ToInt32(b);
            connect.Close();
            connect.Open();



            MySqlDataReader reader6 = cm6.ExecuteReader();
            while (reader6.Read())
            {
                fizAfatartozik = int.Parse(reader6["tartozik"].ToString());
                fizAfakovetel = int.Parse(reader6["kovetel"].ToString());
                fizAfaEgyenleg = int.Parse(reader6["egyenleg"].ToString());
            }

            fizAfakovetel = fizAfakovetel + Convert.ToInt32(b);
            fizAfatartozik = fizAfatartozik + Convert.ToInt32(b);
            fizAfaEgyenleg = fizAfaEgyenleg + Convert.ToInt32(b);
            connect.Close();


















            connect.Open();



            cm3.CommandText = "update szamlatukor  set tartozik='" + tartozik + "' where szamlaId='" + t + "';";
            cm4.CommandText = "update szamlatukor  set kovetel='" + kovetel + "' where szamlaId='" + k + "';";

            cm8.CommandText = "update szamlatukor set egyenleg='" + tartegyenleg + "' where szamlaId='" + t + "'";
            cm9.CommandText = "update szamlatukor set egyenleg='" + kovegyenleg + "' where szamlaId='" + k + "'";

            cm3.ExecuteNonQuery();


            cm4.ExecuteNonQuery();

            connect.Close();

            connect.Open();
            cm8.ExecuteNonQuery();

            connect.Close();
            connect.Open();
            cm9.ExecuteNonQuery();

            connect.Close();
            connect.Open();
            if (irany == true)
            {
                cm7.CommandText = "update szamlatukor set kovetel='" + fizAfakovetel + "' where szamlaId='467';";
                cm10.CommandText = "update szamlatukor  set egyenleg='" + fizAfaEgyenleg + "' where szamlaId='467';";
            }
            else
            {
                cm7.CommandText = "update szamlatukor set tartozik='" + levAfatartozik + "' where szamlaId='466';";
                cm10.CommandText = "update szamlatukor set egyenleg='" + levAfaEgyenleg + "' where szamlaId='466';";

            }

            cm7.ExecuteNonQuery();


            connect.Close();


            connect.Open();
            cm10.ExecuteNonQuery();


            connect.Close();




        }
    }
    }

