using System.Collections.Generic;

namespace V2_Economy_Tool {
	public class ProductionType {
		public string Name { get; }
		public FactoryTemplate Template { get; }
		public Dictionary<Good, decimal> Inputs { get; }
		public KeyValuePair<Good, decimal> Output { get; }

		public ProductionType(string name, FactoryTemplate template, Dictionary<Good, decimal> inputs, KeyValuePair<Good, decimal> output) {
			Name = name;
			Template = template;
			Inputs = inputs;
			Output = output;
		}

		public override bool Equals(object obj) => obj is ProductionType other && other.Name == Name;
		public override int GetHashCode() => Name.GetHashCode();
		public override string ToString() => Name;
	}
}