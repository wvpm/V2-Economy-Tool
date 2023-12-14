using System.Collections.Generic;

namespace V2_Economy_Tool {
	public class FactoryTemplate {
		public string Name { get; }
		public Dictionary<Good, decimal> Maintenance { get; }

		public FactoryTemplate(string name, Dictionary<Good, decimal> maintenance) {
			Name = name;
			Maintenance = maintenance;
		}

		public override bool Equals(object obj) => obj is FactoryTemplate other && other.Name == Name;
		public override int GetHashCode() => Name.GetHashCode();
		public override string ToString() => Name;
	}
}