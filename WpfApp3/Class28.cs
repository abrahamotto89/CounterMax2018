using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WpfApp3
{
    public class AdatbazisMuveletek
    {
        int felhid = 0;
        string felhnev;

        public AdatbazisMuveletek()
        {
            string connString = "SERVER=localhost;DATABASe=konyvelok;UID=root;PASSWORD=macika89;SSL Mode=none";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cm = connection.CreateCommand();
            MySqlCommand beszur = connection.CreateCommand();
            cm.CommandText = "Select * from felhasznalok;";

            try
            {
                connection.Open();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MySqlDataReader reader = cm.ExecuteReader();
           

          

            while (reader.Read())
            {
                felhid = int.Parse(reader["felhasznaloid"].ToString());
                felhnev = reader["felhasznaloNev"].ToString();
            }

            beszur.CommandText = "INSERT into felhasznalok values(7,'Kiss Péter','kispeti8967',2018-12-01,'+36704567894');";
            beszur.ExecuteNonQuery();

            connection.Close();




        }

    }
}
