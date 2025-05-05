using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp02.Classes
{
    public class Partner_Products
    {
        public Int64 id {  get; set; }
        public Int64 product { get; set; }
        public Int64 partner { get; set; }
        public int countProduct { get; set; }
        public DateTime dateSell { get; set; }
    }
}
