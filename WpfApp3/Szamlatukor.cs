using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace WpfApp3
{
    class SzamlaTukor
    {
        List<int> Tukrok = new List<int>();
        List<string> Name = new List<string>();
        string adatf;
        string adatj;
        public SzamlaTukor(string betu,string t,string z )
        {
            string b = betu;
            adatf = t;
            adatj = z;
            StreamReader sr = new StreamReader("szamlatukor.txt");
            StreamReader sb = new StreamReader("sz2.txt");

            int i = 0;
           


            while (!sr.EndOfStream)
            {






                int a = int.Parse(sr.ReadLine());

                Tukrok.Add(a);
            }
            while (!sb.EndOfStream)
            {
                Name.Add(sb.ReadLine());
            }


            string g = "server=localhost;database=" + b + ";userid="+adatf+";password="+adatj+";SslMode=none";


            string eszkoz;

            int x = Tukrok.Count;
            
            int y = Name.Count;
         
            for (i = 0; i < x; i++)
            {
                if (i < 256)
                {
                    eszkoz = "Eszközök";
                }
                else
                {
                    eszkoz = "Források";
                }

                MySqlConnection connect = null;
                MySqlCommand cmd;

                connect = new MySqlConnection(g);
                connect.Open();
                string s = "insert into szamlatukor values('" + Tukrok[i] + "','" + Name[i] + "','"+eszkoz+"','0','0','0')";
                Console.WriteLine(Tukrok[i].ToString(), Name[i]);
                Console.WriteLine("kész");
                cmd = new MySqlCommand(s, connect);
                cmd.ExecuteNonQuery();




            }

        }
    }
}
