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
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText="Select * FROM felhasznalok";
            try
            {
                connection.Open();

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);

                
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader["jelszo"].ToString());

            }

            Console.ReadLine();

            


        }
    }



}
