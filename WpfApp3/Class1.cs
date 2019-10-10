using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp3
{
    public class Kapcsolat 
    {
        public Kapcsolat() { 

            string connString = "SERVER=localhost;DATABASE=konyvelok;UID=root;PASSWORD=kiraly89;";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM felhasznalok",connection);
            connection.Open();

            connection.Close();

            Console.WriteLine("Kész");


        }
    }



}
