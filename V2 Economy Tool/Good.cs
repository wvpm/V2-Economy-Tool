namespace V2_Economy_Tool {
	public class Good {
		public string Name { get; }
		public decimal Price { get; }

		public Good(string name, decimal price) {
			Name = name;
			Price = price;
		}

		public override bool Equals(object obj) => obj is Good other && other.Name == Name;
		public override int GetHashCode() => Name.GetHashCode();
		public override string ToString() => Name;
	}
}