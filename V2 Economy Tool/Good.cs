using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Economy_Tool
{
    public class Good
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Good (string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
