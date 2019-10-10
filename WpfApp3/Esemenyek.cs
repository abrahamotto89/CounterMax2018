using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace WpfApp3
{
    public class Esemenyek
    {
        public int esemenyId { get; set; }
        public  DateTime esemenyIdopont { get; set; }
        public  string esemenyMegnevezes { get; set; }
        public string esemenyHelyszin { get; set; }
        public string esemenyKontakt { get; set; }
        public int esemenyIsIdozito { get; set; }
        public DateTime esemenyIsIdozitoIdo { get; set; }
    }
}
