using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Mydata
    {
        public string tartozik { get; set; }
        public string kovetel { get; set; }
        public string partnerkod { get; set; }
        public string partner { get; set; }
        public string megnevezes { get; set; }
        public int tosszeg { get; set; }
        public int kosszeg { get; set; }
        
        public DateTime _datevalue;

        public string dt
            {
                get { return _datevalue.ToString(); }
                set { DateTime.TryParse(value, out _datevalue); }
            }
        }
    }

