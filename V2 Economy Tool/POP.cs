using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Economy_Tool
{
    public class POP
    {
        public string Name { get; private set; }
        public Dictionary<Good, decimal> Life_Needs { get; private set; }
        public Dictionary<Good, decimal> Everyday_Needs { get; private set; }
        public Dictionary<Good, decimal> Luxury_Needs { get; private set; }

        public POP (string name, Dictionary<Good, decimal> life_needs, Dictionary<Good, decimal> everyday_needs, Dictionary<Good, decimal> luxury_needs)
        {
            Name = name;
            Life_Needs = life_needs;
            Everyday_Needs = everyday_needs;
            Luxury_Needs = luxury_needs;
        }
    }
}
