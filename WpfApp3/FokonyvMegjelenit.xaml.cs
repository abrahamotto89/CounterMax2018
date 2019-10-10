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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window32.xaml
    /// </summary>
    public partial class FokonyvMegjelenit : Window
    {
        List<SzamlaTukor2> mirror = new List<SzamlaTukor2>();
        List<SzamlaTukor2> mirror2 = new List<SzamlaTukor2>();
        List<SzamlaSzamok> mirror3 = new List<SzamlaSzamok>();
        List<SzamlaSzamok> mirror4 = new List<SzamlaSzamok>();
       
        string Ceg;
       
        string adatf;
        string adatj;

        public FokonyvMegjelenit(string x,string y, string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            feltolt(Ceg);
            
             ujSzamlatukor();
            osszeadSzamlak();
            masol();
            befektetettEszkozok();
            Keszletek();
            Kovetelesek();
            Forrasok();
            Koltsegnemek();
            Koltseghelyek();
            TevekenysegKoltsegei();
            ErtekesitesElszOnk();
            ErtekesitesArbeveteleEsBevetelek();
            egyenlegjavit();
            megJelenit(Ceg);
            fokonyv2Torles();
       
    


        }

    

        public void megJelenit(string y)
        {

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSLMode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand cm2 = connect.CreateCommand();
            MySqlCommand cm3 = connect.CreateCommand();


            fokonyvszam.Binding = new Binding("szamlaSzam");
            megnev.Binding = new Binding("szamlaNev");
            forgT.Binding = new Binding("tartozikForgalom");
            forgK.Binding = new Binding("kovetelForgalom");
            egyenleg.Binding = new Binding("egyenleg");


            connect.Open();
            for (int i = 0; i < mirror4.Count(); i++)
            {
                fokonyvLista.Items.Add(new Fokonyv
                {

                    szamlaSzam = mirror4[i].szamlaSzam,
                    szamlaNev = mirror4[i].szamlaNev,
                    tartozikForgalom = mirror4[i].tartozik,
                    kovetelForgalom = mirror4[i].kovetel,
                    egyenleg = mirror4[i].egyenleg,

                });
                   addfokonyv(mirror4[i].tartozik,mirror4[i].kovetel,mirror4[i].egyenleg,mirror4[i].szamlaSzam);
               
            }

            connect.Close();

            DataContext = this;

           



        }

     

        public void masol()
        {
            for (int t = 0; t < mirror3.Count(); t++)
            {
                if (mirror3[t].tartozik > 0 || mirror3[t].kovetel > 0 || mirror3[t].egyenleg > 0)
                {


                    mirror.Add(new SzamlaTukor2
                    {
                        id = t,
                        szamlaSzam = mirror3[t].szamlaSzam,
                        szamlaNev = mirror3[t].szamlaNev,
                        tartozik = mirror3[t].tartozik,
                        kovetel = mirror3[t].kovetel,
                        egyenleg = mirror3[t].egyenleg,
                    });


                }



            }
        }
        public void befektetettEszkozok()
        {
            int i = 0;
    
            List<int> k = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);

            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();

            beszur.CommandText = "insert into fokonyv2 values(1,'BEFEKTETETT ESZKÖZÖK',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(11,'IMMATERIÁLIS JAVAK',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(12,'INGATLANOK ÉS KAPCSOLÓDÓ VAGYONI ÉRTÉKŰ JOGOK',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(13,'MŰSZAKI BEREND. GÉPEK JÁRMŰVEK',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(14,'EGYÉB BEREND FELSZERELÉSEK JÁRMŰVEK',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(15,'TENYÉSZÁLLATOK',0,0,0);";
            beszur8.CommandText = "insert into fokonyv2 values(16,'BERUHÁZÁSOK FELÚJÍTÁSOK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(17,'TULAJDON RÉSZESEDÉST JELENTŐ BEFEKTETÉSEK',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(18,'HITELVISZONYT MEGTESTESÍTŐ ÉRTÉKPAPÍR',0,0,0);";
            beszur11.CommandText = "insert into fokonyv2 values(19,'TARTÓSAN ADOTT KÖLCSÖN',0,0,0);";





            int tartozik11 = 0;
            int kovetel11 = 0;
            int egyenleg11 = 0;

            int tartozik12 = 0;
            int kovetel12 = 0;
            int egyenleg12 = 0;

            int tartozik13 = 0;
            int kovetel13 = 0;
            int egyenleg13 = 0;
            int tartozik14 = 0;
            int kovetel14 = 0;
            int egyenleg14 = 0;
            int tartozik15 = 0;
            int kovetel15 = 0;
            int egyenleg15 = 0;
            int tartozik16 = 0;
            int kovetel16 = 0;
            int egyenleg16 = 0;
            int tartozik17 = 0;
            int kovetel17 = 0;
            int egyenleg17 = 0;
            int tartozik18 = 0;
            int kovetel18 = 0;
            int egyenleg18 = 0;
            int tartozik19 = 0;
            int kovetel19 = 0;
            int egyenleg19 = 0;

            int s = 0;
            connect.Open();
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);
            k.Add(0);

            for (i = 0; i < mirror.Count(); i++)
            {
                
                if (mirror[i].szamlaSzam == 11)
                {
                    beszur.ExecuteNonQuery();
                    tartozik11 = tartozik11 + mirror[i].tartozik;
                    kovetel11 = kovetel11 + mirror[i].kovetel;
                    egyenleg11 = egyenleg11 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik11 + "',kovetel='" + kovetel11 + "',egyenleg='" + egyenleg11 + "' where fokonyviSzam=11;";
                    frissit.ExecuteNonQuery();
                    s++;


                }

                if (mirror[i].szamlaSzam >= 111 && mirror[i].szamlaSzam <= 119)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik11 = tartozik11 + mirror[i].tartozik;
                    kovetel11 = kovetel11 + mirror[i].kovetel;
                    egyenleg11 = egyenleg11 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik11 + "',kovetel='" + kovetel11 + "',egyenleg='" + egyenleg11 + "' where fokonyviSzam=11;";
                    frissit.ExecuteNonQuery();
                }

                if (mirror[i].szamlaSzam == 12)
                {
                    if (s == 0) {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik12 = tartozik12 + mirror[i].tartozik;
                    kovetel12 = kovetel12 + mirror[i].kovetel;
                    egyenleg12 = egyenleg12 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik12 + "',kovetel='" + kovetel12 + "',egyenleg='" + egyenleg12 + "' where fokonyviSzam=12;";
                    frissit.ExecuteNonQuery();
                    k[1]++;




                }



                if (mirror[i].szamlaSzam >= 121 && mirror[i].szamlaSzam <= 129)
                {
                    k[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (k[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik12 = tartozik12 + mirror[i].tartozik;
                    kovetel12 = kovetel12 + mirror[i].kovetel;
                    egyenleg12 = egyenleg12 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik12 + "',kovetel='" + kovetel12 + "',egyenleg='" + egyenleg12 + "' where fokonyviSzam=12;";
                    frissit.ExecuteNonQuery();


                }

                if (mirror[i].szamlaSzam == 13)
                {
                    
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                        
                    }
                   
                    tartozik13 = tartozik13 + mirror[i].tartozik;
                    kovetel13 = kovetel13 + mirror[i].kovetel;
                    egyenleg13 = egyenleg13 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik13 + "',kovetel='" + kovetel13 + "',egyenleg='" + egyenleg13 + "' where fokonyviSzam=13;";
                    frissit.ExecuteNonQuery();
                    k[2]++;


                }











                if (mirror[i].szamlaSzam >= 131 && mirror[i].szamlaSzam <= 139)
                {
                    k[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                       
                    }

                    if (k[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik13 = tartozik13 + mirror[i].tartozik;
                    kovetel13 = kovetel13 + mirror[i].kovetel;
                    egyenleg13 = egyenleg13 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik13 + "',kovetel='" + kovetel13 + "',egyenleg='" + egyenleg13 + "' where fokonyviSzam=13;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 14)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik14 = tartozik14 + mirror[i].tartozik;
                    kovetel14 = kovetel14 + mirror[i].kovetel;
                    egyenleg14 = egyenleg14 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik14 + "',kovetel='" + kovetel14 + "',egyenleg='" + egyenleg14 + "' where fokonyviSzam=14;";
                    frissit.ExecuteNonQuery();
                    k[3]++;


                }


                if (mirror[i].szamlaSzam >= 141 && mirror[i].szamlaSzam <= 149)
                {
                    k[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (k[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();


                    }
                    tartozik14 = tartozik14 + mirror[i].tartozik;
                    kovetel14 = kovetel14 + mirror[i].kovetel;
                    egyenleg14 = egyenleg14 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik14 + "',kovetel='" + kovetel14 + "',egyenleg='" + egyenleg14 + "' where fokonyviSzam=14;";
                    frissit.ExecuteNonQuery();


                }



                if (mirror[i].szamlaSzam == 15)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik15 = tartozik15 + mirror[i].tartozik;
                    kovetel15 = kovetel15 + mirror[i].kovetel;
                    egyenleg15 = egyenleg15 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik15 + "',kovetel='" + kovetel15 + "',egyenleg='" + egyenleg15 + "' where fokonyviSzam=15;";
                    frissit.ExecuteNonQuery();
                    k[4]++;

                }


                if (mirror[i].szamlaSzam >= 151 && mirror[i].szamlaSzam <= 159)
                {
                    k[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (k[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();
                    }
                    tartozik15 = tartozik15 + mirror[i].tartozik;
                    kovetel15 = kovetel15 + mirror[i].kovetel;
                    egyenleg15 = egyenleg15 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik15 + "',kovetel='" + kovetel15 + "',egyenleg='" + egyenleg15 + "' where fokonyviSzam=15;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam == 16)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    tartozik16 = tartozik16 + mirror[i].tartozik;
                    kovetel16 = kovetel16 + mirror[i].kovetel;
                    egyenleg16 = egyenleg16 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik16 + "',kovetel='" + kovetel16 + "',egyenleg='" + egyenleg16 + "' where fokonyviSzam=16;";
                    frissit.ExecuteNonQuery();
                    k[5]++;

                }
                if (mirror[i].szamlaSzam >= 161 && mirror[i].szamlaSzam <= 169)
                {
                    k[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (k[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }
                    tartozik16 = tartozik16 + mirror[i].tartozik;
                    kovetel16 = kovetel16 + mirror[i].kovetel;
                    egyenleg16 = egyenleg16 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik16 + "',kovetel='" + kovetel16 + "',egyenleg='" + egyenleg16 + "' where fokonyviSzam=16;";
                    frissit.ExecuteNonQuery();
                }

                if (mirror[i].szamlaSzam == 17)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik17 = tartozik17 + mirror[i].tartozik;
                    kovetel17 = kovetel17 + mirror[i].kovetel;
                    egyenleg17 = egyenleg17 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik17 + "',kovetel='" + kovetel17 + "',egyenleg='" + egyenleg17 + "' where fokonyviSzam=17;";
                    frissit.ExecuteNonQuery();
                    k[6]++;
                }
                if (mirror[i].szamlaSzam >= 171 && mirror[i].szamlaSzam <= 179)
                {

                    k[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (k[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }

                    tartozik17 = tartozik17 + mirror[i].tartozik;
                    kovetel17 = kovetel17 + mirror[i].kovetel;
                    egyenleg17 = egyenleg17 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik17 + "',kovetel='" + kovetel17 + "',egyenleg='" + egyenleg17 + "' where fokonyviSzam=17;";
                    frissit.ExecuteNonQuery();

                }
                if (mirror[i].szamlaSzam == 18)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik18 = tartozik18 + mirror[i].tartozik;
                    kovetel18 = kovetel18 + mirror[i].kovetel;
                    egyenleg18 = egyenleg18 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik18 + "',kovetel='" + kovetel18 + "',egyenleg='" + egyenleg18 + "' where fokonyviSzam=18;";
                    frissit.ExecuteNonQuery();
                    k[7]++;



                }

                if (mirror[i].szamlaSzam >= 181 && mirror[i].szamlaSzam <= 189)
                {
                    k[7]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (k[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                    }


                    tartozik18 = tartozik18 + mirror[i].tartozik;
                    kovetel18 = kovetel18 + mirror[i].kovetel;
                    egyenleg18 = egyenleg18 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik18 + "',kovetel='" + kovetel18 + "',egyenleg='" + egyenleg18 + "' where fokonyviSzam=18;";
                    frissit.ExecuteNonQuery();

                }
                if (mirror[i].szamlaSzam == 19)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik19 = tartozik19 + mirror[i].tartozik;
                    kovetel19 = kovetel19 + mirror[i].kovetel;
                    egyenleg19 = egyenleg19 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik19 + "',kovetel='" + kovetel19 + "',egyenleg='" + egyenleg19 + "' where fokonyviSzam=19;";
                    frissit.ExecuteNonQuery();
                    k[8]++;


                }

                if (mirror[i].szamlaSzam >= 191 && mirror[i].szamlaSzam <= 199)
                {
                    k[8]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (k[8] == 1)
                    {
                        beszur11.ExecuteNonQuery();
                    }


                    tartozik19 = tartozik19 + mirror[i].tartozik;
                    kovetel19 = kovetel19 + mirror[i].kovetel;
                    egyenleg19 = egyenleg19 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik19 + "',kovetel='" + kovetel19 + "',egyenleg='" + egyenleg19 + "' where fokonyviSzam=19;";
                    frissit.ExecuteNonQuery();

                }
            }


            int tartozik1 = tartozik11 + tartozik12 + tartozik13 + tartozik14 + tartozik15 + tartozik16 + tartozik17 + tartozik18 + tartozik19;
            int kovetel1 = kovetel11 + kovetel12 + kovetel13 + kovetel14 + kovetel15 + kovetel16 + kovetel17 + kovetel18 + kovetel19;
            int egyenleg1 = egyenleg11 + egyenleg12 + egyenleg13 + egyenleg14 + egyenleg15 + egyenleg16 + egyenleg17 + egyenleg18 + egyenleg19;

            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik1 + "',kovetel='" + kovetel1 + "',egyenleg='" + egyenleg1 + "' where fokonyviSzam=1;";
            frissit2.ExecuteNonQuery();
            connect.Close();

        }

        public void Keszletek()
        {
            int i = 0;
           
            List<int> z = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(2,'KÉSZLETEK',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(21,'NYERS ÉS ALAPANYAG',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(22,'ANYAGOK',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(23,'BEFEJEZETLEN TERMELÉS ÉS FÉLKÉSZ TERMÉKEK',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(24,'NÖVENDÉK HÍZÓ ÉS EGYÉB ÁLLATOK',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(25,'KÉSZTERMÉKEK',0,0,0);";
            beszur8.CommandText = "insert into fokonyv2 values(26,'KERESKEDELMI ÁRUK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(27,'KÖZVETÍTETT SZOLGÁLTATÁSOK',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(28,'BETÉTDÍJAS GÖNYGYÖLEGEK',0,0,0);";

            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlDataReader reader = cm.ExecuteReader();



            connect.Close();

            int tartozik21 = 0;
            int kovetel21 = 0;
            int egyenleg21 = 0;

            int tartozik22 = 0;
            int kovetel22 = 0;
            int egyenleg22 = 0;

            int tartozik23 = 0;
            int kovetel23 = 0;
            int egyenleg23 = 0;
            int tartozik24 = 0;
            int kovetel24 = 0;
            int egyenleg24 = 0;
            int tartozik25 = 0;
            int kovetel25 = 0;
            int egyenleg25 = 0;
            int tartozik26 = 0;
            int kovetel26 = 0;
            int egyenleg26 = 0;
            int tartozik27 = 0;
            int kovetel27 = 0;
            int egyenleg27 = 0;
            int tartozik28 = 0;
            int kovetel28 = 0;
            int egyenleg28 = 0;

            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            z.Add(0);
            int s = 0;
            connect.Open();
            for (i = 0; i < mirror.Count(); i++)
            {

                if (mirror[i].szamlaSzam == 21)
                {

                    beszur.ExecuteNonQuery();
                    tartozik21 = tartozik21 + mirror[i].tartozik;
                    kovetel21 = kovetel21 + mirror[i].kovetel;
                    egyenleg21 = egyenleg21 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik21 + "',kovetel='" + kovetel21 + "',egyenleg='" + egyenleg21 + "' where fokonyviSzam=21;";
                    frissit.ExecuteNonQuery();
                    s++;


                }





                if (mirror[i].szamlaSzam == 211)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik21 = tartozik21 + mirror[i].tartozik;
                    kovetel21 = kovetel21 + mirror[i].kovetel;
                    egyenleg21 = egyenleg21 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik21 + "',kovetel='" + kovetel21 + "',egyenleg='" + egyenleg21 + "' where fokonyviSzam=21;";
                    frissit.ExecuteNonQuery();
                }

                if (mirror[i].szamlaSzam == 22)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                }



                if (mirror[i].szamlaSzam >= 221 && mirror[i].szamlaSzam <= 229)
                {
                    z[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (z[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik22 = tartozik22 + mirror[i].tartozik;
                    kovetel22 = kovetel22 + mirror[i].kovetel;
                    egyenleg22 = egyenleg22 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik22 + "',kovetel='" + kovetel22 + "',egyenleg='" + egyenleg22 + "' where fokonyviSzam=22;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam == 23)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik23 = tartozik23 + mirror[i].tartozik;
                    kovetel23 = kovetel23 + mirror[i].kovetel;
                    egyenleg23 = egyenleg23 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik23 + "',kovetel='" + kovetel23 + "',egyenleg='" + egyenleg23 + "' where fokonyviSzam=23;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam >= 231 && mirror[i].szamlaSzam <= 239)
                {
                    z[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (z[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik23 = tartozik23 + mirror[i].tartozik;
                    kovetel23 = kovetel23 + mirror[i].kovetel;
                    egyenleg23 = egyenleg23 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik23 + "',kovetel='" + kovetel23 + "',egyenleg='" + egyenleg23 + "' where fokonyviSzam=23;";
                    frissit.ExecuteNonQuery();

                }
                if (mirror[i].szamlaSzam==24)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }


                    tartozik24 = tartozik24 + mirror[i].tartozik;
                    kovetel24 = kovetel24 + mirror[i].kovetel;
                    egyenleg24 = egyenleg24 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik24 + "',kovetel='" + kovetel24 + "',egyenleg='" + egyenleg24 + "' where fokonyviSzam=24;";
                    frissit.ExecuteNonQuery();
                    z[3]++;
                }



                if (mirror[i].szamlaSzam >= 241 && mirror[i].szamlaSzam <= 249)
                {

                    z[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (z[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();
                    }
                    tartozik24 = tartozik24 + mirror[i].tartozik;
                    kovetel24 = kovetel24 + mirror[i].kovetel;
                    egyenleg24 = egyenleg24 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik24 + "',kovetel='" + kovetel24 + "',egyenleg='" + egyenleg24 + "' where fokonyviSzam=24;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam ==25)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik25 = tartozik25 + mirror[i].tartozik;
                    kovetel25 = kovetel25 + mirror[i].kovetel;
                    egyenleg25 = egyenleg25 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik25 + "',kovetel='" + kovetel25 + "',egyenleg='" + egyenleg25 + "' where fokonyviSzam=25;";
                    frissit.ExecuteNonQuery();
                    z[4]++;

                }


                if (mirror[i].szamlaSzam >= 251 && mirror[i].szamlaSzam <= 259)
                {
                    z[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (z[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();
                    }
                    tartozik25 = tartozik25 + mirror[i].tartozik;
                    kovetel25 = kovetel25 + mirror[i].kovetel;
                    egyenleg25 = egyenleg25 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik25 + "',kovetel='" + kovetel25 + "',egyenleg='" + egyenleg25 + "' where fokonyviSzam=25;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam ==26)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik26 = tartozik26 + mirror[i].tartozik;
                    kovetel26 = kovetel26 + mirror[i].kovetel;
                    egyenleg26 = egyenleg26 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik26 + "',kovetel='" + kovetel26 + "',egyenleg='" + egyenleg26 + "' where fokonyviSzam=26;";
                    frissit.ExecuteNonQuery();
                    z[5]++;



                }
                if (mirror[i].szamlaSzam >= 261 && mirror[i].szamlaSzam <= 269)
                {
                    z[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (z[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }
                    tartozik26 = tartozik26 + mirror[i].tartozik;
                    kovetel26 = kovetel26 + mirror[i].kovetel;
                    egyenleg26 = egyenleg26 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik26 + "',kovetel='" + kovetel26 + "',egyenleg='" + egyenleg26 + "' where fokonyviSzam=26;";
                    frissit.ExecuteNonQuery();
                }

                if (mirror[i].szamlaSzam ==27)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik27 = tartozik27 + mirror[i].tartozik;
                    kovetel27 = kovetel27 + mirror[i].kovetel;
                    egyenleg27 = egyenleg27 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik27 + "',kovetel='" + kovetel27 + "',egyenleg='" + egyenleg27 + "' where fokonyviSzam=27;";
                    frissit.ExecuteNonQuery();
                    z[6]++;

                }
                if (mirror[i].szamlaSzam >= 271 && mirror[i].szamlaSzam <= 279)
                {
                    z[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (z[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }

                    tartozik27 = tartozik27 + mirror[i].tartozik;
                    kovetel27 = kovetel27 + mirror[i].kovetel;
                    egyenleg27 = egyenleg27 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik27 + "',kovetel='" + kovetel27 + "',egyenleg='" + egyenleg27 + "' where fokonyviSzam=27;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam ==28)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik28 = tartozik28 + mirror[i].tartozik;
                    kovetel28 = kovetel28 + mirror[i].kovetel;
                    egyenleg28 = egyenleg28 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik28 + "',kovetel='" + kovetel28 + "',egyenleg='" + egyenleg28 + "' where fokonyviSzam=28;";
                    frissit.ExecuteNonQuery();
                    z[7]++;

                }
                if (mirror[i].szamlaSzam >= 281 && mirror[i].szamlaSzam <= 289)
                {
                    z[7]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (z[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                    }


                    tartozik28 = tartozik28 + mirror[i].tartozik;
                    kovetel28 = kovetel28 + mirror[i].kovetel;
                    egyenleg28 = egyenleg28 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik28 + "',kovetel='" + kovetel28 + "',egyenleg='" + egyenleg28 + "' where fokonyviSzam=28;";
                    frissit.ExecuteNonQuery();

                }



            }


            int tartozik2 = tartozik21 + tartozik22 + tartozik23 + tartozik24 + tartozik25 + tartozik26 + tartozik27 + tartozik28;
            int kovetel2 = kovetel21 + kovetel22 + kovetel23 + kovetel24 + kovetel25 + kovetel26 + kovetel27 + kovetel28;
            int egyenleg2 = egyenleg21 + egyenleg22 + egyenleg23 + egyenleg24 + egyenleg25 + egyenleg26 + egyenleg27 + egyenleg28;

            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik2 + "',kovetel='" + kovetel2 + "',egyenleg='" + egyenleg2 + "' where fokonyviSzam=2;";
            frissit2.ExecuteNonQuery();
            connect.Close();

           

        }


        public void Kovetelesek()
        {
            int i = 0;
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(3,'KÖVETELÉSEK,  PÉNZÜGYI ESZKÖZÖK, AKTIV IDŐBELI ELH.',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(31,'KÖVETELÉSEK ÁRUSZÁLLÍTÁSBÓL ÉS SZOLGBÓL',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(32,'KÖVETELÉSEK KAPCSOLT VÁLLALKOZÁSSAL SZEMBEN',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(33,'KÖVETELÉSEK EGYÉB RÉSZESEDÉSI VISZONYBÓL VÁLL.',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(34,'VÁLTÓKÖVETELÉSEK',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(35,'ADOTT ELŐLEG',0,0,0);";
            beszur8.CommandText = "insert into fokonyv2 values(36,'EGYÉB KÖVETELÉSEK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(37,'ÉRTÉKPAPÍROK',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(38,'PÉNZESZKÖZÖK',0,0,0);";
            beszur11.CommandText = "insert into fokonyv2 values(39,'AKTIV IDŐBELI ELHATÁROLÁSOK',0,0,0);";
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik31 = 0;
            int kovetel31 = 0;
            int egyenleg31 = 0;

            int tartozik32 = 0;
            int kovetel32 = 0;
            int egyenleg32 = 0;

            int tartozik33 = 0;
            int kovetel33 = 0;
            int egyenleg33 = 0;
            int tartozik34 = 0;
            int kovetel34 = 0;
            int egyenleg34 = 0;
            int tartozik35 = 0;
            int kovetel35 = 0;
            int egyenleg35 = 0;
            int tartozik36 = 0;
            int kovetel36 = 0;
            int egyenleg36 = 0;
            int tartozik37 = 0;
            int kovetel37 = 0;
            int egyenleg37 = 0;
            int tartozik38 = 0;
            int kovetel38 = 0;
            int egyenleg38 = 0;
            int tartozik39 = 0;
            int kovetel39 = 0;
            int egyenleg39 = 0;
            int r = 0;
            List<int> g = new List<int>();
            int s = 0;
            connect.Open();


            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);
            g.Add(0);

            for (i = 0; i < mirror.Count(); i++)
            {

                if (mirror[i].szamlaSzam ==31)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik31 = tartozik31 + mirror[i].tartozik;
                    kovetel31 = kovetel31 + mirror[i].kovetel;
                    egyenleg31 = egyenleg31 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik31 + "',kovetel='" + kovetel31 + "',egyenleg='" + egyenleg31 + "' where fokonyviSzam=31;";
                    frissit.ExecuteNonQuery();
                    g[0]++;


                }

             

                if (mirror[i].szamlaSzam >= 311 && mirror[i].szamlaSzam <= 319)
                {
                    s++;
                    g[0]++;
                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik31 = tartozik31 + mirror[i].tartozik;
                    kovetel31 = kovetel31 + mirror[i].kovetel;
                    egyenleg31 = egyenleg31 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik31 + "',kovetel='" + kovetel31 + "',egyenleg='" + egyenleg31 + "' where fokonyviSzam=31;";
                    frissit.ExecuteNonQuery();
                }



                if (mirror[i].szamlaSzam ==32)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik32 = tartozik32 + mirror[i].tartozik;
                    kovetel32 = kovetel32 + mirror[i].kovetel;
                    egyenleg32 = egyenleg32 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik32 + "',kovetel='" + kovetel32 + "',egyenleg='" + egyenleg32 + "' where fokonyviSzam=32;";
                    frissit.ExecuteNonQuery();
                    g[1]++;


                }

                if (mirror[i].szamlaSzam >= 321 && mirror[i].szamlaSzam <= 329)
                {


                    g[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (g[1] == 1)
                        beszur4.ExecuteNonQuery();


                    tartozik32 = tartozik32 + mirror[i].tartozik;
                    kovetel32 = kovetel32 + mirror[i].kovetel;
                    egyenleg32 = egyenleg32 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik32 + "',kovetel='" + kovetel32 + "',egyenleg='" + egyenleg32 + "' where fokonyviSzam=32;";
                    frissit.ExecuteNonQuery();



                }
                if (mirror[i].szamlaSzam ==33)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik33 = tartozik33 + mirror[i].tartozik;
                    kovetel33 = kovetel33 + mirror[i].kovetel;
                    egyenleg33 = egyenleg33 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik33 + "',kovetel='" + kovetel33 + "',egyenleg='" + egyenleg33 + "' where fokonyviSzam=33;";
                    frissit.ExecuteNonQuery();
                    g[2]++;
                }


                if (mirror[i].szamlaSzam >= 331 && mirror[i].szamlaSzam <= 339)
                {

                    g[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (g[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik33 = tartozik33 + mirror[i].tartozik;
                    kovetel33 = kovetel33 + mirror[i].kovetel;
                    egyenleg33 = egyenleg33 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik33 + "',kovetel='" + kovetel33 + "',egyenleg='" + egyenleg33 + "' where fokonyviSzam=33;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam ==34)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik34 = tartozik34 + mirror[i].tartozik;
                    kovetel34 = kovetel34 + mirror[i].kovetel;
                    egyenleg34 = egyenleg34 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik34 + "',kovetel='" + kovetel34 + "',egyenleg='" + egyenleg34 + "' where fokonyviSzam=34;";
                    frissit.ExecuteNonQuery();

                    g[3]++;
                }


                if (mirror[i].szamlaSzam >= 341 && mirror[i].szamlaSzam <= 349)
                {

                    g[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (g[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();

                    }
                    tartozik34 = tartozik34 + mirror[i].tartozik;
                    kovetel34 = kovetel34 + mirror[i].kovetel;
                    egyenleg34 = egyenleg34 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik34 + "',kovetel='" + kovetel34 + "',egyenleg='" + egyenleg34 + "' where fokonyviSzam=34;";
                    frissit.ExecuteNonQuery();


                }

                if (mirror[i].szamlaSzam ==35)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik35 = tartozik35 + mirror[i].tartozik;
                    kovetel35 = kovetel35 + mirror[i].kovetel;
                    egyenleg35 = egyenleg35 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik35 + "',kovetel='" + kovetel35 + "',egyenleg='" + egyenleg35 + "' where fokonyviSzam=35;";
                    frissit.ExecuteNonQuery();
                    g[4]++;

                }

                if (mirror[i].szamlaSzam >= 351 && mirror[i].szamlaSzam <= 359)
                {

                    g[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (g[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();

                    }
                    tartozik35 = tartozik35 + mirror[i].tartozik;
                    kovetel35 = kovetel35 + mirror[i].kovetel;
                    egyenleg35 = egyenleg35 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik35 + "',kovetel='" + kovetel35 + "',egyenleg='" + egyenleg35 + "' where fokonyviSzam=35;";
                    frissit.ExecuteNonQuery();

                }
                if (mirror[i].szamlaSzam ==36)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik36 = tartozik36 + mirror[i].tartozik;
                    kovetel36 = kovetel36 + mirror[i].kovetel;
                    egyenleg36 = egyenleg36 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik36 + "',kovetel='" + kovetel36 + "',egyenleg='" + egyenleg36 + "' where fokonyviSzam=36;";
                    frissit.ExecuteNonQuery();
                    g[5]++;

                }

                if (mirror[i].szamlaSzam >= 361 && mirror[i].szamlaSzam <= 369)
                {

                    g[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (g[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();

                    }
                    tartozik36 = tartozik36 + mirror[i].tartozik;
                    kovetel36 = kovetel36 + mirror[i].kovetel;
                    egyenleg36 = egyenleg36 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik36 + "',kovetel='" + kovetel36 + "',egyenleg='" + egyenleg36 + "' where fokonyviSzam=36;";
                    frissit.ExecuteNonQuery();
                }
                if (mirror[i].szamlaSzam ==37)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik37 = tartozik37 + mirror[i].tartozik;
                    kovetel37 = kovetel37 + mirror[i].kovetel;
                    egyenleg37 = egyenleg37 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik37 + "',kovetel='" + kovetel37 + "',egyenleg='" + egyenleg37 + "' where fokonyviSzam=37;";
                    frissit.ExecuteNonQuery();
                    g[6]++;

                }

                if (mirror[i].szamlaSzam >= 371 && mirror[i].szamlaSzam <= 379)
                {

                    g[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (g[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();

                    }
                    tartozik37 = tartozik37 + mirror[i].tartozik;
                    kovetel37 = kovetel37 + mirror[i].kovetel;
                    egyenleg37 = egyenleg37 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik37 + "',kovetel='" + kovetel37 + "',egyenleg='" + egyenleg37 + "' where fokonyviSzam=37;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam ==38)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik38 = tartozik38 + mirror[i].tartozik;
                    kovetel38 = kovetel38 + mirror[i].kovetel;
                    egyenleg38 = egyenleg38 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik38 + "',kovetel='" + kovetel38 + "',egyenleg='" + egyenleg38 + "' where fokonyviSzam=38;";
                    frissit.ExecuteNonQuery();
                    g[7]++;

                }
                if (mirror[i].szamlaSzam >= 381 && mirror[i].szamlaSzam <= 389)
                {

                    g[7]++;

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (g[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                        r++;
                    }


                    tartozik38 = tartozik38 + mirror[i].tartozik;
                    kovetel38 = kovetel38 + mirror[i].kovetel;
                    egyenleg38 = egyenleg38 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik38 + "',kovetel='" + kovetel38 + "',egyenleg='" + egyenleg38 + "' where fokonyviSzam=38;";
                    frissit.ExecuteNonQuery();
                    Console.WriteLine("az R:" + r);

                }

                if (mirror[i].szamlaSzam ==39)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik39 = tartozik39 + mirror[i].tartozik;
                    kovetel39 = kovetel39 + mirror[i].kovetel;
                    egyenleg39 = egyenleg39 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik39 + "',kovetel='" + kovetel39 + "',egyenleg='" + egyenleg39 + "' where fokonyviSzam=39;";
                    frissit.ExecuteNonQuery();
                    g[8]++;


                }
                if (mirror[i].szamlaSzam >= 391 && mirror[i].szamlaSzam <= 399)
                {



                    g[8]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (g[8] == 1)
                    {
                        beszur11.ExecuteNonQuery();
                    }



                    tartozik39 = tartozik39 + mirror[i].tartozik;
                    kovetel39 = kovetel39 + mirror[i].kovetel;
                    egyenleg39 = egyenleg39 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik39 + "',kovetel='" + kovetel39 + "',egyenleg='" + egyenleg39 + "' where fokonyviSzam=39;";
                    frissit.ExecuteNonQuery();

                }





            }

            int tartozik3 = tartozik31 + tartozik32 + tartozik33 + tartozik34 + tartozik35 + tartozik36 + tartozik37 + tartozik38 + tartozik39;
            int kovetel3 = kovetel31 + kovetel32 + kovetel33 + kovetel34 + kovetel35 + kovetel36 + kovetel37 + kovetel38 + kovetel39;
            int egyenleg3 = egyenleg31 + egyenleg32 + egyenleg33 + egyenleg34 + egyenleg35 + egyenleg36 + egyenleg37 + egyenleg38 + egyenleg39;

            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik3 + "',kovetel='" + kovetel3 + "',egyenleg='" + egyenleg3 + "' where fokonyviSzam=3;";
            frissit2.ExecuteNonQuery();
            connect.Close();

        }




        public void Forrasok()
        {
            int i = 0;
           
            List<int> fo = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(4,'FORRÁSOK',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(41,'SAJÁT TŐKE',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(42,'CÉLTARTALÉK',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(43,'HÁTRASOROLT KÖTELEZETTSÉG',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(44,'HOSSZÚ LEJÁRATÚ KÖTELEZETTSÉGEK',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(45,'RÖVID LEJÁRATÚ KÖTELEZETTSÉGEK',0,0,0);";
            beszur8.CommandText = "insert into fokonyv2 values(48,'PASSZÍV IDŐBELI ELHATÁROLÁSOK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(49,'ÉVI MÉRLEGSZÁMLÁK',0,0,0);";

            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik41 = 0;
            int kovetel41 = 0;
            int egyenleg41 = 0;

            int tartozik42 = 0;
            int kovetel42 = 0;
            int egyenleg42 = 0;

            int tartozik43 = 0;
            int kovetel43 = 0;
            int egyenleg43 = 0;
            int tartozik44 = 0;
            int kovetel44 = 0;
            int egyenleg44 = 0;
            int tartozik45 = 0;
            int kovetel45 = 0;
            int egyenleg45 = 0;

            int tartozik48 = 0;
            int kovetel48 = 0;
            int egyenleg48 = 0;
            int tartozik49 = 0;
            int kovetel49 = 0;
            int egyenleg49 = 0;
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);
            fo.Add(0);

            int s = 0;
            connect.Open();
            for (i = 0; i < mirror.Count(); i++)
            {
                Console.WriteLine("fut");

                if (mirror[i].szamlaSzam == 41)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }



                    tartozik41 = tartozik41 + mirror[i].tartozik;
                    kovetel41 = kovetel41 + mirror[i].kovetel;
                    egyenleg41 = egyenleg41 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik41 + "',kovetel='" + kovetel41 + "',egyenleg='" + egyenleg41 + "' where fokonyviSzam=41;";
                    frissit.ExecuteNonQuery();
                    s++;
                }










                if (mirror[i].szamlaSzam >= 411 && mirror[i].szamlaSzam <= 419)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik41 = tartozik41 + mirror[i].tartozik;
                    kovetel41 = kovetel41 + mirror[i].kovetel;
                    egyenleg41 = egyenleg41 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik41 + "',kovetel='" + kovetel41 + "',egyenleg='" + egyenleg41 + "' where fokonyviSzam=41;";
                    frissit.ExecuteNonQuery();
                }


                if (mirror[i].szamlaSzam == 42)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik42 = tartozik42 + mirror[i].tartozik;
                    kovetel42 = kovetel42 + mirror[i].kovetel;
                    egyenleg42 = egyenleg42 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik42 + "',kovetel='" + kovetel42 + "',egyenleg='" + egyenleg42 + "' where fokonyviSzam=42;";
                    frissit.ExecuteNonQuery();
                    fo[1]++;

                }


                if (mirror[i].szamlaSzam >= 421 && mirror[i].szamlaSzam <= 429)
                {
                    fo[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (fo[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik42 = tartozik42 + mirror[i].tartozik;
                    kovetel42 = kovetel42 + mirror[i].kovetel;
                    egyenleg42 = egyenleg42 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik42 + "',kovetel='" + kovetel42 + "',egyenleg='" + egyenleg42 + "' where fokonyviSzam=42;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam == 43)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik43 = tartozik43 + mirror[i].tartozik;
                    kovetel43 = kovetel43 + mirror[i].kovetel;
                    egyenleg43 = egyenleg43 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik43 + "',kovetel='" + kovetel43 + "',egyenleg='" + egyenleg43 + "' where fokonyviSzam=43;";
                    frissit.ExecuteNonQuery();
                    fo[2]++;
                }


                if (mirror[i].szamlaSzam >= 431 && mirror[i].szamlaSzam <= 433)
                {
                    fo[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (fo[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik43 = tartozik43 + mirror[i].tartozik;
                    kovetel43 = kovetel43 + mirror[i].kovetel;
                    egyenleg43 = egyenleg43 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik43 + "',kovetel='" + kovetel43 + "',egyenleg='" + egyenleg43 + "' where fokonyviSzam=43;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam == 44)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik44 = tartozik44 + mirror[i].tartozik;
                    kovetel44 = kovetel44 + mirror[i].kovetel;
                    egyenleg44 = egyenleg44 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik44 + "',kovetel='" + kovetel44 + "',egyenleg='" + egyenleg44 + "' where fokonyviSzam=44;";
                    frissit.ExecuteNonQuery();
                    fo[3]++;
                }

                if (mirror[i].szamlaSzam >= 441 && mirror[i].szamlaSzam <= 449)
                {
                    fo[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (fo[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();
                    }
                    tartozik44 = tartozik44 + mirror[i].tartozik;
                    kovetel44 = kovetel44 + mirror[i].kovetel;
                    egyenleg44 = egyenleg44 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik44 + "',kovetel='" + kovetel44 + "',egyenleg='" + egyenleg44 + "' where fokonyviSzam=44;";
                    frissit.ExecuteNonQuery();


                }

                if (mirror[i].szamlaSzam == 45)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik45 = tartozik45 + mirror[i].tartozik;
                    kovetel45 = kovetel45 + mirror[i].kovetel;
                    egyenleg45 = egyenleg45 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik45 + "',kovetel='" + kovetel45 + "',egyenleg='" + egyenleg45 + "' where fokonyviSzam=45;";
                    frissit.ExecuteNonQuery();
                    fo[4]++;
                }

                if (mirror[i].szamlaSzam >= 451 && mirror[i].szamlaSzam <= 479)
                {

                    fo[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (fo[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();

                    }
                    tartozik45 = tartozik45 + mirror[i].tartozik;
                    kovetel45 = kovetel45 + mirror[i].kovetel;
                    egyenleg45 = egyenleg45 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik45 + "',kovetel='" + kovetel45 + "',egyenleg='" + egyenleg45 + "' where fokonyviSzam=45;";
                    frissit.ExecuteNonQuery();


                }


                if (mirror[i].szamlaSzam == 48)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik48 = tartozik48 + mirror[i].tartozik;
                    kovetel48 = kovetel48 + mirror[i].kovetel;
                    egyenleg48 = egyenleg48 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik48 + "',kovetel='" + kovetel48 + "',egyenleg='" + egyenleg48 + "' where fokonyviSzam=48;";
                    frissit.ExecuteNonQuery();
                    fo[5]++;
                }


                if (mirror[i].szamlaSzam >= 481 && mirror[i].szamlaSzam <= 483)
                {
                    fo[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (fo[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }


                    tartozik48 = tartozik48 + mirror[i].tartozik;
                    kovetel48 = kovetel48 + mirror[i].kovetel;
                    egyenleg48 = egyenleg48 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik48 + "',kovetel='" + kovetel48 + "',egyenleg='" + egyenleg48 + "' where fokonyviSzam=48;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 49)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik49 = tartozik49 + mirror[i].tartozik;
                    kovetel49 = kovetel49 + mirror[i].kovetel;
                    egyenleg49 = egyenleg49 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik49 + "',kovetel='" + kovetel49 + "',egyenleg='" + egyenleg49 + "' where fokonyviSzam=49;";
                    frissit.ExecuteNonQuery();
                    fo[6]++;

                }
                if (mirror[i].szamlaSzam >= 491 && mirror[i].szamlaSzam <= 493)
                {
                    fo[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (fo[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }



                    tartozik49 = tartozik49 + mirror[i].tartozik;
                    kovetel49 = kovetel49 + mirror[i].kovetel;
                    egyenleg49 = egyenleg49 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik49 + "',kovetel='" + kovetel49 + "',egyenleg='" + egyenleg49 + "' where fokonyviSzam=49;";
                    frissit.ExecuteNonQuery();

                }

            }


            int tartozik4 = tartozik41 + tartozik42 + tartozik43 + tartozik44 + tartozik45 + tartozik48 + tartozik49;
            int kovetel4 = kovetel41 + kovetel42 + kovetel43 + kovetel44 + kovetel45 + kovetel48 + kovetel49;
            int egyenleg4 = egyenleg41 + egyenleg42 + egyenleg43 + egyenleg44 + egyenleg45 + egyenleg48 + egyenleg49;

            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik4 + "',kovetel='" + kovetel4 + "',egyenleg='" + egyenleg4 + "' where fokonyviSzam=4;";
            frissit2.ExecuteNonQuery();
            connect.Close();
          


        }

        public void Koltsegnemek()
        {
            Console.WriteLine("kész");

            int i = 0;
            int r = 0;
          
            List<int> ko = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(5,'KÖLTSÉGNEMEK',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(51,'ANYAG KÖLTSÉG',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(52,'IGÉNYBEVETT SZOLGÁLTATÁSOK KÖLTSÉGEI',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(53,'EGYÉB SZOLGÁLTATÁSOK KÖLTSÉGEI',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(54,'BÉRKÖLTSÉG',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(55,'SZEMÉLYI JELLEGŰ EGYÉB KIFIZETÉSEK',0,0,0);";

            beszur8.CommandText = "insert into fokonyv2 values(56,'BÉRJÁRULÉKOK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(57,'ÉRTÉKCSÖKKENÉSI LEÍRÁS',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(58,'AKTIVÁLT SAJÁT TELJESÍTMÉNYEK ÉRTÉKE',0,0,0);";
            beszur11.CommandText = "insert into fokonyv2 values(59,'KÖLTSÉGNEM-ÁTVEZETÉSI SZÁMLA',0,0,0);";
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik51 = 0;
            int kovetel51 = 0;
            int egyenleg51 = 0;

            int tartozik52 = 0;
            int kovetel52 = 0;
            int egyenleg52 = 0;

            int tartozik53 = 0;
            int kovetel53 = 0;
            int egyenleg53 = 0;
            int tartozik54 = 0;
            int kovetel54 = 0;
            int egyenleg54 = 0;
            int tartozik55 = 0;
            int kovetel55 = 0;
            int egyenleg55 = 0;

            int tartozik56 = 0;
            int kovetel56 = 0;
            int egyenleg56 = 0;
            int tartozik57 = 0;
            int kovetel57 = 0;
            int egyenleg57 = 0;





            int tartozik58 = 0;
            int kovetel58 = 0;
            int egyenleg58 = 0;
            int tartozik59 = 0;
            int kovetel59 = 0;
            int egyenleg59 = 0;


            int s = 0;
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            ko.Add(0);
            connect.Open();

         




            s = 0;
            for (i  = 0; i< mirror.Count(); i++)
            {
               

                if(mirror[i].szamlaSzam == 51){

                    if (s == 0)
                    {

                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik51 = tartozik51 + mirror[i].tartozik;
                    kovetel51 = kovetel51 + mirror[i].kovetel;
                    egyenleg51 = egyenleg51 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik51 + "',kovetel='" + kovetel51 + "',egyenleg='" + egyenleg51 + "' where fokonyviSzam=51;";
                    frissit.ExecuteNonQuery();
                    ko[0]++;
                }


                if (mirror[i].szamlaSzam >= 511 && mirror[i].szamlaSzam <= 519)
                {
                    
                    ko[0]++;
                    if (ko[0]==1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik51 = tartozik51 + mirror[i].tartozik;
                    kovetel51 = kovetel51 + mirror[i].kovetel;
                    egyenleg51 = egyenleg51 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik51 + "',kovetel='" + kovetel51 + "',egyenleg='" + egyenleg51 + "' where fokonyviSzam=51;";
                    frissit.ExecuteNonQuery();
                    
                }

                if (mirror[i].szamlaSzam == 52)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik52 = tartozik52 + mirror[i].tartozik;
                    kovetel52 = kovetel52 + mirror[i].kovetel;
                    egyenleg52 = egyenleg52 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik52 + "',kovetel='" + kovetel52 + "',egyenleg='" + egyenleg52 + "' where fokonyviSzam=52;";
                    frissit.ExecuteNonQuery();
                    ko[1]++;
                }



                if (mirror[i].szamlaSzam >= 521 && mirror[i].szamlaSzam <= 529)
                {
                   
                    ko[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (ko[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik52 = tartozik52 + mirror[i].tartozik;
                    kovetel52 = kovetel52 + mirror[i].kovetel;
                    egyenleg52 = egyenleg52 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik52 + "',kovetel='" + kovetel52 + "',egyenleg='" + egyenleg52 + "' where fokonyviSzam=52;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam == 53)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik53 = tartozik53 + mirror[i].tartozik;
                    kovetel53 = kovetel53 + mirror[i].kovetel;
                    egyenleg53 = egyenleg53 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik53 + "',kovetel='" + kovetel53 + "',egyenleg='" + egyenleg53 + "' where fokonyviSzam=53;";
                    frissit.ExecuteNonQuery();
                    ko[2]++;
                }



                if (mirror[i].szamlaSzam >= 531 && mirror[i].szamlaSzam <= 539)
                {
                    
                    ko[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (ko[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik53 = tartozik53 + mirror[i].tartozik;
                    kovetel53 = kovetel53 + mirror[i].kovetel;
                    egyenleg53 = egyenleg53 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik53 + "',kovetel='" + kovetel53 + "',egyenleg='" + egyenleg53 + "' where fokonyviSzam=53;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 54)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik54 = tartozik54 + mirror[i].tartozik;
                    kovetel54 = kovetel54 + mirror[i].kovetel;
                    egyenleg54 = egyenleg54 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik54 + "',kovetel='" + kovetel54 + "',egyenleg='" + egyenleg54 + "' where fokonyviSzam=54;";
                    frissit.ExecuteNonQuery();
                    ko[3]++;
                }



                if (mirror[i].szamlaSzam == 541)
                {
                    
                    ko[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (ko[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();
                    }
                    tartozik54 = tartozik54 + mirror[i].tartozik;
                    kovetel54 = kovetel54 + mirror[i].kovetel;
                    egyenleg54 = egyenleg54 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik54 + "',kovetel='" + kovetel54 + "',egyenleg='" + egyenleg54 + "' where fokonyviSzam=54;";
                    frissit.ExecuteNonQuery();


                }

                if (mirror[i].szamlaSzam == 55)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik55 = tartozik55 + mirror[i].tartozik;
                    kovetel55 = kovetel55 + mirror[i].kovetel;
                    egyenleg55 = egyenleg55 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik55 + "',kovetel='" + kovetel55 + "',egyenleg='" + egyenleg55 + "' where fokonyviSzam=55;";
                    frissit.ExecuteNonQuery();
                    ko[4]++;
                }


                if (mirror[i].szamlaSzam >= 551 && mirror[i].szamlaSzam <= 559)
                {
                    
                    ko[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (ko[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();
                        r++;
                    }
                    tartozik55 = tartozik55 + mirror[i].tartozik;
                    kovetel55 = kovetel55 + mirror[i].kovetel;
                    egyenleg55 = egyenleg55 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik55 + "',kovetel='" + kovetel55 + "',egyenleg='" + egyenleg55 + "' where fokonyviSzam=55;";
                    frissit.ExecuteNonQuery();


                }


                if (mirror[i].szamlaSzam == 56)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik56 = tartozik56 + mirror[i].tartozik;
                    kovetel56 = kovetel56 + mirror[i].kovetel;
                    egyenleg56 = egyenleg56 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik56 + "',kovetel='" + kovetel56 + "',egyenleg='" + egyenleg56 + "' where fokonyviSzam=56;";
                    frissit.ExecuteNonQuery();
                    ko[5]++;
                }



                if (mirror[i].szamlaSzam >= 561 && mirror[i].szamlaSzam <= 569)
                {
                    
                    ko[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (ko[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }


                    tartozik56 = tartozik56 + mirror[i].tartozik;
                    kovetel56 = kovetel56 + mirror[i].kovetel;
                    egyenleg56 = egyenleg56 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik56 + "',kovetel='" + kovetel56 + "',egyenleg='" + egyenleg56 + "' where fokonyviSzam=56;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam == 57)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    tartozik57 = tartozik57 + mirror[i].tartozik;
                    kovetel57 = kovetel57 + mirror[i].kovetel;
                    egyenleg57 = egyenleg57 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik57 + "',kovetel='" + kovetel57 + "',egyenleg='" + egyenleg57 + "' where fokonyviSzam=57;";
                    frissit.ExecuteNonQuery();
                    ko[6]++;
                }


                if (mirror[i].szamlaSzam >= 571 && mirror[i].szamlaSzam <= 572)
                {
                    
                    ko[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (ko[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }



                    tartozik57 = tartozik57 + mirror[i].tartozik;
                    kovetel57 = kovetel57 + mirror[i].kovetel;
                    egyenleg57 = egyenleg57 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik57 + "',kovetel='" + kovetel57 + "',egyenleg='" + egyenleg57 + "' where fokonyviSzam=57;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 58)
                {

                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik58 = tartozik58 + mirror[i].tartozik;
                    kovetel58 = kovetel58 + mirror[i].kovetel;
                    egyenleg58 = egyenleg58 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik58 + "',kovetel='" + kovetel58 + "',egyenleg='" + egyenleg58 + "' where fokonyviSzam=58;";
                    frissit.ExecuteNonQuery();
                    ko[7]++;
                }

                if (mirror[i].szamlaSzam >= 581 && mirror[i].szamlaSzam <= 582)
                {
                    
                    ko[7]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (ko[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                    }



                    tartozik58 = tartozik58 + mirror[i].tartozik;
                    kovetel58 = kovetel58 + mirror[i].kovetel;
                    egyenleg58 = egyenleg58 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik58 + "',kovetel='" + kovetel58 + "',egyenleg='" + egyenleg58 + "' where fokonyviSzam=58;";
                    frissit.ExecuteNonQuery();

                }


             

                if (mirror[i].szamlaSzam == 59)
                 {
                        
                        ko[8]++;

                        if (s == 0)
                        {
                            beszur.ExecuteNonQuery();
                            s++;

                        }

                        if (ko[8] == 1)
                        {
                            beszur11.ExecuteNonQuery();
                        }



                        tartozik59 = tartozik59 + mirror[i].tartozik;
                        kovetel59 = kovetel59 + mirror[i].kovetel;
                        egyenleg59 = egyenleg59 + mirror[i].egyenleg;

                        beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                        beszur2.ExecuteNonQuery();
                        frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik59 + "',kovetel='" + kovetel59 + "',egyenleg='" + egyenleg59 + "' where fokonyviSzam=59;";
                        frissit.ExecuteNonQuery();

                 }



            }
    
                int tartozik5 = tartozik51 + tartozik52 + tartozik53 + tartozik54 + tartozik55 + tartozik56 + tartozik57 + tartozik58 + tartozik59;
                int kovetel5 = kovetel51 + kovetel52 + kovetel53 + kovetel54 + kovetel55 + kovetel56 + kovetel57 + kovetel58 + kovetel59;
                int egyenleg5 = egyenleg51 + egyenleg52 + egyenleg53 + egyenleg54 + egyenleg55 + egyenleg56 + egyenleg57 + egyenleg58 + egyenleg59;

                frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik5 + "',kovetel='" + kovetel5 + "',egyenleg='" + egyenleg5 + "' where fokonyviSzam=5;";
                frissit2.ExecuteNonQuery();
                connect.Close();
               
                


            

}

        public void Koltseghelyek()
        {
            int i = 0;
            int r = 0;
            
            List<int> h = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(6,'KÖLTSÉGHELYEK,ÁLTALÁNOS KÖLTSÉGEK',0,0,0);";
            beszur3.CommandText = "insert  into fokonyv2 values(61,'JAVÍTÓ KARBANTARTÓ ÜZEMEK KÖLTSÉGEI',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(62,'SZOLGÁLTATÁST VÉGZŐ ÜZEMEK KÖLTSÉGEI',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(63,'GÉPKÖLTSÉG',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(64,'ÜZEMI IRÁNYÍTÁS ÁLTALÁNOS KÖLTSÉGEI',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(66,'KÖZPONTI IRÁNYÍTÁS ÁLTALÁNOS KÖLTSÉGEI',0,0,0);";

            beszur8.CommandText = "insert into fokonyv2 values(67,'ÉRTÉKESÍTÉSI FORGALMAZÁSI KÖLTSÉGEK',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(68,'ELKÜLÖNÍTETT EGYÉB ÁLTALÁNOS KÖLTSÉGEK',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(69,'KÖLTSÉGHELYEK KÖLTSÉGEINEK ÁTVEZETÉSE',0,0,0);";

            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik61 = 0;
            int kovetel61 = 0;
            int egyenleg61 = 0;

            int tartozik62 = 0;
            int kovetel62 = 0;
            int egyenleg62 = 0;

            int tartozik63 = 0;
            int kovetel63 = 0;
            int egyenleg63 = 0;
            int tartozik64 = 0;
            int kovetel64 = 0;
            int egyenleg64 = 0;


            int tartozik66 = 0;
            int kovetel66 = 0;
            int egyenleg66 = 0;
            int tartozik67 = 0;
            int kovetel67 = 0;
            int egyenleg67 = 0;





            int tartozik68 = 0;
            int kovetel68 = 0;
            int egyenleg68 = 0;
            int tartozik69 = 0;
            int kovetel69 = 0;
            int egyenleg69 = 0;


            int s = 0;
            connect.Open();



            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            h.Add(0);
            for (i = 0; i < mirror.Count(); i++)
            {
                if (mirror[i].szamlaSzam == 61)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik61 = tartozik61 + mirror[i].tartozik;
                    kovetel61 = kovetel61 + mirror[i].kovetel;
                    egyenleg61 = egyenleg61 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik61 + "',kovetel='" + kovetel61 + "',egyenleg='" + egyenleg61 + "' where fokonyviSzam=61;";
                    frissit.ExecuteNonQuery();
                }





                if (mirror[i].szamlaSzam == 62)
                {
                    h[1]++;
                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (h[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik62 = tartozik62 + mirror[i].tartozik;
                    kovetel62 = kovetel62 + mirror[i].kovetel;
                    egyenleg62 = egyenleg62 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik62 + "',kovetel='" + kovetel62 + "',egyenleg='" + egyenleg62 + "' where fokonyviSzam=62;";
                    frissit.ExecuteNonQuery();


                }



                if (mirror[i].szamlaSzam == 63)
                {
                    h[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (h[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik63 = tartozik63 + mirror[i].tartozik;
                    kovetel63 = kovetel63 + mirror[i].kovetel;
                    egyenleg63 = egyenleg63 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik63 + "',kovetel='" + kovetel63 + "',egyenleg='" + egyenleg63 + "' where fokonyviSzam=63;";
                    frissit.ExecuteNonQuery();

                }




                if (mirror[i].szamlaSzam == 64)
                {
                    h[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (h[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();
                    }
                    tartozik64 = tartozik64 + mirror[i].tartozik;
                    kovetel64 = kovetel64 + mirror[i].kovetel;
                    egyenleg64 = egyenleg64 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik64 + "',kovetel='" + kovetel64 + "',egyenleg='" + egyenleg64 + "' where fokonyviSzam=64;";
                    frissit.ExecuteNonQuery();


                }



                if (mirror[i].szamlaSzam == 66)
                {

                    h[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (h[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();
                        r++;
                    }
                    tartozik66 = tartozik66 + mirror[i].tartozik;
                    kovetel66 = kovetel66 + mirror[i].kovetel;
                    egyenleg66 = egyenleg66 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik66 + "',kovetel='" + kovetel66 + "',egyenleg='" + egyenleg66 + "' where fokonyviSzam=66;";
                    frissit.ExecuteNonQuery();


                }





                if (mirror[i].szamlaSzam == 67)
                {
                    h[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (h[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }


                    tartozik67 = tartozik67 + mirror[i].tartozik;
                    kovetel67 = kovetel67 + mirror[i].kovetel;
                    egyenleg67 = egyenleg67 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik67 + "',kovetel='" + kovetel67 + "',egyenleg='" + egyenleg67 + "' where fokonyviSzam=67;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 68)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik68 = tartozik68 + mirror[i].tartozik;
                    kovetel68 = kovetel68 + mirror[i].kovetel;
                    egyenleg68 = egyenleg68 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik68 + "',kovetel='" + kovetel68 + "',egyenleg='" + egyenleg68 + "' where fokonyviSzam=68;";
                    frissit.ExecuteNonQuery();
                    h[6]++;
                }

                if (mirror[i].szamlaSzam >= 681 && mirror[i].szamlaSzam <= 689)
                {
                    h[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (h[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }



                    tartozik68 = tartozik68 + mirror[i].tartozik;
                    kovetel68 = kovetel68 + mirror[i].kovetel;
                    egyenleg68 = egyenleg68 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik68 + "',kovetel='" + kovetel68 + "',egyenleg='" + egyenleg68 + "' where fokonyviSzam=68;";
                    frissit.ExecuteNonQuery();

                }

                if (mirror[i].szamlaSzam == 69)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik69 = tartozik69 + mirror[i].tartozik;
                    kovetel69 = kovetel69 + mirror[i].kovetel;
                    egyenleg69 = egyenleg69 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik69 + "',kovetel='" + kovetel69 + "',egyenleg='" + egyenleg69 + "' where fokonyviSzam=69;";
                    frissit.ExecuteNonQuery();
                    h[7]++;

                }

                if (mirror[i].szamlaSzam == 691)
                {
                    h[7]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (h[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                    }



                    tartozik69 = tartozik69 + mirror[i].tartozik;
                    kovetel69 = kovetel69 + mirror[i].kovetel;
                    egyenleg69 = egyenleg69 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik69 + "',kovetel='" + kovetel69 + "',egyenleg='" + egyenleg69 + "' where fokonyviSzam=69;";
                    frissit.ExecuteNonQuery();

                }

            }


            int tartozik6 = tartozik61 + tartozik62 + tartozik63 + tartozik64 + tartozik66 + tartozik66 + tartozik67 + tartozik68 + tartozik69; ;
            int kovetel6 = kovetel61 + kovetel62 + kovetel63 + kovetel64 + kovetel66 + kovetel66 + kovetel67 + kovetel68 + kovetel69;
            int egyenleg6 = egyenleg61 + egyenleg62 + egyenleg63 + egyenleg64 + egyenleg66 + egyenleg66 + egyenleg67 + egyenleg68 + egyenleg69; ;

            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik6 + "',kovetel='" + kovetel6 + "',egyenleg='" + egyenleg6 + "' where fokonyviSzam=6;";
            frissit2.ExecuteNonQuery();
            connect.Close();
           
           


        }


        public void TevekenysegKoltsegei()
        {
            int i = 0;
            int r = 0;
            
            List<int> u = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(7,'TEVÉKENYSÉGEK KÖLTSÉGEI',0,0,0);";

            beszur7.CommandText = "insert into fokonyv2 values(75,'SZOLGÁLTATÁS KÖLTSÉGEI',0,0,0);";

            beszur8.CommandText = "insert into fokonyv2 values(76,'KÖLTSÉGHELYEK TERMELÉSI KÖLTSÉGEI',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(77,'FORGALOMBA HOZATAL KÖLTSÉGEI',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(79,'TEVÉKENYSÉGEK KÖLTSÉGEINEK ELSZÁMOLÁSA',0,0,0);";

            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik75 = 0;
            int kovetel75 = 0;
            int egyenleg75 = 0;
            int tartozik76 = 0;
            int kovetel76 = 0;
            int egyenleg76 = 0;
            int tartozik77 = 0;
            int kovetel77 = 0;
            int egyenleg77 = 0;





            int tartozik79 = 0;
            int kovetel79 = 0;
            int egyenleg79 = 0;


            int s = 0;
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);
            u.Add(0);

            connect.Open();
            for (i = 0; i < mirror.Count(); i++)
            {
                if (mirror[i].szamlaSzam == 75)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();

                        s++;
                    }

                    tartozik75 = tartozik75 + mirror[i].tartozik;
                    kovetel75 = kovetel75 + mirror[i].kovetel;
                    egyenleg75 = egyenleg75 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik75 + "',kovetel='" + kovetel75 + "',egyenleg='" + egyenleg75 + "' where fokonyviSzam=75;";
                    frissit.ExecuteNonQuery();
                }





                if (mirror[i].szamlaSzam == 76)
                {
                    u[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (u[1] == 1)
                    {
                        beszur8.ExecuteNonQuery();
                    }

                    tartozik76 = tartozik76 + mirror[i].tartozik;
                    kovetel76 = kovetel76 + mirror[i].kovetel;
                    egyenleg76 = egyenleg76 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik76 + "',kovetel='" + kovetel76 + "',egyenleg='" + egyenleg76 + "' where fokonyviSzam=76;";
                    frissit.ExecuteNonQuery();


                }


                if (mirror[i].szamlaSzam == 77)
                {
                    u[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (u[2] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                    }
                    tartozik77 = tartozik77 + mirror[i].tartozik;
                    kovetel77 = kovetel77 + mirror[i].kovetel;
                    egyenleg77 = egyenleg77 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik77 + "',kovetel='" + kovetel77 + "',egyenleg='" + egyenleg77 + "' where fokonyviSzam=77;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam == 79)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik79 = tartozik79 + mirror[i].tartozik;
                    kovetel79 = kovetel79 + mirror[i].kovetel;
                    egyenleg79 = egyenleg79 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik79 + "',kovetel='" + kovetel79 + "',egyenleg='" + egyenleg79 + "' where fokonyviSzam=79;";
                    frissit.ExecuteNonQuery();
                    u[3]++;
                }





                if (mirror[i].szamlaSzam >= 791 && mirror[i].szamlaSzam <= 795)
                {

                    u[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (u[3] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                        r++;
                    }
                    tartozik79 = tartozik79 + mirror[i].tartozik;
                    kovetel79 = kovetel79 + mirror[i].kovetel;
                    egyenleg79 = egyenleg79 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik79 + "',kovetel='" + kovetel79 + "',egyenleg='" + egyenleg79 + "' where fokonyviSzam=79;";
                    frissit.ExecuteNonQuery();


                }



            }


            int tartozik7 = tartozik75 + tartozik76 + tartozik77 + tartozik79;
            int kovetel7 = kovetel75 + kovetel76 + kovetel77 + kovetel79;
            int egyenleg7 = egyenleg75 + egyenleg76 + egyenleg77 + egyenleg79;
            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik7 + "',kovetel='" + kovetel7 + "',egyenleg='" + egyenleg7 + "' where fokonyviSzam=7;";
            frissit2.ExecuteNonQuery();
            connect.Close();
          

        }

        public void ErtekesitesElszOnk()
        {
            int i = 0;
            int r = 0;
          
            List<int> w = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(8,'TEVÉKENYSÉGEK KÖLTSÉGEI',0,0,0);";
            beszur3.CommandText = "insert into fokonyv2 values(81,'ANYAGI JELLEGŰ RÁFORDÍTÉSOK',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(82,'SZEMÉLYI JELLEGŰ RÁFORDÍTÁSOK',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(83,'ÉRTÉKCSÖKKENÉSI LEÍRÁS',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(85,'ÉRTÉKESÍTÉS KÖZVETETT KÖLTSÉGEI',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(86,'EGYÁB RÁFORDÍTÁSOK',0,0,0);";
            beszur8.CommandText = "insert into fokonyv2 values(87,'PÉNZÜGYI MŰVELETEK RÁFORDÍTÁSAI',0,0,0);";
            beszur9.CommandText = "insert into fokonyv2 values(88,'RENDKÍVÜLI RÁFORDÍTÁSOK',0,0,0);";
            beszur10.CommandText = "insert into fokonyv2 values(89,'NYERESÉGET TERHELŐ ADÓK',0,0,0);";
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik81 = 0;
            int kovetel81 = 0;
            int egyenleg81 = 0;
            int tartozik82 = 0;
            int kovetel82 = 0;
            int egyenleg82 = 0;
            int tartozik83 = 0;
            int kovetel83 = 0;
            int egyenleg83 = 0;

            int tartozik85 = 0;
            int kovetel85 = 0;
            int egyenleg85 = 0;
            int tartozik86 = 0;
            int kovetel86 = 0;
            int egyenleg86 = 0;
            int tartozik87 = 0;
            int kovetel87 = 0;
            int egyenleg87 = 0;

            int tartozik88 = 0;
            int kovetel88 = 0;
            int egyenleg88 = 0;
            int tartozik89 = 0;
            int kovetel89 = 0;
            int egyenleg89 = 0;
            w.Add(0);
            w.Add(0);
            w.Add(0);
            w.Add(0);
            w.Add(0);
            w.Add(0);
            w.Add(0);
            w.Add(0);
            int s = 0;
            connect.Open();
            for (i = 0; i < mirror.Count(); i++)
            {
                if (mirror[i].szamlaSzam ==81)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik81 = tartozik81 + mirror[i].tartozik;
                    kovetel81 = kovetel81 + mirror[i].kovetel;
                    egyenleg81 = egyenleg81 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik81 + "',kovetel='" + kovetel81 + "',egyenleg='" + egyenleg81 + "' where fokonyviSzam=81;";
                    frissit.ExecuteNonQuery();

                }
                if (mirror[i].szamlaSzam >= 811 && mirror[i].szamlaSzam <= 819)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();
                        beszur3.ExecuteNonQuery();
                        s++;
                    }

                    tartozik81 = tartozik81 + mirror[i].tartozik;
                    kovetel81 = kovetel81 + mirror[i].kovetel;
                    egyenleg81 = egyenleg81 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik81 + "',kovetel='" + kovetel81 + "',egyenleg='" + egyenleg81 + "' where fokonyviSzam=81;";
                    frissit.ExecuteNonQuery();
                }

                if (mirror[i].szamlaSzam ==82)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik82 = tartozik82 + mirror[i].tartozik;
                    kovetel82 = kovetel82 + mirror[i].kovetel;
                    egyenleg82 = egyenleg82 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik82 + "',kovetel='" + kovetel82 + "',egyenleg='" + egyenleg82 + "' where fokonyviSzam=82;";
                    frissit.ExecuteNonQuery();
                    w[1]++;
                }



                if (mirror[i].szamlaSzam >= 821 && mirror[i].szamlaSzam <= 823)
                {
                    w[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }
                    if (w[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik82 = tartozik82 + mirror[i].tartozik;
                    kovetel82 = kovetel82 + mirror[i].kovetel;
                    egyenleg82 = egyenleg82 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik82 + "',kovetel='" + kovetel82 + "',egyenleg='" + egyenleg82 + "' where fokonyviSzam=82;";
                    frissit.ExecuteNonQuery();


                }



                if (mirror[i].szamlaSzam == 83)
                {
                    w[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (w[2] == 1)
                    {

                    }
                    tartozik83 = tartozik83 + mirror[i].tartozik;
                    kovetel83 = kovetel83 + mirror[i].kovetel;
                    egyenleg83 = egyenleg83 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik83 + "',kovetel='" + kovetel83 + "',egyenleg='" + egyenleg83 + "' where fokonyviSzam=83;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam ==85)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik85 = tartozik85 + mirror[i].tartozik;
                    kovetel85 = kovetel85 + mirror[i].kovetel;
                    egyenleg85 = egyenleg85 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik85 + "',kovetel='" + kovetel85 + "',egyenleg='" + egyenleg85 + "' where fokonyviSzam=85;";
                    frissit.ExecuteNonQuery();
                    w[3]++;
                }





                if (mirror[i].szamlaSzam >= 851 && mirror[i].szamlaSzam <= 853)
                {
                    w[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (w[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();
                        r++;
                    }
                    tartozik85 = tartozik85 + mirror[i].tartozik;
                    kovetel85 = kovetel85 + mirror[i].kovetel;
                    egyenleg85 = egyenleg85 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik85 + "',kovetel='" + kovetel85 + "',egyenleg='" + egyenleg85 + "' where fokonyviSzam=85;";
                    frissit.ExecuteNonQuery();


                }


                if (mirror[i].szamlaSzam ==86)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik86 = tartozik86 + mirror[i].tartozik;
                    kovetel86 = kovetel86 + mirror[i].kovetel;
                    egyenleg86 = egyenleg86 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik86 + "',kovetel='" + kovetel86 + "',egyenleg='" + egyenleg86 + "' where fokonyviSzam=86;";
                    frissit.ExecuteNonQuery();
                    w[4]++;

                }

                if (mirror[i].szamlaSzam >= 861 && mirror[i].szamlaSzam <= 859)
                {

                    w[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (w[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();
                        r++;
                    }
                    tartozik86 = tartozik86 + mirror[i].tartozik;
                    kovetel86 = kovetel86 + mirror[i].kovetel;
                    egyenleg86 = egyenleg86 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik86 + "',kovetel='" + kovetel86 + "',egyenleg='" + egyenleg86 + "' where fokonyviSzam=86;";
                    frissit.ExecuteNonQuery();


                }



                if (mirror[i].szamlaSzam ==87)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik87 = tartozik87 + mirror[i].tartozik;
                    kovetel87 = kovetel87 + mirror[i].kovetel;
                    egyenleg87 = egyenleg87 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik87 + "',kovetel='" + kovetel87 + "',egyenleg='" + egyenleg87 + "' where fokonyviSzam=87;";
                    frissit.ExecuteNonQuery();
                    w[5]++;
                }
                if (mirror[i].szamlaSzam >= 871 && mirror[i].szamlaSzam <= 879)
                {

                    w[5]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (w[5] == 1)
                    {
                        beszur8.ExecuteNonQuery();

                    }
                    tartozik87 = tartozik87 + mirror[i].tartozik;
                    kovetel87 = kovetel87 + mirror[i].kovetel;
                    egyenleg87 = egyenleg87 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik87 + "',kovetel='" + kovetel87 + "',egyenleg='" + egyenleg87 + "' where fokonyviSzam=87;";
                    frissit.ExecuteNonQuery();


                }

                if (mirror[i].szamlaSzam ==88)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik88 = tartozik88 + mirror[i].tartozik;
                    kovetel88 = kovetel88 + mirror[i].kovetel;
                    egyenleg88 = egyenleg88 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik88 + "',kovetel='" + kovetel88 + "',egyenleg='" + egyenleg88 + "' where fokonyviSzam=88;";
                    frissit.ExecuteNonQuery();
                    w[6]++;
                }
                if (mirror[i].szamlaSzam >= 881 && mirror[i].szamlaSzam <= 889)
                {

                    w[6]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (w[6] == 1)
                    {
                        beszur9.ExecuteNonQuery();
                        r++;
                    }
                    tartozik88 = tartozik88 + mirror[i].tartozik;
                    kovetel88 = kovetel88 + mirror[i].kovetel;
                    egyenleg88 = egyenleg88 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik88 + "',kovetel='" + kovetel88 + "',egyenleg='" + egyenleg88 + "' where fokonyviSzam=88;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam ==89)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik89 = tartozik89 + mirror[i].tartozik;
                    kovetel89 = kovetel89 + mirror[i].kovetel;
                    egyenleg89 = egyenleg89 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik89 + "',kovetel='" + kovetel89 + "',egyenleg='" + egyenleg89 + "' where fokonyviSzam=89;";
                    frissit.ExecuteNonQuery();
                    w[7]++;
                }

                if (mirror[i].szamlaSzam == 891)
                {

                    w[7]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (w[7] == 1)
                    {
                        beszur10.ExecuteNonQuery();
                        r++;
                    }
                    tartozik89 = tartozik89 + mirror[i].tartozik;
                    kovetel89 = kovetel89 + mirror[i].kovetel;
                    egyenleg89 = egyenleg89 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik89 + "',kovetel='" + kovetel89 + "',egyenleg='" + egyenleg89 + "' where fokonyviSzam=89;";
                    frissit.ExecuteNonQuery();


                }

            }


            int tartozik8 = tartozik81 + tartozik82 + tartozik83 + tartozik85 + tartozik86 + tartozik87 + tartozik88 + tartozik89;
            int kovetel8 = kovetel81 + kovetel82 + kovetel83 + kovetel85 + kovetel86 + kovetel87 + kovetel88 + kovetel89;
            int egyenleg8 = egyenleg81 + egyenleg82 + egyenleg83 + egyenleg85 + egyenleg86 + egyenleg87 + egyenleg88 + egyenleg89;
            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik8 + "',kovetel='" + kovetel8 + "',egyenleg='" + egyenleg8 + "' where fokonyviSzam=8;";
            frissit2.ExecuteNonQuery();
            connect.Close();
           
           
        }

        public void ErtekesitesArbeveteleEsBevetelek()
        {
            int i = 0;
            
            List<int> p = new List<int>();
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            MySqlCommand parancs = connect.CreateCommand();
            MySqlCommand beszur = connect.CreateCommand();
            MySqlCommand beszur3 = connect.CreateCommand();
            MySqlCommand beszur2 = connect.CreateCommand();
            MySqlCommand beszur4 = connect.CreateCommand();
            MySqlCommand beszur5 = connect.CreateCommand();
            MySqlCommand beszur6 = connect.CreateCommand();
            MySqlCommand beszur7 = connect.CreateCommand();
            MySqlCommand beszur8 = connect.CreateCommand();
            MySqlCommand beszur9 = connect.CreateCommand();
            MySqlCommand beszur10 = connect.CreateCommand();
            MySqlCommand beszur11 = connect.CreateCommand();
            MySqlCommand frissit = connect.CreateCommand();
            MySqlCommand frissit2 = connect.CreateCommand();
            cm.CommandText = "Select * FROM szamlatukor";
            beszur.CommandText = "insert into fokonyv2 values(9,'ÉRTÉKESÍTÉS ÁRBEVÉTELE ÉS BEVÉTELEK',0,0,0);";
            beszur3.CommandText = "insert into fokonyv2 values(91,'BELFÖLDI ÉRTÉKESÍTÉS ÁRBEVÉTELE',0,0,0);";
            beszur4.CommandText = "insert into fokonyv2 values(93,'EXPORT ÉRTÉKESÍTÉSE ÁRBEVÉTELE',0,0,0);";
            beszur5.CommandText = "insert into fokonyv2 values(96,'EGYÉB BEVÉTELEK',0,0,0);";
            beszur6.CommandText = "insert into fokonyv2 values(97,'PÉNZÜGYI BEVÉTELEK MŰVELETEI',0,0,0);";
            beszur7.CommandText = "insert into fokonyv2 values(98,'RENDKÍVÜLI BEVÉTELEK',0,0,0);";


            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            connect.Close();

            int tartozik91 = 0;
            int kovetel91 = 0;
            int egyenleg91 = 0;

            int tartozik93 = 0;
            int kovetel93 = 0;
            int egyenleg93 = 0;


            int tartozik96 = 0;
            int kovetel96 = 0;
            int egyenleg96 = 0;
            int tartozik97 = 0;
            int kovetel97 = 0;
            int egyenleg97 = 0;

            int tartozik98 = 0;
            int kovetel98 = 0;
            int egyenleg98 = 0;



            int s = 0;
            p.Add(0);
            p.Add(0);
            p.Add(0);
            p.Add(0);
            p.Add(0);
            p.Add(0);
            p.Add(0);
            p.Add(0);
            connect.Open();
            for (i = 0; i < mirror.Count(); i++)
            {
                if (mirror[i].szamlaSzam == 91)
                {
                    s++;

                    if (s == 1)
                    {
                        beszur.ExecuteNonQuery();

                        s++;
                    }

                    tartozik91 = tartozik91 + mirror[i].tartozik;
                    kovetel91 = kovetel91 + mirror[i].kovetel;
                    egyenleg91 = egyenleg91 + mirror[i].egyenleg;
                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik91 + "',kovetel='" + kovetel91 + "',egyenleg='" + egyenleg91 + "' where fokonyviSzam=91;";
                    frissit.ExecuteNonQuery();
                }





                if (mirror[i].szamlaSzam == 93)
                {
                    p[1]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }

                    if (p[1] == 1)
                    {
                        beszur4.ExecuteNonQuery();
                    }

                    tartozik93 = tartozik93 + mirror[i].tartozik;
                    kovetel93 = kovetel93 + mirror[i].kovetel;
                    egyenleg93 = egyenleg93 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik93 + "',kovetel='" + kovetel93 + "',egyenleg='" + egyenleg93 + "' where fokonyviSzam=93;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam == 96)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik96 = tartozik96 + mirror[i].tartozik;
                    kovetel96 = kovetel96 + mirror[i].kovetel;
                    egyenleg96 = egyenleg96 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik96 + "',kovetel='" + kovetel96 + "',egyenleg='" + egyenleg96 + "' where fokonyviSzam=96;";
                    frissit.ExecuteNonQuery();
                    p[2]++;



                }

                if (mirror[i].szamlaSzam >= 961 && mirror[i].szamlaSzam <= 969)
                {
                    p[2]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }

                    if (p[2] == 1)
                    {
                        beszur5.ExecuteNonQuery();
                    }
                    tartozik96 = tartozik96 + mirror[i].tartozik;
                    kovetel96 = kovetel96 + mirror[i].kovetel;
                    egyenleg96 = egyenleg96 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik96 + "',kovetel='" + kovetel96 + "',egyenleg='" + egyenleg96 + "' where fokonyviSzam=96;";
                    frissit.ExecuteNonQuery();

                }


                if (mirror[i].szamlaSzam ==97)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik97 = tartozik97 + mirror[i].tartozik;
                    kovetel97 = kovetel97 + mirror[i].kovetel;
                    egyenleg97 = egyenleg97 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik97 + "',kovetel='" + kovetel97 + "',egyenleg='" + egyenleg97 + "' where fokonyviSzam=97;";
                    frissit.ExecuteNonQuery();
                    p[3]++;
                }







                if (mirror[i].szamlaSzam >= 971 && mirror[i].szamlaSzam <= 979)
                {

                    p[3]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (p[3] == 1)
                    {
                        beszur6.ExecuteNonQuery();

                    }
                    tartozik97 = tartozik97 + mirror[i].tartozik;
                    kovetel97 = kovetel97 + mirror[i].kovetel;
                    egyenleg97 = egyenleg97 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik97 + "',kovetel='" + kovetel97 + "',egyenleg='" + egyenleg97 + "' where fokonyviSzam=97;";
                    frissit.ExecuteNonQuery();


                }
                if (mirror[i].szamlaSzam ==98)
                {
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;
                    }
                    tartozik98 = tartozik98 + mirror[i].tartozik;
                    kovetel98 = kovetel98 + mirror[i].kovetel;
                    egyenleg98 = egyenleg98 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik98 + "',kovetel='" + kovetel98 + "',egyenleg='" + egyenleg98 + "' where fokonyviSzam=98;";
                    frissit.ExecuteNonQuery();
                    p[4]++;
                }



                if (mirror[i].szamlaSzam >= 981 && mirror[i].szamlaSzam <= 989)
                {

                    p[4]++;
                    if (s == 0)
                    {
                        beszur.ExecuteNonQuery();
                        s++;

                    }


                    if (p[4] == 1)
                    {
                        beszur7.ExecuteNonQuery();

                    }
                    tartozik98 = tartozik98 + mirror[i].tartozik;
                    kovetel98 = kovetel98 + mirror[i].kovetel;
                    egyenleg98 = egyenleg98 + mirror[i].egyenleg;

                    beszur2.CommandText = "insert into fokonyv2 values('" + mirror[i].szamlaSzam + "','" + mirror[i].szamlaNev + "','" + mirror[i].tartozik + "','" + mirror[i].kovetel + "','" + mirror[i].egyenleg + "');";
                    beszur2.ExecuteNonQuery();
                    frissit.CommandText = "update fokonyv2 set tartozik='" + tartozik98 + "',kovetel='" + kovetel98 + "',egyenleg='" + egyenleg98 + "' where fokonyviSzam=98;";
                    frissit.ExecuteNonQuery();


                }


            }


            int tartozik9 = tartozik91 + tartozik93 + tartozik96 + tartozik97 + tartozik98;
            int kovetel9 = kovetel91 + kovetel93 + kovetel96 + kovetel97 + kovetel98;
            int egyenleg9 = egyenleg91 + egyenleg93 + egyenleg96 + egyenleg97 + egyenleg98;
            frissit2.CommandText = "update fokonyv2 set tartozik='" + tartozik9 + "',kovetel='" + kovetel9 + "',egyenleg='" + egyenleg9 + "' where fokonyviSzam=9;";
            frissit2.ExecuteNonQuery();
            connect.Close();
        




        }



       


        public void ujSzamlatukor()
        {

            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection kapcs = new MySqlConnection(conn);
            MySqlCommand cm = kapcs.CreateCommand();
            MySqlCommand parancscs = kapcs.CreateCommand();

            cm.CommandText = "select *from szamlatukor";

            try
            {
                kapcs.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MySqlDataReader reader = cm.ExecuteReader();

            while (reader.Read())
            {

                mirror3.Add(new SzamlaSzamok
                {
                    szamlaSzam = int.Parse(reader["szamlaId"].ToString()),
                    szamlaNev = reader["szamlaTipus"].ToString(),
                    tartozik = int.Parse(reader["tartozik"].ToString()),
                    kovetel = int.Parse(reader["kovetel"].ToString()),
                    egyenleg = int.Parse(reader["egyenleg"].ToString()),

                });

            }
            kapcs.Close();



        }

        public void osszeadSzamlak()
        {



            int i = 0;
            int tartozik119 = 0;
            int kovetel119 = 0;
            int egyenleg119 = 0;
            int tartozik179 = 0;
            int kovetel179 = 0;
            int egyenleg179 = 0;
            int tartozik193 = 0;
            int kovetel193 = 0;
            int egyenleg193 = 0;
            int tartozik199 = 0;
            int kovetel199 = 0;
            int egyenleg199 = 0;
            int tartozik359 = 0;
            int kovetel359 = 0;
            int egyenleg359 = 0;
            int tartozik361 = 0;
            int kovetel361 = 0;
            int egyenleg361 = 0;
            int tartozik362 = 0;
            int kovetel362 = 0;
            int egyenleg362 = 0;
            int tartozik363 = 0;
            int kovetel363 = 0;
            int egyenleg363 = 0;
            int tartozik364 = 0;
            int kovetel364 = 0;
            int egyenleg364 = 0;

            int tartozik365 = 0;
            int kovetel365 = 0;
            int egyenleg365 = 0;

            int tartozik371 = 0;
            int kovetel371 = 0;
            int egyenleg371 = 0;

            int tartozik372 = 0;
            int kovetel372 = 0;
            int egyenleg372 = 0;

            int tartozik373 = 0;
            int kovetel373 = 0;
            int egyenleg373 = 0;

            int tartozik374 = 0;
            int kovetel374 = 0;
            int egyenleg374 = 0;

            int tartozik381 = 0;
            int kovetel381 = 0;
            int egyenleg381 = 0;

            int tartozik382 = 0;
            int kovetel382 = 0;
            int egyenleg382 = 0;

            int tartozik385 = 0;
            int kovetel385 = 0;
            int egyenleg385 = 0;

            int tartozik386 = 0;
            int kovetel386 = 0;
            int egyenleg386 = 0;

            int tartozik391 = 0;
            int kovetel391 = 0;
            int egyenleg391 = 0;

            int tartozik392 = 0;
            int kovetel392 = 0;
            int egyenleg392 = 0;

            int tartozik393 = 0;
            int kovetel393 = 0;
            int egyenleg393 = 0;

            int tartozik399 = 0;
            int kovetel399 = 0;
            int egyenleg399 = 0;

            int tartozik414 = 0;
            int kovetel414 = 0;
            int egyenleg414 = 0;

            int tartozik431 = 0;
            int kovetel431 = 0;
            int egyenleg431 = 0;

            int tartozik443 = 0;
            int kovetel443 = 0;
            int egyenleg443 = 0;


            int tartozik444 = 0;
            int kovetel444 = 0;
            int egyenleg444 = 0;

            int tartozik445 = 0;
            int kovetel445 = 0;
            int egyenleg445 = 0;

            int tartozik446 = 0;
            int kovetel446 = 0;
            int egyenleg446 = 0;

            int tartozik449 = 0;
            int kovetel449 = 0;
            int egyenleg449 = 0;

            int tartozik451 = 0;
            int kovetel451 = 0;
            int egyenleg451 = 0;

            int tartozik452 = 0;
            int kovetel452 = 0;
            int egyenleg452 = 0;

            int tartozik454 = 0;
            int kovetel454 = 0;
            int egyenleg454 = 0;

            int tartozik455 = 0;
            int kovetel455 = 0;
            int egyenleg455 = 0;

            int tartozik458 = 0;
            int kovetel458 = 0;
            int egyenleg458 = 0;

            int tartozik463 = 0;
            int kovetel463 = 0;
            int egyenleg463 = 0;

            int tartozik464 = 0;
            int kovetel464 = 0;
            int egyenleg464 = 0;

            int tartozik465 = 0;
            int kovetel465 = 0;
            int egyenleg465 = 0;



            int tartozik469 = 0;
            int kovetel469 = 0;
            int egyenleg469 = 0;

            int tartozik471 = 0;
            int kovetel471 = 0;
            int egyenleg471 = 0;

            int tartozik474 = 0;
            int kovetel474 = 0;
            int egyenleg474 = 0;

            int tartozik479 = 0;
            int kovetel479 = 0;
            int egyenleg479 = 0;


            int tartozik481 = 0;
            int kovetel481 = 0;
            int egyenleg481 = 0;

            int tartozik482 = 0;
            int kovetel482 = 0;
            int egyenleg482 = 0;

            int tartozik483 = 0;
            int kovetel483 = 0;
            int egyenleg483 = 0;



            int tartozik863 = 0;
            int kovetel863 = 0;
            int egyenleg863 = 0;

            int tartozik865 = 0;
            int kovetel865 = 0;
            int egyenleg865 = 0;

            int tartozik866 = 0;
            int kovetel866 = 0;
            int egyenleg866 = 0;

            int tartozik867 = 0;
            int kovetel867 = 0;
            int egyenleg867 = 0;

            int tartozik869 = 0;
            int kovetel869 = 0;
            int egyenleg869 = 0;


            int tartozik871 = 0;
            int kovetel871 = 0;
            int egyenleg871 = 0;

            int tartozik872 = 0;
            int kovetel872 = 0;
            int egyenleg872 = 0;

            int tartozik873 = 0;
            int kovetel873 = 0;
            int egyenleg873 = 0;

            int tartozik874 = 0;
            int kovetel874 = 0;
            int egyenleg874 = 0;

            int tartozik875 = 0;
            int kovetel875 = 0;
            int egyenleg875 = 0;

            int tartozik876 = 0;
            int kovetel876 = 0;
            int egyenleg876 = 0;

            int tartozik877 = 0;
            int kovetel877 = 0;
            int egyenleg877 = 0;

            int tartozik878 = 0;
            int kovetel878 = 0;
            int egyenleg878 = 0;

            int tartozik879 = 0;
            int kovetel879 = 0;
            int egyenleg879 = 0;

            int tartozik889 = 0;
            int kovetel889 = 0;
            int egyenleg889 = 0;

            int tartozik963 = 0;
            int kovetel963 = 0;
            int egyenleg963 = 0;
            int tartozik965 = 0;
            int kovetel965 = 0;
            int egyenleg965 = 0;
            int tartozik966 = 0;
            int kovetel966 = 0;
            int egyenleg966 = 0;
            int tartozik967 = 0;
            int kovetel967 = 0;
            int egyenleg967 = 0;
            int tartozik969 = 0;
            int kovetel969 = 0;
            int egyenleg969 = 0;
            int tartozik971 = 0;
            int kovetel971 = 0;
            int egyenleg971 = 0;

            int tartozik972 = 0;
            int kovetel972 = 0;
            int egyenleg972 = 0;
            int tartozik973 = 0;
            int kovetel973 = 0;
            int egyenleg973 = 0;
            int tartozik974 = 0;
            int kovetel974 = 0;
            int egyenleg974 = 0;
            int tartozik975 = 0;
            int kovetel975 = 0;
            int egyenleg975 = 0;
            int tartozik976 = 0;
            int kovetel976 = 0;
            int egyenleg976 = 0;
            int tartozik977 = 0;
            int kovetel977 = 0;
            int egyenleg977 = 0;
            int tartozik978 = 0;
            int kovetel978 = 0;
            int egyenleg978 = 0;
            int tartozik979 = 0;
            int kovetel979 = 0;
            int egyenleg979 = 0;
            int tartozik989 = 0;
            int kovetel989 = 0;
            int egyenleg989 = 0;

     
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 1191)
                {
                    tartozik119 = tartozik119 + mirror3[i].tartozik;
                    kovetel119 = kovetel119 + mirror3[i].kovetel;
                    egyenleg119 = egyenleg119 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 1192)
                {
                    tartozik119 = tartozik119 + mirror3[i].tartozik;
                    kovetel119 = kovetel119 + mirror3[i].kovetel;
                    egyenleg119 = egyenleg119 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 1193)
                {
                    tartozik119 = tartozik119 + mirror3[i].tartozik;
                    kovetel119 = kovetel119 + mirror3[i].kovetel;
                    egyenleg119 = egyenleg119 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 1194)
                {
                    tartozik119 = tartozik119 + mirror3[i].tartozik;
                    kovetel119 = kovetel119 + mirror3[i].kovetel;
                    egyenleg119 = egyenleg119 + mirror3[i].egyenleg;


                }



            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 1791)
                {
                    tartozik179 = tartozik179 + mirror3[i].tartozik;
                    kovetel179 = kovetel179 + mirror3[i].kovetel;
                    egyenleg179 = egyenleg179 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 1792)
                {
                    tartozik179 = tartozik179 + mirror3[i].tartozik;
                    kovetel179 = kovetel179 + mirror3[i].kovetel;
                    egyenleg179 = egyenleg179 + mirror3[i].egyenleg;

                }



            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 1931)
                {
                    tartozik193 = tartozik193 + mirror3[i].tartozik;
                    kovetel193 = kovetel193 + mirror3[i].kovetel;
                    egyenleg193 = egyenleg193 + mirror3[i].egyenleg;

                }






            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 1991)
                {
                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 1992)
                {
                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 1993)
                {
                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 1995)
                {

                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 1996)
                {
                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 1997)
                {

                    tartozik199 = tartozik199 + mirror3[i].tartozik;
                    kovetel199 = kovetel199 + mirror3[i].kovetel;
                    egyenleg199 = egyenleg199 + mirror3[i].egyenleg;

                }




            }



            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3591)
                {
                    tartozik359 = tartozik359 + mirror3[i].tartozik;
                    kovetel359 = kovetel359 + mirror3[i].kovetel;
                    egyenleg359 = egyenleg359 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3592)
                {
                    tartozik359 = tartozik359 + mirror3[i].tartozik;
                    kovetel359 = kovetel359 + mirror3[i].kovetel;
                    egyenleg359 = egyenleg359 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3593)
                {
                    tartozik359 = tartozik359 + mirror3[i].tartozik;
                    kovetel359 = kovetel359 + mirror3[i].kovetel;
                    egyenleg359 = egyenleg359 + mirror3[i].egyenleg;

                }






            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3611)
                {
                    tartozik361 = tartozik361 + mirror3[i].tartozik;
                    kovetel361 = kovetel361 + mirror3[i].kovetel;
                    egyenleg361 = egyenleg361 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3612)
                {
                    tartozik361 = tartozik361 + mirror3[i].tartozik;
                    kovetel361 = kovetel361 + mirror3[i].kovetel;
                    egyenleg361 = egyenleg361 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3613)
                {
                    tartozik361 = tartozik361 + mirror3[i].tartozik;
                    kovetel361 = kovetel361 + mirror3[i].kovetel;
                    egyenleg361 = egyenleg361 + mirror3[i].egyenleg;
                }






            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3621)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3622)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3623)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3624)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3625)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3626)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;
                }



                if (mirror3[i].szamlaSzam == 3627)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3628)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3629)
                {
                    tartozik362 = tartozik362 + mirror3[i].tartozik;
                    kovetel362 = kovetel362 + mirror3[i].kovetel;
                    egyenleg362 = egyenleg362 + mirror3[i].egyenleg;
                }




            }

            for (i = 0; i < mirror3.Count(); i++)
            {

                if (mirror3[i].szamlaSzam == 3631)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3632)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3633)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3634)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3635)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3636)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3637)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3638)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3639)
                {
                    tartozik363 = tartozik363 + mirror3[i].tartozik;
                    kovetel363 = kovetel363 + mirror3[i].kovetel;
                    egyenleg363 = egyenleg363 + mirror3[i].egyenleg;

                }



            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3641)
                {
                    tartozik364 = tartozik364 + mirror3[i].tartozik;
                    kovetel364 = kovetel364 + mirror3[i].kovetel;
                    egyenleg364 = egyenleg364 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3642)
                {
                    tartozik364 = tartozik364 + mirror3[i].tartozik;
                    kovetel364 = kovetel364 + mirror3[i].kovetel;
                    egyenleg364 = egyenleg364 + mirror3[i].egyenleg;

                }






            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3651)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3652)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3653)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 3654)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3655)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3658)
                {
                    tartozik365 = tartozik365 + mirror3[i].tartozik;
                    kovetel365 = kovetel365 + mirror3[i].kovetel;
                    egyenleg365 = egyenleg365 + mirror3[i].egyenleg;

                }






            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3711)
                {
                    tartozik371 = tartozik371 + mirror3[i].tartozik;
                    kovetel371 = kovetel371 + mirror3[i].kovetel;
                    egyenleg371 = egyenleg371 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3712)
                {
                    tartozik371 = tartozik371 + mirror3[i].tartozik;
                    kovetel371 = kovetel371 + mirror3[i].kovetel;
                    egyenleg371 = egyenleg371 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 3713)
                {

                    tartozik371 = tartozik371 + mirror3[i].tartozik;
                    kovetel371 = kovetel371 + mirror3[i].kovetel;
                    egyenleg371 = egyenleg371 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 3714)
                {
                    tartozik371 = tartozik371 + mirror3[i].tartozik;
                    kovetel371 = kovetel371 + mirror3[i].kovetel;
                    egyenleg371 = egyenleg371 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3719)
                {
                    tartozik371 = tartozik371 + mirror3[i].tartozik;
                    kovetel371 = kovetel371 + mirror3[i].kovetel;
                    egyenleg371 = egyenleg371 + mirror3[i].egyenleg;

                }







            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3721)
                {
                    tartozik372 = tartozik372 + mirror3[i].tartozik;
                    kovetel372 = kovetel372 + mirror3[i].kovetel;
                    egyenleg372 = egyenleg372 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3729)
                {
                    tartozik372 = tartozik372 + mirror3[i].tartozik;
                    kovetel372 = kovetel372 + mirror3[i].kovetel;
                    egyenleg372 = egyenleg372 + mirror3[i].egyenleg;
                }

            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3731)
                {
                    tartozik373 = tartozik373 + mirror3[i].tartozik;
                    kovetel373 = kovetel373 + mirror3[i].kovetel;
                    egyenleg373 = egyenleg373 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3739)
                {
                    tartozik373 = tartozik373 + mirror3[i].tartozik;
                    kovetel373 = kovetel373 + mirror3[i].kovetel;
                    egyenleg373 = egyenleg373 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3741)
                {
                    tartozik374 = tartozik374 + mirror3[i].tartozik;
                    kovetel374 = kovetel374 + mirror3[i].kovetel;
                    egyenleg374 = egyenleg374 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3742)
                {
                    tartozik374 = tartozik374 + mirror3[i].tartozik;
                    kovetel374 = kovetel374 + mirror3[i].kovetel;
                    egyenleg374 = egyenleg374 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3749)
                {
                    tartozik374 = tartozik374 + mirror3[i].tartozik;
                    kovetel374 = kovetel374 + mirror3[i].kovetel;
                    egyenleg374 = egyenleg374 + mirror3[i].egyenleg;

                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3811)
                {
                    tartozik381 = tartozik381 + mirror3[i].tartozik;
                    kovetel381 = kovetel381 + mirror3[i].kovetel;
                    egyenleg381 = egyenleg381 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3812)
                {
                    tartozik381 = tartozik381 + mirror3[i].tartozik;
                    kovetel381 = kovetel381 + mirror3[i].kovetel;
                    egyenleg381 = egyenleg381 + mirror3[i].egyenleg;
                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3821)
                {
                    tartozik382 = tartozik382 + mirror3[i].tartozik;
                    kovetel382 = kovetel382 + mirror3[i].kovetel;
                    egyenleg382 = egyenleg382 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3829)
                {
                    tartozik382 = tartozik382 + mirror3[i].tartozik;
                    kovetel382 = kovetel382 + mirror3[i].kovetel;
                    egyenleg382 = egyenleg382 + mirror3[i].egyenleg;
                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3851)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3852)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3853)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3854)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3855)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3856)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3857)
                {
                    tartozik385 = tartozik385 + mirror3[i].tartozik;
                    kovetel385 = kovetel385 + mirror3[i].kovetel;
                    egyenleg385 = egyenleg385 + mirror3[i].egyenleg;


                }




            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3861)
                {
                    tartozik386 = tartozik386 + mirror3[i].tartozik;
                    kovetel386 = kovetel386 + mirror3[i].kovetel;
                    egyenleg386 = egyenleg386 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3862)
                {

                    tartozik386 = tartozik386 + mirror3[i].tartozik;
                    kovetel386 = kovetel386 + mirror3[i].kovetel;
                    egyenleg386 = egyenleg386 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3863)
                {

                    tartozik386 = tartozik386 + mirror3[i].tartozik;
                    kovetel386 = kovetel386 + mirror3[i].kovetel;
                    egyenleg386 = egyenleg386 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3868)
                {
                    tartozik386 = tartozik386 + mirror3[i].tartozik;
                    kovetel386 = kovetel386 + mirror3[i].kovetel;
                    egyenleg386 = egyenleg386 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 3869)
                {
                    tartozik386 = tartozik386 + mirror3[i].tartozik;
                    kovetel386 = kovetel386 + mirror3[i].kovetel;
                    egyenleg386 = egyenleg386 + mirror3[i].egyenleg;



                }





            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3911)
                {
                    tartozik391 = tartozik391 + mirror3[i].tartozik;
                    kovetel391 = kovetel391 + mirror3[i].kovetel;
                    egyenleg391 = egyenleg391 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3912)
                {
                    tartozik391 = tartozik391 + mirror3[i].tartozik;
                    kovetel391 = kovetel391 + mirror3[i].kovetel;
                    egyenleg391 = egyenleg391 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 3913)
                {
                    tartozik391 = tartozik391 + mirror3[i].tartozik;
                    kovetel391 = kovetel391 + mirror3[i].kovetel;
                    egyenleg391 = egyenleg391 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3921)
                {
                    tartozik392 = tartozik392 + mirror3[i].tartozik;
                    kovetel392 = kovetel392 + mirror3[i].kovetel;
                    egyenleg392 = egyenleg392 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3922)
                {
                    tartozik392 = tartozik392 + mirror3[i].tartozik;
                    kovetel392 = kovetel392 + mirror3[i].kovetel;
                    egyenleg392 = egyenleg392 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 3923)
                {
                    tartozik392 = tartozik392 + mirror3[i].tartozik;
                    kovetel392 = kovetel392 + mirror3[i].kovetel;
                    egyenleg392 = egyenleg392 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3931)
                {
                    tartozik393 = tartozik393 + mirror3[i].tartozik;
                    kovetel393 = kovetel393 + mirror3[i].kovetel;
                    egyenleg393 = egyenleg393 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3932)
                {


                    tartozik393 = tartozik393 + mirror3[i].tartozik;
                    kovetel393 = kovetel393 + mirror3[i].kovetel;
                    egyenleg393 = egyenleg393 + mirror3[i].egyenleg;

                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 3991)
                {
                    tartozik399 = tartozik399 + mirror3[i].tartozik;
                    kovetel399 = kovetel399 + mirror3[i].kovetel;
                    egyenleg399 = egyenleg399 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3992)
                {

                    tartozik399 = tartozik399 + mirror3[i].tartozik;
                    kovetel399 = kovetel399 + mirror3[i].kovetel;
                    egyenleg399 = egyenleg399 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 3993)
                {

                    tartozik399 = tartozik399 + mirror3[i].tartozik;
                    kovetel399 = kovetel399 + mirror3[i].kovetel;
                    egyenleg399 = egyenleg399 + mirror3[i].egyenleg;

                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4141)
                {
                    tartozik414 = tartozik414 + mirror3[i].tartozik;
                    kovetel414 = kovetel414 + mirror3[i].kovetel;
                    egyenleg414 = egyenleg414 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4142)
                {
                    tartozik414 = tartozik414 + mirror3[i].tartozik;
                    kovetel414 = kovetel414 + mirror3[i].kovetel;
                    egyenleg414 = egyenleg414 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4143)
                {
                    tartozik414 = tartozik414 + mirror3[i].tartozik;
                    kovetel414 = kovetel414 + mirror3[i].kovetel;
                    egyenleg414 = egyenleg414 + mirror3[i].egyenleg;
                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4311)
                {
                    tartozik431 = tartozik431 + mirror3[i].tartozik;
                    kovetel431 = kovetel431 + mirror3[i].kovetel;
                    egyenleg431 = egyenleg431 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4312)
                {
                    tartozik431 = tartozik431 + mirror3[i].tartozik;
                    kovetel431 = kovetel431 + mirror3[i].kovetel;
                    egyenleg431 = egyenleg431 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4313)
                {
                    tartozik431 = tartozik431 + mirror3[i].tartozik;
                    kovetel431 = kovetel431 + mirror3[i].kovetel;
                    egyenleg431 = egyenleg431 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4314)
                {
                    tartozik431 = tartozik431 + mirror3[i].tartozik;
                    kovetel431 = kovetel431 + mirror3[i].kovetel;
                    egyenleg431 = egyenleg431 + mirror3[i].egyenleg;
                }



            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4431)
                {
                    tartozik443 = tartozik443 + mirror3[i].tartozik;
                    kovetel443 = kovetel443 + mirror3[i].kovetel;
                    egyenleg443 = egyenleg443 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4432)
                {
                    tartozik443 = tartozik443 + mirror3[i].tartozik;
                    kovetel443 = kovetel443 + mirror3[i].kovetel;
                    egyenleg443 = egyenleg443 + mirror3[i].egyenleg;

                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4441)
                {
                    tartozik444 = tartozik444 + mirror3[i].tartozik;
                    kovetel444 = kovetel444 + mirror3[i].kovetel;
                    egyenleg444 = egyenleg444 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4442)
                {
                    tartozik444 = tartozik444 + mirror3[i].tartozik;
                    kovetel444 = kovetel444 + mirror3[i].kovetel;
                    egyenleg444 = egyenleg444 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4451)
                {
                    tartozik445 = tartozik445 + mirror3[i].tartozik;
                    kovetel445 = kovetel445 + mirror3[i].kovetel;
                    egyenleg445 = egyenleg445 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4452)
                {

                    tartozik445 = tartozik445 + mirror3[i].tartozik;
                    kovetel445 = kovetel445 + mirror3[i].kovetel;
                    egyenleg445 = egyenleg445 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4461)
                {
                    tartozik446 = tartozik446 + mirror3[i].tartozik;
                    kovetel446 = kovetel446 + mirror3[i].kovetel;
                    egyenleg446 = egyenleg446 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4462)
                {
                    tartozik446 = tartozik446 + mirror3[i].tartozik;
                    kovetel446 = kovetel446 + mirror3[i].kovetel;
                    egyenleg446 = egyenleg446 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4463)
                {
                    tartozik446 = tartozik446 + mirror3[i].tartozik;
                    kovetel446 = kovetel446 + mirror3[i].kovetel;
                    egyenleg446 = egyenleg446 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4464)
                {
                    tartozik446 = tartozik446 + mirror3[i].tartozik;
                    kovetel446 = kovetel446 + mirror3[i].kovetel;
                    egyenleg446 = egyenleg446 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4491)
                {
                    tartozik449 = tartozik449 + mirror3[i].tartozik;
                    kovetel449 = kovetel449 + mirror3[i].kovetel;
                    egyenleg449 = egyenleg449 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4492)
                {
                    tartozik449 = tartozik449 + mirror3[i].tartozik;
                    kovetel449 = kovetel449 + mirror3[i].kovetel;
                    egyenleg449 = egyenleg449 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4499)
                {
                    tartozik449 = tartozik449 + mirror3[i].tartozik;
                    kovetel449 = kovetel449 + mirror3[i].kovetel;
                    egyenleg449 = egyenleg449 + mirror3[i].egyenleg;
                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4511)
                {
                    tartozik451 = tartozik451 + mirror3[i].tartozik;
                    kovetel451 = kovetel451 + mirror3[i].kovetel;
                    egyenleg451 = egyenleg451 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4512)
                {
                    tartozik451 = tartozik451 + mirror3[i].tartozik;
                    kovetel451 = kovetel451 + mirror3[i].kovetel;
                    egyenleg451 = egyenleg451 + mirror3[i].egyenleg;



                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4521)
                {
                    tartozik452 = tartozik452 + mirror3[i].tartozik;
                    kovetel452 = kovetel452 + mirror3[i].kovetel;
                    egyenleg452 = egyenleg452 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4522)
                {
                    tartozik452 = tartozik452 + mirror3[i].tartozik;
                    kovetel452 = kovetel452 + mirror3[i].kovetel;
                    egyenleg452 = egyenleg452 + mirror3[i].egyenleg;



                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4541)
                {
                    tartozik454 = tartozik454 + mirror3[i].tartozik;
                    kovetel454 = kovetel454 + mirror3[i].kovetel;
                    egyenleg454 = egyenleg454 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4542)
                {

                    tartozik454 = tartozik454 + mirror3[i].tartozik;
                    kovetel454 = kovetel454 + mirror3[i].kovetel;
                    egyenleg454 = egyenleg454 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4543)
                {
                    tartozik454 = tartozik454 + mirror3[i].tartozik;
                    kovetel454 = kovetel454 + mirror3[i].kovetel;
                    egyenleg454 = egyenleg454 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4544)
                {

                    tartozik454 = tartozik454 + mirror3[i].tartozik;
                    kovetel454 = kovetel454 + mirror3[i].kovetel;
                    egyenleg454 = egyenleg454 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4549)
                {

                    tartozik454 = tartozik454 + mirror3[i].tartozik;
                    kovetel454 = kovetel454 + mirror3[i].kovetel;
                    egyenleg454 = egyenleg454 + mirror3[i].egyenleg;


                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4551)
                {
                    tartozik455 = tartozik455 + mirror3[i].tartozik;
                    kovetel455 = kovetel455 + mirror3[i].kovetel;
                    egyenleg455 = egyenleg455 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4552)
                {
                    tartozik455 = tartozik455 + mirror3[i].tartozik;
                    kovetel455 = kovetel455 + mirror3[i].kovetel;
                    egyenleg455 = egyenleg455 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4559)
                {
                    tartozik455 = tartozik455 + mirror3[i].tartozik;
                    kovetel455 = kovetel455 + mirror3[i].kovetel;
                    egyenleg455 = egyenleg455 + mirror3[i].egyenleg;




                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4581)
                {
                    tartozik458 = tartozik458 + mirror3[i].tartozik;
                    kovetel458 = kovetel458 + mirror3[i].kovetel;
                    egyenleg458 = egyenleg458 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4582)
                {

                    tartozik458 = tartozik458 + mirror3[i].tartozik;
                    kovetel458 = kovetel458 + mirror3[i].kovetel;
                    egyenleg458 = egyenleg458 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4583)
                {


                    tartozik458 = tartozik458 + mirror3[i].tartozik;
                    kovetel458 = kovetel458 + mirror3[i].kovetel;
                    egyenleg458 = egyenleg458 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4584)
                {
                    tartozik458 = tartozik458 + mirror3[i].tartozik;
                    kovetel458 = kovetel458 + mirror3[i].kovetel;
                    egyenleg458 = egyenleg458 + mirror3[i].egyenleg;




                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 46310)
                {
                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 46311)
                {
                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4632)
                {

                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4633)
                {

                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4634)
                {
                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4635)
                {

                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4636)
                {

                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4637)
                {
                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4638)
                {


                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4639)
                {
                    tartozik463 = tartozik463 + mirror3[i].tartozik;
                    kovetel463 = kovetel463 + mirror3[i].kovetel;
                    egyenleg463 = egyenleg463 + mirror3[i].egyenleg;




                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 46410)
                {
                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 46411)
                {
                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4642)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4643)
                {


                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4644)
                {
                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4645)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4646)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4647)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4648)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;



                }
                if (mirror3[i].szamlaSzam == 4649)
                {

                    tartozik464 = tartozik464 + mirror3[i].tartozik;
                    kovetel464 = kovetel464 + mirror3[i].kovetel;
                    egyenleg464 = egyenleg464 + mirror3[i].egyenleg;



                }

            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4651)
                {
                    tartozik465 = tartozik465 + mirror3[i].tartozik;
                    kovetel465 = kovetel465 + mirror3[i].kovetel;
                    egyenleg465 = egyenleg465 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4652)
                {
                    tartozik465 = tartozik465 + mirror3[i].tartozik;
                    kovetel465 = kovetel465 + mirror3[i].kovetel;
                    egyenleg465 = egyenleg465 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4653)
                {


                    tartozik465 = tartozik465 + mirror3[i].tartozik;
                    kovetel465 = kovetel465 + mirror3[i].kovetel;
                    egyenleg465 = egyenleg465 + mirror3[i].egyenleg;


                }
            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4691)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4692)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4693)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4694)
                {

                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4695)
                {

                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4696)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4697)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4699)
                {
                    tartozik469 = tartozik469 + mirror3[i].tartozik;
                    kovetel469 = kovetel469 + mirror3[i].kovetel;
                    egyenleg469 = egyenleg469 + mirror3[i].egyenleg;


                }
            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4711)
                {
                    tartozik471 = tartozik471 + mirror3[i].tartozik;
                    kovetel471 = kovetel471 + mirror3[i].kovetel;
                    egyenleg471 = egyenleg471 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4712)
                {
                    tartozik471 = tartozik471 + mirror3[i].tartozik;
                    kovetel471 = kovetel471 + mirror3[i].kovetel;
                    egyenleg471 = egyenleg471 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4713)
                {

                    tartozik471 = tartozik471 + mirror3[i].tartozik;
                    kovetel471 = kovetel471 + mirror3[i].kovetel;
                    egyenleg471 = egyenleg471 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4742)
                {
                    tartozik474 = tartozik474 + mirror3[i].tartozik;
                    kovetel474 = kovetel474 + mirror3[i].kovetel;
                    egyenleg474 = egyenleg474 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4743)
                {
                    tartozik474 = tartozik474 + mirror3[i].tartozik;
                    kovetel474 = kovetel474 + mirror3[i].kovetel;
                    egyenleg474 = egyenleg474 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4743)
                {
                    tartozik474 = tartozik474 + mirror3[i].tartozik;
                    kovetel474 = kovetel474 + mirror3[i].kovetel;
                    egyenleg474 = egyenleg474 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4749)
                {

                    tartozik474 = tartozik474 + mirror3[i].tartozik;
                    kovetel474 = kovetel474 + mirror3[i].kovetel;
                    egyenleg474 = egyenleg474 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4791)
                {
                    tartozik479 = tartozik479 + mirror3[i].tartozik;
                    kovetel479 = kovetel479 + mirror3[i].kovetel;
                    egyenleg479 = egyenleg479 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4792)
                {

                    tartozik479 = tartozik479 + mirror3[i].tartozik;
                    kovetel479 = kovetel479 + mirror3[i].kovetel;
                    egyenleg479 = egyenleg479 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4793)
                {


                    tartozik479 = tartozik479 + mirror3[i].tartozik;
                    kovetel479 = kovetel479 + mirror3[i].kovetel;
                    egyenleg479 = egyenleg479 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4799)
                {

                    tartozik479 = tartozik479 + mirror3[i].tartozik;
                    kovetel479 = kovetel479 + mirror3[i].kovetel;
                    egyenleg479 = egyenleg479 + mirror3[i].egyenleg;



                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4811)
                {
                    tartozik481 = tartozik481 + mirror3[i].tartozik;
                    kovetel481 = kovetel481 + mirror3[i].kovetel;
                    egyenleg481 = egyenleg481 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4812)
                {

                    tartozik481 = tartozik481 + mirror3[i].tartozik;
                    kovetel481 = kovetel481 + mirror3[i].kovetel;
                    egyenleg481 = egyenleg481 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 4813)
                {

                    tartozik481 = tartozik481 + mirror3[i].tartozik;
                    kovetel481 = kovetel481 + mirror3[i].kovetel;
                    egyenleg481 = egyenleg481 + mirror3[i].egyenleg;

                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4821)
                {
                    tartozik482 = tartozik482 + mirror3[i].tartozik;
                    kovetel482 = kovetel482 + mirror3[i].kovetel;
                    egyenleg482 = egyenleg482 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4822)
                {
                    tartozik482 = tartozik482 + mirror3[i].tartozik;
                    kovetel482 = kovetel482 + mirror3[i].kovetel;
                    egyenleg482 = egyenleg482 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4823)
                {
                    tartozik482 = tartozik482 + mirror3[i].tartozik;
                    kovetel482 = kovetel482 + mirror3[i].kovetel;
                    egyenleg482 = egyenleg482 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 4831)
                {
                    tartozik483 = tartozik483 + mirror3[i].tartozik;
                    kovetel483 = kovetel483 + mirror3[i].kovetel;
                    egyenleg483 = egyenleg483 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4832)
                {
                    tartozik483 = tartozik483 + mirror3[i].tartozik;
                    kovetel483 = kovetel483 + mirror3[i].kovetel;
                    egyenleg483 = egyenleg483 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 4833)
                {
                    tartozik483 = tartozik483 + mirror3[i].tartozik;
                    kovetel483 = kovetel483 + mirror3[i].kovetel;
                    egyenleg483 = egyenleg483 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 4834)
                {

                    tartozik483 = tartozik483 + mirror3[i].tartozik;
                    kovetel483 = kovetel483 + mirror3[i].kovetel;
                    egyenleg483 = egyenleg483 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8631)
                {
                    tartozik863 = tartozik863 + mirror3[i].tartozik;
                    kovetel863 = kovetel863 + mirror3[i].kovetel;
                    egyenleg863 = egyenleg863 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8632)
                {
                    tartozik863 = tartozik863 + mirror3[i].tartozik;
                    kovetel863 = kovetel863 + mirror3[i].kovetel;
                    egyenleg863 = egyenleg863 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8633)
                {
                    tartozik863 = tartozik863 + mirror3[i].tartozik;
                    kovetel863 = kovetel863 + mirror3[i].kovetel;
                    egyenleg863 = egyenleg863 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 8634)
                {
                    tartozik863 = tartozik863 + mirror3[i].tartozik;
                    kovetel863 = kovetel863 + mirror3[i].kovetel;
                    egyenleg863 = egyenleg863 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 8635)
                {
                    tartozik863 = tartozik863 + mirror3[i].tartozik;
                    kovetel863 = kovetel863 + mirror3[i].kovetel;
                    egyenleg863 = egyenleg863 + mirror3[i].egyenleg;

                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8651)
                {
                    tartozik865 = tartozik865 + mirror3[i].tartozik;
                    kovetel865 = kovetel865 + mirror3[i].kovetel;
                    egyenleg865 = egyenleg865 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8652)
                {

                    tartozik865 = tartozik865 + mirror3[i].tartozik;
                    kovetel865 = kovetel865 + mirror3[i].kovetel;
                    egyenleg865 = egyenleg865 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8653)
                {
                    tartozik865 = tartozik865 + mirror3[i].tartozik;
                    kovetel865 = kovetel865 + mirror3[i].kovetel;
                    egyenleg865 = egyenleg865 + mirror3[i].egyenleg;

                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8661)
                {
                    tartozik866 = tartozik866 + mirror3[i].tartozik;
                    kovetel866 = kovetel866 + mirror3[i].kovetel;
                    egyenleg866 = egyenleg866 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8662)
                {
                    tartozik866 = tartozik866 + mirror3[i].tartozik;
                    kovetel866 = kovetel866 + mirror3[i].kovetel;
                    egyenleg866 = egyenleg866 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8663)
                {
                    tartozik866 = tartozik866 + mirror3[i].tartozik;
                    kovetel866 = kovetel866 + mirror3[i].kovetel;
                    egyenleg866 = egyenleg866 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8664)
                {

                    tartozik866 = tartozik866 + mirror3[i].tartozik;
                    kovetel866 = kovetel866 + mirror3[i].kovetel;
                    egyenleg866 = egyenleg866 + mirror3[i].egyenleg;
                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8671)
                {
                    tartozik867 = tartozik867 + mirror3[i].tartozik;
                    kovetel867 = kovetel867 + mirror3[i].kovetel;
                    egyenleg867 = egyenleg867 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8672)
                {
                    tartozik867 = tartozik867 + mirror3[i].tartozik;
                    kovetel867 = kovetel867 + mirror3[i].kovetel;
                    egyenleg867 = egyenleg867 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8673)
                {
                    tartozik867 = tartozik867 + mirror3[i].tartozik;
                    kovetel867 = kovetel867 + mirror3[i].kovetel;
                    egyenleg867 = egyenleg867 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8674)
                {
                    tartozik867 = tartozik867 + mirror3[i].tartozik;
                    kovetel867 = kovetel867 + mirror3[i].kovetel;
                    egyenleg867 = egyenleg867 + mirror3[i].egyenleg;

                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8691)
                {
                    tartozik869 = tartozik869 + mirror3[i].tartozik;
                    kovetel869 = kovetel869 + mirror3[i].kovetel;
                    egyenleg869 = egyenleg869 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8692)
                {
                    tartozik869 = tartozik869 + mirror3[i].tartozik;
                    kovetel869 = kovetel869 + mirror3[i].kovetel;
                    egyenleg869 = egyenleg869 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8693)
                {

                    tartozik869 = tartozik869 + mirror3[i].tartozik;
                    kovetel869 = kovetel869 + mirror3[i].kovetel;
                    egyenleg869 = egyenleg869 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8694)
                {
                    tartozik869 = tartozik869 + mirror3[i].tartozik;
                    kovetel869 = kovetel869 + mirror3[i].kovetel;
                    egyenleg869 = egyenleg869 + mirror3[i].egyenleg;

                }


            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8711)
                {
                    tartozik871 = tartozik871 + mirror3[i].tartozik;
                    kovetel871 = kovetel871 + mirror3[i].kovetel;
                    egyenleg871 = egyenleg871 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8712)
                {
                    tartozik871 = tartozik871 + mirror3[i].tartozik;
                    kovetel871 = kovetel871 + mirror3[i].kovetel;
                    egyenleg871 = egyenleg871 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8713)
                {
                    tartozik871 = tartozik871 + mirror3[i].tartozik;
                    kovetel871 = kovetel871 + mirror3[i].kovetel;
                    egyenleg871 = egyenleg871 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8714)
                {
                    tartozik871 = tartozik871 + mirror3[i].tartozik;
                    kovetel871 = kovetel871 + mirror3[i].kovetel;
                    egyenleg871 = egyenleg871 + mirror3[i].egyenleg;

                }


            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8721)
                {
                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8722)
                {

                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8723)
                {

                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8724)
                {

                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8725)
                {
                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8726)
                {
                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8727)
                {
                    tartozik872 = tartozik872 + mirror3[i].tartozik;
                    kovetel872 = kovetel872 + mirror3[i].kovetel;
                    egyenleg872 = egyenleg872 + mirror3[i].egyenleg;

                }




            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8731)
                {
                    tartozik873 = tartozik873 + mirror3[i].tartozik;
                    kovetel873 = kovetel873 + mirror3[i].kovetel;
                    egyenleg873 = egyenleg873 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8732)
                {
                    tartozik873 = tartozik873 + mirror3[i].tartozik;
                    kovetel873 = kovetel873 + mirror3[i].kovetel;
                    egyenleg873 = egyenleg873 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8733)
                {
                    tartozik873 = tartozik873 + mirror3[i].tartozik;
                    kovetel873 = kovetel873 + mirror3[i].kovetel;
                    egyenleg873 = egyenleg873 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8734)
                {
                    tartozik873 = tartozik873 + mirror3[i].tartozik;
                    kovetel873 = kovetel873 + mirror3[i].kovetel;
                    egyenleg873 = egyenleg873 + mirror3[i].egyenleg;

                }




            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8741)
                {
                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8742)
                {
                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8743)
                {
                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8746)
                {

                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8747)
                {

                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8748)
                {
                    tartozik874 = tartozik874 + mirror3[i].tartozik;
                    kovetel874 = kovetel874 + mirror3[i].kovetel;
                    egyenleg874 = egyenleg874 + mirror3[i].egyenleg;
                }




            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8751)
                {
                    tartozik875 = tartozik875 + mirror3[i].tartozik;
                    kovetel875 = kovetel875 + mirror3[i].kovetel;
                    egyenleg875 = egyenleg875 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8752)
                {
                    tartozik875 = tartozik875 + mirror3[i].tartozik;
                    kovetel875 = kovetel875 + mirror3[i].kovetel;
                    egyenleg875 = egyenleg875 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8753)
                {
                    tartozik875 = tartozik875 + mirror3[i].tartozik;
                    kovetel875 = kovetel875 + mirror3[i].kovetel;
                    egyenleg875 = egyenleg875 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8754)
                {
                    tartozik875 = tartozik875 + mirror3[i].tartozik;
                    kovetel875 = kovetel875 + mirror3[i].kovetel;
                    egyenleg875 = egyenleg875 + mirror3[i].egyenleg;
                }




            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8761)
                {
                    tartozik876 = tartozik876 + mirror3[i].tartozik;
                    kovetel876 = kovetel876 + mirror3[i].kovetel;
                    egyenleg876 = egyenleg876 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8762)
                {
                    tartozik876 = tartozik876 + mirror3[i].tartozik;
                    kovetel876 = kovetel876 + mirror3[i].kovetel;
                    egyenleg876 = egyenleg876 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8763)
                {

                    tartozik876 = tartozik876 + mirror3[i].tartozik;
                    kovetel876 = kovetel876 + mirror3[i].kovetel;
                    egyenleg876 = egyenleg876 + mirror3[i].egyenleg;
                }





            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8771)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8772)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8773)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8774)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8775)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 8776)
                {
                    tartozik877 = tartozik877 + mirror3[i].tartozik;
                    kovetel877 = kovetel877 + mirror3[i].kovetel;
                    egyenleg877 = egyenleg877 + mirror3[i].egyenleg;

                }





            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8781)
                {
                    tartozik878 = tartozik878 + mirror3[i].tartozik;
                    kovetel878 = kovetel878 + mirror3[i].kovetel;
                    egyenleg878 = egyenleg878 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8782)
                {
                    tartozik878 = tartozik878 + mirror3[i].tartozik;
                    kovetel878 = kovetel878 + mirror3[i].kovetel;
                    egyenleg878 = egyenleg878 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8783)
                {
                    tartozik878 = tartozik878 + mirror3[i].tartozik;
                    kovetel878 = kovetel878 + mirror3[i].kovetel;
                    egyenleg878 = egyenleg878 + mirror3[i].egyenleg;

                }





            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8791)
                {
                    tartozik879 = tartozik879 + mirror3[i].tartozik;
                    kovetel879 = kovetel879 + mirror3[i].kovetel;
                    egyenleg879 = egyenleg879 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8792)
                {
                    tartozik879 = tartozik879 + mirror3[i].tartozik;
                    kovetel879 = kovetel879 + mirror3[i].kovetel;
                    egyenleg879 = egyenleg879 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8793)
                {
                    tartozik879 = tartozik879 + mirror3[i].tartozik;
                    kovetel879 = kovetel879 + mirror3[i].kovetel;
                    egyenleg879 = egyenleg879 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 8794)
                {
                    tartozik879 = tartozik879 + mirror3[i].tartozik;
                    kovetel879 = kovetel879 + mirror3[i].kovetel;
                    egyenleg879 = egyenleg879 + mirror3[i].egyenleg;

                }



            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 8891)
                {
                    tartozik889 = tartozik889 + mirror3[i].tartozik;
                    kovetel889 = kovetel889 + mirror3[i].kovetel;
                    egyenleg889 = egyenleg889 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8892)
                {
                    tartozik889 = tartozik889 + mirror3[i].tartozik;
                    kovetel889 = kovetel889 + mirror3[i].kovetel;
                    egyenleg889 = egyenleg889 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 8893)
                {
                    tartozik889 = tartozik889 + mirror3[i].tartozik;
                    kovetel889 = kovetel889 + mirror3[i].kovetel;
                    egyenleg889 = egyenleg889 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 8894)
                {
                    tartozik889 = tartozik889 + mirror3[i].tartozik;
                    kovetel889 = kovetel889 + mirror3[i].kovetel;
                    egyenleg889 = egyenleg889 + mirror3[i].egyenleg;

                }

                if (mirror3[i].szamlaSzam == 8895)
                {

                    tartozik889 = tartozik889 + mirror3[i].tartozik;
                    kovetel889 = kovetel889 + mirror3[i].kovetel;
                    egyenleg889 = egyenleg889 + mirror3[i].egyenleg;
                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9631)
                {
                    tartozik963 = tartozik963 + mirror3[i].tartozik;
                    kovetel963 = kovetel963 + mirror3[i].kovetel;
                    egyenleg963 = egyenleg963 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9632)
                {
                    tartozik963 = tartozik963 + mirror3[i].tartozik;
                    kovetel963 = kovetel963 + mirror3[i].kovetel;
                    egyenleg963 = egyenleg963 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9633)
                {
                    tartozik963 = tartozik963 + mirror3[i].tartozik;
                    kovetel963 = kovetel963 + mirror3[i].kovetel;
                    egyenleg963 = egyenleg963 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 9634)
                {
                    tartozik963 = tartozik963 + mirror3[i].tartozik;
                    kovetel963 = kovetel963 + mirror3[i].kovetel;
                    egyenleg963 = egyenleg963 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 9635)
                {

                    tartozik963 = tartozik963 + mirror3[i].tartozik;
                    kovetel963 = kovetel963 + mirror3[i].kovetel;
                    egyenleg963 = egyenleg963 + mirror3[i].egyenleg;

                }


            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9651)
                {
                    tartozik965 = tartozik965 + mirror3[i].tartozik;
                    kovetel965 = kovetel965 + mirror3[i].kovetel;
                    egyenleg965 = egyenleg965 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9652)
                {
                    tartozik965 = tartozik965 + mirror3[i].tartozik;
                    kovetel965 = kovetel965 + mirror3[i].kovetel;
                    egyenleg965 = egyenleg965 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 9653)
                {
                    tartozik965 = tartozik965 + mirror3[i].tartozik;
                    kovetel965 = kovetel965 + mirror3[i].kovetel;
                    egyenleg965 = egyenleg965 + mirror3[i].egyenleg;


                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9661)
                {
                    tartozik966 = tartozik966 + mirror3[i].tartozik;
                    kovetel966 = kovetel966 + mirror3[i].kovetel;
                    egyenleg966 = egyenleg966 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9662)
                {
                    tartozik966 = tartozik966 + mirror3[i].tartozik;
                    kovetel966 = kovetel966 + mirror3[i].kovetel;
                    egyenleg966 = egyenleg966 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 9663)
                {

                    tartozik966 = tartozik966 + mirror3[i].tartozik;
                    kovetel966 = kovetel966 + mirror3[i].kovetel;
                    egyenleg966 = egyenleg966 + mirror3[i].egyenleg;


                }
                if (mirror3[i].szamlaSzam == 9664)
                {
                    tartozik966 = tartozik966 + mirror3[i].tartozik;
                    kovetel966 = kovetel966 + mirror3[i].kovetel;
                    egyenleg966 = egyenleg966 + mirror3[i].egyenleg;


                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9671)
                {
                    tartozik967 = tartozik967 + mirror3[i].tartozik;
                    kovetel967 = kovetel967 + mirror3[i].kovetel;
                    egyenleg967 = egyenleg967 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9672)
                {

                    tartozik967 = tartozik967 + mirror3[i].tartozik;
                    kovetel967 = kovetel967 + mirror3[i].kovetel;
                    egyenleg967 = egyenleg967 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9673)
                {
                    tartozik967 = tartozik967 + mirror3[i].tartozik;
                    kovetel967 = kovetel967 + mirror3[i].kovetel;
                    egyenleg967 = egyenleg967 + mirror3[i].egyenleg;


                }


            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9694)
                {
                    tartozik969 = tartozik969 + mirror3[i].tartozik;
                    kovetel969 = kovetel969 + mirror3[i].kovetel;
                    egyenleg969 = egyenleg969 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9695)
                {
                    tartozik969 = tartozik969 + mirror3[i].tartozik;
                    kovetel969 = kovetel969 + mirror3[i].kovetel;
                    egyenleg969 = egyenleg969 + mirror3[i].egyenleg;

                }
            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9711)
                {
                    tartozik971 = tartozik971 + mirror3[i].tartozik;
                    kovetel971 = kovetel971 + mirror3[i].kovetel;
                    egyenleg971 = egyenleg971 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9712)
                {
                    tartozik971 = tartozik971 + mirror3[i].tartozik;
                    kovetel971 = kovetel971 + mirror3[i].kovetel;
                    egyenleg971 = egyenleg971 + mirror3[i].egyenleg;

                }
            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9721)
                {
                    tartozik972 = tartozik972 + mirror3[i].tartozik;
                    kovetel972 = kovetel972 + mirror3[i].kovetel;
                    egyenleg972 = egyenleg972 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9722)
                {
                    tartozik972 = tartozik972 + mirror3[i].tartozik;
                    kovetel972 = kovetel972 + mirror3[i].kovetel;
                    egyenleg972 = egyenleg972 + mirror3[i].egyenleg;

                }
            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9731)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9732)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9733)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9734)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9735)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9736)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9737)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9738)
                {
                    tartozik973 = tartozik973 + mirror3[i].tartozik;
                    kovetel973 = kovetel973 + mirror3[i].kovetel;
                    egyenleg973 = egyenleg973 + mirror3[i].egyenleg;
                }
            }


            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9741)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9742)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9743)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 9744)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9745)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 9746)
                {
                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9747)
                {

                    tartozik974 = tartozik974 + mirror3[i].tartozik;
                    kovetel974 = kovetel974 + mirror3[i].kovetel;
                    egyenleg974 = egyenleg974 + mirror3[i].egyenleg;
                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9751)
                {
                    tartozik975 = tartozik975 + mirror3[i].tartozik;
                    kovetel975 = kovetel975 + mirror3[i].kovetel;
                    egyenleg975 = egyenleg975 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9752)
                {
                    tartozik975 = tartozik975 + mirror3[i].tartozik;
                    kovetel975 = kovetel975 + mirror3[i].kovetel;
                    egyenleg975 = egyenleg975 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9753)
                {
                    tartozik975 = tartozik975 + mirror3[i].tartozik;
                    kovetel975 = kovetel975 + mirror3[i].kovetel;
                    egyenleg975 = egyenleg975 + mirror3[i].egyenleg;
                }

                if (mirror3[i].szamlaSzam == 9754)
                {
                    tartozik975 = tartozik975 + mirror3[i].tartozik;
                    kovetel975 = kovetel975 + mirror3[i].kovetel;
                    egyenleg975 = egyenleg975 + mirror3[i].egyenleg;
                }


            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9761)
                {
                    tartozik976 = tartozik976 + mirror3[i].tartozik;
                    kovetel976 = kovetel976 + mirror3[i].kovetel;
                    egyenleg976 = egyenleg976 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9762)
                {
                    tartozik976 = tartozik976 + mirror3[i].tartozik;
                    kovetel976 = kovetel976 + mirror3[i].kovetel;
                    egyenleg976 = egyenleg976 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9763)
                {
                    tartozik976 = tartozik976 + mirror3[i].tartozik;
                    kovetel976 = kovetel976 + mirror3[i].kovetel;
                    egyenleg976 = egyenleg976 + mirror3[i].egyenleg;
                }



            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9771)
                {
                    tartozik977 = tartozik977 + mirror3[i].tartozik;
                    kovetel977 = kovetel977 + mirror3[i].kovetel;
                    egyenleg977 = egyenleg977 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9772)
                {
                    tartozik977 = tartozik977 + mirror3[i].tartozik;
                    kovetel977 = kovetel977 + mirror3[i].kovetel;
                    egyenleg977 = egyenleg977 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9773)
                {
                    tartozik977 = tartozik977 + mirror3[i].tartozik;
                    kovetel977 = kovetel977 + mirror3[i].kovetel;
                    egyenleg977 = egyenleg977 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9774)
                {
                    tartozik977 = tartozik977 + mirror3[i].tartozik;
                    kovetel977 = kovetel977 + mirror3[i].kovetel;
                    egyenleg977 = egyenleg977 + mirror3[i].egyenleg;
                }


            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9781)
                {
                    tartozik978 = tartozik978 + mirror3[i].tartozik;
                    kovetel978 = kovetel978 + mirror3[i].kovetel;
                    egyenleg978 = egyenleg978 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9782)
                {
                    tartozik978 = tartozik978 + mirror3[i].tartozik;
                    kovetel978 = kovetel978 + mirror3[i].kovetel;
                    egyenleg978 = egyenleg978 + mirror3[i].egyenleg;

                }

            }
            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9791)
                {
                    tartozik979 = tartozik979 + mirror3[i].tartozik;
                    kovetel979 = kovetel979 + mirror3[i].kovetel;
                    egyenleg979 = egyenleg979 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9792)
                {

                    tartozik979 = tartozik979 + mirror3[i].tartozik;
                    kovetel979 = kovetel979 + mirror3[i].kovetel;
                    egyenleg979 = egyenleg979 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9793)
                {
                    tartozik979 = tartozik979 + mirror3[i].tartozik;
                    kovetel979 = kovetel979 + mirror3[i].kovetel;
                    egyenleg979 = egyenleg979 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9794)
                {
                    tartozik979 = tartozik979 + mirror3[i].tartozik;
                    kovetel979 = kovetel979 + mirror3[i].kovetel;
                    egyenleg979 = egyenleg979 + mirror3[i].egyenleg;

                }

            }

            for (i = 0; i < mirror3.Count(); i++)
            {
                if (mirror3[i].szamlaSzam == 9891)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9892)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9893)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9894)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;
                }
                if (mirror3[i].szamlaSzam == 9895)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;

                }
                if (mirror3[i].szamlaSzam == 9896)
                {
                    tartozik989 = tartozik989 + mirror3[i].tartozik;
                    kovetel989 = kovetel989 + mirror3[i].kovetel;
                    egyenleg989 = egyenleg989 + mirror3[i].egyenleg;
                }

            }



            mirror3[9].tartozik = mirror3[9].tartozik + tartozik119;
            mirror3[9].kovetel = mirror3[9].kovetel + kovetel119;
            mirror3[9].egyenleg = mirror3[9].egyenleg + egyenleg119;

            mirror3[54].tartozik = mirror3[54].tartozik + tartozik179;
            mirror3[54].kovetel = mirror3[54].kovetel + kovetel179;
            mirror3[54].egyenleg = mirror3[54].egyenleg + egyenleg179;

            mirror3[66].tartozik = mirror3[66].tartozik + tartozik193;
            mirror3[66].kovetel = mirror3[66].kovetel + kovetel193;
            mirror3[66].egyenleg = mirror3[66].egyenleg + egyenleg193;

            mirror3[72].tartozik = mirror3[72].tartozik + tartozik199;
            mirror3[72].kovetel = mirror3[72].kovetel + kovetel199;
            mirror3[72].egyenleg = mirror3[72].egyenleg + egyenleg199;

            mirror3[156].tartozik = mirror3[156].tartozik + tartozik359;
            mirror3[156].kovetel = mirror3[156].kovetel + kovetel359;
            mirror3[156].egyenleg = mirror3[156].egyenleg + egyenleg359;

            mirror3[161].tartozik = mirror3[161].tartozik + tartozik361;
            mirror3[161].kovetel = mirror3[161].kovetel + kovetel361;
            mirror3[161].egyenleg = mirror3[161].egyenleg + egyenleg361;

            mirror3[165].tartozik = mirror3[165].tartozik + tartozik362;
            mirror3[165].kovetel = mirror3[165].kovetel + kovetel362;
            mirror3[165].egyenleg = mirror3[165].egyenleg + egyenleg362;

            mirror3[175].tartozik = mirror3[175].tartozik + tartozik363;
            mirror3[175].kovetel = mirror3[175].kovetel + kovetel363;
            mirror3[175].egyenleg = mirror3[175].egyenleg + egyenleg363;

            mirror3[185].tartozik = mirror3[185].tartozik + tartozik361;
            mirror3[185].kovetel = mirror3[185].kovetel + kovetel361;
            mirror3[185].egyenleg = mirror3[185].egyenleg + egyenleg361;

            mirror3[188].tartozik = mirror3[188].tartozik + tartozik365;
            mirror3[188].kovetel = mirror3[188].kovetel + kovetel365;
            mirror3[188].egyenleg = mirror3[188].egyenleg + egyenleg365;

            mirror3[200].tartozik = mirror3[200].tartozik + tartozik371;
            mirror3[200].kovetel = mirror3[200].kovetel + kovetel371;
            mirror3[200].egyenleg = mirror3[200].egyenleg + egyenleg371;


            mirror3[206].tartozik = mirror3[206].tartozik + tartozik372;
            mirror3[206].kovetel = mirror3[206].kovetel + kovetel372;
            mirror3[206].egyenleg = mirror3[206].egyenleg + egyenleg372;

            mirror3[209].tartozik = mirror3[206].tartozik + tartozik373;
            mirror3[209].kovetel = mirror3[206].kovetel + kovetel373;
            mirror3[209].egyenleg = mirror3[206].egyenleg + egyenleg373;

            mirror3[212].tartozik = mirror3[206].tartozik + tartozik374;
            mirror3[212].kovetel = mirror3[206].kovetel + kovetel374;
            mirror3[212].egyenleg = mirror3[206].egyenleg + egyenleg374;

            mirror3[217].tartozik = mirror3[217].tartozik + tartozik381;
            mirror3[217].kovetel = mirror3[217].kovetel + kovetel381;
            mirror3[217].egyenleg = mirror3[217].egyenleg + egyenleg381;

            mirror3[220].tartozik = mirror3[220].tartozik + tartozik382;
            mirror3[220].kovetel = mirror3[220].kovetel + kovetel382;
            mirror3[220].egyenleg = mirror3[220].egyenleg + egyenleg382;

            mirror3[225].tartozik = mirror3[225].tartozik + tartozik385;
            mirror3[225].kovetel = mirror3[225].kovetel + kovetel385;
            mirror3[225].egyenleg = mirror3[225].egyenleg + egyenleg385;

            mirror3[233].tartozik = mirror3[233].tartozik + tartozik386;
            mirror3[233].kovetel = mirror3[233].kovetel + kovetel386;
            mirror3[233].egyenleg = mirror3[233].egyenleg + egyenleg386;

            mirror3[241].tartozik = mirror3[241].tartozik + tartozik391;
            mirror3[241].kovetel = mirror3[241].kovetel + kovetel391;
            mirror3[241].egyenleg = mirror3[241].egyenleg + egyenleg391;


            mirror3[245].tartozik = mirror3[245].tartozik + tartozik392;
            mirror3[245].kovetel = mirror3[245].kovetel + kovetel392;
            mirror3[245].egyenleg = mirror3[245].egyenleg + egyenleg392;


            mirror3[249].tartozik = mirror3[249].tartozik + tartozik393;
            mirror3[249].kovetel = mirror3[249].kovetel + kovetel393;
            mirror3[249].egyenleg = mirror3[249].egyenleg + egyenleg393;

            mirror3[252].tartozik = mirror3[252].tartozik + tartozik399;
            mirror3[252].kovetel = mirror3[252].kovetel + kovetel399;
            mirror3[252].egyenleg = mirror3[252].egyenleg + egyenleg399;

            mirror3[261].tartozik = mirror3[261].tartozik + tartozik414;
            mirror3[261].kovetel = mirror3[261].kovetel + kovetel414;
            mirror3[261].egyenleg = mirror3[261].egyenleg + egyenleg414;

            mirror3[273].tartozik = mirror3[273].tartozik + tartozik431;
            mirror3[273].kovetel = mirror3[273].kovetel + kovetel431;
            mirror3[273].egyenleg = mirror3[273].egyenleg + egyenleg431;

            mirror3[283].tartozik = mirror3[283].tartozik + tartozik443;
            mirror3[283].kovetel = mirror3[283].kovetel + kovetel443;
            mirror3[283].egyenleg = mirror3[283].egyenleg + egyenleg443;

            mirror3[286].tartozik = mirror3[286].tartozik + tartozik444;
            mirror3[286].kovetel = mirror3[286].kovetel + kovetel444;
            mirror3[286].egyenleg = mirror3[286].egyenleg + egyenleg444;


            mirror3[289].tartozik = mirror3[289].tartozik + tartozik445;
            mirror3[289].kovetel = mirror3[289].kovetel + kovetel445;
            mirror3[289].egyenleg = mirror3[289].egyenleg + egyenleg445;


            mirror3[292].tartozik = mirror3[292].tartozik + tartozik446;
            mirror3[292].kovetel = mirror3[292].kovetel + kovetel446;
            mirror3[292].egyenleg = mirror3[292].egyenleg + egyenleg446;

            mirror3[299].tartozik = mirror3[299].tartozik + tartozik449;
            mirror3[299].kovetel = mirror3[299].kovetel + kovetel449;
            mirror3[299].egyenleg = mirror3[299].egyenleg + egyenleg449;

            mirror3[304].tartozik = mirror3[304].tartozik + tartozik451;
            mirror3[304].kovetel = mirror3[304].kovetel + kovetel451;
            mirror3[304].egyenleg = mirror3[304].egyenleg + egyenleg451;

            mirror3[307].tartozik = mirror3[307].tartozik + tartozik452;
            mirror3[307].kovetel = mirror3[307].kovetel + kovetel452;
            mirror3[307].egyenleg = mirror3[307].egyenleg + egyenleg452;


            mirror3[311].tartozik = mirror3[311].tartozik + tartozik454;
            mirror3[311].kovetel = mirror3[311].kovetel + kovetel454;
            mirror3[311].egyenleg = mirror3[311].egyenleg + egyenleg454;

            mirror3[317].tartozik = mirror3[317].tartozik + tartozik455;
            mirror3[317].kovetel = mirror3[317].kovetel + kovetel455;
            mirror3[317].egyenleg = mirror3[317].egyenleg + egyenleg455;

            mirror3[323].tartozik = mirror3[323].tartozik + tartozik458;
            mirror3[323].kovetel = mirror3[323].kovetel + kovetel458;
            mirror3[323].egyenleg = mirror3[323].egyenleg + egyenleg458;


            mirror3[331].tartozik = mirror3[331].tartozik + tartozik463;
            mirror3[331].kovetel = mirror3[331].kovetel + kovetel463;
            mirror3[331].egyenleg = mirror3[331].egyenleg + egyenleg463;

            mirror3[342].tartozik = mirror3[342].tartozik + tartozik464;
            mirror3[342].kovetel = mirror3[342].kovetel + kovetel464;
            mirror3[342].egyenleg = mirror3[342].egyenleg + egyenleg464;

            mirror3[355].tartozik = mirror3[353].tartozik + tartozik465;
            mirror3[353].kovetel = mirror3[353].kovetel + kovetel465;
            mirror3[353].egyenleg = mirror3[353].egyenleg + egyenleg465;

            mirror3[360].tartozik = mirror3[360].tartozik + tartozik469;
            mirror3[360].kovetel = mirror3[360].kovetel + kovetel469;
            mirror3[360].egyenleg = mirror3[360].egyenleg + egyenleg469;

            mirror3[369].tartozik = mirror3[369].tartozik + tartozik471;
            mirror3[369].kovetel = mirror3[369].kovetel + kovetel471;
            mirror3[369].egyenleg = mirror3[369].egyenleg + egyenleg471;

            mirror3[375].tartozik = mirror3[375].tartozik + tartozik474;
            mirror3[375].kovetel = mirror3[375].kovetel + kovetel474;
            mirror3[375].egyenleg = mirror3[375].egyenleg + egyenleg474;

            mirror3[384].tartozik = mirror3[384].tartozik + tartozik479;
            mirror3[384].kovetel = mirror3[384].kovetel + kovetel479;
            mirror3[384].egyenleg = mirror3[384].egyenleg + egyenleg479;

            mirror3[390].tartozik = mirror3[390].tartozik + tartozik481;
            mirror3[390].kovetel = mirror3[390].kovetel + kovetel481;
            mirror3[390].egyenleg = mirror3[390].egyenleg + egyenleg481;

            mirror3[394].tartozik = mirror3[394].tartozik + tartozik482;
            mirror3[394].kovetel = mirror3[394].kovetel + kovetel482;
            mirror3[394].egyenleg = mirror3[394].egyenleg + egyenleg482;

            mirror3[398].tartozik = mirror3[398].tartozik + tartozik483;
            mirror3[398].kovetel = mirror3[398].kovetel + kovetel483;
            mirror3[398].egyenleg = mirror3[398].egyenleg + egyenleg483;

            mirror3[496].tartozik = mirror3[496].tartozik + tartozik863;
            mirror3[496].kovetel = mirror3[496].kovetel + kovetel863;
            mirror3[496].egyenleg = mirror3[496].egyenleg + egyenleg863;


            mirror3[503].tartozik = mirror3[503].tartozik + tartozik865;
            mirror3[503].kovetel = mirror3[503].kovetel + kovetel865;
            mirror3[503].egyenleg = mirror3[505].egyenleg + egyenleg865;

            mirror3[507].tartozik = mirror3[507].tartozik + tartozik866;
            mirror3[507].kovetel = mirror3[507].kovetel + kovetel866;
            mirror3[507].egyenleg = mirror3[507].egyenleg + egyenleg866;

            mirror3[512].tartozik = mirror3[512].tartozik + tartozik867;
            mirror3[512].kovetel = mirror3[512].kovetel + kovetel867;
            mirror3[512].egyenleg = mirror3[512].egyenleg + egyenleg867;


            mirror3[517].tartozik = mirror3[517].tartozik + tartozik869;
            mirror3[517].kovetel = mirror3[517].kovetel + kovetel869;
            mirror3[517].egyenleg = mirror3[517].egyenleg + egyenleg869;

            mirror3[523].tartozik = mirror3[523].tartozik + tartozik871;
            mirror3[523].kovetel = mirror3[523].kovetel + kovetel871;
            mirror3[523].egyenleg = mirror3[523].egyenleg + egyenleg871;

            mirror3[528].tartozik = mirror3[528].tartozik + tartozik872;
            mirror3[528].kovetel = mirror3[528].kovetel + kovetel872;
            mirror3[528].egyenleg = mirror3[528].egyenleg + egyenleg872;

            mirror3[536].tartozik = mirror3[536].tartozik + tartozik873;
            mirror3[536].kovetel = mirror3[536].kovetel + kovetel873;
            mirror3[536].egyenleg = mirror3[536].egyenleg + egyenleg873;

            mirror3[541].tartozik = mirror3[541].tartozik + tartozik874;
            mirror3[541].kovetel = mirror3[541].kovetel + kovetel874;
            mirror3[541].egyenleg = mirror3[541].egyenleg + egyenleg874;

            mirror3[548].tartozik = mirror3[548].tartozik + tartozik875;
            mirror3[548].kovetel = mirror3[548].kovetel + kovetel875;
            mirror3[548].egyenleg = mirror3[548].egyenleg + egyenleg875;

            mirror3[553].tartozik = mirror3[553].tartozik + tartozik876;
            mirror3[553].kovetel = mirror3[553].kovetel + kovetel876;
            mirror3[553].egyenleg = mirror3[553].egyenleg + egyenleg876;

            mirror3[557].tartozik = mirror3[557].tartozik + tartozik877;
            mirror3[557].kovetel = mirror3[557].kovetel + kovetel877;
            mirror3[557].egyenleg = mirror3[557].egyenleg + egyenleg877;

            mirror3[564].tartozik = mirror3[564].tartozik + tartozik878;
            mirror3[564].kovetel = mirror3[564].kovetel + kovetel878;
            mirror3[564].egyenleg = mirror3[564].egyenleg + egyenleg878;

            mirror3[568].tartozik = mirror3[568].tartozik + tartozik879;
            mirror3[568].kovetel = mirror3[568].kovetel + kovetel879;
            mirror3[568].egyenleg = mirror3[568].egyenleg + egyenleg879;

            mirror3[582].tartozik = mirror3[582].tartozik + tartozik889;
            mirror3[582].kovetel = mirror3[582].kovetel + kovetel889;
            mirror3[582].egyenleg = mirror3[582].egyenleg + egyenleg889;


            mirror3[597].tartozik = mirror3[597].tartozik + tartozik963;
            mirror3[597].kovetel = mirror3[597].kovetel + kovetel963;
            mirror3[597].egyenleg = mirror3[597].egyenleg + egyenleg963;


            mirror3[604].tartozik = mirror3[604].tartozik + tartozik965;
            mirror3[604].kovetel = mirror3[604].kovetel + kovetel965;
            mirror3[604].egyenleg = mirror3[604].egyenleg + egyenleg965;

            mirror3[608].tartozik = mirror3[608].tartozik + tartozik966;
            mirror3[608].kovetel = mirror3[608].kovetel + kovetel966;
            mirror3[608].egyenleg = mirror3[608].egyenleg + egyenleg966;

            mirror3[613].tartozik = mirror3[613].tartozik + tartozik967;
            mirror3[613].kovetel = mirror3[613].kovetel + kovetel967;
            mirror3[613].egyenleg = mirror3[613].egyenleg + egyenleg967;

            mirror3[617].tartozik = mirror3[617].tartozik + tartozik969;
            mirror3[617].kovetel = mirror3[617].kovetel + kovetel969;
            mirror3[617].egyenleg = mirror3[617].egyenleg + egyenleg969;


            mirror3[622].tartozik = mirror3[622].tartozik + tartozik971;
            mirror3[622].kovetel = mirror3[622].kovetel + kovetel971;
            mirror3[622].egyenleg = mirror3[622].egyenleg + egyenleg971;

            mirror3[625].tartozik = mirror3[625].tartozik + tartozik972;
            mirror3[625].kovetel = mirror3[625].kovetel + kovetel972;
            mirror3[625].egyenleg = mirror3[625].egyenleg + egyenleg972;

            mirror3[628].tartozik = mirror3[628].tartozik + tartozik973;
            mirror3[628].kovetel = mirror3[628].kovetel + kovetel973;
            mirror3[628].egyenleg = mirror3[628].egyenleg + egyenleg973;

            mirror3[637].tartozik = mirror3[637].tartozik + tartozik974;
            mirror3[637].kovetel = mirror3[637].kovetel + kovetel974;
            mirror3[637].egyenleg = mirror3[637].egyenleg + egyenleg974;

            mirror3[645].tartozik = mirror3[645].tartozik + tartozik975;
            mirror3[645].kovetel = mirror3[645].kovetel + kovetel975;
            mirror3[645].egyenleg = mirror3[645].egyenleg + egyenleg975;

            mirror3[650].tartozik = mirror3[650].tartozik + tartozik976;
            mirror3[650].kovetel = mirror3[650].kovetel + kovetel976;
            mirror3[650].egyenleg = mirror3[650].egyenleg + egyenleg976;

            mirror3[654].tartozik = mirror3[654].tartozik + tartozik977;
            mirror3[654].kovetel = mirror3[654].kovetel + kovetel977;
            mirror3[654].egyenleg = mirror3[654].egyenleg + egyenleg977;

            mirror3[659].tartozik = mirror3[659].tartozik + tartozik978;
            mirror3[659].kovetel = mirror3[659].kovetel + kovetel978;
            mirror3[659].egyenleg = mirror3[659].egyenleg + egyenleg978;

            mirror3[662].tartozik = mirror3[662].tartozik + tartozik979;
            mirror3[662].kovetel = mirror3[662].kovetel + kovetel979;
            mirror3[662].egyenleg = mirror3[662].egyenleg + egyenleg979;

            mirror3[675].tartozik = mirror3[675].tartozik + tartozik989;
            mirror3[675].kovetel = mirror3[675].kovetel + kovetel989;
            mirror3[675].egyenleg = mirror3[675].egyenleg + egyenleg989;


        }





      
        public void egyenlegjavit()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "select *from fokonyv2;";
            connect.Open();
            MySqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                mirror4.Add(new SzamlaSzamok
                {

                    szamlaSzam = int.Parse(reader["fokonyviSzam"].ToString()),
                    szamlaNev = reader["nev"].ToString(),
                    tartozik = int.Parse(reader["tartozik"].ToString()),
                    kovetel = int.Parse(reader["kovetel"].ToString()),
                    egyenleg = int.Parse(reader["egyenleg"].ToString()),



                });
            }
            connect.Close();




            for (int f = 0; f < mirror4.Count(); f++)
            {
                if (mirror4[f].tartozik > mirror4[f].kovetel)
                {
                    mirror4[f].egyenleg = mirror4[f].tartozik - mirror4[f].kovetel;
                }

                if (mirror4[f].kovetel > mirror4[f].tartozik)
                {
                    mirror4[f].egyenleg = mirror4[f].kovetel - mirror4[f].tartozik;
                }
                if (mirror4[f].tartozik == mirror4[f].kovetel)
                {
                    mirror4[f].egyenleg = 0;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

      
        private void fokonyvLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void nyomtatas_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(fokonyvLista, "Nyomtatás Folyamatban van");

            }

           
        }
        public void fokonyv2Torles()
        {
            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            connect.Open();
            cm.CommandText = "delete from fokonyv2;";
            cm.ExecuteNonQuery();
            connect.Close();
        }


       
        public void addfokonyv(int a, int b,int c,int e)
        {


            string conn = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            connect.Open();
            cm.CommandText = "update fokonyv set tforgalom='" + a + "',kforgalom='" + b + "',egyenleg='" + c + "' where fokonyviSzam='" + e + "';";
            cm.ExecuteNonQuery();
            connect.Close();
        }

        public void feltolt(string x)
        {
            Console.WriteLine("Belépett a felötlséebe");
            List<SzamlaTukor2> szamla = new List<SzamlaTukor2>();
            int i = 0;
            string connString = "SERVER=localhost;DATABASE=" + x + ";UID="+adatf+";PASSWORD="+adatj+";Ssl Mode=none";
            MySqlConnection connect = new MySqlConnection(connString);


            MySqlCommand szamlatukorLevolvas = connect.CreateCommand();
            szamlatukorLevolvas.CommandText = "select *from szamlatukor;";
            MySqlCommand beillsztFokony = connect.CreateCommand();
            connect.Open();
            MySqlDataReader reader = szamlatukorLevolvas.ExecuteReader();

            while (reader.Read())
            {
                i++;
                szamla.Add(new SzamlaTukor2
                {
                    id = i,
                    szamlaSzam = int.Parse(reader["szamlaId"].ToString()),
                    szamlaNev = reader["szamlaTipus"].ToString(),
                    tartozik = 0,
                    kovetel = 0,
                    egyenleg = 0,

                });
               
            }
            connect.Close();
           
    
            
        }

       

    }

    
}
