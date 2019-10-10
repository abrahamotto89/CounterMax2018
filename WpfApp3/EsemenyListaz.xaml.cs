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
    /// Interaction logic for Window17.xaml
    /// </summary>
    public partial class EsemenyListaz : Window
    {
        DateTime d1;
        DateTime d2;
     
        DateTime d4;
        DateTime d5;
        string Cegnev;
       
       
        string felhasznaloNev;
        int felhasznaloId = 0;
        string adatf;
        string adatj;

        public List<Esemenyek> esemenyLista { get; set; }
        public EsemenyListaz(string x,string felhnev,string y,string z)
           
        {
           
            felhasznaloNev = felhnev;
            

            Cegnev = x;
            adatf = y;
            adatj = z;
            esemenyLista = new List<Esemenyek>();
            InitializeComponent();
            mod.IsEnabled = false;
            torl.IsEnabled = false;
            string conn2String = "SERVER=localhost;DATABASE=" + Cegnev + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            string conn3String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlConnection connection3 = new MySqlConnection(conn3String);

            MySqlCommand cmd = connection2.CreateCommand();
            MySqlCommand parancs = connection3.CreateCommand();
            MySqlCommand parancs3 = connection3.CreateCommand();
            cmd.CommandText = "Select * FROM esemenyek";
            parancs.CommandText = "Select * FROM esemenyek";
            parancs3.CommandText = "Select *from felhasznalok;";
            try
            {
                connection2.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }


            try
            {
                connection3.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }

            
            MySqlDataReader reader3 = parancs3.ExecuteReader();



            while (reader3.Read())
            {
                if (reader3["felhasznaloNev"].ToString() == felhasznaloNev)
                {
                    felhasznaloId = int.Parse(reader3["felhasznaloid"].ToString());
                }
            }
            connection3.Close();



            connection3.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            MySqlDataReader reader2 = parancs.ExecuteReader();

            while (reader.Read())
            {



                

                if (reader["esemenyId"].ToString() != "")
                {

                 

                    string atalakit = reader["esemenyNapja"].ToString();
                    string atalakit3 = reader["esemenyIdeje"].ToString();
                    string atalakit2 = reader["esemenyIdozitoIdo"].ToString();
                   

                    d1 = DateTime.Parse(atalakit);
                    
                    d4 = DateTime.Parse(atalakit3);

                    d5 = new DateTime(d1.Year,d1.Month,d1.Day,d4.Hour,d4.Minute,d4.Second);

                    d2 = DateTime.Parse(atalakit2);
                  esemenyLista.Add(

                    


                        new Esemenyek
                                {

                            esemenyId=int.Parse(reader["esemenyId"].ToString()),
                            esemenyIdopont=d5,
                            esemenyMegnevezes=reader["esemenyMegnevezes"].ToString(),
                            esemenyHelyszin=reader["esemenyHelyszin"].ToString(),
                            esemenyKontakt=reader["esemenyKontakt"].ToString(),
                            esemenyIsIdozito=int.Parse(reader["esemenyIdozito"].ToString()),
                 
                            
                            
                            esemenyIsIdozitoIdo=new DateTime(d2.Year,d2.Month,d2.Day,d2.Hour,d2.Minute,d2.Second),
                           
                            
                           


                            





                        

                     });




                }
        /*
                else
                {
                 

                    string atalakit = reader["esemenyNapja"].ToString();
                    string atalakit3 = reader["esemenyIdeje"].ToString();
                    string atalakit2 = reader["esemenyIdozitoIdo"].ToString();


                    d1 = DateTime.Parse(atalakit);

                    d4 = DateTime.Parse(atalakit3);

                    d5 = new DateTime(d1.Year, d1.Month, d1.Day, d4.Hour, d4.Minute, d4.Second);

                    d2 = DateTime.Parse(atalakit2);
                    esemenyLista.Add(new Esemenyek
                    {
                        esemenyId = int.Parse(reader["esemenyId"].ToString()),
                        esemenyIdopont = d5,
                        esemenyMegnevezes = reader["esemenyMegnevezes"].ToString(),
                        esemenyHelyszin = reader["esemenyHelyszin"].ToString(),
                        esemenyKontakt = reader["esemenyKontakt"].ToString(),
                        esemenyIsIdozito = int.Parse(reader["esemenyIdozito"].ToString()),
                        esemenyIsIdozitoIdo =d2,
                       


                    });

                }
                i++;
               */
            }





            while(reader2.Read())
            {


               

                if (reader2["esemenyId"].ToString() != "")
                {
                   
                    if (int.Parse(reader2["felhasznalok_felhasznaloId"].ToString())==felhasznaloId) {
                        
                        string atalakit = reader2["esemenyNapja"].ToString();
                        string atalakit3 = reader2["esemenyIdeje"].ToString();
                        string atalakit2 = reader2["esemenyIdozitoIdo"].ToString();


                        d1 = DateTime.Parse(atalakit);

                        d4 = DateTime.Parse(atalakit3);

                        d5 = new DateTime(d1.Year, d1.Month, d1.Day, d4.Hour, d4.Minute, d4.Second);

                        d2 = DateTime.Parse(atalakit2);
                        esemenyLista.Add(




                            new Esemenyek
                            {

                                esemenyId = int.Parse(reader2["esemenyId"].ToString()),
                                esemenyIdopont = d5,
                                esemenyMegnevezes = reader2["esemenyMegnevezes"].ToString(),
                                esemenyHelyszin = reader2["esemenyHelyszin"].ToString(),
                                esemenyKontakt = reader2["esemenyKontakt"].ToString(),
                                esemenyIsIdozito = int.Parse(reader2["esemenyIdozito"].ToString()),



                                esemenyIsIdozitoIdo = new DateTime(d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute, d2.Second),













                            });




                    }

                 

                }
            }









            DataContext = this;
        }

        private void Lista1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //módosítás

        
                bool y = false;
              
                Esemenyek c1 = (Esemenyek)Lista4.SelectedItems[0];
                for(int x = 0; x < esemenyLista.Count(); x++)
                {
                    if (esemenyLista[x].esemenyId == c1.esemenyId)
                    {
                        Window w15 = new EsemenyFelvesz(Cegnev, c1.esemenyId.ToString(), true, y,felhasznaloNev,adatf,adatj);
                        w15.Show();
                    }
                }
           
                
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Kilépés
        
            FoAblak w6 = new FoAblak(felhasznaloNev, Cegnev,false,adatf,adatj);
            w6.Show();
            this.Close();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //törlés

         
                Esemenyek c2 = (Esemenyek)Lista4.SelectedItems[0];
                string conn2String = "SERVER=localhost;DATABASE=" + Cegnev + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                
            MySqlConnection connection2 = new MySqlConnection(conn2String);
           
            MySqlCommand cmd2 = connection2.CreateCommand();
                string conn3String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            connection2.Open();
            cmd2.CommandText = "delete from esemenyek where esemenyId='" + c2.esemenyId + "'";

                cmd2.ExecuteNonQuery();

                connection2.Close();

                MySqlConnection connection3 = new MySqlConnection(conn3String);
                MySqlCommand cmd3 = connection3.CreateCommand();
               
               
                connection3.Open();
                cmd3.CommandText = "delete from esemenyek where esemenyId='" + c2.esemenyId + "'";
            
                cmd3.ExecuteNonQuery();

                connection3.Close();


                MessageBox.Show("Esemény Törölve");
        
                  
                 EsemenyListaz w17 = new EsemenyListaz(Cegnev,felhasznaloNev,adatf,adatj);
                w17.Show();
            this.Close();

        }

        private void mod_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void torl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void torl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void mod_IsEnabledChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Lista4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mod.IsEnabled = true;
            torl.IsEnabled = true;
        }
    }
}
