using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp02.Classes
{
    public class Materials
    {
        public Int64 id {  get; set; }
        public string typeMaterial {  get; set; }
        public double defectRate { get; set; }
        public string name { get; set; }
        public Int64 supplier {  get; set; }
        public int countPackage { get; set; }
        public string description { get; set; }
        public byte[] image { get; set; }
        public double price { get; set; }
        public int countInStorage { get; set; }
    }
}
