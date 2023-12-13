using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace V2_Economy_Tool {
	public partial class POP_form : Form {
		private readonly List<POP> _pops;
		private POP _selected;
		private bool _isUnemployed = false, _isPopSizeValid = false, _isConsciousnessValid = false, _isPluralityValid = false, _isBaseGoodsDemandValid = false, _isInventionImpactOnDemandValid = false, _isNumberOfInventionsValid = false, _isUnemploymentBenefitValid = false, _isAdministrativeEfficiencyValid = false, _isIncomeValid = false, _isEffectiveTaxRateValid = false, _isTariffValid = false, ready_11 = false;
		private Dictionary<Good, bool> life_needs_tariffs, everyday_needs_tariffs, luxury_needs_tariffs;
		private uint _numberOfInventions, _popSize;
		private decimal _consciousness, _baseGoodDemand, _inventionImpactOnDemand, _income, _totalIncome, _plurality, _unemploymentBenifit, _administrativeEfficiency, _tariffs, _effectiveTaxRate;

		public POP_form(List<POP> pops) {
			_pops = pops;
			InitializeComponent();
			foreach (POP item in _pops) {
				POP_Type_Box.Items.Add(item.Name);
			}
			LifeNeedsList.Columns.Add("Good", 80);
			LifeNeedsList.Columns.Add("X", 40);
			LifeNeedsList.Columns.Add("Price", 40);
			LifeNeedsList.Columns.Add("Cost", 70);
			EverydayNeedsList.Columns.Add("Good", 80);
			EverydayNeedsList.Columns.Add("X", 40);
			EverydayNeedsList.Columns.Add("Price", 40);
			EverydayNeedsList.Columns.Add("Cost", 70);
			LuxuryNeedsList.Columns.Add("Good", 80);
			LuxuryNeedsList.Columns.Add("X", 40);
			LuxuryNeedsList.Columns.Add("Price", 40);
			LuxuryNeedsList.Columns.Add("Cost", 70);
		}

		private void POP_Type_Box_SelectedIndexChanged(object sender, EventArgs e) {
			_selected = _pops.First(x => x.Name == POP_Type_Box.Text);
			life_needs_tariffs = new Dictionary<Good, bool>();
			everyday_needs_tariffs = new Dictionary<Good, bool>();
			luxury_needs_tariffs = new Dictionary<Good, bool>();
			foreach (Good item in _selected.Life_Needs.Keys)
				life_needs_tariffs.Add(item, true);
			foreach (Good item in _selected.Everyday_Needs.Keys)
				everyday_needs_tariffs.Add(item, true);
			foreach (Good item in _selected.Luxury_Needs.Keys)
				luxury_needs_tariffs.Add(item, true);
			ready_11 = true;
			UpdateAll();
		}

		private void UpdateAll() {
			LifeNeedsList.ItemCheck -= LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck -= EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck -= LuxuryNeedsList_ItemCheck;

			LifeNeedsList.Items.Clear();
			EverydayNeedsList.Items.Clear();
			LuxuryNeedsList.Items.Clear();
			Total_Income_Box.Text = Life_Costs_Box.Text = Everyday_Costs_Box.Text = Life_And_Everyday_Costs_Box.Text = Luxury_Costs_Box.Text = Total_Costs_Box.Text = string.Empty;
			if (_isPopSizeValid && _isConsciousnessValid && _isPluralityValid && _isBaseGoodsDemandValid && _isInventionImpactOnDemandValid && _isNumberOfInventionsValid && (_isUnemploymentBenefitValid || !_isUnemployed) && _isAdministrativeEfficiencyValid && _isIncomeValid && _isEffectiveTaxRateValid && _isTariffValid && ready_11) {
				decimal subsidies = 0, modifier = (1M + _plurality) * (1M + _consciousness / 10M) * _baseGoodDemand * _popSize / 200000M, costs, lifecosts = 0, everydaycosts = 0, luxurycosts = 0;
				ListViewItem temp;
				foreach (KeyValuePair<Good, decimal> need in _selected.Life_Needs) {
					temp = new ListViewItem(need.Key.Name);
					temp.SubItems.Add(need.Value.ToString());
					temp.SubItems.Add(need.Key.Price.ToString());
					costs = need.Key.Price * need.Value * modifier;
					if (life_needs_tariffs[need.Key]) {
						costs *= 1 + _administrativeEfficiency * _tariffs;
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = true;
					}
					else {
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = false;
					}
					lifecosts += costs;
					LifeNeedsList.Items.Add(temp);
					if (_isUnemployed) subsidies += 2M * _unemploymentBenifit * _administrativeEfficiency * need.Key.Price * need.Value;
				}
				Life_Costs_Box.Text = lifecosts.Normalize().ToString();
				foreach (KeyValuePair<Good, decimal> need in _selected.Everyday_Needs) {
					temp = new ListViewItem(need.Key.Name);
					temp.SubItems.Add(need.Value.ToString());
					temp.SubItems.Add(need.Key.Price.ToString());
					costs = need.Key.Price * need.Value * modifier * (1M + _numberOfInventions * _inventionImpactOnDemand);
					if (everyday_needs_tariffs[need.Key]) {
						costs *= 1M + _administrativeEfficiency * _tariffs;
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = true;
					}
					else {
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = false;
					}
					everydaycosts += costs;
					EverydayNeedsList.Items.Add(temp);
				}
				Everyday_Costs_Box.Text = everydaycosts.Normalize().ToString();
				Life_And_Everyday_Costs_Box.Text = (lifecosts + everydaycosts).Normalize().ToString();
				foreach (KeyValuePair<Good, decimal> need in _selected.Luxury_Needs) {
					temp = new ListViewItem(need.Key.Name);
					temp.SubItems.Add(need.Value.ToString());
					temp.SubItems.Add(need.Key.Price.ToString());
					costs = need.Key.Price * need.Value * modifier * (1M + _numberOfInventions * _inventionImpactOnDemand);
					if (luxury_needs_tariffs[need.Key]) {
						costs *= 1M + _administrativeEfficiency * _tariffs;
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = true;
					}
					else {
						temp.SubItems.Add(costs.Normalize().ToString());
						temp.Checked = false;
					}
					luxurycosts += costs;
					LuxuryNeedsList.Items.Add(temp);
				}
				Luxury_Costs_Box.Text = luxurycosts.Normalize().ToString();
				Total_Costs_Box.Text = (lifecosts + everydaycosts + luxurycosts).Normalize().ToString();
				_totalIncome = (_income + subsidies * _popSize / 200000M) * (1M - _effectiveTaxRate);
				Total_Income_Box.Text = _totalIncome.Normalize().ToString();
				if (_totalIncome > lifecosts) {
					Life_Needs_Satisfaction_Box.Text = "100%";
					_totalIncome -= lifecosts;
					if (_totalIncome > everydaycosts) {
						Everyday_Needs_Satisfaction_Box.Text = "100%";
						_totalIncome -= everydaycosts;
						if (_totalIncome > luxurycosts)
							Luxury_Needs_Satisfaction_Box.Text = "100%";
						else
							Luxury_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / luxurycosts).Normalize(), 8).ToString() + '%';
					}
					else {
						Everyday_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / everydaycosts).Normalize(), 8).ToString() + '%';
						Luxury_Needs_Satisfaction_Box.Text = "0%";
					}
				}
				else {
					Life_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / lifecosts).Normalize(), 8).ToString() + '%';
					Everyday_Needs_Satisfaction_Box.Text = Luxury_Needs_Satisfaction_Box.Text = "0%";
				}
			}

			LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
		}

		private void UpdateCostsOnly() {
			LifeNeedsList.ItemCheck -= LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck -= EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck -= LuxuryNeedsList_ItemCheck;

			decimal subsidies = 0, modifier = (1M + _plurality) * (1M + _consciousness / 10M) * _baseGoodDemand * _popSize / 200000M, costs, lifecosts = 0, everydaycosts = 0, luxurycosts = 0;
			ListViewItem temp;
			foreach (KeyValuePair<Good, decimal> need in _selected.Life_Needs) {
				temp = LifeNeedsList.FindItemWithText(need.Key.Name);
				costs = need.Key.Price * need.Value * modifier;
				if (life_needs_tariffs[need.Key])
					costs *= 1 + _administrativeEfficiency * _tariffs;
				temp.SubItems[3].Text = costs.Normalize().ToString();
				lifecosts += costs;
				if (_isUnemployed) subsidies += 2M * _unemploymentBenifit * _administrativeEfficiency * need.Key.Price * need.Value;
			}
			Life_Costs_Box.Text = lifecosts.Normalize().ToString();
			foreach (KeyValuePair<Good, decimal> need in _selected.Everyday_Needs) {
				temp = EverydayNeedsList.FindItemWithText(need.Key.Name);
				costs = need.Key.Price * need.Value * modifier * (1M + _numberOfInventions * _inventionImpactOnDemand);
				if (everyday_needs_tariffs[need.Key])
					costs *= 1M + _administrativeEfficiency * _tariffs;
				temp.SubItems[3].Text = costs.Normalize().ToString();
				everydaycosts += costs;
			}
			Everyday_Costs_Box.Text = everydaycosts.Normalize().ToString();
			Life_And_Everyday_Costs_Box.Text = (lifecosts + everydaycosts).Normalize().ToString();
			foreach (KeyValuePair<Good, decimal> need in _selected.Luxury_Needs) {
				temp = LuxuryNeedsList.FindItemWithText(need.Key.Name);
				costs = need.Key.Price * need.Value * modifier * (1M + _numberOfInventions * _inventionImpactOnDemand);
				if (luxury_needs_tariffs[need.Key])
					costs *= 1M + _administrativeEfficiency * _tariffs;
				temp.SubItems[3].Text = costs.Normalize().ToString();
				luxurycosts += costs;
			}
			Luxury_Costs_Box.Text = luxurycosts.Normalize().ToString();
			Total_Costs_Box.Text = (lifecosts + everydaycosts + luxurycosts).Normalize().ToString();
			_totalIncome = (_income + subsidies * _popSize / 200000M) * (1M - _effectiveTaxRate);
			Total_Income_Box.Text = _totalIncome.Normalize().ToString();
			if (_totalIncome > lifecosts) {
				Life_Needs_Satisfaction_Box.Text = "100%";
				_totalIncome -= lifecosts;
				if (_totalIncome > everydaycosts) {
					Everyday_Needs_Satisfaction_Box.Text = "100%";
					_totalIncome -= everydaycosts;
					if (_totalIncome > luxurycosts)
						Luxury_Needs_Satisfaction_Box.Text = "100%";
					else
						Luxury_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / luxurycosts).Normalize(), 8).ToString() + '%';
				}
				else {
					Everyday_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / everydaycosts).Normalize(), 8).ToString() + '%';
					Luxury_Needs_Satisfaction_Box.Text = "0%";
				}
			}
			else {
				Life_Needs_Satisfaction_Box.Text = Math.Round((100M * _totalIncome / lifecosts).Normalize(), 8).ToString() + '%';
				Everyday_Needs_Satisfaction_Box.Text = Luxury_Needs_Satisfaction_Box.Text = "0%";
			}

			LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
		}

		private void SizeBox_TextChanged(object sender, EventArgs e) {
			_isPopSizeValid = uint.TryParse(Size_Box.Text, out _popSize);
			UpdateAll();
		}

		private void Consciousness_Box_TextChanged(object sender, EventArgs e) {
			_isConsciousnessValid = decimal.TryParse(Consciousness_Box.Text, out _consciousness);
			UpdateAll();
		}

		private void Plurality_Box_TextChanged(object sender, EventArgs e) {
			_isPluralityValid = TryParsePercentage(Plurality_Box.Text, out _plurality);
			UpdateAll();
		}

		private void Base_Goods_Demand_Box_TextChanged(object sender, EventArgs e) {
			_isBaseGoodsDemandValid = decimal.TryParse(Base_Goods_Demand_Box.Text, out _baseGoodDemand);
			UpdateAll();
		}

		private void Invention_Impact_On_Demand_Box_TextChanged(object sender, EventArgs e) {
			_isInventionImpactOnDemandValid = decimal.TryParse(Invention_Impact_On_Demand_Box.Text, out _inventionImpactOnDemand);
			UpdateAll();
		}

		private void Inventions_Box_TextChanged(object sender, EventArgs e) {
			_isNumberOfInventionsValid = uint.TryParse(Inventions_Box.Text, out _numberOfInventions);
			UpdateAll();
		}

		private void Unemployement_Benifit_Box_TextChanged(object sender, EventArgs e) {
			_isUnemploymentBenefitValid = TryParsePercentage(Unemployement_Benifit_Box.Text, out _unemploymentBenifit);
			UpdateAll();
		}

		private void Administrative_Efficiency_Box_TextChanged(object sender, EventArgs e) {
			_isAdministrativeEfficiencyValid = TryParsePercentage(Administrative_Efficiency_Box.Text, out _administrativeEfficiency);
			UpdateAll();
		}

		private void IncomeBox_TextChanged(object sender, EventArgs e) {
			_isIncomeValid = decimal.TryParse(Income_Box.Text, out _income);
			UpdateAll();
		}

		private void Effective_Tax_Box_TextChanged(object sender, EventArgs e) {
			_isEffectiveTaxRateValid = TryParsePercentage(Effective_Tax_Box.Text, out _effectiveTaxRate);
			UpdateAll();
		}

		private void Tariffs_Box_TextChanged(object sender, EventArgs e) {
			_isTariffValid = TryParsePercentage(Tariffs_Box.Text, out _tariffs);
			UpdateAll();
		}

		private void Unemployed_Box_CheckedChanged(object sender, EventArgs e) {
			_isUnemployed = Unemployed_Box.Checked;
			UpdateAll();
		}

		private void LifeNeedsList_ItemCheck(object sender, ItemCheckEventArgs e) {
			life_needs_tariffs[life_needs_tariffs.Keys.First(x => x.Name == LifeNeedsList.Items[e.Index].Text)] = e.NewValue == CheckState.Checked;
			UpdateCostsOnly();
		}

		private void EverydayNeedsList_ItemCheck(object sender, ItemCheckEventArgs e) {
			everyday_needs_tariffs[everyday_needs_tariffs.Keys.First(x => x.Name == EverydayNeedsList.Items[e.Index].Text)] = e.NewValue == CheckState.Checked;
			UpdateCostsOnly();
		}

		private void LuxuryNeedsList_ItemCheck(object sender, ItemCheckEventArgs e) {
			luxury_needs_tariffs[luxury_needs_tariffs.Keys.First(x => x.Name == LuxuryNeedsList.Items[e.Index].Text)] = e.NewValue == CheckState.Checked;
			UpdateCostsOnly();
		}

		private static bool TryParsePercentage(string text, out decimal value) {
			if (text.EndsWith("%", StringComparison.OrdinalIgnoreCase)) {
				if (decimal.TryParse(text.Substring(0, text.Length - 1), out value)) {
					value /= 100M;
					return true;
				}
				else {
					return false;
				}
			}

			return decimal.TryParse(text, out value);
		}
	}
}
