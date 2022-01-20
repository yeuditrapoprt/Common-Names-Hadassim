using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFrmoFile
{
    class NamesPairs
    {
        public string name1 { get; set; }
        public string name2 { get; set; }
        public NamesPairs(string name1, string name2)
        {
            this.name1 = name1;
            this.name2 = name2;
        }
    }
}
