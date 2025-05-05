using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp02.Classes
{
    public class GetChanges
    {     
        public int id {  get; set; }
        public string name
        {
            get; set;
        }
        public double priceMin {  get; set; }
        public DateTime dateSell { get; set; }
        public int countProduct { get; set; }
    }
}
