using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Bank
   
    {

        public int id { get; set; }
        public int szamlaSzam { get; set; }
        public string bizonylatSzam { get; set; }
        public double netto { get; set; }
        public double afa { get; set; }
        public double brutto { get; set; }
        public string megjegyzes { get; set; }
        public int ellenSzamla { get; set; }
        public DateTime ido;
        public string dt
        {
            get { return ido.ToString(); }
            set { DateTime.TryParse(value, out ido); }
        }
        public int partnerKod { get; set; }
        public int munkaSzam { get; set; }
    }
}
