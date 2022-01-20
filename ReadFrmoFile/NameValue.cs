using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFrmoFile
{
    public class NameValue
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public NameValue(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
