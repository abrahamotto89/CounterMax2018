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
using System.Text.RegularExpressions;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window18.xaml
    /// </summary>
    public partial class NaploBank : Window
    {

        public List<Bank> bankTetelLista { get; set; }
        public List<BankNaplo> bankNaploLista { get; set; }
        string Ceg;
        DateTime dt;
        int i = 0;
        int counter = 0;
       
        string ssz;
        bool valto = false;
        string rendben;
        bool d;
        string szamlaszam;
        int naploosszeg = 0;
        string adatf;
        string adatj;
        public NaploBank(string x,string y,string z)
        {
            Ceg = x;
            adatf = y;
            adatj = z;

            InitializeComponent();
            bankTetelLista = new List<Bank>();
            bankNaploLista = new List<BankNaplo>();
            ment.IsEnabled = false;
            torl.IsEnabled = false;

            sorszam.Text =getSorszam(Ceg);
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PartnerKivalaszt w12 = new PartnerKivalaszt(Ceg, false,adatf,adatj);
            w12.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListazMunkaSzam w21 = new ListazMunkaSzam(Ceg,adatf,adatj);
            w21.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           


            counter++;
           

        

           

            if(ellenoriz()==true)
            {
                
                i++;
                if (munkaNev.Text == "")
                {
                    munkaNev.Text = "999";
                }
               
            
                string date = datum.Text;
                dt = DateTime.Parse(date);
              
               
                if (bevkia.Text.ToString() == "Bevétel")
                {

                    bankTetelLista.Add(new Bank




                    {
                        id = i,
                        szamlaSzam = int.Parse(bank.Text),
                        bizonylatSzam = bizszam.Text.ToString(),
                        netto = double.Parse(netOssz.Text),
                        afa = double.Parse(afaOssz.Text),
                        brutto = double.Parse(bruttOssz.Text),
                        megjegyzes = megjegyzes.Text.ToString(),
                        ellenSzamla = int.Parse(ellen.Text),
                         dt= datum.Text,
                        partnerKod = int.Parse(partnerNev.Text),
                        munkaSzam = int.Parse(munkaNev.Text),



                    }

                            );



                    beillesztes();
                }


                else
                {
                    bankTetelLista.Add(new Bank




                    {
                        id = i,
                        szamlaSzam = int.Parse(ellen.Text),
                        bizonylatSzam = bizszam.Text.ToString(),
                        netto = double.Parse(netOssz.Text),
                        afa = double.Parse(afaOssz.Text),
                        brutto = double.Parse(bruttOssz.Text),
                        megjegyzes = megjegyzes.Text.ToString(),
                        ellenSzamla = int.Parse(bank.Text),
                        dt = datum.Text,
                        partnerKod = int.Parse(partnerNev.Text),
                        munkaSzam = int.Parse(munkaNev.Text),



                    }

                            );



                    beillesztes();
                }

                ment.IsEnabled = true;
                torl.IsEnabled = true;
                mod.IsEnabled = true;

                ellen.Text = "";
                bank.Text = "";
                datum.Text = "";
                bevkia.Text = "";
                megjegyzes.Text = "";
                partnerNev.Text = "";
                munkaNev.Text = "";
                bizszam.Text = "";
                netOssz.Text = "";
                afaOssz.Text = "";
                bruttOssz.Text = "";
               
                MessageBox.Show("Tétel felvéve");

            }
            else
            {
                MessageBox.Show("Kérem ellenőrizze az adatokat!!!");
            }



           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //módosítás
            var selectedItem = Banktetelek.SelectedItem;
            Bank c2 = (Bank)Banktetelek.SelectedItems[0];
            for (i = 0; i < bankTetelLista.Count; i++)
            {
                if (bankTetelLista[i].bizonylatSzam == c2.bizonylatSzam)
                {
                    bank.Text = bankTetelLista[i].szamlaSzam.ToString();
                    ellen.Text = bankTetelLista[i].ellenSzamla.ToString();
                    bizszam.Text = bankTetelLista[i].bizonylatSzam.ToString();
                    partnerNev.Text = bankTetelLista[i].partnerKod.ToString();
                    munkaNev.Text = bankTetelLista[i].munkaSzam.ToString();
                    megjegyzes.Text = bankTetelLista[i].megjegyzes.ToString();

                    netOssz.Text = bankTetelLista[i].netto.ToString();
                    afaOssz.Text = bankTetelLista[i].afa.ToString();

                    bruttOssz.Text = bankTetelLista[i].brutto.ToString();
                    bankTetelLista.RemoveAt(i);
                        
                    

                    


                   

                }

                Banktetelek.Items.Remove(selectedItem);
            }



        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //kilépés
            
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //mentés
            bevkia.IsEnabled = true;
            char[] kezdoSorszam = sorszam.Text.ToCharArray();
            Array.Reverse(kezdoSorszam);
            string kezdo = new string(kezdoSorszam);
            int kezdoSorSzam = int.Parse(kezdo);
            if (valto == true)
            {
                kezdoSorSzam = kezdoSorSzam + 1000;
            }
            ment.IsEnabled = false;
            


            if (bankTetelLista.Count != 0)
            {





             
               
                if (kezdoSorSzam < 10000)
                {

                    sorszam.Text = reverseString(kezdoSorSzam);
                  

                }
                else
                    if (kezdoSorSzam >= 10000)
                {
                    string y = sorSzamGenerator(10000);
                   
                    char[] array3 = y.ToCharArray();
                    char[] s1 = new char[4];
                    s1[0] = array3[0];
                    s1[1] = array3[1];
                    s1[2] = array3[3];
                    s1[3] = array3[2];



                    string oke = new string(s1);
                    
             
                }
                

        
                string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cm = connect.CreateCommand();
                cm.CommandText = "Select * FROM banknaplo";
                try
                {
                    connect.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }



                MySqlDataReader reader = cm.ExecuteReader();
                int szamlalo = 0;


                while (reader.Read())
                {



                    szamlalo++;

                }












                string connection1 = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connection2 = new MySqlConnection(connection1);

                MySqlCommand cmd;

                connection2.Open();
               
                for (i = 0; i < bankTetelLista.Count; i++)
                {


                    naploosszeg = naploosszeg + Convert.ToInt32(bankTetelLista[i].brutto);
                   
                    string s = "INSERT INTO banknaplo VALUES('" + szamlalo + "','" + sorszam.Text + "','" + bankTetelLista[i].bizonylatSzam + "','" + bankTetelLista[i].szamlaSzam + "','" + bankTetelLista[i].ellenSzamla + "','" + bankTetelLista[i].netto + "','" + bankTetelLista[i].afa + "','" + bankTetelLista[i].brutto + "','" + bankTetelLista[i].megjegyzes + "','" + bankTetelLista[i].ido + "','" + bankTetelLista[i].partnerKod + "','" + bankTetelLista[i].munkaSzam + "');";
                    cmd = new MySqlCommand(s, connection2);
                    cmd.ExecuteNonQuery();

                    szamlalo++;
                    string tart = bankTetelLista[i].szamlaSzam.ToString();
                    string kov = bankTetelLista[i].ellenSzamla.ToString();

                    if (bevkia.Text.ToString() == "Bevétel")
                    {
                        d = true;
                        konyvelBank(Ceg, tart, kov, bankTetelLista[i].brutto, bankTetelLista[i].afa, d);
                    }
                    else
                    {
                        d = false;

                        konyvelBank(Ceg, tart, kov, bankTetelLista[i].brutto, bankTetelLista[i].afa, d);


                    }


             


                    if (i == bankTetelLista.Count()-1)
                    {

                        bankNaploLista.Add(new BankNaplo
                        {
                            sorszam = sorszam.Text,
                            fokonyviszam = "384",
                            nyitoErtek = int.Parse(nyito.Text),
                            bizszam = bankTetelLista[i].bizonylatSzam,
                            partnerKod = bankTetelLista[i].partnerKod,
                            munkaKod = bankTetelLista[i].munkaSzam,
                            megjegyzes = bankTetelLista[i].megjegyzes,
                            osszeg = naploosszeg,
                            idoTime = bankTetelLista[i].ido,

                        }
                    );

                        
                    }
                }
        }
                


            else
                MessageBox.Show("Még nem vett fel elemeket");


           
            for (i = 0; i < bankTetelLista.Count; i++)
            {
                bankTetelLista.RemoveAt(i);
                
            }
            Banktetelek.Items.Clear();
            

            bankTetelLista = new List<Bank>();

            string connectt= "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcsolat = new MySqlConnection(connectt);

            MySqlCommand parancs;
            string s10 = "INSERT INTO bankNaploOsszegzes VALUES('"+bankNaploLista[0].sorszam+"','"+bankNaploLista[0].fokonyviszam+"','"+bankNaploLista[0].nyitoErtek+"','"+bankNaploLista[0].bizszam+"','"+bankNaploLista[0].partnerKod+"','"+bankNaploLista[0].munkaKod+"','"+bankNaploLista[0].megjegyzes+"','"+bankNaploLista[0].osszeg+"','"+bankNaploLista[0].idoTime+"');";
            parancs = new MySqlCommand(s10, kapcsolat);
            kapcsolat.Open();



            parancs.ExecuteNonQuery();
            

            i = 0;

            valto = true;

            sorszam.Text = getSorszam(Ceg);

            datum.Text = "";
            nyito.Text = "";
            afavalasztas.Text = "";




            

        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var selecteditem = Banktetelek.SelectedItem;
            Bank c1 = (Bank)Banktetelek.SelectedItems[0];


            for (i = 0; i < bankTetelLista.Count; i++)
            {
                if (bankTetelLista[i].bizonylatSzam == c1.bizonylatSzam)
                {
                    bankTetelLista.RemoveAt(i);
                }
            }



            Banktetelek.Items.Remove(selecteditem);


        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            KivalasztSzamla w10 = new KivalasztSzamla(Ceg,"384",true,adatf,adatj);
            w10.Show();
        }



        private void kivalasztElleneszamla_Click(object sender, RoutedEventArgs e)
        {
            KivalasztSzamla w10 = new KivalasztSzamla(Ceg,"",false,adatf,adatj);
            w10.Show();
        }

        private void hozzadPartner_Click(object sender, RoutedEventArgs e)
        {
            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
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

                partnerNev.Text = reader["partnerkod"].ToString();





            }


            string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd3 = connect.CreateCommand();

            connect.Open(); ;




            cmd3.CommandText = "Delete from partner;";
            cmd3.ExecuteNonQuery();

            connection2.Close();
        }

        private void hozzadBank_Click(object sender, RoutedEventArgs e)
        {
           
            string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bank.Text = reader["szamlaszam"].ToString();
                szamlaszam = bank.Text;


            }

            connection.Close();





            string connString2 = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(connString2);
            MySqlCommand cmd2 = connection2.CreateCommand();
            cmd2.CommandText = "Select * FROM szamlatukor";
            connection2.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                if (reader2["szamlaId"].ToString() == szamlaszam)
                {
               
                    nyito.Text = reader2["egyenleg"].ToString();
                }
            }
            hozzadBank.IsEnabled = true;

        }

        private void hozzadEllen_Click(object sender, RoutedEventArgs e)
        {
     
            
            string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                szamlaszam = reader["szamlaszam"].ToString();
                
                ellenNev.Text = reader["szamlanev"].ToString();
                ellen.Text = szamlaszam;

            }
            connection.Close();
           







            hozzadEllen.IsEnabled = true;

        }

        public static bool szamEllenorzes(string x)
        {
            bool a = true;
           
            string minta = @"^[1-9][0-9]*$";
            string input = x;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;

            char[] array = x.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (Char.IsDigit(array[i]) == false)
                {
                    a = false;
                }
            }
            return (a);
        }

        public void beillesztes()
        {
            ment.IsEnabled = true;
            torl.IsEnabled = true;
           
            id.Binding = new Binding("id");
            szamlaSzam.Binding = new Binding("szamlaSzam");
            bizonylatSzam.Binding = new Binding("bizonylatSzam");

            net.Binding = new Binding("netto");
            áfa.Binding = new Binding("afa");

            brutto.Binding = new Binding("brutto");

            megj.Binding = new Binding("megjegyzes");
            ellensz.Binding = new Binding("ellenSzamla");
            ido.Binding = new Binding("dt");
            partnerKod.Binding = new Binding("partnerKod");
            munkaSzam.Binding = new Binding("munkaSzam");





            Banktetelek.Items.Add(new Bank { id = 1, szamlaSzam = int.Parse(bank.Text), bizonylatSzam = bizszam.Text, netto = double.Parse(netOssz.Text), afa = double.Parse(afaOssz.Text), brutto = double.Parse(bruttOssz.Text), megjegyzes = megjegyzes.Text, ellenSzamla = int.Parse(ellen.Text), ido = dt, partnerKod = int.Parse(partnerNev.Text), munkaSzam = int.Parse(munkaNev.Text) });

            bank.Text = "";
            ellen.Text = "";
            partnerNev.Text = "";
            megjegyzes.Text = "";
            munkaNev.Text = "";
            bizszam.Text = "";
            ellenNev.Text = "";
            netOssz.Text = "";
            afaOssz.Text = "";
            bruttOssz.Text = "";

            DataContext = this;

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Banktetelek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sorszam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {



            if (szamEllenorzes(netOssz.Text) == false || afavalasztas.Text.ToString()=="")
            {
                MessageBox.Show("Rosszul adtam meg a nettó összeget");
            }
            else
            {
                double a = int.Parse(netOssz.Text);
                double afaerteke =0.00;
                double brutto = 0;

                string b = afavalasztas.Text.ToString();
                if (b == "5%")
                {
                    afaerteke = a * 0.05;
                    afaOssz.Text = afaerteke.ToString();
                    brutto = a + afaerteke;
                    bruttOssz.Text = brutto.ToString();

                }
                if (b == "27%")
                {
                    afaerteke = a * 0.27;
                    afaOssz.Text = afaerteke.ToString();
                    brutto = a + afaerteke;
                    bruttOssz.Text = brutto.ToString();
                }
                if (b == "18%")
                {
                    afaerteke = a * 0.18;
                    afaOssz.Text = afaerteke.ToString();
                    brutto = a + afaerteke;
                    bruttOssz.Text = brutto.ToString();
                }
                if (b == "0%")
                {
                    afaerteke = 0.00;
                    afaOssz.Text = afaerteke.ToString();
                    brutto = a + afaerteke;
                    bruttOssz.Text = brutto.ToString();
                }
            }


        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
        public int reverseNumber(int Number)
        {
            int ReverseNumber = 0;
            while (Number > 0)
            {
                ReverseNumber = (ReverseNumber * 10) + (Number % 10);
                Number = Number / 10;
            }
            return ReverseNumber;
        }
        public string reverseString(int nm)
        {
            int x = nm;
            char[] arr = x.ToString().ToCharArray();
            Array.Reverse(arr);
            string vissza = new string(arr);
            return (vissza);
        }

        public string sorSzamGenerator(int s)

        {
            int sorszam = s;
            char[] arr;
        
            

                
                arr = sorszam.ToString().ToCharArray();
                Array.Reverse(arr);

            char[] array2=new string(arr).Remove(1, 1).ToCharArray();

            string sd = new string(array2);


            return (sd);

        }

        public string getSorszam(string company)
        {
            string conn = "SERVER=localhost;DATABASE=" + company + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select sorszam from banknaplo where tetelId=(select MAX(tetelId) from banknaplo);";

            connect.Open();

            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read()) {
                ssz = reader["sorszam"].ToString();


            }
            if (ssz == null)
            {
                ssz = "0000";
            }
            char[] array = ssz.ToCharArray();
            Array.Reverse(array);
            string megforditott = new string(array);
            int atalakit = int.Parse(megforditott);

            atalakit = atalakit + 1000;
          

            if (atalakit < 10000)
            {
                megforditott = atalakit.ToString();
                array = megforditott.ToCharArray();
                Array.Reverse(array);
                rendben = new string(array);
            }
            if (atalakit >= 10000)
            {
                string y = sorSzamGenerator(atalakit);
               
                char[] array3 = y.ToCharArray();
                char[] s1 = new char[4];
                s1[0] = array3[0];
                s1[1] = array3[1];
                s1[2] = array3[3];
                s1[3] = array3[2];



                rendben = new string(s1);




            }
            connect.Close();
        
            return (rendben);
        }

        private void megjegyzes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void hozzadMunka_Click(object sender, RoutedEventArgs e)
        {
            string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand cm2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM munkaszamok";
            cm2.CommandText = "delete  from munkaszamok";
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


                munkaNev.Text = reader["munkaId"].ToString();

            }
            connect.Close();
            connect.Open();
            cm2.ExecuteNonQuery();


            connect.Close();

        }


        public void konyvelBank(string ceg, string t, string k, double a, double b, bool irany)
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
            levAfaEgyenleg= levAfaEgyenleg + Convert.ToInt32(b);
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
            fizAfaEgyenleg=fizAfaEgyenleg+ Convert.ToInt32(b);
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
                cm10.CommandText = "update szamlatukor set egyenleg='"+fizAfaEgyenleg+"' where szamlaId='467';";
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

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }
        public bool ellenoriz()
        {
            bool vissza = true;

            if (bevkia.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki a számla típusát!!!");
            }


            if (ellen.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki az ellenszámlát!!!");
            }


            if (datum.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }
            if (bank.Text == "")
            {
                MessageBox.Show("Kérem adja meg a számlaszámot!!!!");
                vissza = false;
            }

            if (bizszam.Text == "")
            {
                MessageBox.Show("Kérem adja meg a bizonylatszámot!!!");
                vissza = false;
            }
            if (munkaNev.Text == "")
            {
                MessageBox.Show("Kérem adja meg a munkakódot");

            }
            if (partnerNev.Text == "")
            {
                MessageBox.Show("Kérem Adja meg a partnerkódot!!!!");
                vissza = false;
            }

            if (megjegyzes.Text == "")
            {
                MessageBox.Show("Kérem töltse ki a megjegyzés mezőt!!!");
                vissza = false;

            }
            if (afavalasztas.Text == "")
            {
                MessageBox.Show("Kérem válassza ki az áfa mértékét!!!!");
                vissza = false;
            }
            if (szamEllenorzes(netOssz.Text) == false)
            {
                MessageBox.Show("Rosszul adta meg a nettó összeget!!!!");
                vissza = false;
            }
            if (munkaNev.Text == "")
            {
                munkaNev.Text = "999";
            }

            if (afaOssz.Text == "")
            {
                MessageBox.Show("Áfa értéke helytelen!!!");
                vissza = false;
            }
            if (bruttOssz.Text == "")
            {
                MessageBox.Show("Bruttó értéke helytelen!!!!");
            }
            return (vissza);
        }
    }
}
