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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class FoAblak : Window
    {

       public List<Esemenyek> esemenyLekerdezLista { get; set; }
        string Felh;
        string Ceg;
        string adatbfelhasznalo;
        string adatbjelszo;
       
       
        bool lekerdezEsemeny = false;
        public FoAblak(string b,string a,bool lekerdez,string adatbFnev,string adatbJelsz)
        {
           Felh = b;

         Ceg = a;
            adatbfelhasznalo = adatbFnev;
            adatbjelszo = adatbJelsz;
            lekerdezEsemeny = lekerdez;
           
            InitializeComponent();
            egyenlegLekerdezes();
            if (lekerdezEsemeny == true)
            {
                esemenyValid(Ceg);
            }
            vallalkozas.Content ="Vállalkozás:"+a;
            bejelent.Content = "Bejelentkezve:"+b;
           


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            NaploNyito w7 = new NaploNyito(Ceg,"",false,adatbfelhasznalo,adatbjelszo);
            w7.Show();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
          

            NaploVevoSzallito w8 = new NaploVevoSzallito(Ceg,adatbfelhasznalo,adatbjelszo);
            w8.Show();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
            NaploPenztar w23 = new NaploPenztar(Ceg,adatbfelhasznalo,adatbjelszo);
            w23.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
           
            PartnerFelvesz w11 = new PartnerFelvesz(Ceg,adatbfelhasznalo,adatbjelszo);
            w11.Show();

        }

        private void bej_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        public void egyenlegLekerdezes()
        {

            string conn = "SERVER=localhost;DATABASE="+Ceg+";UID="+adatbfelhasznalo+";PASSWORD="+adatbjelszo+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(conn);
            MySqlCommand cmd = connection.CreateCommand();
            
            cmd.CommandText = "Select *from szamlatukor Where szamlaId=3811;";
           

            connection.Open();


            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                if (int.Parse(reader["tartozik"].ToString()) > int.Parse(reader["kovetel"].ToString()))
                {
                    penztar.Text = reader["egyenleg"].ToString();
                }
                else
                    if (int.Parse(reader["kovetel"].ToString()) > int.Parse(reader["tartozik"].ToString()))
                {
                    penztar.Text = "-" + reader["egyenleg"].ToString();
                }
                
            }

            connection.Close();


            MySqlConnection connection2 = new MySqlConnection(conn);

            MySqlCommand cmd2 = connection2.CreateCommand();
            cmd2.CommandText = "Select *from szamlatukor Where szamlaId=384;";
            connection2.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                if (int.Parse(reader2["tartozik"].ToString()) > int.Parse(reader2["kovetel"].ToString()))
                {
                    bank.Text = reader2["egyenleg"].ToString();
                }
                else
                   if (int.Parse(reader2["kovetel"].ToString()) > int.Parse(reader2["tartozik"].ToString()))
                {
                    bank.Text ="-"+reader2["egyenleg"].ToString();
                }

               


            }
                connection2.Close();
        
        }


     

    

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
           
            PartnerKivalaszt w12 = new PartnerKivalaszt(Ceg,true,adatbfelhasznalo,adatbjelszo);
            w12.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
          
            EsemenyFelvesz w15 = new EsemenyFelvesz(Ceg,"",false,false,Felh,adatbfelhasznalo,adatbjelszo);
            w15.Show();
           
            


        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
          

            EsemenyListaz w17 = new EsemenyListaz(Ceg, Felh, adatbfelhasznalo, adatbjelszo);
            w17.Show();
            Console.WriteLine("6osberkja");
            this.Close();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
        

        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {

        }

       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Lista1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void penztar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {

            ListazCegek w3 = new ListazCegek(Felh,adatbfelhasznalo,adatbjelszo);
            w3.Show();
            this.Close();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
          

            NaploBank w18 =new NaploBank(Ceg,adatbfelhasznalo,adatbjelszo);
            w18.Show();

        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
          
            NaploPenztar w23= new NaploPenztar(Ceg,adatbfelhasznalo,adatbjelszo);
            w23.Show();

        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
         
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
           
            BankPenztarNaploMegjelenit w9 = new BankPenztarNaploMegjelenit(Ceg,adatbfelhasznalo,adatbjelszo);
            w9.Show();
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {

         
            OsszesVegyesNaplo w26 = new OsszesVegyesNaplo(Ceg,adatbfelhasznalo,adatbjelszo);
            w26.Show();
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
           
            OsszesVevoSzallitoNaplo w24 = new OsszesVevoSzallitoNaplo(Ceg,adatbfelhasznalo,adatbjelszo);
            w24.Show();
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
         
            NaploVegyes w25 = new NaploVegyes(Ceg,adatbfelhasznalo,adatbjelszo);
            w25.Show();
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
           
            FelveszDolgozo w27 = new FelveszDolgozo(Ceg,0,false,adatbfelhasznalo,adatbjelszo);
            w27.Show();
        }

        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
           
            ListazDolgozo w28 = new ListazDolgozo(Ceg,adatbfelhasznalo,adatbjelszo);
            w28.Show();
        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            
            BerszamDolgozo w29 = new BerszamDolgozo(Ceg,adatbfelhasznalo,adatbjelszo);
            w29.Show();
        }
           private void Button_Click(object sender, RoutedEventArgs e)
        {
                    this.Close();
        }

        private void MenuItem_Click_23(object sender, RoutedEventArgs e)
        {
          
            BerfeladasDolgozo w30 = new BerfeladasDolgozo(Ceg,adatbfelhasznalo,adatbjelszo);
            w30.Show();
        }

        private void MenuItem_Click_24(object sender, RoutedEventArgs e)
        {
           
            BerfizetesAblak w33 = new BerfizetesAblak(Ceg,adatbfelhasznalo,adatbjelszo);
            w33.Show();
        }

        private void MenuItem_Click_25(object sender, RoutedEventArgs e)
        {
        
            MerlegMegjelenit w31 = new MerlegMegjelenit(Ceg,adatbfelhasznalo,adatbjelszo);
            w31.Show();
        }

        private void MenuItem_Click_26(object sender, RoutedEventArgs e)
        {
         
            FokonyvMegjelenit w32 = new FokonyvMegjelenit(Ceg,adatbfelhasznalo,adatbjelszo);
            w32.Show();
        }

        private void MenuItem_Click_27(object sender, RoutedEventArgs e)
        {
            ZaroNaploAblak w34 = new ZaroNaploAblak(Ceg,adatbfelhasznalo,adatbjelszo);
            w34.Show();
        }

        private void MenuItem_Click_28(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kilépett a programból");
            this.Close();

        }

        private void esemenyValid(string x)
        {
            int i = 0;
            bool esemenyeLesz = false;
            List<Esemenyek> esemenyListaFoablak = new List<Esemenyek>();
            string conn1 = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbfelhasznalo+";PASSWORD="+adatbjelszo+";Ssl Mode=none";
            string conn2 = "SERVER=localhost;DATABASE="+x+";UID="+adatbfelhasznalo+";PASSWORD="+adatbjelszo+";Ssl Mode=none";

            MySqlConnection connect1 = new MySqlConnection(conn1);
            MySqlConnection connect2 = new MySqlConnection(conn2);

            MySqlCommand lekerdezes1 = connect1.CreateCommand();
            MySqlCommand lekerdezes2 = connect2.CreateCommand();

            lekerdezes1.CommandText = "Select *from esemenyek where felhasznalok_felhasznaloId='"+lekerEsemenyKod(Felh)+"';";
            lekerdezes2.CommandText = "Select *from esemenyek;";

            connect1.Open();
            connect2.Open();
            MySqlDataReader reader1 = lekerdezes1.ExecuteReader();
            MySqlDataReader reader2 = lekerdezes2.ExecuteReader();
            var src = DateTime.Now;
            DateTime d1 = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);



            while (reader1.Read())
            {
                i++;
                DateTime d4 = DateTime.Parse(reader1["esemenyNapja"].ToString());
                DateTime d5 = DateTime.Parse(reader1["esemenyIdeje"].ToString());

                DateTime d2 = DateTime.Parse(reader1["esemenyNapja"].ToString());
                if(d2.Year==d1.Year && d2.Month==d1.Month && d2.Day == d1.Day)
                {
                   
                    esemenyeLesz = true;
                    esemenyListaFoablak.Add(new Esemenyek
                    {
                        esemenyId = int.Parse(reader1["esemenyId"].ToString()),
                        esemenyIdopont = new DateTime(d4.Year, d4.Month, d4.Day, d5.Hour, d5.Minute, d5.Second),
                        esemenyMegnevezes = reader1["esemenyMegnevezes"].ToString(),
                        esemenyHelyszin = reader1["esemenyHelyszin"].ToString(),
                        esemenyKontakt=reader1["esemenyKontakt"].ToString(),
                        esemenyIsIdozito=int.Parse(reader1["esemenyIdozito"].ToString()),
                        esemenyIsIdozitoIdo=DateTime.Parse(reader1["esemenyIdozitoIdo"].ToString()),
                    });
                }
            }
            connect1.Close();



         

            while (reader2.Read())
            {
                i++;
                DateTime d4 = DateTime.Parse(reader2["esemenyNapja"].ToString());
                DateTime d5 = DateTime.Parse(reader2["esemenyIdeje"].ToString());

                DateTime d2 = DateTime.Parse(reader2["esemenyNapja"].ToString());







                if (d2.Year == d1.Year && d2.Month == d1.Month && d2.Day == d1.Day)
                {
                    
                    esemenyeLesz = true;
                    esemenyListaFoablak.Add(new Esemenyek
                    {
                        esemenyId = int.Parse(reader2["esemenyId"].ToString()),
                        esemenyIdopont = new DateTime(d4.Year, d4.Month, d4.Day, d5.Hour, d5.Minute, d5.Second),
                        esemenyMegnevezes = reader2["esemenyMegnevezes"].ToString(),
                        esemenyHelyszin = reader2["esemenyHelyszin"].ToString(),
                        esemenyKontakt = reader2["esemenyKontakt"].ToString(),
                        esemenyIsIdozito = int.Parse(reader2["esemenyIdozito"].ToString()),
                        esemenyIsIdozitoIdo = DateTime.Parse(reader2["esemenyIdozitoIdo"].ToString()),
                    });
                }


            }
            connect2.Close();
           
            if (i > 0)
            {
                eido.Binding = new Binding("esemenyIdopont");
                ehelyszin.Binding = new Binding("esemenyHelyszin");
                ekontakt.Binding = new Binding("esemenyKontakt");
                emegnev.Binding = new Binding("esemenyMegnevezes");

                for (int z = 0; z < esemenyListaFoablak.Count(); z++)
                {
                    esemenyFoablakLista.Items.Add(new Esemenyek
                    {
                        esemenyIdopont = esemenyListaFoablak[z].esemenyIdopont,
                        esemenyHelyszin = esemenyListaFoablak[z].esemenyHelyszin,
                        esemenyKontakt = esemenyListaFoablak[z].esemenyKontakt,
                        esemenyMegnevezes=esemenyListaFoablak[z].esemenyMegnevezes,

                    });
                }

                DataContext = this;
                if (i == 1 && esemenyeLesz==true)
                {
                    MessageBox.Show("Önnek a mai napon fontos eseménye lesz!!!");
                }
                else
                {
                    if (i > 1 && esemenyeLesz == true)
                    {
                        MessageBox.Show("Önnek a mai napon fontos eseményei lesznek!!!");
                    }
                }
            }

        }

        private void MenuItem_Click_29(object sender, RoutedEventArgs e)
        {
            PartnerListaz w13 = new PartnerListaz(Ceg,adatbfelhasznalo,adatbjelszo);
            w13.Show();
        }

        public int lekerEsemenyKod(string felhaszn)
        {
            int vissza = 0;
            string conn1 = "SERVER=localhost;DATABASE=konyvelok;UID=" + adatbfelhasznalo + ";PASSWORD=" + adatbjelszo + ";Ssl Mode=none";
            MySqlConnection conn = new MySqlConnection(conn1);
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();

            cmd.CommandText = "Select * from felhasznalok where felhasznaloNev='"+felhaszn+"';";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza =int.Parse(reader["felhasznaloid"].ToString());
            }

            conn.Close();

            return (vissza);

        }
    }
}
