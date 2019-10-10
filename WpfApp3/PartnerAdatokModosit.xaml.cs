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
    /// Interaction logic for Window14.xaml
    /// </summary>
    public partial class PartnerAdatokModosit : Window
    {
        string partnerKod;
        string cegNev;
        string adatf;
        string adatj;
        public PartnerAdatokModosit(string x,string y,string adat,string z )
        {
            InitializeComponent();
            partnerKod = y;
            cegNev = x;
            adatf = adat;
            adatj = z;


            partnerAdatokLekerdez(cegNev,partnerKod);
        }

        public void partnerAdatokLekerdez(string cnev,string pkod)
        {



            string conn2String = "SERVER=localhost;DATABASE=" + cegNev + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
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
                if (reader["partnerId"].ToString() == partnerKod)
                {
                    Id.Text = reader["partnerId"].ToString();
                    Nev.Text = reader["partnerNev"].ToString();
                    Asz.Text = reader["partnerAdo"].ToString();
                    Cim.Text = reader["partnerCim"].ToString();
                    Cegj.Text = reader["partnerCegj"].ToString();
                    Bank.Text = reader["partnerBank"].ToString();
                    Banksz.Text = reader["partnerBanksz"].ToString();
                    Tel.Text = reader["partnerTel"].ToString();
                    Email.Text = reader["partnerMail"].ToString();
                    Iban.Text = reader["partnerIban"].ToString();
                }
               
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cim_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conn2String = "SERVER=localhost;DATABASE="+cegNev+";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            Console.WriteLine(conn2String);
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd2 = connection2.CreateCommand();






            cmd2.CommandText = "update partnerek set partnerNev='"+Nev.Text+"',partnerAdo='"+Asz.Text+ "',partnerCim='" + Cim.Text + "',partnerCegj='"+Cegj.Text+"',partnerBank='"+Bank.Text+"',partnerBanksz='"+Banksz.Text+"',partnerTel='"+Tel.Text+"',partnerMail='"+Email.Text+"',partnerIban='"+Iban.Text+"' where partnerId='"+Id.Text+"'";
            connection2.Open();
            cmd2.ExecuteNonQuery();

            connection2.Close();
            MessageBox.Show("Partner Adatok Módosítva");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string conn2String = "SERVER=localhost;DATABASE=" + cegNev + ";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
            Console.WriteLine(conn2String);
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd2 = connection2.CreateCommand();






            cmd2.CommandText = "delete from partnerek where partnerId='"+partnerKod+"'";
            connection2.Open();
            cmd2.ExecuteNonQuery();

            connection2.Close();


            MessageBox.Show("Partner Törölve");

            PartnerKivalaszt w12 = new PartnerKivalaszt(cegNev, false,adatf,adatj);
            w12.Show();

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
