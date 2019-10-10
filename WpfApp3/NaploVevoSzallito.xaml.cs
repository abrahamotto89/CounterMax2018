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
    /// Interaction logic for Window8.xaml
    /// </summary>
    public partial class NaploVevoSzallito : Window
    {
        string Ceg;
        public List<VevoSzallitoNaplo> vevoSzallitoNaploLista { get; set; }
        public List<VevoSzallito> vevoSzallitoLista {get; set;}
        public List<SzallitoVevoNaplo> listaOsszegzes { get; set; }
        string ssz;
        string rendben;
        int szamlalo = 0;
        int i = 0;
        double naploOsszeg = 0.00;
        bool valto = false;
        string adatf;
        string adatj;
        public NaploVevoSzallito(string x,string y,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            vevoSzallitoLista = new List<VevoSzallito>();
            vevoSzallitoNaploLista = new List<VevoSzallitoNaplo>();
            listaOsszegzes = new List<SzallitoVevoNaplo>();
           sorszamText.Text = getSorszam(Ceg);
            ment.IsEnabled = false;
            torl.IsEnabled = false;
            mod.IsEnabled = false;
          
          

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(tipusValaszt.Text);
            
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           ListazMunkaSzam w21=new ListazMunkaSzam(Ceg,adatf,adatj);
            w21.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //partnerKivalaszt
            PartnerKivalaszt w12 = new PartnerKivalaszt(Ceg, false,adatf,adatj);
            w12.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //partnerHozzad
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

                partnerKodText.Text = reader["partnerkod"].ToString();





            }


            string conn = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd3 = connect.CreateCommand();

            connect.Open(); ;




            cmd3.CommandText = "Delete from partner;";
            cmd3.ExecuteNonQuery();

            connection2.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //ujTétel
            int munkakodbeir = 0;
            if (ellenoriz() == true)
            {
                i++;
                szamlalo++;
                vevoSzallitoLista.Add(new VevoSzallito
                {
                    id = i,
                    megjegyzes = megjText.Text,
                    netto = double.Parse(nettoText.Text.ToString()),
                    afa = double.Parse(afaText.Text.ToString()),
                    brutto = double.Parse(bruttoText.Text.ToString()),
                    ellenSzamla = ellenszamlaText.Text,

                });

                string valaszt;

                if (tipusValaszt.Text.ToString() == "Vevő Számla")
                {
                    valaszt = "311";

                }
                else
                    valaszt = "4541";
                if (munkaKod.Text == "")
                {
                     munkakodbeir=999;
                }
                else
                {
                    munkakodbeir = int.Parse(munkaKod.Text);
                }
                vevoSzallitoNaploLista.Add(new VevoSzallitoNaplo
                {
                    id = szamlalo,
                    sorSzam = sorszamText.Text.ToString(),
                    tipus = tipusValaszt.Text.ToString(),
                    szamlaSzam = valaszt,
                    ellenSzamla = ellenszamlaText.Text.ToString(),
                    bizonylatSzam = bizszamText.Text.ToString(),
                    munkaSzam = munkakodbeir,
                    partnerKod = int.Parse(partnerKodText.Text),
                    megjegyzes = megjText.Text.ToString(),
                    fizetesModja = fizmod.Text,
                    kelt = DateTime.Parse(keltText.Text),
                    teljIdeje = DateTime.Parse(teljText.Text),
                    fizHat = DateTime.Parse(fizHatText.Text),
                    afaEsed = DateTime.Parse(afaEsedText.Text),
                    netto = double.Parse(nettoText.Text),
                    afa = double.Parse(afaText.Text.ToString()),
                    brutto = double.Parse(bruttoText.Text),
                    afaKulcs = afavalasztas.Text.ToString(),





                });






                id.Binding = new Binding("id");
                megj.Binding = new Binding("megjegyzes");
                net.Binding = new Binding("netto");
                afa.Binding = new Binding("afa");
                brutto.Binding = new Binding("brutto");
                ellensz.Binding = new Binding("ellenSzamla");


                VevoSzallTetelek.Items.Add(new VevoSzallito { id = i, megjegyzes = megjText.Text, netto = double.Parse(nettoText.Text), afa = double.Parse(afaText.Text), brutto = double.Parse(bruttoText.Text), ellenSzamla = ellenszamlaText.Text });

                DataContext = this;



                tipusValaszt.IsEnabled = false;
                ment.IsEnabled = true;
                torl.IsEnabled = true;
                mod.IsEnabled = true;

                munkaKod.Text = "";
                ellenszamlaText.Text = "";
                megjText.Text = "";
                nettoText.Text = "";
                afaText.Text = "";
                bruttoText.Text = "";

            }
            else
            {
                MessageBox.Show("Tétel felvétele sikertelen!!!" + "\n Kérem nézze át az adatokat!!!");

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            KivalasztSzamla w10 = new KivalasztSzamla(Ceg, "", false,adatf,adatj);
            w10.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Várakoztunk 20mp");
            string connString = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select * FROM szamlak";

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ellenszamlaText.Text = reader["szamlaszam"].ToString();

                ellenszamlaNevText.Text = reader["szamlanev"].ToString();
                

            }
            connection.Close();








            hozzadEllen.IsEnabled = true;
        }
       

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (szamEllenorzes(nettoText.Text)==false)
            {
                MessageBox.Show("Rosszul adtam meg a nettó összeget");
            }
            else
            {
                if (szamEllenorzes(nettoText.Text) == true && afavalasztas.Text!="")
                {

                    double a = Double.Parse(nettoText.Text.ToString());
                    double afaerteke = 0.00;
                    double brutto = 0.00;

                    string b = afavalasztas.Text.ToString();
                    if (b == "5%")
                    {

                        afaerteke = a * 0.05;


                        string oke = afaerteke.ToString();
                        string.Format("{0:0.00}", oke);

                        afaText.Text = oke;


                        brutto = a + afaerteke;

                        string oke2 = brutto.ToString();
                        string.Format("{0:0.00}", oke2);
                        bruttoText.Text = oke2;
                    }
                    if (b == "27%")

                    {
                        afaerteke = a * 0.27;
                        afaText.Text = afaerteke.ToString();
                        brutto = a + afaerteke;
                        bruttoText.Text = brutto.ToString();
                    }
                    if (b == "18%")
                    {
                        afaerteke = a * 0.18;
                        afaText.Text = afaerteke.ToString();
                        brutto = a + afaerteke;
                        bruttoText.Text = brutto.ToString();
                    }
                    if (b == "0%")
                    {
                        afaerteke = 0.00;
                        afaText.Text = afaerteke.ToString();
                        brutto = a + afaerteke;
                        bruttoText.Text = brutto.ToString();
                    }
                    if (b == "mentes")
                    {
                        afaerteke = 0.00;
                        afaText.Text = afaerteke.ToString();
                        brutto = a + afaerteke;
                        bruttoText.Text = brutto.ToString();
                    }
                }
               if(szamEllenorzes(nettoText.Text)==true && afavalasztas.Text == "")
                {
                    MessageBox.Show("Kérem válassza ki az áfa értékét!!!!");
                }
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
          
                //mentés



                if (vevoSzallitoNaploLista.Count != 0)
            {
                for (i = 0; i < vevoSzallitoNaploLista.Count; i++)
                {


                    naploOsszeg = naploOsszeg + vevoSzallitoNaploLista[i].brutto;
                    string kapcsolatneve = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                    MySqlConnection connect = new MySqlConnection(kapcsolatneve);
                    MySqlCommand cm = connect.CreateCommand();


                  
                   

                    cm.CommandText = "insert into vevoszallitonaplo values('" + vevoSzallitoNaploLista[i].id + "','" + vevoSzallitoNaploLista[i].sorSzam + "','" + vevoSzallitoNaploLista[i].tipus + "','" + vevoSzallitoNaploLista[i].szamlaSzam + "','" + vevoSzallitoNaploLista[i].ellenSzamla + "','" + vevoSzallitoNaploLista[i].bizonylatSzam + "','" + vevoSzallitoNaploLista[i].megjegyzes + "','" + vevoSzallitoNaploLista[i].fizetesModja + "','" + vevoSzallitoNaploLista[i].kelt + "','" + vevoSzallitoNaploLista[i].teljIdeje + "','" + vevoSzallitoNaploLista[i].fizHat + "','" + vevoSzallitoNaploLista[i].afaEsed + "','" + vevoSzallitoNaploLista[i].netto + "','"+vevoSzallitoNaploLista[i].afa+"','"+vevoSzallitoNaploLista[i].brutto+"','" + vevoSzallitoNaploLista[i].afaKulcs + "','"+vevoSzallitoNaploLista[i].partnerKod+"','"+vevoSzallitoNaploLista[i].munkaSzam+"');";
                    try
                    {
                        connect.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    




                    cm.ExecuteNonQuery();
                    connect.Close();
                    if (tipusValaszt.Text.ToString() == "Vevő Számla")
                    {
                        bool irany = true;
                        konyvelBank(Ceg, vevoSzallitoNaploLista[i].szamlaSzam, vevoSzallitoNaploLista[i].ellenSzamla, vevoSzallitoNaploLista[i].brutto, vevoSzallitoNaploLista[i].afa, irany);
                    }
                    else
                         if (tipusValaszt.Text.ToString() == "Szállító Számla")
                    {
                        bool irany = false;
                        konyvelBank(Ceg, vevoSzallitoNaploLista[i].ellenSzamla, vevoSzallitoNaploLista[i].szamlaSzam, vevoSzallitoNaploLista[i].brutto, vevoSzallitoNaploLista[i].afa, irany);
                    }


                    ellenszamlaNevText.Text = "";
                    ellenszamlaText.Text = "";
                    bizszamText.Text = "";
                    munkaKod.Text = "";
                    partnerKodText.Text = "";
                    megjText.Text = "";
                    nettoText.Text = "";
                    afaText.Text = "";
                    bruttoText.Text = "";
                    fizmod.IsEnabled = false;

                    tipusValaszt.IsEnabled = true;
                    fizmod.IsEnabled = true;
                    Console.WriteLine("i érteéke: "+i);
                    if (i == vevoSzallitoNaploLista.Count() - 1)
                    {
                        if (vevoSzallitoNaploLista[i].szamlaSzam == "311")
                        {
                            listaOsszegzes.Add(new SzallitoVevoNaplo
                            {
                                sorszam = vevoSzallitoNaploLista[i].sorSzam,
                                fokonyviszam = "311",
                                nyitoErtek = int.Parse(nyito.Text),
                                bizszam = vevoSzallitoNaploLista[i].bizonylatSzam,
                                partnerKod = vevoSzallitoNaploLista[i].partnerKod,
                                munkaKod = vevoSzallitoNaploLista[i].munkaSzam,
                                megjegyzes = vevoSzallitoNaploLista[i].megjegyzes,
                                osszeg=Convert.ToInt32(vevoSzallitoNaploLista[i].brutto),
                                idoTime = vevoSzallitoNaploLista[i].teljIdeje,

                            });


                        }

                        else
                            if (vevoSzallitoNaploLista[i].szamlaSzam == "4541")
                        {
                            listaOsszegzes.Add(new SzallitoVevoNaplo
                            {
                                sorszam = vevoSzallitoNaploLista[i].sorSzam,
                                fokonyviszam = "4541",
                                nyitoErtek = int.Parse(nyito.Text),
                                bizszam = vevoSzallitoNaploLista[i].bizonylatSzam,
                                partnerKod = vevoSzallitoNaploLista[i].partnerKod,
                                munkaKod = vevoSzallitoNaploLista[i].munkaSzam,
                                megjegyzes = vevoSzallitoNaploLista[i].megjegyzes,
                                osszeg=Convert.ToInt32(vevoSzallitoNaploLista[i].brutto),
                                idoTime = vevoSzallitoNaploLista[i].teljIdeje,

                            });

                        }
                    }


                }


                ellenszamlaNevText.Text = "";
                ellenszamlaText.Text = "";
                bizszamText.Text = "";
                munkaKod.Text = "";
                partnerKodText.Text = "";
                megjText.Text = "";
                nettoText.Text = "";
                afaText.Text = "";
                bruttoText.Text = "";
                fizmod.IsEnabled = true;
                tipusValaszt.Text = "";
                tipusValaszt.IsEnabled = true;
                keltText.Text = "";
                teljText.Text = "";
                fizHatText.Text = "";
                afaEsedText.Text = "";
                nyito.Text = "";
                ment.IsEnabled = false;
                mod.IsEnabled = false;
                torl.IsEnabled = false;
            


            }
            else
                MessageBox.Show("Nem vett fel tételt");





            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcs = new MySqlConnection(conn);
            MySqlCommand parancs = kapcs.CreateCommand();
            parancs.CommandText = "insert into vevoszallitonaploosszegzes values('" + listaOsszegzes[0].sorszam + "','" + listaOsszegzes[0].fokonyviszam + "','" + listaOsszegzes[0].nyitoErtek + "','" + listaOsszegzes[0].bizszam + "','" + listaOsszegzes[0].partnerKod + "','" + listaOsszegzes[0].munkaKod+ "','" +listaOsszegzes[0].megjegyzes+ "','" + listaOsszegzes[0].osszeg + "','" + listaOsszegzes[0].idoTime + "');";

            try{
                kapcs.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            parancs.ExecuteNonQuery();
            kapcs.Close();

            ment.IsEnabled = false;
            mod.IsEnabled = false;
            torl.IsEnabled = false;



            for (i = 0; i < vevoSzallitoNaploLista.Count; i++)
            {
                vevoSzallitoNaploLista.RemoveAt(i);
            }

            VevoSzallTetelek.Items.Clear();

            for (i = 0; i < listaOsszegzes.Count; i++)
            {
                listaOsszegzes.RemoveAt(i);
            }
            sorszamText.Text = getSorszam(Ceg);
        }
        public string getSorszam(string company)
        {
            string conn = "SERVER=localhost;DATABASE=" + company + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand cm2 = connect.CreateCommand();
            cm.CommandText = "Select sorSzam from vevoszallitonaplo where id=(select MAX(id) from vevoszallitonaplo);";
            cm2.CommandText = "select *from vevoszallitonaplo;";

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                ssz = reader["sorSzam"].ToString();
                

            }

            connect.Close();


            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            MySqlDataReader reader2 = cm2.ExecuteReader();
            while (reader2.Read())
            {
                szamlalo = int.Parse(reader2["id"].ToString());


            }
            connect.Close();
            if (ssz == null)
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

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var selecteditem = VevoSzallTetelek.SelectedItem;
            VevoSzallito c1 = (VevoSzallito)VevoSzallTetelek.SelectedItems[0];


            for (i = 0; i < vevoSzallitoNaploLista.Count; i++)
            {
                if (vevoSzallitoNaploLista[i].ellenSzamla == c1.ellenSzamla)
                {
                   vevoSzallitoNaploLista.RemoveAt(i);
                }
            }



            VevoSzallTetelek.Items.Remove(selecteditem);
            szamlalo--;

            ellenszamlaNevText.Text = "";
            ellenszamlaText.Text = "";
            bizszamText.Text = "";
            munkaKod.Text = "";
            partnerKodText.Text = "";
            megjText.Text = "";
            nettoText.Text = "";
            afaText.Text = "";
            bruttoText.Text = "";
            fizmod.Text = "";

            tipusValaszt.Text = "";
            fizmod.IsEnabled = true;
            tipusValaszt.IsEnabled = true;
            nyito.Text = "";
            keltText.Text = "";
            fizHatText.Text = "";
            afaEsedText.Text = "";
            afavalasztas.Text = "";

            teljText.Text = "";

            if (vevoSzallitoNaploLista.Count() == 0)
            {
                ment.IsEnabled = false;
                torl.IsEnabled = false;
                mod.IsEnabled = false;
            }

        }
        public void konyvelBank(string ceg, string t, string k, double a, double b, bool irany)
        {
            int tartozik = 0;

            int kovetel = 0;
            int tartozikOldalKovetel = 0;
            int kovetelOldalTartozik = 0;
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



            cm.CommandText = "select *from szamlatukor where szamlaId='" + t + "';"; //k

            cm2.CommandText = "select *from szamlatukor where szamlaId='" + k + "';";  //t
           
            cm5.CommandText = "Select *from szamlatukor where szamlaId='466';";
            cm6.CommandText = "Select *from szamlatukor where szamlaId='467';";



            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                tartozik = int.Parse(reader["tartozik"].ToString());
                Console.WriteLine("tartoziklekerdezes"+tartozik);
               
            }


            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MySqlDataReader reader2 = cm2.ExecuteReader();
            while (reader2.Read())
            {
                kovetel = int.Parse(reader2["kovetel"].ToString());
                Console.WriteLine("kovetellekerdezes"+kovetel);


            }

            connect.Close();

            if (irany == true)
            {
                tartozik = tartozik + Convert.ToInt32(a);
                kovetel = kovetel + (Convert.ToInt32(a) - Convert.ToInt32(b));
                Console.WriteLine("irany==trueefut" + tartozik+kovetel);
               
            }


            else
            {
                tartozik = tartozik + (Convert.ToInt32(a) - Convert.ToInt32(b));
                kovetel = kovetel + Convert.ToInt32(a);
                Console.WriteLine("irany==falsefut"+tartozik+kovetel);

            }
            cm3.CommandText = "update szamlatukor  set tartozik='" + tartozik + "' where szamlaId='" + t + "';";
            cm4.CommandText = "update szamlatukor  set kovetel='" + kovetel + "' where szamlaId='" + k + "';";

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cm3.ExecuteNonQuery();
            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cm4.ExecuteNonQuery();

            connect.Close();
            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


       
            MySqlDataReader readerE=cm.ExecuteReader();
            while (readerE.Read())
            {
                tartegyenleg = int.Parse(readerE["egyenleg"].ToString());
                tartozik = int.Parse(readerE["tartozik"].ToString());
                tartozikOldalKovetel = int.Parse(readerE["kovetel"].ToString());

                Console.WriteLine("egyenlegfut"+tartegyenleg);

            }
            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader readerKE = cm2.ExecuteReader();
            Console.WriteLine("Jelenleg ez fut");
         
            while (readerKE.Read())
            {
                kovegyenleg = int.Parse(readerKE["egyenleg"].ToString());
                kovetel = int.Parse(readerKE["kovetel"].ToString());
                kovetelOldalTartozik = int.Parse(readerKE["tartozik"].ToString());
                Console.WriteLine("egyenlegfut");

            }
            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




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
            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            



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












            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





         


          
            if (tartozik >= tartozikOldalKovetel)
            {
                tartegyenleg = tartozik - tartozikOldalKovetel;

            }
            if (tartozikOldalKovetel >= tartozik)
            {
                tartegyenleg = tartozikOldalKovetel - tartozik;
            }

            if (kovetel >= kovetelOldalTartozik)
            {
                kovegyenleg = kovetel - kovetelOldalTartozik;
            }
            if (kovetelOldalTartozik >= kovetel)
            {
                kovegyenleg = kovetelOldalTartozik - kovetel;
            }



            cm8.CommandText = "update szamlatukor set egyenleg='" + tartegyenleg + "' where szamlaId='" + t + "'";
            cm9.CommandText = "update szamlatukor set egyenleg='" + kovegyenleg + "' where szamlaId='" + k + "'";

           

        
            cm8.ExecuteNonQuery();

            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            cm9.ExecuteNonQuery();

            connect.Close();
         
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


            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cm7.ExecuteNonQuery();


            connect.Close();

            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cm10.ExecuteNonQuery();


            connect.Close();


        }


        public int getNyitoertek(string x, string szamla)
        {

            int szamlaEgyenleg = 0;
            string conn = "SERVER=localhost;DATABASE="+x+";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
           
            cm.CommandText = "Select * FROM szamlatukor where szamlaId='"+szamla+"'";
            try
            {

                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                szamlaEgyenleg = int.Parse(reader["egyenleg"].ToString());
            }

            connect.Close();
            Console.WriteLine(szamlaEgyenleg);
            return (szamlaEgyenleg);
            
        }

        private void tipusValaszt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipusValaszt.Text == "Vevő Számla")
            {
                nyito.Text = (getNyitoertek(Ceg, "311")).ToString();
            }
            else
                nyito.Text = (getNyitoertek(Ceg, "4541")).ToString();
        }

        private void tipusValaszt_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (tipusValaszt.Text == "Vevő Számla")
            {
                nyito.Text = (getNyitoertek(Ceg, "4541")).ToString();
            }
            else
                nyito.Text = (getNyitoertek(Ceg, "311")).ToString();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (VevoSzallTetelek.SelectedItem != null)
            {

                var selecteditem = VevoSzallTetelek.SelectedItem;
                VevoSzallito c1 = (VevoSzallito)VevoSzallTetelek.SelectedItems[0];
                int a = 0;
                for (i = 0; i < vevoSzallitoLista.Count(); i++)
                {
                    if (c1.ellenSzamla == vevoSzallitoLista[i].ellenSzamla && c1.brutto == vevoSzallitoLista[i].brutto)
                    {
                        a = i;
                    }
                }


                for (i = 0; i < vevoSzallitoNaploLista.Count(); i++)
                {
                    if (vevoSzallitoNaploLista[i].ellenSzamla == c1.ellenSzamla && vevoSzallitoNaploLista[i].brutto == c1.brutto)
                    {
                        ellenszamlaText.Text = vevoSzallitoNaploLista[i].ellenSzamla;
                        bizszamText.Text = vevoSzallitoNaploLista[i].bizonylatSzam;
                        partnerKodText.Text = vevoSzallitoNaploLista[i].partnerKod.ToString();
                        munkaKod.Text = vevoSzallitoNaploLista[i].munkaSzam.ToString();
                        megjText.Text = vevoSzallitoNaploLista[i].megjegyzes;
                        nettoText.Text = vevoSzallitoNaploLista[i].netto.ToString();
                        afaText.Text = vevoSzallitoNaploLista[i].afa.ToString();
                        bruttoText.Text = vevoSzallitoNaploLista[i].brutto.ToString();
                        fizmod.Text = vevoSzallitoNaploLista[i].fizetesModja;
                        vevoSzallitoNaploLista.RemoveAt(i);
                        vevoSzallitoLista.RemoveAt(a);
                    }
                }

                VevoSzallTetelek.Items.Remove(selecteditem);


            }
            else
                MessageBox.Show("Kérem jelölje ki a módosítandó tételt");
        }

        public bool ellenoriz()
        {
            bool vissza = true;

            if (tipusValaszt.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki a számla típusát!!!");
            }


            if (ellenszamlaText.Text == "")
            {
                vissza = false;
                MessageBox.Show("Kérem válassza ki az ellenszámlát!!!");
            }


            if (keltText.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }
            if (teljText.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }

            if (fizHatText.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }
            if (afaEsedText.Text == "")
            {
                MessageBox.Show("Kérem adja meg  helyesen a dátumokat!!!!");
                vissza = false;
            }

            if (bizszamText.Text == "")
            {
                MessageBox.Show("Kérem adja meg a bizonylatszámot!!!");
                vissza = false;
            }
            if(munkaKod.Text==""){
                MessageBox.Show("Kérem adja meg a munkakódot");
               
            }
            if (partnerKodText.Text == "")
            {
                MessageBox.Show("Kérem Adja meg a partnerkódot!!!!");
                vissza = false;
            }

            if(megjText.Text=="") {
                MessageBox.Show("Kérem töltse ki a megjegyzés mezőt!!!");
                vissza = false;
                
            }
            if (nettoText.Text == "")
            {
                MessageBox.Show("Kérem adja meg a könyvelési értéket");
                vissza=false;
            }
            if (fizmod.Text == "")
            {
                MessageBox.Show("Kérem adja meg a fizetés módját!!!");
                vissza = false;
            }

            return (vissza);
        }
        public static bool szamEllenorzes(string x)
        {
            bool a = true;
            char[] array = x.ToCharArray();
           
            string minta = @"^[1-9][0-9]*$";
            string input = x;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (Char.IsDigit(array[i]) == false)
                {
                    a = false;
                }
            }
            return (a);
        }
    }
}
