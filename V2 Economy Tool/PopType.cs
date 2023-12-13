using System.Collections.Generic;

namespace V2_Economy_Tool {
	public class PopType {
		public string Name { get; private set; }
		public Dictionary<Good, decimal> Life_Needs { get; private set; }
		public Dictionary<Good, decimal> Everyday_Needs { get; private set; }
		public Dictionary<Good, decimal> Luxury_Needs { get; private set; }

		public PopType(string name, Dictionary<Good, decimal> life_needs, Dictionary<Good, decimal> everyday_needs, Dictionary<Good, decimal> luxury_needs) {
			Name = name;
			Life_Needs = life_needs;
			Everyday_Needs = everyday_needs;
			Luxury_Needs = luxury_needs;
		}

		public override bool Equals(object obj) => obj is PopType other && other.Name == Name;
		public override int GetHashCode() => Name.GetHashCode();
		public override string ToString() => Name;
	}
}