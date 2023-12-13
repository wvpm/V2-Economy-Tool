using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace V2_Economy_Tool {
	public partial class POP_form : Form {
		private readonly IReadOnlyCollection<PopType> _popTypes;
		private PopType _selected;
		private bool _isUnemployed = false,
			_isPopSizeValid = false,
			_isConsciousnessValid = false,
			_isPluralityValid = false,
			_isBaseGoodsDemandValid = false,
			_isInventionImpactOnDemandValid = false,
			_isNumberOfInventionsValid = false,
			_isUnemploymentBenefitValid = false,
			_isAdministrativeEfficiencyValid = false,
			_isIncomeValid = false,
			_isEffectiveTaxRateValid = false,
			_isTariffValid = false,
			_hasSelectedPopType = false;
		private HashSet<Good> _importedGoods;
		private uint _numberOfInventions, _popSize;
		private decimal _consciousness,
			_baseGoodDemand,
			_inventionImpactOnDemand,
			_income,
			_totalIncome,
			_plurality,
			_unemploymentBenifit,
			_administrativeEfficiency,
			_tariffs,
			_effectiveTaxRate;

		public POP_form(IReadOnlyCollection<PopType> popTypes) {
			_popTypes = popTypes;
			InitializeComponent();

			foreach (PopType item in _popTypes) {
				POP_Type_Box.Items.Add(item.Name);
			}

			foreach (ListView listView in new[] { LifeNeedsList, EverydayNeedsList, LuxuryNeedsList }) {
				listView.Columns.Add("Good", 70);
				listView.Columns.Add("X", 45);
				listView.Columns.Add("Price", 45);
				listView.Columns.Add("Cost", 70);
			}

			Consciousness_Box.Text = Plurality_Box.Text = Inventions_Box.Text = Tariffs_Box.Text = Effective_Tax_Box.Text = "0";
			Administrative_Efficiency_Box.Text = "100%";
		}

		private void POP_Type_Box_SelectedIndexChanged(object sender, EventArgs e) {
			_selected = _popTypes.Single(x => x.Name == POP_Type_Box.Text);
			_importedGoods = _selected.Life_Needs.Keys.Concat(_selected.Everyday_Needs.Keys).Concat(_selected.Luxury_Needs.Keys).ToHashSet();
			_hasSelectedPopType = true;
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
			if (_isPopSizeValid
				&& _isConsciousnessValid
				&& _isPluralityValid
				&& _isBaseGoodsDemandValid
				&& _isInventionImpactOnDemandValid
				&& _isNumberOfInventionsValid
				&& (_isUnemploymentBenefitValid || !_isUnemployed)
				&& _isAdministrativeEfficiencyValid
				&& _isIncomeValid
				&& _isEffectiveTaxRateValid
				&& _isTariffValid
				&& _hasSelectedPopType) {
				decimal subsidies = 0, costs, lifeCosts = 0, everyDayCosts = 0, luxuryCosts = 0,
					needModifier = (1M + _plurality) * (1M + _consciousness / 10M) * _baseGoodDemand * _popSize / 200000M,
					effectiveTariffsMultiplier = 1M + _administrativeEfficiency * _tariffs;
				foreach (KeyValuePair<Good, decimal> need in _selected.Life_Needs) {
					decimal quantityNeeded = need.Value * needModifier;
					costs = need.Key.Price * quantityNeeded;
					bool isImported;
					if (isImported = _importedGoods.Contains(need.Key)) {
						costs *= effectiveTariffsMultiplier;
					}
					lifeCosts += costs;
					LifeNeedsList.Items.Add(CreateListViewItemForNeed(need.Key, quantityNeeded, costs, isImported));
					if (_isUnemployed) {
						subsidies += 2M * _unemploymentBenifit * _administrativeEfficiency * need.Key.Price * need.Value;
					}
				}

				needModifier *= 1M + _numberOfInventions * _inventionImpactOnDemand;

				void FillNeedsList(Dictionary<Good, decimal> needs, ListView listView, ref decimal sumOfCosts) {
					foreach (KeyValuePair<Good, decimal> need in needs) {
						decimal quantityNeeded = need.Value * needModifier;
						costs = need.Key.Price * quantityNeeded;
						bool isImported;
						if (isImported = _importedGoods.Contains(need.Key)) {
							costs *= effectiveTariffsMultiplier;
						}
						sumOfCosts += costs;
						listView.Items.Add(CreateListViewItemForNeed(need.Key, quantityNeeded, costs, isImported));
					}
				}

				FillNeedsList(_selected.Everyday_Needs, EverydayNeedsList, ref everyDayCosts);
				FillNeedsList(_selected.Luxury_Needs, LuxuryNeedsList, ref luxuryCosts);

				_totalIncome = (_income + subsidies * _popSize / 200000M) * (1M - _effectiveTaxRate);
				Total_Income_Box.Text = _totalIncome.Normalize().ToString();
				UpdateCostsAndSatisfaction(lifeCosts, everyDayCosts, luxuryCosts);
			}

			LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
		}

		private void UpdateCostsAndSatisfaction(decimal lifecosts, decimal everydaycosts, decimal luxurycosts) {
			Life_Costs_Box.Text = lifecosts.Normalize().ToString();
			Everyday_Costs_Box.Text = everydaycosts.Normalize().ToString();
			Life_And_Everyday_Costs_Box.Text = (lifecosts + everydaycosts).Normalize().ToString();
			Luxury_Costs_Box.Text = luxurycosts.Normalize().ToString();
			Total_Costs_Box.Text = (lifecosts + everydaycosts + luxurycosts).Normalize().ToString();

			decimal moneyLeft = _totalIncome;
			if (moneyLeft > lifecosts) {
				Life_Needs_Satisfaction_Box.Text = "100%";
				moneyLeft -= lifecosts;
				if (moneyLeft > everydaycosts) {
					Everyday_Needs_Satisfaction_Box.Text = "100%";
					moneyLeft -= everydaycosts;
					if (moneyLeft > luxurycosts) {
						Luxury_Needs_Satisfaction_Box.Text = "100%";
					}
					else {
						Luxury_Needs_Satisfaction_Box.Text = Math.Round((100M * moneyLeft / luxurycosts).Normalize(), 8).ToString() + '%';
					}
				}
				else {
					Everyday_Needs_Satisfaction_Box.Text = Math.Round((100M * moneyLeft / everydaycosts).Normalize(), 8).ToString() + '%';
					Luxury_Needs_Satisfaction_Box.Text = "0%";
				}
			}
			else {
				Life_Needs_Satisfaction_Box.Text = Math.Round((100M * moneyLeft / lifecosts).Normalize(), 8).ToString() + '%';
				Everyday_Needs_Satisfaction_Box.Text = Luxury_Needs_Satisfaction_Box.Text = "0%";
			}
		}

		private void UpdateCostsOnly() {
			LifeNeedsList.ItemCheck -= LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck -= EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck -= LuxuryNeedsList_ItemCheck;

			decimal lifeCosts = 0M, everyDayCosts = 0M, luxuryCosts = 0M,
				needModifier = (1M + _plurality) * (1M + _consciousness / 10M) * _baseGoodDemand * _popSize / 200000M,
				effectiveTariffsMultiplier = 1M + _administrativeEfficiency * _tariffs;

			void ProcessListViewItem(ListViewItem item, ref decimal sumOfCosts) {
				Good good = (Good)item.Tag;
				decimal baseQuantity = _selected.Life_Needs[good], quantityNeeded = baseQuantity * needModifier;
				decimal costs = good.Price * quantityNeeded;
				bool isImported;
				if (isImported = _importedGoods.Contains(good)) {
					costs *= effectiveTariffsMultiplier;
				}
				sumOfCosts += costs;
				UpdateListViewItem(item, costs, isImported);
			}

			foreach (ListViewItem item in LifeNeedsList.Items) {
				ProcessListViewItem(item, ref lifeCosts);
			}

			needModifier *= 1M + _numberOfInventions * _inventionImpactOnDemand;

			foreach (ListViewItem item in EverydayNeedsList.Items) {
				ProcessListViewItem(item, ref everyDayCosts);
			}

			foreach (ListViewItem item in LuxuryNeedsList.Items) {
				ProcessListViewItem(item, ref luxuryCosts);
			}

			UpdateCostsAndSatisfaction(lifeCosts, everyDayCosts, luxuryCosts);

			LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
			EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
			LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
		}

		private static ListViewItem CreateListViewItemForNeed(Good good, decimal quantity, decimal costs, bool isImported) {
			ListViewItem item = new ListViewItem(good.Name) {
				Checked = isImported,
				Tag = good
			};
			item.SubItems.Add(quantity.Normalize().ToString());
			item.SubItems.Add(good.Price.ToString());
			item.SubItems.Add(costs.Normalize().ToString());
			return item;
		}

		private static void UpdateListViewItem(ListViewItem item, decimal costs, bool isImported) {
			item.SubItems[3].Text = costs.Normalize().ToString();
			item.Checked = isImported;
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
			Good good = (Good)LifeNeedsList.Items[e.Index].Tag;
			if (e.NewValue == CheckState.Checked) {
				_importedGoods.Add(good);
			}
			else if (e.NewValue == CheckState.Unchecked) {
				_importedGoods.Remove(good);
			}
			UpdateCostsOnly();
		}

		private void EverydayNeedsList_ItemCheck(object sender, ItemCheckEventArgs e) {
			Good good = (Good)EverydayNeedsList.Items[e.Index].Tag;
			if (e.NewValue == CheckState.Checked) {
				_importedGoods.Add(good);
			}
			else if (e.NewValue == CheckState.Unchecked) {
				_importedGoods.Remove(good);
			}
			UpdateCostsOnly();
		}

		private void LuxuryNeedsList_ItemCheck(object sender, ItemCheckEventArgs e) {
			Good good = (Good)LuxuryNeedsList.Items[e.Index].Tag;
			if (e.NewValue == CheckState.Checked) {
				_importedGoods.Add(good);
			}
			else if (e.NewValue == CheckState.Unchecked) {
				_importedGoods.Remove(good);
			}
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