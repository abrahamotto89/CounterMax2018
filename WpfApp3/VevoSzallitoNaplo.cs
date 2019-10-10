using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class VevoSzallitoNaplo
    {
        public int id { get; set; }
        public string sorSzam { get; set; }
        public string tipus { get; set; }
        public string szamlaSzam { get; set; }
        public string ellenSzamla { get; set; }
        public string bizonylatSzam { get; set; }
        public int munkaSzam { get; set;}
        public int partnerKod { get; set; }
        public string megjegyzes { get; set; }
        public string fizetesModja { get; set; }
        public DateTime kelt;
        public DateTime teljIdeje;
        public DateTime fizHat;
        public DateTime afaEsed;
        public double  netto { get; set; }
        public double  afa { get; set; }
        public double brutto { get; set; }
        public string afaKulcs { get; set; }

    }
}
