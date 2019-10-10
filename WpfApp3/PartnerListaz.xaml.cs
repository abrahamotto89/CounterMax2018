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
    /// Interaction logic for Window13.xaml
    /// </summary>
    public partial class PartnerListaz : Window
    {
        string Ceg;
        string adatf;
        string adatj;
        List<PartnerView> plista { get; set; }
        public PartnerListaz(string x,string y,string z)
        {

            Ceg = x;
            adatf = y;
            adatj = z;
            InitializeComponent();
            plista = new List<PartnerView>();
            partnerAdatokLekerdez(Ceg);
            mod.IsEnabled = false;
            torl.IsEnabled = false;

          



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PartnerFelvesz w11 = new PartnerFelvesz(Ceg,adatf,adatj);
            w11.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selecteditem = partnerLista.SelectedItems[0];
            if (selecteditem == null)
            {
                MessageBox.Show("Kérem jelöljön ki egyet");
            }
            else
            {
                PartnerView d1 = (PartnerView)partnerLista.SelectedItems[0];
                PartnerAdatokModosit w14 = new PartnerAdatokModosit(Ceg, d1.partnerId,adatf,adatj);
                w14.Show();
                this.Close();
            }


        }


        public void partnerAdatokLekerdez(string cnev)
        {

            partnerId.Binding = new Binding("partnerId");
            partnerNev.Binding = new Binding("partnerNev");
            partnerAdo.Binding = new Binding("partnerAdo");
            partnerCim.Binding = new Binding("partnerCim");
            partnerCegj.Binding = new Binding("parnterCegj");
            partnerBank.Binding = new Binding("partnerBank");
            partnerBanksz.Binding = new Binding("partnerBanksz");
            partnerTel.Binding = new Binding("partnerTel");
            partnerMail.Binding = new Binding("partnerMail");
            partnerIban.Binding = new Binding("partnerIban");

            string conn2String = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd = connection2.CreateCommand();
            cmd.CommandText = "Select * FROM partnerek";
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
                partnerLista.Items.Add(new PartnerView
                {


                    partnerId = reader["partnerId"].ToString(),
                    partnerNev = reader["partnerNev"].ToString(),
                    partnerAdo = reader["partnerAdo"].ToString(),
                    partnerCim = reader["partnerCim"].ToString(),
                    partnerCegj = reader["partnerCegj"].ToString(),
                    partnerBank = reader["partnerBank"].ToString(),
                    partnerBanksz = reader["partnerBanksz"].ToString(),
                    partnerTel = reader["partnerTel"].ToString(),
                    partnerMail = reader["partnerMail"].ToString(),
                    partnerIban = reader["partnerIban"].ToString(),



                });

            }

            connection2.Close();

            DataContext = this;
        
        }

        private void partnerLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mod.IsEnabled = true;
            torl.IsEnabled = true;
        }

        private void torl_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem = partnerLista.SelectedItems[0];

            PartnerView d1 = (PartnerView)partnerLista.SelectedItems[0];

            string conn2String = "SERVER=localhost;DATABASE=" + Ceg + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand hasznal = connection2.CreateCommand();
            MySqlCommand cmd = connection2.CreateCommand();
            MySqlCommand setkeys = connection2.CreateCommand();
            MySqlCommand onsetkeys = connection2.CreateCommand();
            connection2.Open();

           
            setkeys.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";
            setkeys.ExecuteNonQuery();
            

       
            cmd.CommandText = "delete from partnerek where partnerId='" + (d1.partnerId) + "';";
            cmd.ExecuteNonQuery();
            

       
            onsetkeys.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
            onsetkeys.ExecuteNonQuery();
            partnerLista.Items.Remove(d1);
            connection2.Close();


        }

        
    }
}
