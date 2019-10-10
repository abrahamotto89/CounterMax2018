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
    /// Interaction logic for Window22.xaml
    /// </summary>
    public partial class FelveszMunkaSzam : Window
    {



        string Ceg;
        List<Munka> munkaSzamLista { get; set; }
        string adatf;
        string adatj;
        public FelveszMunkaSzam(string x,string y,string z)
        {
            InitializeComponent();
            Ceg = x;
            adatf = y;
            adatj = z;
            munkaSzamLista = new List<Munka>();
            // munkaSzamLekerdezes(Ceg);
            // beillesztes();
            mod.IsEnabled = false;
            torl.IsEnabled = false;
            ment.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string kapcs = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection conn = null;
            MySqlCommand cmd;
            conn = new MySqlConnection(kapcs);
            conn.Open();
            if (munkaszamellenorzes() == true)
            {
                for (int i = 0; i < munkaSzamLista.Count; i++)
                {
                    string s = "INSERT INTO munkaszam values('" + munkaSzamLista[i].munkaSzam + "','" + munkaSzamLista[i].munkaMegnevezes + "')";
                    cmd = new MySqlCommand(s, conn);
                    cmd.ExecuteNonQuery();
                }

                munkaSzamTetelek.Items.Clear();
                for (int k = 0; k < munkaSzamLista.Count; k++)
                {
                    munkaSzamLista.RemoveAt(k);
                }
                conn.Close();


                torl.IsEnabled = false;
                ment.IsEnabled = false;
                mod.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Kérem válasszon másik kódot!!!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //felveszúj 
            if (ellenoriz() == true)
            {


                munkaSzamLista.Add(new Munka
                {
                    munkaSzam = int.Parse(munkaszam.Text.ToString()),

                    munkaMegnevezes = munkaNev.Text.ToString()
                }
                );




                beillesztes();

                mod.IsEnabled = true;
                torl.IsEnabled = true;
                ment.IsEnabled = true;
                munkaszam.Text = "";
                munkaNev.Text = "";

            }
            else
            {
                MessageBox.Show("Hibásan bevitt értékek");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Munka m1 = (Munka)munkaSzamTetelek.SelectedItems[0];
            for (int t = 0; t < munkaSzamLista.Count; t++)
            {
                if (m1.munkaSzam == munkaSzamLista[t].munkaSzam)
                {
                    munkaszam.Text = m1.munkaSzam.ToString();
                    munkaNev.Text = m1.munkaMegnevezes;
                    munkaSzamTetelek.Items.Clear();
                    munkaSzamLista.RemoveAt(t);

                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        public void munkaSzamLekerdezes(string x)
        {


            string conn = "SERVER=localhost;DATABASE=" + x + ";UID=root;PASSWORD=macika89;SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cm = connect.CreateCommand();
            cm.CommandText = "Select * FROM munkaSzam";
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

                {

                    munkaSzamLista.Add(new Munka
                    {
                        munkaSzam = int.Parse(reader["munkaSzam"].ToString()),

                        munkaMegnevezes = reader["munkaMegnevezes"].ToString()

                    }
                    );



                }




            }

        }


            public void beillesztes()
            {
                munkasz.Binding = new Binding("munkaSzam");
                munkamegn.Binding = new Binding("munkaMegnevezes");

                int i = 0;

                for (i = 0; i < munkaSzamLista.Count; i++) {
                    munkaSzamTetelek.Items.Add(new Munka { munkaSzam = munkaSzamLista[i].munkaSzam, munkaMegnevezes = munkaSzamLista[i].munkaMegnevezes });


                }

                DataContext = this;




            }

            private void torl_Click(object sender, RoutedEventArgs e)
            {
                Munka m1 = (Munka)munkaSzamTetelek.SelectedItems[0];
                for (int t = 0; t < munkaSzamLista.Count; t++)
                {
                    if (m1.munkaSzam == munkaSzamLista[t].munkaSzam)
                    {

                        munkaSzamTetelek.Items.Clear();
                        munkaSzamLista.RemoveAt(t);

                    }
                }
            }

            public bool ellenoriz()
            {
                bool vissza = true;
                string f = munkaszam.Text;
                char[] array = f.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if (Char.IsDigit(array[i]) == false)
                    {
                        vissza = false;

                    }
                    if (i == array.Length - 1 && vissza == false)
                    {
                        MessageBox.Show("A munkaszám mezőbe csak szám karakter adható meg!!!!");
                    }
                }


                if (munkaszam.Text == "")
                {

                    vissza = false;
                    MessageBox.Show("Kérem töltse ki a munkaszám mezőt!!!");
                }
                if (munkaNev.Text == "")
                {
                    vissza = false;
                    MessageBox.Show("Kérem töltse ki a munka megnevezés mezőt!!!");
                }

                return (vissza);

            }

            public bool munkaszamellenorzes()
            {
                bool vissza = true;
                string kapcs = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                MySqlConnection connnect = new MySqlConnection(kapcs);
                MySqlCommand cmd = connnect.CreateCommand();
                connnect.Open();
                cmd.CommandText = "Select *from munkaszam";

                List<int> munkaszamok = new List<int>();

                MySqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())

                {
                    munkaszamok.Add(int.Parse(reader2["munkaSzam"].ToString()));

                }
                for (int i = 0; i < munkaSzamLista.Count; i++) {
                            for(int g = 0; g < munkaszamok.Count; g++)
                                        {
                    if (munkaSzamLista[i].munkaSzam == munkaszamok[g])
                    {
                        vissza = false;
                    }
                                        }
                }

                return (vissza);
            }


        }
 } 
