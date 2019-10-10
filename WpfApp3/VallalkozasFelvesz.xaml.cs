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
using System.Timers;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>


    public partial class VallalkozasFelvesz : Window
    {

        List<int> lista = new List<int>();
        string adatf;
        string adatj;
        string felhasznalo;
        public VallalkozasFelvesz(string felh,string y, string z)
        {
            InitializeComponent();
            adatf = y;
            adatj = z;
            felhasznalo = felh;
        }



        private void kepNev_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void forma_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ujbazis_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                lista.Add(i);
            }

            if (elleorizAdatok() == true)
            {


                MessageBox.Show("Kérem várjon az adatok felvétele épp zajlik");

                string cs = "server=localhost;userid=" + adatf + ";password=" + adatj + ";SslMode=none";
                string tablaCreate = " Create Table vallalkozasAdatok(vid int(2) ,vnev varchar(45),vcim varchar(45),vtel varchar(45),vbanksz varchar(26),vado varchar(15),vemail varchar(45),kepvName varchar(45),kepvTel varchar(45));";
                string name = nev.Text;
                string place = cm.Text;
                string tel = telszam.Text;
                string mail = email.Text;
                string bank = bankszamla.Text;
                string ado = adoszam.Text;
                string kepvn = kepviseloneve.Text;
                string kepvt = kepviselotelszam.Text;
                string nevb = "'" + name + " ';";
                string s0 = "CREATE DATABASE IF NOT EXISTS" + " " + name;
                string cs10 = "server=localhost;database=" + name + ";userid=" + adatf + ";password=" + adatj + ";SslMode=none";

                string csmix = "database=" + name + ";";
                string cs1 = "server=localhost;" + csmix + "userid=" + adatf + ";password=" + adatj + ";SslMode=none";
                string x = "server=localhost;database=konyvelok;userid=" + adatf + ";password=" + adatj + ";SslMode=none";




                adatbazisLetrehozas(cs, s0, cs10, tablaCreate);
                beillesztVallalkozasok(x, felhasznaloLekerdezes(x), name, kepvn, kepvt);
                beillesztVallalkozasAdatok(cs1, 1, name, place, tel, bank, ado, mail, kepvn, kepvt);
                createSzamlatukor(cs1);
                createPartner(cs1);
                SzamlaTukor sz1 = new SzamlaTukor(name, adatf, adatj);
                createTetelek(cs1);
                beillesztEsemenyek(cs1);
                createDolgozok(cs1);
                createMunkaszam(cs1);
                createHonapok(cs1);
                createBernyilvantartas(cs1);
                createFokonyv(cs1);

                createMerleg(cs1);

                createPenztarnaplo(cs1);
                createVegyesnaplo(cs1);
                createVevoSzallitonaplo(cs1);
                createBanknaplo(cs1);

                beillesbankNaploOsszegzes(cs1);
                beillesPenztarNaploOsszegzes(cs1);
                beillesVegyesNaploOsszegzes(cs1);
                beillesVevoszallitoNaploOsszegzes(cs1);
                beillesztSzamlatukor2(cs1);
                beillesztFokonyv2(cs1);
                insertHonapokEsMunkaSzam(cs1);
                insertFokonyvRow(cs1);

                MessageBox.Show("A vállalkozást sikeresen felvettük!!!");
                Window w3 = new ListazCegek(felhasznalo,adatf,adatj);
                w3.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Rosszul töltötte ki a mezőket!!");


            }

        }

        public void beillesztVallalkozasok(string kapcs, int b, string c, string d, string e)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
            int inov = b;
            string name = c;

            string kepvn = d;
            string kepvt = e;


            string s = "INSERT INTO vallalkozasok(vallalkozasId,vallalkozasNev,vallalkozasiForma,kepviseloNeve,kepviseloTelszam)VALUES('" + inov + "','" + name + "','" + name + "','" + kepvn + "','" + kepvt + "');";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();


        }

        public void beillesztVallalkozasAdatok(string kapcs, int y, string a, string b, string c, string d, string e, string f, string g, string h)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
            int szam = y;
            string name = a;
            string place = b;
            string tel = c;
            string bank = d;
            string ado = e;
            string mail = f;
            string kepvn = g;
            string kepvt = h;

            string s = "INSERT INTO vallalkozasAdatok(vid ,vnev ,vcim ,vtel,vbanksz,vado,vemail,kepvName,kepvTel)VALUES('" + szam + "','" + name + "','" + place + "','" + tel + "','" + bank + "','" + ado + "','" + mail + "','" + kepvn + "','" + kepvt + "')";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }

      
        public void createPartner(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `partnerek` (`partnerId` int(3) NOT NULL,`partnerNev` varchar(45) DEFAULT NULL,`partnerAdo` varchar(13) DEFAULT NULL,`partnerCim` varchar(45) DEFAULT NULL,`partnerCegj` varchar(20) DEFAULT NULL,`partnerBank` varchar(45) DEFAULT NULL,`partnerBanksz` varchar(26) DEFAULT NULL,`partnerTel` varchar(13) DEFAULT NULL,`partnerMail` varchar(45) DEFAULT NULL,`partnerIban` varchar(20) DEFAULT NULL,PRIMARY KEY(`partnerId`));";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createSzamlatukor(string kapcs)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
            string s = "CREATE TABLE `szamlatukor` (`szamlaId` varchar(6) DEFAULT NULL,`szamlaTipus` varchar(100) DEFAULT NULL,`szamlaNev` varchar(100) DEFAULT NULL,`tartozik` int(10) DEFAULT NULL,`kovetel` int(10) DEFAULT NULL,`egyenleg` int(10) DEFAULT NULL);";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createDolgozok(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `dolgozok` (`dolgozoId` int(3) NOT NULL,`dolgozoNeve` varchar(45) DEFAULT NULL,`dolgozoSzulIdo` datetime DEFAULT NULL,`dolgozoSzulHely` varchar(45) DEFAULT NULL,`anyjaNeve` varchar(45) DEFAULT NULL,`dolgozoCime` varchar(45) DEFAULT NULL,`dolgozoAdoAz` varchar(13) DEFAULT NULL,`dolgozoTajszam` varchar(9) DEFAULT NULL,`dolgozoBank` varchar(26) DEFAULT NULL,`dolgozoMail` varchar(45) DEFAULT NULL,`dolgozoFelvIdeje` datetime DEFAULT NULL,`dolgozoJogviszony` varchar(15) DEFAULT NULL,`dolgozoBer` int(10) DEFAULT NULL,`szamfejtesVolt` varchar(8) DEFAULT NULL,PRIMARY KEY(`dolgozoId`));";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }

        public void createFokonyv(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `fokonyv` (`fokonyviSzam` int(5) NOT NULL,`nev` varchar(90) DEFAULT NULL,`tforgalom` int(10) DEFAULT NULL,`kforgalom` int(10) DEFAULT NULL,`egyenleg` int(10) DEFAULT NULL,`szamlalo` int(4) DEFAULT NULL,PRIMARY KEY(`fokonyviSzam`));";

            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createMerleg(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `merleg` (`tetelNev` varchar(10) NOT NULL,`tetelMegnevezes` varchar(90) DEFAULT NULL,`elozoEv` int(10) DEFAULT NULL,`targyEv` int(10) DEFAULT NULL,`szamlalo` int(3) NOT NULL,PRIMARY KEY(`szamlalo`));";

            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createHonapok(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `honapok` (`id` int(2) NOT NULL,`honapNev` varchar(10) DEFAULT NULL,`munkaNapSzam` int(2) DEFAULT NULL,`fizetettUnnep` int(2) DEFAULT NULL,PRIMARY KEY(`id`));";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }

        public void createMunkaszam(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `munkaszam` (`munkaSzam` int(3) NOT NULL,`munkaMegnevezes` varchar(45) DEFAULT NULL, PRIMARY KEY(`munkaSzam`));";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createBernyilvantartas(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `bernyilvantartas` (`id` int(11) NOT NULL,`jogviszony` varchar(14) DEFAULT NULL,`honap` varchar(10) DEFAULT NULL,`alapber` int(10) DEFAULT NULL,`ledolgNapok` int(2) DEFAULT NULL,`szabadNapok` varchar(2) DEFAULT NULL,`unnepNapok` varchar(2) DEFAULT NULL,`szja` int(10) DEFAULT NULL,`nyugdij` int(10) DEFAULT NULL,`eb` int(10) DEFAULT NULL,`munkaeroPiaci` int(10) DEFAULT NULL,`szocHozza` int(10) DEFAULT NULL,`kepzesiHozza` int(10) DEFAULT NULL,`berkoltseg` int(10) DEFAULT NULL,`nettober` int(10) DEFAULT NULL,`bruttober` int(10) DEFAULT NULL,`oraber` int(10) DEFAULT NULL,`dolgozok_dolgozoId` int(3) NOT NULL,`allapot` varchar(13) DEFAULT NULL,PRIMARY KEY(`id`),KEY `fk_bernyilvantartas_dolgozok1_idx` (`dolgozok_dolgozoId`),CONSTRAINT `fk_bernyilvantartas_dolgozok1` FOREIGN KEY(`dolgozok_dolgozoId`) REFERENCES `dolgozok` (`dolgozoId`));";

            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }

        public void createBanknaplo(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `banknaplo` (`tetelId` int(4) NOT NULL,`sorSzam` varchar(7) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`tartozik` int(5) DEFAULT NULL,`kovetel` int(5) DEFAULT NULL,`netto` int(10) DEFAULT NULL,`afa` varchar(40) DEFAULT NULL,`brutto` varchar(40) DEFAULT NULL,`megjegyzes` varchar(45) DEFAULT NULL,`datum` datetime DEFAULT NULL,`partnerek_partnerId` int(3) DEFAULT NULL,`munkaszam_munkaSzam` int(3) DEFAULT NULL,PRIMARY KEY(`tetelId`),KEY `fk_banknaplo_partnerek1_idx` (`partnerek_partnerId`),KEY `fk_banknaplo_munkaszam1_idx` (`munkaszam_munkaSzam`),CONSTRAINT `fk_banknaplo_munkaszam1` FOREIGN KEY(`munkaszam_munkaSzam`) REFERENCES `munkaszam` (`munkaSzam`),CONSTRAINT `fk_banknaplo_partnerek1` FOREIGN KEY(`partnerek_partnerId`) REFERENCES `partnerek` (`partnerId`));";


            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createPenztarnaplo(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `penztarnaplo` (`tetelId` int(4) NOT NULL,`sorSzam` varchar(7) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`tartozik` int(10) DEFAULT NULL,`kovetel` int(10) DEFAULT NULL,`netto` int(10) DEFAULT NULL,`afa` varchar(40) DEFAULT NULL,`brutto` varchar(40) DEFAULT NULL,`megjegyzes` varchar(45) DEFAULT NULL,`datum` datetime DEFAULT NULL,`munkaszam_munkaSzam` int(3) DEFAULT NULL,`partnerek_partnerId` int(3) DEFAULT NULL,PRIMARY KEY(`tetelId`),KEY `fk_penztarnaplo_munkaszam1_idx` (`munkaszam_munkaSzam`),KEY `fk_penztarnaplo_partnerek1_idx` (`partnerek_partnerId`),CONSTRAINT `fk_penztarnaplo_munkaszam1` FOREIGN KEY(`munkaszam_munkaSzam`) REFERENCES `munkaszam` (`munkaSzam`),CONSTRAINT `fk_penztarnaplo_partnerek1` FOREIGN KEY(`partnerek_partnerId`) REFERENCES `partnerek` (`partnerId`));";


            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }

        public void createVegyesnaplo(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `vegyesnaplo` (`sorSzam` varchar(4) NOT NULL,`tetelSzam` int(3) DEFAULT NULL,`megjegyzes` varchar(45) DEFAULT NULL,`netto` int(10) DEFAULT NULL,`afa` int(10) DEFAULT NULL,`brutto` int(10) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`TSzamla` varchar(5) DEFAULT NULL,`KSzamla` varchar(5) DEFAULT NULL,`datum` datetime DEFAULT NULL,`naploOsszeg` int(10) DEFAULT NULL,`munkaszam_munkaSzam` int(3) NOT NULL,`partnerek_partnerId` int(3) NOT NULL,PRIMARY KEY(`sorSzam`),KEY `fk_vegyesnaplo_munkaszam1_idx` (`munkaszam_munkaSzam`),KEY `fk_vegyesnaplo_partnerek1_idx` (`partnerek_partnerId`),CONSTRAINT `fk_vegyesnaplo_munkaszam1` FOREIGN KEY(`munkaszam_munkaSzam`) REFERENCES `munkaszam` (`munkaSzam`),CONSTRAINT `fk_vegyesnaplo_partnerek1` FOREIGN KEY(`partnerek_partnerId`) REFERENCES `partnerek` (`partnerId`));";

            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void createVevoSzallitonaplo(string con)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `vevoszallitonaplo` (`id` int(4) NOT NULL,`sorSzam` varchar(4) DEFAULT NULL,`tipus` varchar(15) DEFAULT NULL,`szamlaSzam` varchar(5) DEFAULT NULL,`ellenSzamla` varchar(5) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`megjegyzes` varchar(45) DEFAULT NULL,`fizetesModja` varchar(15) DEFAULT NULL,`kelt` datetime DEFAULT NULL,`teljIdeje` datetime DEFAULT NULL,`fizHat` datetime DEFAULT NULL,`afaEsed` datetime DEFAULT NULL,`netto` double(10, 2) DEFAULT NULL,`afa` varchar(40) DEFAULT NULL,`brutto` varchar(40) DEFAULT NULL,`afakulcs` varchar(6) DEFAULT NULL, `partnerek_partnerId` int(3) NOT NULL,`munkaszam_munkaSzam` int(3) NOT NULL,PRIMARY KEY(`id`),KEY `fk_vevoszallitonaplo_partnerek1_idx` (`partnerek_partnerId`),KEY `fk_vevoszallitonaplo_munkaszam1_idx` (`munkaszam_munkaSzam`),CONSTRAINT `fk_vevoszallitonaplo_munkaszam1` FOREIGN KEY(`munkaszam_munkaSzam`) REFERENCES `munkaszam` (`munkaSzam`),CONSTRAINT `fk_vevoszallitonaplo_partnerek1` FOREIGN KEY(`partnerek_partnerId`) REFERENCES `partnerek` (`partnerId`));";
            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void adatbazisLetrehozas(string x, string y, string z, string zs)
        {
            string cs = x;
            string s0 = y;
            string cs10 = z;
            string tablaCreate = zs;


            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(cs);
            conn.Open();


            cmd = new MySqlCommand(s0, conn);
            cmd.ExecuteNonQuery();


            MySqlConnection connect = null;
            MySqlCommand cmdy;

            connect = new MySqlConnection(cs10);
            connect.Open();
            cmdy = new MySqlCommand(tablaCreate, connect);
            cmdy.ExecuteNonQuery();
        }

        public int felhasznaloLekerdezes(string a)
        {

            int i = 0;

            MySqlConnection connection = new MySqlConnection(a);
            MySqlCommand cmd7 = connection.CreateCommand();
            cmd7.CommandText = "Select * FROM vallalkozasok";

            connection.Open();
            MySqlDataReader reader = cmd7.ExecuteReader();
            while (reader.Read())
            {
                i++;

            }


            connection.Close();

            if (i == 0)
            {
                i = i + 1;
            }
            Console.WriteLine(i);
            int inov = i;
            if (i > 1)
            {
                inov = i + 1;
            }


            return (inov);
        }

        public int vallalkozasSzamLekerdezes(string b)
        {
            int i = 0;

            MySqlConnection connection = new MySqlConnection(b);
            MySqlCommand cmd7 = connection.CreateCommand();
            cmd7.CommandText = "Select * FROM vallalkozasok";

            connection.Open();
            MySqlDataReader reader = cmd7.ExecuteReader();
            while (reader.Read())
            {
                i++;

            }


            connection.Close();

            if (i == 0)
            {
                i = i + 1;
            }
            Console.WriteLine(i);
            int inov = i;
            if (i > 1)
            {
                inov = i + 1;
            }


            return (inov);
        }

        public void createTetelek(string con)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(con);
            conn.Open();
            string s = "CREATE TABLE `tetelek` (`tetelId` int(4) DEFAULT NULL,`tartozik` varchar(5) DEFAULT NULL,`kovetel` varchar(5) DEFAULT NULL,`partnerKod` varchar(5) DEFAULT NULL,`partnerNev` varchar(40) DEFAULT NULL,`megnevezes` varchar(30) DEFAULT NULL,`tartozikOsszeg` int(10) DEFAULT NULL,`kovetelOsszeg` int(10) DEFAULT NULL,`datum` varchar(20) DEFAULT NULL);";

            cmd = new MySqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void beillesztEsemenyek(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `esemenyek` (`esemenyId` int(3) NOT NULL,`esemenyNapja` datetime DEFAULT NULL,`esemenyIdeje` time DEFAULT NULL,`esemenyMegnevezes` varchar(45) DEFAULT NULL,`esemenyHelyszin` varchar(45) DEFAULT NULL,`esemenyKontakt` varchar(45) DEFAULT NULL,`esemenyIdozito` int(1) DEFAULT NULL,`esemenyIdozitoIdo` datetime DEFAULT NULL,PRIMARY KEY(`esemenyId`));";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }


        public void beillesbankNaploOsszegzes(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `banknaploosszegzes` (`sorSzam` varchar(4) DEFAULT NULL,`fokonyviSzam` varchar(5) DEFAULT NULL,`nyitoErtek` int(10) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`partnerKod` int(3) DEFAULT NULL,`munkaKod` int(3) DEFAULT NULL,`megjegyzes` varchar(30) DEFAULT NULL,`osszeg` int(10) DEFAULT NULL,`datum` datetime DEFAULT NULL,KEY `idx_banknaploosszegzes_partnerKod` (`partnerKod`));";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }
        public void beillesPenztarNaploOsszegzes(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `penztarnaploosszegzes` (`sorSzam` varchar(4) DEFAULT NULL,`fokonyviSzam` varchar(5) DEFAULT NULL,`nyitoErtek` int(10) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`partnerKod` int(3) DEFAULT NULL,`munkaKod` int(3) DEFAULT NULL,`megjegyzes` varchar(30) DEFAULT NULL,`osszeg` int(10) DEFAULT NULL,`datum` datetime DEFAULT NULL);";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }
        public void beillesVegyesNaploOsszegzes(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `vegyesnaploosszegzes` (`sorSzam` varchar(4) DEFAULT NULL,`megjegyzes` varchar(30) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`munkaKod` int(3) DEFAULT NULL,`partnerKod` int(3) DEFAULT NULL,`datum` datetime DEFAULT NULL,`naploOsszeg` int(10) DEFAULT NULL);";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }
        public void beillesVevoszallitoNaploOsszegzes(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `vevoszallitonaploosszegzes` (`sorszam` varchar(4) DEFAULT NULL,`fokonyviSzam` varchar(5) DEFAULT NULL,`nyitoErtek` int(10) DEFAULT NULL,`bizonylatSzam` varchar(30) DEFAULT NULL,`partnerKod` int(3) DEFAULT NULL,`munkakod` int(3) DEFAULT NULL,`megjegyzes` varchar(30) DEFAULT NULL,`osszeg` int(10) DEFAULT NULL,`datum` datetime DEFAULT NULL);";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }

        public void beillesztFokonyv2(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `fokonyv2` (`fokonyviSzam` int(5) DEFAULT NULL,`nev` varchar(90) DEFAULT NULL,`tartozik` int(10) DEFAULT NULL,`kovetel` int(10) DEFAULT NULL,`egyenleg` int(10) DEFAULT NULL);";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }
        public void beillesztSzamlatukor2(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "CREATE TABLE `szamltukor2` (`szamlaId` int(5) DEFAULT NULL,`szamlaNev` varchar(90) DEFAULT NULL,`tartozik` int(10) DEFAULT NULL,`kovetel` int(10) DEFAULT NULL,`egyenleg` int(10) DEFAULT NULL,`szamolo` int(3) DEFAULT NULL);";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListazCegek w3 = new ListazCegek(felhasznalo, adatf, adatj);
            w3.Show();
            this.Close();
        }


        public void insertHonapokEsMunkaSzam(string f)
        {
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "insert into munkaszam values('999','');";
            cmd.ExecuteNonQuery();
            kapcsolat.Close();


            kapcsolat.Open();
            cmd.CommandText = "insert into honapok values(1,'Január','22',2);";
            cmd.ExecuteNonQuery();



            cmd.CommandText = "insert into honapok values(2,'Február','21',0);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(3,'Március','22',1);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(4,'Április','22',2);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(5,'Május','22',1);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(6,'Június','22',1);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(7,'Július','22',0);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(8,'Augusztus','22',2);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(9,'Szeptember','22',0);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(10,'Október','22',2);";

            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(11,'November','22',1);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into honapok values(12,'December','22',3);";
            cmd.ExecuteNonQuery();

        }



        public void insertFokonyvRow(string f)
        {
            List<SzamlaTukor2> szamlatukortolt = new List<SzamlaTukor2>();
            int i = 0;
            string connect = f;
            MySqlConnection kapcsolat = new MySqlConnection(connect);
            MySqlCommand cmd = kapcsolat.CreateCommand();
            MySqlCommand beszur = kapcsolat.CreateCommand();
            kapcsolat.Open();
            cmd.CommandText = "Select *from szamlatukor;";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                szamlatukortolt.Add(new SzamlaTukor2
                {
                    id = i,
                    szamlaSzam = int.Parse(reader["szamlaId"].ToString()),
                    szamlaNev = reader["szamlaTipus"].ToString(),
                    tartozik = 0,
                    kovetel = 0,
                    egyenleg = 0,

                });

                i++;
            }

            kapcsolat.Close();



            kapcsolat.Open();

            for (int k = 0; k < szamlatukortolt.Count(); k++)
            {
                beszur.CommandText = "insert into fokonyv values('" + szamlatukortolt[k].szamlaSzam + "','" + szamlatukortolt[k].szamlaNev + "',0,0,0,'" + szamlatukortolt[k].id + "');";
                beszur.ExecuteNonQuery();
            }

            kapcsolat.Close();

        }



        public bool elleorizAdatok()
        {
            bool vissza = true;
        
            if (cimEllenorzes(cm.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki a cím mezőt" + "\n Helyes Formátum : 9025, Győr, Budai Nagy Antal utca 15.");


                vissza = false;
            }

            if (adoszamEllenorzes(adoszam.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki az adószám mezőt" + "\n Helyes formátum : 8747784578");
                vissza = false;
            }

            if (bankszamEllenorzes(bankszamla.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki a bankszámlaszám mezőt" + "\n Helyes formátum: 00000000-00000000-00000000");
                vissza = false;
            }

            if (emailEllenorzes(email.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul töltötte ki az email- mezőt!!!" + "\n Helyes formátum: fsfsdf@gmail.com");
                vissza = false;
            }
           
            if (telEllenorzes(telszam.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul adta meg a telefonszámot!!!" + "\n Helyes Formátum: +36-302080898");
                vissza = false;
            }
            if (telEllenorzes(kepviselotelszam.Text.ToString()) == false)
            {
                MessageBox.Show("Rosszul adta meg a képviselő telefonszámot!!!" + "\n Helyes Formátum: +36-302080898");
                vissza = false;
            }

           
            return (vissza);
        }



        public static bool cimEllenorzes(string lakcim)
        {
            bool a = true;
            string minta = @"^[1-9][0-9]{3},[0-9a-zA-Zá-éíóöőúüűÁÉÍŐÖÚÜ\s\\,\-].{10,95}$";
            string input = lakcim;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool adoszamEllenorzes(string ado)
        {
            bool a = true;
            string minta = @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[1-5]-[0-9][0-9]$";
            string input = ado;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool bankszamEllenorzes(string bsz)
        {
            bool a = true;
            string minta = @"^[0-9]{8}-[0-9]{8}-[0-9]{8}$";
            string input = bsz;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }
        public static bool emailEllenorzes(string mail)
        {
            bool a = true;
            string minta = @"[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$";
            string input = mail;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }

        public static bool telEllenorzes(string tel)
        {
            bool a = true;
            string minta = @"[+36]-(\d+)";
            string input = tel;
            Match match = Regex.Match(input, minta);
            if (match.Success)
            {
                a = true;
            }
            else
                a = false;


            return (a);
        }

    }
}

