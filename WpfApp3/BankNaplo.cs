using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
     public class BankNaplo
    {
        public string sorszam { get; set; }
        public string fokonyviszam { get; set; }
        public int nyitoErtek { get; set; }
        public string bizszam { get; set; }
        public int partnerKod { get; set; }
        public int  munkaKod { get; set; }
        public string megjegyzes { get; set; }
        public int osszeg { get; set; }
        public DateTime idoTime;
        public string dt
       {
           get { return idoTime.ToString(); }
            set { DateTime.TryParse(value, out idoTime); }
       }
    }
}
