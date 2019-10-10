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
    /// Interaction logic for Window25.xaml
    /// </summary>
    public partial class NaploVegyes : Window
    {
        string visszaKod;
        string visszaNev;
        string visszaEgyenleg;
        string Ceg;
        int i = 0;
        int tetelOsszeg = 0;
       
        
        string rendben;
        string ssz;
        int naploosszeg = 0;
        bool valto = false;
        
        string adatf;
        string adatj;
        List<Vegyes> vegyesLista { get; set; }
        List<VegyesNaplo> vegyesNaploLista { get; set; }

        public NaploVegyes(string x,string y,string z)
        {


            InitializeComponent();
            vegyesLista = new List<Vegyes>();
            vegyesNaploLista = new List<VegyesNaplo>();
            Ceg = x;
            adatf = y;
            adatj = z;

            sorszamText.Text = getSorszam(Ceg);
            ment.IsEnabled = false;
            torl.IsEnabled = false;
            mod.IsEnabled = false;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Ujtétel

           
                beillesztes();
           
            

        }

        private void ellenszamlaNevText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nyito_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bizszamText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void munkaKod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void partnerKodText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void afaText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bruttoText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {//Módosítás
            var selecteditem = VegyesTetelek.SelectedItems[0];
            Vegyes v1 = (Vegyes)VegyesTetelek.SelectedItems[0];


            for (i = 0; i < vegyesLista.Count(); i++)
            {
                
                if (vegyesLista[i].bizonylatSzam == v1.bizonylatSzam && vegyesLista[i].tetelSzam == v1.tetelSzam)
                {

                    
                    tartozikKod.Text = vegyesLista[i].TSzamla;
                    kovetelKod.Text = vegyesLista[i].KSzamla;
                    keltText.Text = vegyesLista[i].DaTuM.ToString();
                    bizszamText.Text = vegyesLista[i].bizonylatSzam;
                    munkaKod.Text = vegyesLista[i].munkaKod.ToString();
                    partnerKod.Text = vegyesLista[i].partnerKod.ToString();
                    megjText.Text = vegyesLista[i].megjegyzes;
                    nettoText.Text = vegyesLista[i].netto.ToString();
                    afaText.Text = vegyesLista[i].afa.ToString();
                    bruttoText.Text = vegyesLista[i].brutto.ToString();

                    vegyesLista.RemoveAt(i);
                }







            }



            VegyesTetelek.Items.Remove(selecteditem);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //Torlés
            var selectedItem = VegyesTetelek.SelectedItems[0];
            Vegyes v1 = (Vegyes)VegyesTetelek.SelectedItems[0];

            for (i = 0; i < vegyesLista.Count(); i++)
            {
                if (vegyesLista[i].bizonylatSzam == v1.bizonylatSzam && vegyesLista[i].tetelSzam == v1.tetelSzam)
                {
                    vegyesLista.RemoveAt(i);

                }

            }
            for (i = 0; i < vegyesLista.Count(); i++)
            {
                vegyesLista[i].tetelSzam = i;
            }

            VegyesTetelek.Items.Remove(selectedItem);

            if (vegyesLista.Count() == 0) {
                ment.IsEnabled = false;
                torl.IsEnabled = false;
                mod.IsEnabled = false;
            }
            tartozikKod.Text = "";
            kovetelKod.Text = "";
            keltText.Text = "";
            bizszamText.Text = "";
            partnerKod.Text = "";
            munkaKod.Text = "";
            megjText.Text = "";
            nettoText.Text = "";
            afaText.Text = "";
            bruttoText.Text = "";
            afavalasztas.Text = "";
            TNyito.Text = "";
            KNyito.Text = "";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            //mentés

            valto = true;

            if (vegyesLista.Count != 0)
            {

               



                string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connect = new MySqlConnection(conn);
                MySqlCommand cm = connect.CreateCommand();
                cm.CommandText = "Select * FROM vegyesnaplo";
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

                for (i = 0; i < vegyesLista.Count; i++)
                {

                   
                    naploosszeg = naploosszeg + vegyesLista[i].brutto;

                    if (i == 0)
                    {
                        string s = "INSERT INTO vegyesnaplo VALUES('" + vegyesLista[i].sorSzam + "','" + vegyesLista[i].tetelSzam + "','" + vegyesLista[i].megjegyzes + "','" + vegyesLista[i].netto + "','" + vegyesLista[i].afa + "','" + vegyesLista[i].brutto + "','" + vegyesLista[i].bizonylatSzam + "','" + vegyesLista[i].TSzamla + "','" + vegyesLista[i].KSzamla + "','" + vegyesLista[i].DaTuM + "','" + naploosszeg + "','" + vegyesLista[i].munkaKod + "','" + vegyesLista[i].partnerKod + "');";
                        cmd = new MySqlCommand(s, connection2);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string s = "INSERT INTO vegyesnaplo VALUES('" + getSorszam(Ceg).ToString()+ "','" + vegyesLista[i].tetelSzam + "','" + vegyesLista[i].megjegyzes + "','" + vegyesLista[i].netto + "','" + vegyesLista[i].afa + "','" + vegyesLista[i].brutto + "','" + vegyesLista[i].bizonylatSzam + "','" + vegyesLista[i].TSzamla + "','" + vegyesLista[i].KSzamla + "','" + vegyesLista[i].DaTuM + "','" + naploosszeg + "','" + vegyesLista[i].munkaKod + "','" + vegyesLista[i].partnerKod + "');";
                        cmd = new MySqlCommand(s, connection2);
                        cmd.ExecuteNonQuery();
                    }
                    szamlalo++;
                    string tart = vegyesLista[i].TSzamla;
                    string kov = vegyesLista[i].KSzamla;


                    konyvelVegyes(Ceg, tart, kov, vegyesLista[i].brutto, vegyesLista[i].afa, true);



                    if (i == vegyesLista.Count() - 1)
                    {

                        vegyesNaploLista.Add(new VegyesNaplo
                        {
                            sorSzam = sorszamText.Text,
                            bizonylatSzam = vegyesLista[i].bizonylatSzam,
                            partnerKod = vegyesLista[i].partnerKod,
                            munkaKod = vegyesLista[i].munkaKod,
                            megjegyzes = vegyesLista[i].megjegyzes,
                            naploOsszeg = naploosszeg,
                            DaT = vegyesLista[i].DaTuM,

                        }
                    );

                        
                    }
                }


                
                char[] kezdoSorszam = sorszamText.Text.ToCharArray();
                Array.Reverse(kezdoSorszam);
                string kezdo = new string(kezdoSorszam);
                int kezdoSorSzam = int.Parse(kezdo);
                if (valto == true)
                {
                    kezdoSorSzam = kezdoSorSzam + 1000;
                }




                
                if (kezdoSorSzam < 10000)
                {

                    sorszamText.Text = reverseString(kezdoSorSzam);


                }
                else
                    if (kezdoSorSzam > 10000)
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







                for (i = 0; i < vegyesLista.Count; i++)
                {
                    vegyesLista.RemoveAt(i);

                }
                VegyesTetelek.Items.Clear();


                vegyesLista = new List<Vegyes>();

                string connectt = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection kapcsolat = new MySqlConnection(connectt);

                MySqlCommand parancs;
                string s10 = "INSERT INTO vegyesnaploosszegzes VALUES('" + vegyesNaploLista[0].sorSzam + "','" + vegyesNaploLista[0].megjegyzes + "','" + vegyesNaploLista[0].bizonylatSzam + "','" + vegyesNaploLista[0].munkaKod + "','" + vegyesNaploLista[0].partnerKod + "','" + vegyesNaploLista[0].DaT + "','" + vegyesNaploLista[0].naploOsszeg + "');";
                parancs = new MySqlCommand(s10, kapcsolat);
                kapcsolat.Open();



                parancs.ExecuteNonQuery();


                i = 0;
                sorszamText.Text = getSorszam(Ceg);

                tartozikKod.Text = "";
                kovetelKod.Text = "";
                keltText.Text = "";
                bizszamText.Text = "";
                partnerKod.Text = "";
                munkaKod.Text = "";
                megjText.Text = "";
                nettoText.Text = "";
                afaText.Text = "";
                bruttoText.Text = "";
                afavalasztas.Text = "";
                TNyito.Text = "";
                KNyito.Text = "";

            }

            else
                MessageBox.Show("Még nem vett fel elemeket");







        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            kovetelKod.Text = hozzaadSzamla().ToString();
            kovetelNev.Text = visszaNev.ToString();
            KNyito.Text = getNyito(kovetelKod.Text.ToString());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            KivalasztSzamla w10 = new KivalasztSzamla(Ceg, "", false,adatf,adatj);
            w10.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            ListazMunkaSzam w21 = new ListazMunkaSzam(Ceg,adatf,adatj);
            w21.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hozzadMunka();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PartnerKivalaszt w12 = new PartnerKivalaszt(Ceg, false,adatf,adatj);
            w12.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            hozzadPartner();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (szamEllenorzes(nettoText.Text) == false || afavalasztas.Text.ToString() == "")
            {
                MessageBox.Show("Rosszul adtam meg a nettó összeget");
            }
            else
            {
                if (szamEllenorzes(nettoText.Text) == true){
                    double a = int.Parse(nettoText.Text);
                    double afaerteke = 0.00;
                    double brutto = 0;

                    string b = afavalasztas.Text.ToString();
                    if (b == "5%")
                    {
                        afaerteke = a * 0.05;
                        int z = Convert.ToInt32(afaerteke);
                        afaText.Text = z.ToString();
                       
                        brutto = a + afaerteke;
                        int j = Convert.ToInt32(brutto);
                        bruttoText.Text =j.ToString();

                    }
                    if (b == "27%")
                    {
                        afaerteke = a * 0.27;
                        int z = Convert.ToInt32(afaerteke);
                        afaText.Text = z.ToString();
                        brutto = a + afaerteke;
                        int j = Convert.ToInt32(brutto);
                        bruttoText.Text = j.ToString();
                    }
                    if (b == "18%")
                    {
                        afaerteke = a * 0.18;
                        int z = Convert.ToInt32(afaerteke);
                        afaText.Text =z.ToString();
                        brutto = a + afaerteke;
                        int j = Convert.ToInt32(brutto);
                        bruttoText.Text = j.ToString();
                    }
                    if (b == "0%")
                    {
                        afaerteke = 0.00;
                        afaText.Text = afaerteke.ToString();
                        brutto = a + afaerteke;
                        bruttoText.Text = brutto.ToString();
                    }



                }
               
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public string hozzaadSzamla()
        {

            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd = connection2.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";
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

                visszaKod = reader["szamlaszam"].ToString();
                visszaNev = reader["szamlanev"].ToString();




            }


            string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd3 = connect.CreateCommand();

            connect.Open(); ;




            cmd3.CommandText = "Delete from szamlak;";
            cmd3.ExecuteNonQuery();

            connection2.Close();

            return (visszaKod);
        }
        public string getNyito(string x)
        {

            string conn2String = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd = connection2.CreateCommand();
            cmd.CommandText = "Select * FROM szamlatukor where szamlaId='" + x + "'";
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
                visszaEgyenleg = reader["egyenleg"].ToString();





            }



            return (visszaEgyenleg);
        }

        private void hozzadMunka()
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


                munkaKod.Text = reader["munkaId"].ToString();

            }
            connect.Close();
            connect.Open();
            cm2.ExecuteNonQuery();


            connect.Close();

        }

        public void hozzadPartner()
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

                partnerKod.Text = reader["partnerkod"].ToString();





            }


            string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd3 = connect.CreateCommand();

            connect.Open(); 




            cmd3.CommandText = "Delete from partner;";
            cmd3.ExecuteNonQuery();

            connection2.Close();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            tartozikKod.Text = hozzaadSzamla().ToString();
            tartozikNev.Text = visszaNev;
            TNyito.Text = getNyito(tartozikKod.Text.ToString());

        }
        public void beillesztes()
        {

            i++;


            ment.IsEnabled = true;
            torl.IsEnabled = true;
            if (ellenoriz() == true)
            {
                if (munkaKod.Text == "")
                {
                    munkaKod.Text = "999";
                }
                if (vegyesLista.Count == 0){
                    vegyesLista.Add(new Vegyes
                      {
                          sorSzam = sorszamText.Text.ToString(),
                          tetelSzam = i,
                          megjegyzes = megjText.Text,
                          netto = int.Parse(nettoText.Text),
                          afa = int.Parse(afaText.Text),
                          brutto = int.Parse(bruttoText.Text),
                          bizonylatSzam = bizszamText.Text,
                          munkaKod = int.Parse(munkaKod.Text),
                          partnerKod = int.Parse(partnerKod.Text),
                          TSzamla = tartozikKod.Text,
                          KSzamla = kovetelKod.Text,
                          DaTuM = DateTime.Parse(keltText.Text),
                          naploOsszeg = tetelOsszeg,
                      });


                }
                else
                {
                    vegyesLista.Add(new Vegyes
                    {
                        sorSzam = sorszamText.Text,
                        tetelSzam = i,
                        megjegyzes = megjText.Text,
                        netto = int.Parse(nettoText.Text),
                        afa = int.Parse(afaText.Text),
                        brutto = int.Parse(bruttoText.Text),
                        bizonylatSzam = bizszamText.Text,
                        munkaKod = int.Parse(munkaKod.Text),
                        partnerKod = int.Parse(partnerKod.Text),
                        TSzamla = tartozikKod.Text,
                        KSzamla = kovetelKod.Text,
                        DaTuM = DateTime.Parse(keltText.Text),
                        naploOsszeg = tetelOsszeg,
                    });

                }




                id.Binding = new Binding("tetelSzam");


                net.Binding = new Binding("netto");
                afa.Binding = new Binding("afa");

                brutto.Binding = new Binding("brutto");

                megj.Binding = new Binding("megjegyzes");
                tartozik.Binding = new Binding("TSzamla");
                ellensz.Binding = new Binding("KSzamla");



                int a = 0;
                a = int.Parse(afaText.Text);
                

                VegyesTetelek.Items.Add(new Vegyes { sorSzam = sorszamText.Text, tetelSzam = i, megjegyzes = megjText.Text.ToString(), netto = int.Parse(nettoText.Text), afa = int.Parse(afaText.Text), brutto = int.Parse(bruttoText.Text), bizonylatSzam = bizszamText.Text, munkaKod = int.Parse(munkaKod.Text.ToString()), partnerKod = int.Parse(partnerKod.Text.ToString()), TSzamla = tartozikKod.Text.ToString(), KSzamla = kovetelKod.Text.ToString(), DaTuM = DateTime.Parse(keltText.Text), naploOsszeg = tetelOsszeg });

                tartozikKod.Text = "";
                tartozikNev.Text = "";
                kovetelKod.Text = "";
                kovetelNev.Text = "";
                TNyito.Text = "";
                KNyito.Text = "";
                bizszamText.Text = "";
                munkaKod.Text = "";
                partnerKod.Text = "";
                megjText.Text = "";
                nettoText.Text = "";
                afaText.Text = "";
                bruttoText.Text = "";



                DataContext = this;

                ment.IsEnabled = true;
                torl.IsEnabled = true;
                mod.IsEnabled = true;

            }
            else
            {
                MessageBox.Show("Helytelenül adta meg az adatokat!!!!!");

            }

        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {

            KivalasztSzamla w10 = new KivalasztSzamla(Ceg, "", false,adatf,adatj);
            w10.Show();

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
            for(int h = 0; h < array.Length; h++)
            {
                if (Char.IsDigit(array[h]) == false)
                {
                    a = false;
                }
            }

            return (a);
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

            char[] array2 = new string(arr).Remove(1, 1).ToCharArray();

            string sd = new string(array2);


            return (sd);

        }

        public string getSorszam(string company)
        {
            int num = 0;
            string conn = "SERVER=localhost;DATABASE=" + company + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "SELECT sorszam FROM vegyesnaplo WHERE sorSzam=(SELECT MAX(sorSzam) FROM vegyesnaplo);";
            connect.Open();

            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                num++;
                ssz = reader["sorSzam"].ToString();
                
            }
            if (num == 0)
            {
                ssz = "0000";
            }
            char[] array = ssz.ToCharArray();
            Array.Reverse(array);
            string megforditott = new string(array);
            int atalakit = int.Parse(megforditott);

            atalakit = atalakit + 1000;
            Console.WriteLine(atalakit);

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
            cm6.CommandText = "Select * from szamlatukor where szamlaId='467';";




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
                cm10.CommandText = "update szamlatukor set egyenleg='" + fizAfaEgyenleg + "' where szamlaId='467';";
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }


        public int lekerdezI(string x)
        {
            int szam = 0;

            string conn = "SERVER=localhost;DATABASE=" + x + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select tetelSzam from vegyesnaplo where tetelSzam=(select MAX(tetelSzam) from vegyesnaplo);";

            connect.Open();

            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {

                szam = int.Parse(reader["tetelSzam"].ToString());

            }

            return (szam);
        }



        public bool ellenoriz()
        {
            bool vissza = true;

            if (tartozikKod.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki a Tartozik számlát!!!");
            }


            if (kovetelKod.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki a Követel számlát!!!");
            }


            if (keltText.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }
        

          
      

            if (bizszamText.Text == "")
            {
                MessageBox.Show("Kérem adja meg a bizonylatszámot!!!");
                vissza = false;
            }
            if (munkaKod.Text == "")
            {
                MessageBox.Show("Kérem adja meg a munkakódot");

            }
            if (partnerKod.Text == "")
            {
                MessageBox.Show("Kérem Adja meg a partnerkódot!!!!");
                vissza = false;
            }

            if (megjText.Text == "")
            {
                MessageBox.Show("Kérem töltse ki a megjegyzés mezőt!!!");
                vissza = false;

            }
            if (nettoText.Text == "")
            {
                MessageBox.Show("Kérem adja meg a könyvelési értéket");
                vissza = false;
            }
           

            return (vissza);
        }
    }
}

    
