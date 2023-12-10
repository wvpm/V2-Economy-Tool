using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Economy_Tool
{
    public class Factory_template
    {
        public string Name { get; private set; }
        public Dictionary<Good, decimal> Maintenance { get; private set; }

        public Factory_template(string name, Dictionary<Good, decimal> maintenance)
        {
            Name = name;
            Maintenance = maintenance;
        }
    }
}
