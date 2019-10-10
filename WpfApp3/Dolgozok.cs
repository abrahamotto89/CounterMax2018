using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
   public class Dolgozok
    {
        public int id { get; set; }
        public string nev { get; set; }
        public DateTime szulIdo;
        public string dtS
        {
            get { return szulIdo.ToString(); }
            set { DateTime.TryParse(value, out szulIdo); }
        }
        public string szulHely { get; set; }
        public string anyjaNeve { get; set; }
        public string cime { get; set; }
        public string adoSzam { get; set; }
        public string tajSzam { get; set; }
        public string bankSzamla { get; set; }
        public string email { get; set; }
        public DateTime felvIdeje;
        public string dt
        {
            get { return felvIdeje.ToString(); }
            set { DateTime.TryParse(value, out felvIdeje); }
        }
    
    public string jogviszony { get; set; }
        public int haviBer { get; set; }

        public string szamfejtes { get; set; }
        public string allapot { get; set; }
    }
}
