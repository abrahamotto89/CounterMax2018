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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class ListazCegek : Window
    {
        public List<Cegek> Ceglista1 { get; set; }
        public String cegneve;
       
        string fnev;
        string adatbazisfnev;
        string adatbazisjelszo;



        public ListazCegek(string x,string y,string z)
        {



            fnev = x;

            adatbazisfnev = y;
            adatbazisjelszo = z;

            Lekerdezes();

            
            InitializeComponent();
        }


        private void Lekerdezes()
        {
            string conn2String = "SERVER=localhost;DATABASE=konyvelok;UID="+adatbazisfnev+";PASSWORD="+adatbazisjelszo+";SSL Mode=None";
            MySqlConnection connection2 = new MySqlConnection(conn2String);
            MySqlCommand cmd = connection2.CreateCommand();
            cmd.CommandText = "Select * FROM vallalkozasok";
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

                if (i == 0)
                {

                    Ceglista1 = new List<Cegek>()
                    {


                        new Cegek
                                {
                                 Cegnev = reader["vallalkozasNev"].ToString(),
                               // Kepviselo = reader["kepviseloNeve"].ToString(),



                        },

                     };

                   


                }

                else
                {
                    Ceglista1.Add(new Cegek
                    {
                        Cegnev = reader["vallalkozasNev"].ToString(),
                        //Kepviselo = reader["kepviseloNeve"].ToString(),
                    }

                       );

                }
                i++;
            }


            DataContext = this;


        }




        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {




        }


        private void uj_Click(object sender, RoutedEventArgs e)
        {
            VallalkozasFelvesz w1 = new VallalkozasFelvesz(fnev,adatbazisfnev,adatbazisjelszo);
            w1.Show();
            this.Close();
        }

        private void kivalaszt_Click(object sender, RoutedEventArgs e)
        {



            Cegek c1 = (Cegek)Lista1.SelectedItems[0];
            FoAblak w1 = new FoAblak(fnev,c1.Cegnev,true,adatbazisfnev,adatbazisjelszo);
            w1.Show();

            this.Close();

            

           
          




        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           



 



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
