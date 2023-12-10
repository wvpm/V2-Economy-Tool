using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Economy_Tool
{
    public class Production_type
    {
        public string Name { get; private set; }
        public Factory_template Template { get; private set; }
        public Dictionary<Good, decimal> Inputs { get; private set; }
        public KeyValuePair<Good, decimal> Output { get; private set; }

        public Production_type (string name, Factory_template template, Dictionary<Good, decimal> inputs, KeyValuePair<Good, decimal> output)
        {
            Name = name;
            Template = template;
            Inputs = inputs;
            Output = output;
        }
    }
}
