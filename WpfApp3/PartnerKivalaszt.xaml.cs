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
    /// Interaction logic for Window12.xaml
    /// </summary>
    public partial class PartnerKivalaszt : Window
    {
        public List<Partnerek> partnerLista { get; set; }
        
        string Cegnev;
        bool isKivalaszt;
        string adatf;
        string adatj;
        public PartnerKivalaszt(string x,bool kiv,string y,string z)
        {
            Cegnev = x;
            adatf = y;
            adatj = z;
            InitializeComponent();
            Lekerdezes();
             isKivalaszt = kiv;
        }




        private void Lekerdezes()
        {
            string conn2String = "SERVER=localhost;DATABASE="+Cegnev+";UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
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
            int i = 0;


            while (reader.Read())
            {

                if (i == 0 && reader["partnerNev"].ToString()!="")
                {

                    partnerLista = new List<Partnerek>()
                    {


                        new Partnerek
                                {
                                
                                 Partnerkod=reader["partnerId"].ToString(),
                                Partnernev = reader["partnerNev"].ToString()



                        },

                     };




                }

                else
                {
                    partnerLista.Add(new Partnerek
                    {
                        Partnernev = reader["partnerNev"].ToString(),
                        Partnerkod = reader["partnerId"].ToString()


                    });

                }
                i++;
            }


            DataContext = this;


        }

        public void  Button_Click(object sender, RoutedEventArgs e)
        {


            
            



            Partnerek c1 = (Partnerek)Lista1.SelectedItems[0];
            if (c1.Partnernev != "")
            {

               
                string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatf+";PASSWORD="+adatj+";SSL Mode=None";
                Console.WriteLine(conn2String);
                MySqlConnection connection2 = new MySqlConnection(conn2String);
                MySqlCommand cmd2 = connection2.CreateCommand();






                cmd2.CommandText = "INSERT INTO partner Values('" + c1.Partnerkod + "','" + c1.Partnernev + "');";
                connection2.Open();
                cmd2.ExecuteNonQuery();

                connection2.Close();

                if (isKivalaszt == true)
                {
                    PartnerAdatokModosit w14 = new PartnerAdatokModosit(Cegnev, c1.Partnerkod,adatf,adatj);
                    w14.Show();
                }
                
                this.Close();
              
            }

            else
                MessageBox.Show("Nincs partner Kérem vegyen fel partnereket");

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
