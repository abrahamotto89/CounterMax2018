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
    /// Interaction logic for Window31.xaml
    /// </summary>
    public partial class MerlegMegjelenit : Window
    {
        List<Eszkozok> eszkoz = new List<Eszkozok>();
        List<Forrasok> forras = new List<Forrasok>();
        List<SzamlaSzamok> szamlak = new List<SzamlaSzamok>();
        string Ceg;
        string adatf;
        string adatj;
        int befektetetteszkozok = 0;
        int forgoOsszes = 0;
        int aktivIdobeli = 0;
        public MerlegMegjelenit(string x, string y,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            feltolt(Ceg);
            szamlakFeltolt();
            egyenlegJavit();
           befektetettEszkozok();
            ForgoEszkozok();
            forrasokMerleg();
            fokonyvBeolvas();
            megjelenitEszkozok();
            megjelenitForrasok();
        }
        public void fokonyvBeolvas()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select * from merleg;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                if (int.Parse(reader["szamlalo"].ToString()) < 10)
                {
                    eszkoz.Add(new Eszkozok
                    {
                        tetelNev = reader["tetelNev"].ToString(),
                        tetelMegnevezes = reader["tetelMegnevezes"].ToString(),
                        elozoEv = 0,
                        targyEv = int.Parse(reader["targyEv"].ToString()),
                    });
                }

                if (int.Parse(reader["szamlalo"].ToString()) >= 10)
                {
                    forras.Add(new Forrasok
                    {
                        tetelNev = reader["tetelNev"].ToString(),
                        tetelMegnevezes = reader["tetelMegnevezes"].ToString(),
                        elozoEv = 0,
                        targyEv = int.Parse(reader["targyEv"].ToString()),
                    });
                }
            }




        }













        public void megjelenitEszkozok()
        {
            tetel.Binding = new Binding("tetelNev");
            megnev.Binding = new Binding("tetelMegnevezes");
            elozoEv.Binding = new Binding("elozoEv");
            targyEv.Binding = new Binding("targyEv");
         


         

            

            for (int i = 0; i < eszkoz.Count(); i++)
            {

                Eszkozok.Items.Add(new Eszkozok
                {

                    tetelNev = eszkoz[i].tetelNev,
                    tetelMegnevezes = eszkoz[i].tetelMegnevezes,
                    elozoEv = eszkoz[i].elozoEv,
                    targyEv = eszkoz[i].targyEv,

                });

            }

          
            












            DataContext = this;
          


        }
        public void megjelenitForrasok()
        {
            tetelF.Binding = new Binding("tetelNev");
            megnevF.Binding = new Binding("tetelMegnevezes");
            elozoEvf.Binding = new Binding("elozoEv");
            targyEvf.Binding = new Binding("targyEv");

            

                        for (int i = 0; i < forras.Count(); i++)
                        {

                            Forrasok.Items.Add(new Forrasok
                            {

                                tetelNev = forras[i].tetelNev,
                                tetelMegnevezes = forras[i].tetelMegnevezes,
                                elozoEv = forras[i].elozoEv,
                                targyEv = forras[i].targyEv,

                            });

                        }


                


           






            DataContext = this;
           
        }



        public void szamlakFeltolt()
        {

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand im = connect.CreateCommand();
            cm.CommandText = "Select * from fokonyv;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
                szamlak.Add(new SzamlaSzamok
                {

                    szamlaSzam = int.Parse(reader["fokonyviSzam"].ToString()),
                    szamlaNev = reader["nev"].ToString(),
                    tartozik = int.Parse(reader["tforgalom"].ToString()),
                    kovetel = int.Parse(reader["kforgalom"].ToString()),
                    egyenleg = int.Parse(reader["egyenleg"].ToString()),


                });



            }
            connect.Close();


        }

        public void befektetettEszkozok()
        {

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand targyi = connect.CreateCommand();
            MySqlCommand befektetp = connect.CreateCommand();
            MySqlCommand befektettEszk = connect.CreateCommand();
            int alapitasatszervezes = 0;
            int kiserletifejlesztes = 0;
            int vagyonertekujogok = 0;
            int szellemitermek = 0;
            int uzletivagyceg = 0;
            int immaterialisjavakraadotteloleg = 0;
            int immaterialisjavakertekhelyesbitese = 0;
            List<int> osszes = new List<int>();
            int immaterialis = 0;
            int befektetPenzugy = 0;
 
            List<int> h = new List<int>();
            h.Add(0);
            h.Add(0);

            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);

            h.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);

            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);
            osszes.Add(0);

            osszes.Add(0);


            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 111)
                {
                    alapitasatszervezes = alapitasatszervezes + szamlak[i].egyenleg;
                    h[0] = 1;

                }

                if (szamlak[i].szamlaSzam == 1191 && h[0] == 1)
                {
                    alapitasatszervezes = alapitasatszervezes - szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 112)
                {

                    kiserletifejlesztes = kiserletifejlesztes + szamlak[i].egyenleg;
                    h[1] = 1;

                }

                if (szamlak[i].szamlaSzam == 1192 && h[1] == 1)
                {

                    kiserletifejlesztes = kiserletifejlesztes - szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 113)
                {

                    vagyonertekujogok = vagyonertekujogok + szamlak[i].egyenleg;
                    h[2] = 1;

                }

                if (szamlak[i].szamlaSzam == 1193 && h[2] == 1)
                {


                    vagyonertekujogok = vagyonertekujogok - szamlak[i].egyenleg;

                }

                if (szamlak[i].szamlaSzam == 114)
                {

                    szellemitermek = szellemitermek + szamlak[i].egyenleg;
                    h[3] = 1;

                }

                if (szamlak[i].szamlaSzam == 1194 && h[3] == 1)
                {

                    szellemitermek = szellemitermek - szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 115)
                {

                    uzletivagyceg = uzletivagyceg + szamlak[i].egyenleg;
                    h[4] = 1;

                }

                if (szamlak[i].szamlaSzam == 1195 && h[4] == 1)
                {

                    uzletivagyceg = uzletivagyceg - szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 351)
                {

                    immaterialisjavakraadotteloleg = immaterialisjavakraadotteloleg + szamlak[i].egyenleg;
                    h[5] = 1;

                }

                if (szamlak[i].szamlaSzam == 3591 && h[5] == 1)
                {

                    immaterialisjavakraadotteloleg = immaterialisjavakraadotteloleg - szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 117)
                {
                    immaterialisjavakertekhelyesbitese = immaterialisjavakertekhelyesbitese + szamlak[i].egyenleg;

                }








            }
            immaterialis = alapitasatszervezes + kiserletifejlesztes + vagyonertekujogok + szellemitermek + uzletivagyceg + immaterialisjavakraadotteloleg + immaterialisjavakertekhelyesbitese;

            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + immaterialis + "' where szamlalo=1;";
            parancs.ExecuteNonQuery();

            connect.Close();

            int ingatlanokeskapcs = 0;
            int muszakiberendezes = 0;
            int egyebberendezes = 0;
            int tenyeszallat = 0;
            int beruhazasfelujitas = 0;
            int beruhazasraadotteloleg = 0;
            int targyieszkozertekhelyesbitese = 0;
            int targyieszkozok = 0;
            for (int i = 0; i < szamlak.Count(); i++)
            {


                if (szamlak[i].szamlaSzam == 12)
                {
                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;


                }

                if (szamlak[i].szamlaSzam == 121)
                {
                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;

                }


                if (szamlak[i].szamlaSzam == 122)
                {

                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;
                }

                if (szamlak[i].szamlaSzam == 123)
                {
                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;


                }
                if (szamlak[i].szamlaSzam == 124)
                {
                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;

                }
                if (szamlak[i].szamlaSzam == 125)
                {

                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;
                }
                if (szamlak[i].szamlaSzam == 126)
                {

                    ingatlanokeskapcs = ingatlanokeskapcs + szamlak[i].egyenleg;
                    h[6] = 1;
                }



                if (szamlak[i].szamlaSzam == 128 && h[6] == 1)
                {
                    ingatlanokeskapcs = ingatlanokeskapcs - szamlak[i].egyenleg;
                  
                }


                if (szamlak[i].szamlaSzam == 13)
                {
                    muszakiberendezes = muszakiberendezes + szamlak[i].egyenleg;
                    h[7] = 1;


                }

                if (szamlak[i].szamlaSzam == 131)
                {
                    muszakiberendezes = muszakiberendezes + szamlak[i].egyenleg;
                    h[7] = 1;

                }


                if (szamlak[i].szamlaSzam == 132)
                {

                    muszakiberendezes = muszakiberendezes + szamlak[i].egyenleg;
                    h[7] = 1;
                }


                if (szamlak[i].szamlaSzam == 138 && h[7] == 1)
                {
                    muszakiberendezes = muszakiberendezes - szamlak[i].egyenleg;


                }


                if (szamlak[i].szamlaSzam == 139 && h[7] == 1)
                {

                    muszakiberendezes = muszakiberendezes - szamlak[i].egyenleg;

                }

                if (szamlak[i].szamlaSzam == 14)
                {
                    egyebberendezes = egyebberendezes + szamlak[i].egyenleg;
                    h[8] = 1;


                }


                if (szamlak[i].szamlaSzam == 141)
                {
                    egyebberendezes = egyebberendezes + szamlak[i].egyenleg;
                    h[8] = 1;


                }


                if (szamlak[i].szamlaSzam == 142)
                {

                    egyebberendezes = egyebberendezes + szamlak[i].egyenleg;
                    h[8] = 1;

                }

                if (szamlak[i].szamlaSzam == 143)
                {

                    egyebberendezes = egyebberendezes + szamlak[i].egyenleg;
                    h[8] = 1;

                }



                if (szamlak[i].szamlaSzam == 144)
                {
                    egyebberendezes = egyebberendezes + szamlak[i].egyenleg;
                    h[8] = 1;


                }

                if (szamlak[i].szamlaSzam == 148 && h[8] == 1)
                {
                    egyebberendezes = egyebberendezes - szamlak[i].egyenleg;



                }
                if (szamlak[i].szamlaSzam == 149 && h[8] == 1)
                {
                    egyebberendezes = egyebberendezes - szamlak[i].egyenleg;



                }


                if (szamlak[i].szamlaSzam == 15)
                {
                    tenyeszallat = tenyeszallat + szamlak[i].egyenleg;
                    h[9] = 1;



                }
                if (szamlak[i].szamlaSzam == 151)
                {
                    tenyeszallat = tenyeszallat + szamlak[i].egyenleg;
                    h[9] = 1;


                }
                if (szamlak[i].szamlaSzam == 152)
                {


                    tenyeszallat = tenyeszallat + szamlak[i].egyenleg;
                    h[9] = 1;

                }
                if (szamlak[i].szamlaSzam == 153)
                {
                    tenyeszallat = tenyeszallat + szamlak[i].egyenleg;
                    h[9] = 1;



                }


                if (szamlak[i].szamlaSzam == 158 && h[9] == 1)
                {
                    tenyeszallat = tenyeszallat - szamlak[i].egyenleg;




                }
                if (szamlak[i].szamlaSzam == 159 && h[9] == 1)
                {
                    tenyeszallat = tenyeszallat - szamlak[i].egyenleg;




                }

                if (szamlak[i].szamlaSzam == 16)
                {
                    beruhazasfelujitas = beruhazasfelujitas + szamlak[i].egyenleg;
                    h[10] = 1;



                }
                if (szamlak[i].szamlaSzam == 161)
                {

                    beruhazasfelujitas = beruhazasfelujitas + szamlak[i].egyenleg;
                    h[10] = 1;

                }
                if (szamlak[i].szamlaSzam == 162)
                {

                    beruhazasfelujitas = beruhazasfelujitas + szamlak[i].egyenleg;
                    h[10] = 1;

                }


                if (szamlak[i].szamlaSzam == 168 && h[10] == 1)
                {

                    beruhazasfelujitas = beruhazasfelujitas - szamlak[i].egyenleg;

                }
                if (szamlak[i].szamlaSzam == 169 && h[10] == 1)
                {

                    beruhazasfelujitas = beruhazasfelujitas - szamlak[i].egyenleg;


                }
                if (szamlak[i].szamlaSzam == 352)
                {

                    beruhazasraadotteloleg = beruhazasraadotteloleg + szamlak[i].egyenleg;
                    h[11] = 1;
                }
                if (szamlak[i].szamlaSzam == 3592 && h[11] == 1)
                {

                    beruhazasraadotteloleg = beruhazasraadotteloleg - szamlak[i].egyenleg;

                }


                if (szamlak[i].szamlaSzam == 127)
                {

                    targyieszkozertekhelyesbitese = targyieszkozertekhelyesbitese + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 137)
                {

                    targyieszkozertekhelyesbitese = targyieszkozertekhelyesbitese + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 147)
                {

                    targyieszkozertekhelyesbitese = targyieszkozertekhelyesbitese + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 157)
                {

                    targyieszkozertekhelyesbitese = targyieszkozertekhelyesbitese + szamlak[i].egyenleg;
                }




            }

            connect.Open();
            targyieszkozok = ingatlanokeskapcs + muszakiberendezes + egyebberendezes + tenyeszallat + beruhazasfelujitas + beruhazasraadotteloleg + targyieszkozertekhelyesbitese;
            targyi.CommandText = "update merleg set targyEv='" + targyieszkozok + "' where szamlalo=2;";
            targyi.ExecuteNonQuery();

            connect.Close();

            int tartosreszedeskapcsolt = 0;
            int tartosanadottkolcson = 0;
            int egyebtartos = 0;
            int tartosanadottkolcsonegyeb = 0;
            int egyebtartosanadottkolcson = 0;
            int tartoshitelviszonymegtestesito = 0;
            int befektetettepenzugyieszkozokertekhely = 0;
            int befektetettpenzertekkul = 0;
            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 17)
                {

                }

                if (szamlak[i].szamlaSzam == 171)
                {
                    tartosreszedeskapcsolt = tartosreszedeskapcsolt + szamlak[i].egyenleg;
                    h[12] = 1;


                }

                if (szamlak[i].szamlaSzam == 179 && h[12] == 1)
                {
                    tartosreszedeskapcsolt = tartosreszedeskapcsolt - szamlak[i].egyenleg;



                }

                if (szamlak[i].szamlaSzam == 191)
                {
                    tartosanadottkolcson = tartosanadottkolcson + szamlak[i].egyenleg;
                    h[13] = 1;


                }

                if (szamlak[i].szamlaSzam == 199 && h[13] == 1)
                {
                    tartosanadottkolcson = tartosanadottkolcson - szamlak[i].egyenleg;




                }
                if (szamlak[i].szamlaSzam == 172)
                {
                    egyebtartos = egyebtartos + szamlak[i].egyenleg;
                    h[14] = 1;


                }

                if (szamlak[i].szamlaSzam == 179 && h[14] == 1)
                {
                    egyebtartos = egyebtartos - szamlak[i].egyenleg;




                }
                if (szamlak[i].szamlaSzam == 192)
                {
                    tartosanadottkolcson = tartosanadottkolcson + szamlak[i].egyenleg;
                    h[15] = 1;


                }

                if (szamlak[i].szamlaSzam == 199 && h[15] == 1)
                {
                    tartosanadottkolcson = tartosanadottkolcson - szamlak[i].egyenleg;




                }

                if (szamlak[i].szamlaSzam == 193)
                {
                    egyebtartosanadottkolcson = egyebtartosanadottkolcson + szamlak[i].egyenleg;
                    h[16] = 1;


                }


                if (szamlak[i].szamlaSzam == 194)
                {
                    egyebtartosanadottkolcson = egyebtartosanadottkolcson + szamlak[i].egyenleg;
                    h[16] = 1;


                }
                if (szamlak[i].szamlaSzam == 195)
                {
                    egyebtartosanadottkolcson = egyebtartosanadottkolcson + szamlak[i].egyenleg;
                    h[16] = 1;


                }
                if (szamlak[i].szamlaSzam == 196)
                {
                    egyebtartosanadottkolcson = egyebtartosanadottkolcson + szamlak[i].egyenleg;
                    h[16] = 1;


                }
                if (szamlak[i].szamlaSzam == 197)
                {
                    egyebtartosanadottkolcson = egyebtartosanadottkolcson + szamlak[i].egyenleg;
                    h[16] = 1;


                }
                if (szamlak[i].szamlaSzam == 199 && h[16] == 1)
                {


                    egyebtartosanadottkolcson = egyebtartosanadottkolcson - szamlak[i].egyenleg;


                }
                if (szamlak[i].szamlaSzam == 18)
                {


                    tartoshitelviszonymegtestesito = tartoshitelviszonymegtestesito + szamlak[i].egyenleg;
                    h[17] = 1;

                }

                if (szamlak[i].szamlaSzam == 189 && h[17] == 1)

                {


                    tartoshitelviszonymegtestesito = tartoshitelviszonymegtestesito - szamlak[i].egyenleg;
                    h[17] = 1;

                }

                if (szamlak[i].szamlaSzam == 177)

                {



                    befektetettepenzugyieszkozokertekhely = befektetettepenzugyieszkozokertekhely + szamlak[i].egyenleg;

                }



                if (szamlak[i].szamlaSzam == 178)
                {
                    befektetettpenzertekkul = befektetettpenzertekkul + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 188)
                {
                    befektetettpenzertekkul = befektetettpenzertekkul + szamlak[i].egyenleg;
                }

            }

            befektetPenzugy = tartosreszedeskapcsolt + tartosanadottkolcson + egyebtartos + tartosanadottkolcsonegyeb + egyebtartosanadottkolcson + tartoshitelviszonymegtestesito + befektetettepenzugyieszkozokertekhely + befektetettpenzertekkul;
            connect.Open();
            befektetp.CommandText = "update merleg set targyEv='" + befektetPenzugy + "'where szamlalo=3;";
            befektetp.ExecuteNonQuery();
            connect.Close();
            befektetetteszkozok = immaterialis + targyieszkozok + befektetPenzugy;
            connect.Open();

            befektettEszk.CommandText = "update merleg set targyEv='" + befektetetteszkozok + "' where szamlalo=0;";
            befektettEszk.ExecuteNonQuery();
            connect.Close();



        }

        public void ForgoEszkozok()
        {
            int anyagok = 0;
            int befejezetlen = 0;
            int novohizo = 0;
            int kesztermekek = 0;
            int aruk1 = 0;
            int aruk2 = 0;
            int aruk3 = 0;
            int keszletreadottelolegek = 0;
            int kulomseg228 = 0;
            List<int> g = new List<int>();
            List<int> t = new List<int>();
                
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);

            g.Add(0);
            g.Add(0);



            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);
            t.Add(0);

            t.Add(0);
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs1 = connect.CreateCommand();
            MySqlCommand forgoeszkoz = connect.CreateCommand();
            List<int> f = new List<int>();
            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 21)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                    t[0] = 1;


                }
                if (szamlak[i].szamlaSzam == 211 && t[0]==0)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }

                if (szamlak[i].szamlaSzam == 22)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                    t[1] = 1;

                }
                if (szamlak[i].szamlaSzam == 221 && t[1]==0)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 222)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 223)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 224)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 225)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 226)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }
                if (szamlak[i].szamlaSzam == 227)
                {
                    anyagok = anyagok + szamlak[i].egyenleg;
                    g[0] = 1;
                }

                if (szamlak[i].szamlaSzam == 228 && g[0] == 1)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        kulomseg228 = kulomseg228 + szamlak[i].tartozik;
                    }
                    else
                        if (szamlak[i].kovetel > szamlak[i].tartozik)
                    {
                        kulomseg228 = kulomseg228 - szamlak[i].kovetel;
                    }
                    anyagok = anyagok + kulomseg228;
                }
                if (szamlak[i].szamlaSzam == 229 && g[0] == 1)
                {
                    anyagok = anyagok - szamlak[i].egyenleg;


                }








            }

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 231)
                {
                    befejezetlen = befejezetlen + szamlak[i].egyenleg;
                    g[1] = 1;

                }
                if (szamlak[i].szamlaSzam == 235)
                {
                    befejezetlen = befejezetlen + szamlak[i].egyenleg;
                    g[1] = 1;

                }

                if (szamlak[i].szamlaSzam == 238 && g[1] == 1)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        befejezetlen = befejezetlen + szamlak[i].tartozik;
                    }
                    else
                        if (szamlak[i].kovetel > szamlak[i].tartozik)
                    {
                        befejezetlen = befejezetlen - szamlak[i].kovetel;
                    }

                }
                if (szamlak[i].szamlaSzam == 239 && g[1] == 1)
                {
                    befejezetlen = befejezetlen - szamlak[i].egyenleg;
                }





            }

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 24)
                {
                    novohizo = novohizo + szamlak[i].egyenleg;
                    g[2] = 1;
                }
                if (szamlak[i].szamlaSzam == 241)
                {
                    novohizo = novohizo + szamlak[i].egyenleg;
                    g[2] = 1;

                }
                if (szamlak[i].szamlaSzam == 242)
                {
                    novohizo = novohizo + szamlak[i].egyenleg;
                    g[2] = 1;

                }

                if (szamlak[i].szamlaSzam == 243)
                {
                    novohizo = novohizo + szamlak[i].egyenleg;
                    g[2] = 1;

                }

                if (szamlak[i].szamlaSzam == 248 && g[2] == 1)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        novohizo = novohizo + szamlak[i].tartozik;
                    }
                    else
                        if (szamlak[i].kovetel > szamlak[i].tartozik)
                    {
                        novohizo = novohizo - szamlak[i].kovetel;
                    }



                }

                if (szamlak[i].szamlaSzam == 249 && g[2] == 1)
                {
                    novohizo = novohizo - szamlak[i].egyenleg;
                    g[1] = 1;

                }



            }
            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 25)
                {
                    kesztermekek = kesztermekek + szamlak[i].egyenleg;
                    g[3] = 1;
                }
                if (szamlak[i].szamlaSzam == 251)
                {
                    kesztermekek = kesztermekek + szamlak[i].egyenleg;
                    g[3] = 1;

                }

                if (szamlak[i].szamlaSzam == 258 && g[3] == 1)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        kesztermekek = kesztermekek + szamlak[i].tartozik;
                    }
                    else
                        if (szamlak[i].kovetel > szamlak[i].tartozik)
                    {
                        kesztermekek = kesztermekek - szamlak[i].kovetel;

                    }


                }
                if (szamlak[i].szamlaSzam == 259 && g[3] == 1)
                {
                    kesztermekek = kesztermekek - szamlak[i].egyenleg;
                    g[3] = 1;

                }

            }



            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 26)
                {
                    aruk1 = aruk1 + szamlak[i].egyenleg;
                    g[4] = 1;
                }
                if (szamlak[i].szamlaSzam == 261)
                {
                    aruk1 = aruk1 + szamlak[i].egyenleg;
                    g[4] = 1;

                }
                if (szamlak[i].szamlaSzam == 263 && g[4] == 1)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        aruk1 = aruk1 + szamlak[i].tartozik;
                    }
                    else
                        if (szamlak[i].kovetel > szamlak[i].tartozik)
                    {

                        aruk1 = aruk1 - szamlak[i].kovetel;
                    }


                }


                if (szamlak[i].szamlaSzam == 265 && g[4] == 1)
                {
                    aruk1 = aruk1 - szamlak[i].egyenleg;
                    g[4] = 1;

                }
                if (szamlak[i].szamlaSzam == 269 && g[4] == 1)
                {
                    aruk1 = aruk1 - szamlak[i].egyenleg;
                    g[4] = 1;

                }


            }

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 27)
                {
                    aruk2 = aruk2 + szamlak[i].egyenleg;
                    g[5] = 1;
                }
                if (szamlak[i].szamlaSzam == 279 && g[5] == 1)
                {
                    aruk2 = aruk2 - szamlak[i].egyenleg;
                    g[4] = 1;

                }
            }
            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 27)
                {
                    aruk2 = aruk2 + szamlak[i].egyenleg;
                    g[5] = 1;
                }
                if (szamlak[i].szamlaSzam == 279 && g[5] == 1)
                {
                    aruk2 = aruk2 - szamlak[i].egyenleg;
                    g[5] = 1;

                }
            }

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 28)
                {
                    aruk3 = aruk3 + szamlak[i].egyenleg;
                    g[6] = 1;
                }


                if (szamlak[i].szamlaSzam == 281)
                {
                    aruk3 = aruk3 + szamlak[i].egyenleg;
                    g[6] = 1;
                }

                if (szamlak[i].szamlaSzam == 288 && g[6] == 1)
                {
                    aruk3 = aruk3 - szamlak[i].egyenleg;
                    g[6] = 1;

                }
                if (szamlak[i].szamlaSzam == 289 && g[6] == 1)
                {
                    aruk3 = aruk3 - szamlak[i].egyenleg;
                    g[6] = 1;

                }
            }

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 353)
                {
                    keszletreadottelolegek = keszletreadottelolegek + szamlak[i].egyenleg;
                    g[7] = 1;
                }
                if (szamlak[i].szamlaSzam == 3593 && g[7] == 1)
                {

                    keszletreadottelolegek = keszletreadottelolegek - szamlak[i].egyenleg;

                }
            }
            int keszletek = anyagok + befejezetlen + novohizo + kesztermekek + aruk1 + aruk2 + aruk3 + keszletreadottelolegek;
            connect.Open();
            parancs1.CommandText = "update merleg set targyEv='" + keszletek + "' where szamlalo=5;";
            parancs1.ExecuteNonQuery();

            connect.Close();



            int kovetelesekaruszallitasbol = 0;
            int kovetelesekkapcsolt = 0;
            int kovetelesekegyeb = 0;
            int valtokovetelesek = 0;
            int egyebkovetelesek = 0;
            int kovetelesekertekelesikul = 0;
            int szarmazekosugyletek = 0;

            List<int> h = new List<int>();
            h.Add(0);
            h.Add(0);

            h.Add(0);

            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);

            for (int i = 0; i < szamlak.Count(); i++)
            {

                if (szamlak[i].szamlaSzam == 31)
                {
                    kovetelesekaruszallitasbol = kovetelesekaruszallitasbol + szamlak[i].egyenleg;
                    h[0] = 1;
                }

                if (szamlak[i].szamlaSzam == 315 && h[0] == 1)
                {
                    kovetelesekaruszallitasbol = kovetelesekaruszallitasbol - szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 319 && h[0] == 1)
                {
                    kovetelesekaruszallitasbol = kovetelesekaruszallitasbol - szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 32)
                {
                    kovetelesekkapcsolt = kovetelesekkapcsolt + szamlak[i].egyenleg;
                    h[1] = 1;
                }
                if (szamlak[i].szamlaSzam == 329 && h[1] == 1)
                {
                    kovetelesekkapcsolt = kovetelesekkapcsolt - szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 33)
                {
                    kovetelesekegyeb = kovetelesekegyeb + szamlak[i].egyenleg;
                    h[2] = 1;
                }


                if (szamlak[i].szamlaSzam == 339 && h[2] == 1)
                {
                    kovetelesekegyeb = kovetelesekegyeb - szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 34)
                {
                    valtokovetelesek = valtokovetelesek + szamlak[i].egyenleg;
                    h[3] = 1;
                }

                if (szamlak[i].szamlaSzam == 345 && h[3] == 1)
                {
                    valtokovetelesek = valtokovetelesek - szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 349 && h[3] == 1)
                {
                    valtokovetelesek = valtokovetelesek - szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 314)
                {
                    kovetelesekertekelesikul = kovetelesekertekelesikul + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 318)
                {
                    kovetelesekertekelesikul = kovetelesekertekelesikul + szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 344)
                {
                    kovetelesekertekelesikul = kovetelesekertekelesikul + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 348)
                {
                    kovetelesekertekelesikul = kovetelesekertekelesikul + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 367)
                {
                    szarmazekosugyletek = szarmazekosugyletek + szamlak[i].egyenleg;
                }


            }

            int kovetelesek = kovetelesekaruszallitasbol + kovetelesekkapcsolt + kovetelesekegyeb + valtokovetelesek + egyebkovetelesek + kovetelesekertekelesikul + szarmazekosugyletek;

            connect.Open();
            parancs1.CommandText = "update merleg set targyEv='" + kovetelesek + "' where szamlalo=6;";
            parancs1.ExecuteNonQuery();

            connect.Close();
            int reszesedeskapocsolt = 0;
            int egyebreszesedes = 0;
            int sajatreszvenyek = 0;
            int forgatasicelu = 0;
            int ertekpapirkulonbozete = 0;
            for (int i = 0; i < szamlak.Count(); i++)
            {

                if (szamlak[i].szamlaSzam == 371)
                {
                    reszesedeskapocsolt = reszesedeskapocsolt + szamlak[i].egyenleg;
                    h[3] = 1;
                }

                if (szamlak[i].szamlaSzam == 3719 && h[3] == 1)
                {
                    reszesedeskapocsolt = reszesedeskapocsolt - szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 371)
                {
                    egyebreszesedes = egyebreszesedes + szamlak[i].egyenleg;
                    h[4] = 1;
                }
                if (szamlak[i].szamlaSzam == 3729 && h[4] == 1)
                {
                    egyebreszesedes = egyebreszesedes - szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 373)
                {
                    sajatreszvenyek = sajatreszvenyek + szamlak[i].egyenleg;
                    h[5] = 1;
                }

                if (szamlak[i].szamlaSzam == 3739 && h[5] == 1)
                {
                    sajatreszvenyek = sajatreszvenyek - szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 374)
                {
                    forgatasicelu = forgatasicelu + szamlak[i].egyenleg;
                    h[6] = 1;
                }

                if (szamlak[i].szamlaSzam == 3749 && h[6] == 1)
                {
                    forgatasicelu = forgatasicelu - szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 375)
                {
                    ertekpapirkulonbozete = ertekpapirkulonbozete + szamlak[i].egyenleg;
                }




            }





            int ertekpapirok = reszesedeskapocsolt + egyebreszesedes + sajatreszvenyek + forgatasicelu + ertekpapirkulonbozete;




            connect.Open();
            parancs1.CommandText = "update merleg set targyEv='" + ertekpapirok + "' where szamlalo=7;";
            parancs1.ExecuteNonQuery();

            connect.Close();





            int penztar = 0;
            int bankbetet = 0;


            for (int i = 0; i < szamlak.Count(); i++)
            {

                if (szamlak[i].szamlaSzam == 381 || szamlak[i].szamlaSzam == 382 || szamlak[i].szamlaSzam == 383)
                {


                    penztar = penztar + szamlak[i].egyenleg;


                }

                if (szamlak[i].szamlaSzam == 384 || szamlak[i].szamlaSzam == 385 || szamlak[i].szamlaSzam == 386)
                {

                    bankbetet = bankbetet + szamlak[i].egyenleg;



                    h[7] = 1;






                }
                if (szamlak[i].szamlaSzam == 389)
                {
                    if (szamlak[i].tartozik > szamlak[i].kovetel)
                    {
                        bankbetet = bankbetet + szamlak[i].egyenleg;
                    }
                    else
                        bankbetet = bankbetet - szamlak[i].egyenleg;
                }


            }



            int penzeszkozok = ertekpapirok + bankbetet;

            connect.Open();
            parancs1.CommandText = "update merleg set targyEv='" + penzeszkozok + "' where szamlalo=8;";
            parancs1.ExecuteNonQuery();

            connect.Close();

            forgoOsszes = keszletek + kovetelesek + ertekpapirok + penzeszkozok;




            int bevetelekaktiv = 0;
            int koltsegekaktiv = 0;
            int halasztottraf = 0;

            for (int i = 0; i < szamlak.Count(); i++)
            {

                if (szamlak[i].szamlaSzam == 391)
                {
                    bevetelekaktiv = bevetelekaktiv + szamlak[i].egyenleg;
                    h[8] = 1;
                }




                if (szamlak[i].szamlaSzam == 392)
                {
                    koltsegekaktiv = koltsegekaktiv + szamlak[i].egyenleg;
                    h[9] = 1;
                }

                if (szamlak[i].szamlaSzam == 393)
                {
                    halasztottraf = halasztottraf + szamlak[i].egyenleg;
                    h[10] = 1;
                }

                if (szamlak[i].szamlaSzam == 399 && h[8] == 1)
                {
                    bevetelekaktiv = bevetelekaktiv - szamlak[i].egyenleg;
                }



                if (szamlak[i].szamlaSzam == 399 && h[9] == 1)
                {
                    koltsegekaktiv = koltsegekaktiv - szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 339 && h[10] == 1)
                {
                    halasztottraf = halasztottraf - szamlak[i].egyenleg;
                }

            }


            aktivIdobeli = bevetelekaktiv + koltsegekaktiv + halasztottraf;
            connect.Open();
            parancs1.CommandText = "update merleg set targyEv='" + aktivIdobeli + "' where szamlalo=9;";
            parancs1.ExecuteNonQuery();

            connect.Close();
            forgoOsszes = keszletek + kovetelesek + ertekpapirok + penzeszkozok;
            connect.Open();
            forgoeszkoz.CommandText = "update merleg set targyEv='" + forgoOsszes + "' where szamlalo=4;";
            forgoeszkoz.ExecuteNonQuery();
            connect.Close();
            int eszkozokOsszesen = befektetetteszkozok + forgoOsszes + aktivIdobeli;

            eszkozertek.Text = eszkozokOsszesen.ToString();



        }

        public void forrasokMerleg()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand parancs1 = connect.CreateCommand();
            MySqlCommand parancs2 = connect.CreateCommand();
            MySqlCommand parancs3= connect.CreateCommand();
            MySqlCommand parancs4 = connect.CreateCommand();
            MySqlCommand parancs5 = connect.CreateCommand();
            MySqlCommand parancs6 = connect.CreateCommand();
            MySqlCommand parancs7 = connect.CreateCommand();
            MySqlCommand parancs8 = connect.CreateCommand();
            connect.Open();
            int jegyzettToke = 0;
            int jegyzettDebenem = 0;
            int toketartalek = 0;
            int eredmenytartalek = 0;
            int lekotottTartalek = 0;
            int ertekelesiTartalek = 0;
            int merlegszerinti = 0;
            int sajattoke = 0;
            int celtartalekok = 0;
            int celtartalekvarhatokot = 0;
            int celtartalekjovobeni = 0;
            int egyebceltartalek = 0;
            int kotelezettsegek = 0;
            int hatrasorolkotkapcsolt = 0;
            int hatrasoroltkotegyeb = 0;
            int hatrasoroltegyebgazd = 0;
            int hosszulejaratukot = 0;
            int hosszulejaratrakapottkolcson = 0;
            int atvalthatokotvenyek = 0;
            int tartozasokkotvenykibocsatasbol = 0;
            int beruhazasiesfejlesztesihitelek = 0;
            int egyebhosszulejaratuhitelek = 0;
            int tartoskotkapcsoltvallszembeb = 0;
            int tartoskotegyeb = 0;
            int egyebhosszulejaratu = 0;
            int rovidlejaratu = 0;
            int r1 = 0;
            int r2 = 0;
            int r3 = 0;
            int r4 = 0;
            int r5 = 0;
            int r6 = 0;
            int r7 = 0;
            int r8 = 0;
            int r9 = 0;
            int r10 = 0;
            int passzividobeli = 0;
            
            List<int> osszes = new List<int>();
            List<int> b = new List<int>();
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);
            b.Add(0);


            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 411)
                {

                    jegyzettToke = jegyzettToke + szamlak[i].egyenleg;
                    b[0] = 1;

                }

                if (szamlak[i].szamlaSzam == 325)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;




                }


                if (szamlak[i].szamlaSzam == 326)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 327)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 328)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;
                }



                if (szamlak[i].szamlaSzam == 332)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 358)
                {
                    jegyzettDebenem = jegyzettDebenem + szamlak[i].egyenleg;
                }



                if (szamlak[i].szamlaSzam == 412)
                {
                    toketartalek = toketartalek + szamlak[i].egyenleg;
                    b[2] = 1;


                }
                if (szamlak[i].szamlaSzam == 413)
                {


                    if (szamlak[i].tartozik < szamlak[i].kovetel)
                    {
                        eredmenytartalek = eredmenytartalek + szamlak[i].egyenleg;
                    }
                    else
                    {
                        eredmenytartalek = eredmenytartalek - szamlak[i].egyenleg;
                        b[3] = 1;
                    }
                }
                if (szamlak[i].szamlaSzam == 414)
                {
                    lekotottTartalek = lekotottTartalek + szamlak[i].egyenleg;
                    b[4] = 1;


                }


                if (szamlak[i].szamlaSzam == 417)
                {
                    ertekelesiTartalek = ertekelesiTartalek + szamlak[i].egyenleg;

                }
                if (szamlak[i].szamlaSzam == 419)
                {

                    if (szamlak[i].tartozik < szamlak[i].kovetel)
                    {
                        merlegszerinti = merlegszerinti + szamlak[i].egyenleg;

                    }
                    else
                    {
                        merlegszerinti = merlegszerinti - szamlak[i].egyenleg;
                    }

                }

            }
            sajattoke = jegyzettToke - jegyzettDebenem + toketartalek + eredmenytartalek + lekotottTartalek + ertekelesiTartalek + merlegszerinti;
           
      
            parancs.CommandText = "update merleg set targyEv='" + jegyzettToke + "' where szamlalo=11;";
            parancs.ExecuteNonQuery();
            connect.Close();


            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + jegyzettDebenem + "' where szamlalo=12;";
            parancs.ExecuteNonQuery();
            connect.Close();

            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + toketartalek + "' where szamlalo=13;";
            parancs.ExecuteNonQuery();
            connect.Close();


            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + eredmenytartalek + "' where szamlalo=14;";
            parancs.ExecuteNonQuery();
            connect.Close();

            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + lekotottTartalek + "' where szamlalo=15;";
            parancs.ExecuteNonQuery();
            connect.Close();
            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + ertekelesiTartalek + "' where szamlalo=16;";
            parancs.ExecuteNonQuery();
            connect.Close();

            connect.Open();
            parancs.CommandText = "update merleg set targyEv='" + merlegszerinti + "' where szamlalo=17;";
            parancs.ExecuteNonQuery();
            connect.Close();






            connect.Open();
            if (sajattoke > 0)
            {
           
                parancs7.CommandText = "update merleg set targyEv='" + sajattoke + "' where szamlalo=10;";
                parancs7.ExecuteNonQuery();
               
            }
           

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 421)
                {
                    celtartalekvarhatokot = celtartalekvarhatokot + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 422 || szamlak[i].szamlaSzam == 424)
                {
                    celtartalekjovobeni = celtartalekjovobeni + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 429)
                {
                    egyebceltartalek = egyebceltartalek + szamlak[i].egyenleg;
                }

            }

            celtartalekok = celtartalekvarhatokot + celtartalekjovobeni + egyebceltartalek;

            if (celtartalekok > 0)
            {
             
                parancs6.CommandText = "update merleg set targyEv='" + celtartalekok + "' where szamlalo=18;";
                parancs6.ExecuteNonQuery();
              
            }
           

            for (int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].szamlaSzam == 431)
                {
                    hatrasorolkotkapcsolt = hatrasorolkotkapcsolt + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 432)
                {
                    hatrasoroltkotegyeb = hatrasoroltkotegyeb + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 433)
                {
                    hatrasoroltegyebgazd = hatrasoroltegyebgazd + szamlak[i].egyenleg;
                }


                if (szamlak[i].szamlaSzam == 441)
                {
                    hosszulejaratrakapottkolcson = hosszulejaratrakapottkolcson + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 442)
                {
                    atvalthatokotvenyek = atvalthatokotvenyek + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 443)
                {
                    tartozasokkotvenykibocsatasbol = tartozasokkotvenykibocsatasbol + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 444)
                {
                    beruhazasiesfejlesztesihitelek = beruhazasiesfejlesztesihitelek + szamlak[i].egyenleg;



                }


                if (szamlak[i].szamlaSzam == 445)
                {
                    egyebhosszulejaratuhitelek = egyebhosszulejaratuhitelek + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 446)
                {
                    tartoskotkapcsoltvallszembeb = tartoskotkapcsoltvallszembeb + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 447)
                {
                    tartoskotegyeb = tartoskotegyeb + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 448 || szamlak[i].szamlaSzam == 449)
                {
                    egyebhosszulejaratu = egyebhosszulejaratu + szamlak[i].egyenleg;
                }



            }

        int hatra = hatrasorolkotkapcsolt + hatrasoroltegyebgazd + hatrasoroltkotegyeb;

            if (hatra > 0)
            {
            
                parancs5.CommandText = "update merleg set targyEv='" + hatra + "' where szamlalo=20;";
                parancs5.ExecuteNonQuery();
           



            }


            
            hosszulejaratukot = hosszulejaratrakapottkolcson + atvalthatokotvenyek + tartozasokkotvenykibocsatasbol + beruhazasiesfejlesztesihitelek + egyebhosszulejaratuhitelek + tartoskotkapcsoltvallszembeb + tartoskotegyeb + egyebhosszulejaratu;
           

                        if (hosszulejaratukot > 0)
                        {

                            parancs4.CommandText = "update merleg set targyEv='" + hosszulejaratukot + "' where szamlalo=21;";
                            parancs4.ExecuteNonQuery();


                        }

            
            int bevetelekpassziv = 0;
            int koltsegekpasziv = 0;
            int halasztottbev = 0;


            for (int i = 0; i < szamlak.Count(); i++)
            {
                
                if (szamlak[i].szamlaSzam == 451)
                {
                    r1 = r1 + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 452)
                {
                    r2 = r2 + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 453)
                {
                    r3 = r3 + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 454 || szamlak[i].szamlaSzam == 455 || szamlak[i].szamlaSzam == 456)
                {
                    r4 = r4 + szamlak[i].egyenleg;

                  
                }
                if (szamlak[i].szamlaSzam == 457)
                {
                    r5 = r5 + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 458)
                {
                    r6 = r6 + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 459)
                {
                    r7 = r7 + szamlak[i].egyenleg;
                }
                if (szamlak[i].szamlaSzam == 461 || szamlak[i].szamlaSzam == 462 || szamlak[i].szamlaSzam == 463 || szamlak[i].szamlaSzam == 464 || szamlak[i].szamlaSzam == 465 || szamlak[i].szamlaSzam == 466 || szamlak[i].szamlaSzam == 467 || szamlak[i].szamlaSzam == 468 || szamlak[i].szamlaSzam == 469 || szamlak[i].szamlaSzam == 470 || szamlak[i].szamlaSzam == 471 || szamlak[i].szamlaSzam == 472 || szamlak[i].szamlaSzam == 473 || szamlak[i].szamlaSzam == 474 || szamlak[i].szamlaSzam == 475 || szamlak[i].szamlaSzam == 476 || szamlak[i].szamlaSzam == 477 || szamlak[i].szamlaSzam == 478 || szamlak[i].szamlaSzam == 479)
                     {
                         r8 = r8 + szamlak[i].egyenleg;
                     }
                     


                if (szamlak[i].szamlaSzam == 4796)
                {
                    r9 = r9 + szamlak[i].egyenleg;
                }

                if (szamlak[i].szamlaSzam == 478)
                {
                    r10 = r10 + szamlak[i].egyenleg;

                }

            }


            rovidlejaratu = r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9 + r10;
           
           


          
            kotelezettsegek = hatra + hosszulejaratukot + rovidlejaratu;
          
            if (rovidlejaratu > 0)
                {

                  
                    parancs3.CommandText = "update merleg set targyEv='" + rovidlejaratu + "' where szamlalo=22;";
                    parancs3.ExecuteNonQuery();
                   
                }

                if (kotelezettsegek > 0)
                {
              
                    parancs2.CommandText = "update merleg set targyEv='" + kotelezettsegek + "' where szamlalo=19;";
                    parancs2.ExecuteNonQuery();
                  
                }

             
                for (int a = 0; a < szamlak.Count(); a++)
                {
                    if (szamlak[a].szamlaSzam == 481)
                    {
                        bevetelekpassziv = bevetelekpassziv + szamlak[a].egyenleg;
                    }

                    if (szamlak[a].szamlaSzam == 482)
                    {
                        koltsegekpasziv = koltsegekpasziv + szamlak[a].egyenleg;
                    }


                    if (szamlak[a].szamlaSzam == 483)
                    {
                        halasztottbev = halasztottbev + szamlak[a].egyenleg;
                    }


                }








     


            int passziv = bevetelekpassziv + koltsegekpasziv + halasztottbev;
            if (passziv > 0)
            {

                parancs1.CommandText = "update merleg set targyEv='" + passziv + "' where szamlalo=23;";
                parancs1.ExecuteNonQuery();


            }
          
            forrasertek.Text = (sajattoke + celtartalekok + kotelezettsegek + passzividobeli).ToString();
        }
        public void egyenlegJavit()
        {

            for(int i = 0; i < szamlak.Count(); i++)
            {
                if (szamlak[i].tartozik > szamlak[i].kovetel)
                {
                    szamlak[i].egyenleg = szamlak[i].tartozik - szamlak[i].kovetel;
                }

                if (szamlak[i].kovetel > szamlak[i].tartozik)
                {
                    szamlak[i].egyenleg = szamlak[i].kovetel - szamlak[i].tartozik;
                }

                if (szamlak[i].tartozik == szamlak[i].kovetel)
                {
                    szamlak[i].egyenleg = 0;
                }



            }












        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Eszkozok, "Nyomtatás Folyamatban van");
                printDialog.PrintVisual(Forrasok, "Nyomtatás Folyamatban van");
            }
        }

       


        public void feltolt(string v)
        {
            int i = 0;
            string conn = "SERVER=localhost;DATABASE="+v+";UID="+adatf+";PASSWORD="+adatj+";Ssl Mode=none";
            MySqlConnection connection = new MySqlConnection(conn);
            MySqlCommand lekerdezes = connection.CreateCommand();
            MySqlCommand beszurMerleg = connection.CreateCommand();
            connection.Open();
            lekerdezes.CommandText = "Select * from merleg;";
            MySqlDataReader reader = lekerdezes.ExecuteReader();
            while (reader.Read())
            {
                i++;
            }
            connection.Close();
           
            if (i == 0)
            {
                connection.Open();
                beszurMerleg.CommandText = "insert into merleg values('A.','BEFEKTETETT ESZKÖZÖK',0,0,0)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('I.','IMMATERIÁLIS JAVAK',0,0,1)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('II.','TÁRGYI ESZKÖZÖK',0,0,2)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('III.','BEFEKTETETT PÉNZÜGYI ESZKÖZÖK',0,0,3)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('B.','FORGÓ ESZKÖZÖK',0,0,4)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('I.','KÉSZLETEK',0,0,5)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('II.','KÖVETELÉSEK',0,0,6)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('III.','ÉRTÉKPAPÍROK',0,0,7)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('IV.','PÉNZESZKÖZÖK',0,0,8)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('C.','AKTIV IDŐBELI ELHATÁROLÁSOK',0,0,9)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('D.','SAJÁT TŐKE',0,0,10)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('I.','JEGYZETT TŐKE',0,0,11)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('II.','JEGYZET DE BE NEM FIZETETT TŐKE',0,0,12)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('III.','TŐKETARTALÉK',0,0,13)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('IV.','EREDMÉNYTARTALÉK',0,0,14)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('V.','LEKÖTÖTT TARTALÉK',0,0,15)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('VI.','ÉRTÉKELÉSI TARTALÉK',0,0,16)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('VII.','MÉRLEG SZERINTI EREDMÉNY',0,0,17)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('E.','CÉLTARTALÉKOK',0,0,18)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('F.','KÖTELEZETTSÉGEK',0,0,19)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('I.','HÁTRASOROLT KÖTELEZETTSÉGEK',0,0,20)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('II.','HOSSZÚ LEJÁRATÚ KÖTELEZETTSÉGEK',0,0,21)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('III.','RÖVID LEJÁRATÚ KÖTELEZETTSÉGEK',0,0,22)";
                beszurMerleg.ExecuteNonQuery();
                beszurMerleg.CommandText = "insert into merleg values('G.','PASSZÍV IDŐBELI ELHATÁROLÁSOK',0,0,23)";
                beszurMerleg.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
