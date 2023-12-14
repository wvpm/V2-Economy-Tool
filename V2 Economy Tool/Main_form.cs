using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace V2_Economy_Tool {
	public partial class Main_form : Form {
		private string _goodsPath, _popPath, _productionTypesPath;
		private IReadOnlyCollection<Good> _goods;
		private IReadOnlyCollection<ProductionType> _productionTypes;
		private IReadOnlyCollection<PopType> _pops;

		public Main_form() {
			InitializeComponent();
			Production_typesList.Columns.Add("Name", 120);
			Production_typesList.Columns.Add("Profit", 60);
			Production_typesList.Columns.Add("Profitability", 70);
			GoodsList.Columns.Add("Name", 100);
			GoodsList.Columns.Add("Price", 60);
		}

		private void Load_Button_Click(object sender, EventArgs e) {
			if (Program.Process_filepath(filepath_Box.Text, out _goodsPath, out _popPath, out _productionTypesPath)) {
				GoodsList.Items.Clear();
				filepath_Box.BackColor = Color.Empty;
				_goods = Program.LoadGoods(_goodsPath);
				_pops = Program.LoadPOPs(_popPath, _goods);
				_productionTypes = Program.LoadProduction_types(_productionTypesPath, _goods);
				ListViewItem temp;
				foreach (Good item in _goods) {
					temp = new ListViewItem(item.Name);
					temp.SubItems.Add(item.Price.ToString());
					GoodsList.Items.Add(temp);
				}
			}
			else {
				filepath_Box.BackColor = Color.Red;
			}
		}

		private void GoodsList_SelectedIndexChanged(object sender, EventArgs e) {
			ListViewItem item;
			decimal revenue, profit, profitability, inputcosts;
			Production_typesList.Items.Clear();
			foreach (ProductionType productionType in _productionTypes) {
				if (productionType.Output.Key.Name == GoodsList.FocusedItem.Text) {
					item = new ListViewItem(productionType.Name) { Tag = productionType };
					inputcosts = 0;
					revenue = productionType.Output.Value * productionType.Output.Key.Price;
					foreach (KeyValuePair<Good, decimal> item2 in productionType.Inputs) {
						inputcosts += item2.Key.Price * item2.Value;
					}

					foreach (KeyValuePair<Good, decimal> item2 in productionType.Template.Maintenance) {
						inputcosts += item2.Key.Price * item2.Value;
					}

					profit = Math.Round(revenue - inputcosts, 3);
					item.SubItems.Add(profit.ToString());
					if (profit > 0) {
						item.BackColor = Color.Green;
					}
					else if (profit < 0) {
						item.BackColor = Color.Red;
					}
					else {
						item.BackColor = Color.Empty;
					}

					if (inputcosts != 0) {
						profitability = Math.Round(100 * revenue / inputcosts, 3);
						item.SubItems.Add(profitability.ToString() + '%');
						if (profitability > 100) {
							item.BackColor = Color.Green;
						}
						else if (profitability < 100) {
							item.BackColor = Color.Red;
						}
						else {
							item.BackColor = Color.Empty;
						}
					}
					else {
						item.SubItems.Add("#DIV/0!");
						item.BackColor = Color.Green;
					}
					Production_typesList.Items.Add(item);
				}
			}
		}

		private void Production_typesList_DoubleClick(object sender, EventArgs e) {
			if (Production_typesList.SelectedItems.Count == 1) {
				ProductionType productionType = (ProductionType)Production_typesList.FocusedItem.Tag;
				Production_type_form form = new Production_type_form(productionType);
				form.Show();
			}
		}

		private void POP_Button_Click(object sender, EventArgs e) {
			POP_form form = new POP_form(_pops);
			form.Show();
		}
	}
}