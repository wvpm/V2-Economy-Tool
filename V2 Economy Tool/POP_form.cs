using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V2_Economy_Tool
{
    public partial class POP_form : Form
    {
        private List<POP> POPs;
        private POP selected;
        private bool unemployed = false, ready_0 = false, ready_1 = false, ready_2 = false, ready_3 = false, ready_4 = false, ready_5 = false, ready_6 = false, ready_7 = false, ready_8 = false, ready_9 = false, ready_10 = false, ready_11 = false;
        private Dictionary<Good, bool> life_needs_tariffs, everyday_needs_tariffs, luxury_needs_tariffs;
        private uint inventions, POP_size;
        private decimal consciousness, base_good_demand, invention_impact_on_demand, income, total_income, plurality, unemployment_benifit, administrative_efficiency, tariffs, effective_tax;

        public POP_form(List<POP> pops)
        {
            POPs = pops;
            InitializeComponent();
            foreach (POP item in POPs)
            {
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

        private void POP_Type_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = POPs.First(x => x.Name == POP_Type_Box.Text);
            life_needs_tariffs = new Dictionary<Good, bool>();
            everyday_needs_tariffs = new Dictionary<Good, bool>();
            luxury_needs_tariffs = new Dictionary<Good, bool>();
            foreach (Good item in selected.Life_Needs.Keys)
                life_needs_tariffs.Add(item, true);
            foreach (Good item in selected.Everyday_Needs.Keys)
                everyday_needs_tariffs.Add(item, true);
            foreach (Good item in selected.Luxury_Needs.Keys)
                luxury_needs_tariffs.Add(item, true);
            ready_11 = true;
            UpdateAll();
        }

        private void UpdateAll()
        {
            LifeNeedsList.ItemCheck -= LifeNeedsList_ItemCheck;
            EverydayNeedsList.ItemCheck -= EverydayNeedsList_ItemCheck;
            LuxuryNeedsList.ItemCheck -= LuxuryNeedsList_ItemCheck;

            LifeNeedsList.Items.Clear();
            EverydayNeedsList.Items.Clear();
            LuxuryNeedsList.Items.Clear();
            Total_Income_Box.Text = Life_Costs_Box.Text = Everyday_Costs_Box.Text = Life_And_Everyday_Costs_Box.Text = Luxury_Costs_Box.Text = Total_Costs_Box.Text = string.Empty;
            if (ready_0 && ready_1 && ready_2 && ready_3 && ready_4 && ready_5 && (ready_6 || !unemployed) && ready_7 && ready_8 && ready_9 && ready_10 && ready_11)
            {
                decimal subsidies = 0, modifier = (1 + plurality) * (1 + consciousness / 10) * base_good_demand * POP_size / 200000, costs, lifecosts = 0, everydaycosts = 0, luxurycosts = 0;
                ListViewItem temp;
                foreach (KeyValuePair<Good, decimal> need in selected.Life_Needs)
                {
                    temp = new ListViewItem(need.Key.Name);
                    temp.SubItems.Add(need.Value.ToString());
                    temp.SubItems.Add(need.Key.Price.ToString());
                    costs = need.Key.Price * need.Value * modifier;
                    if (life_needs_tariffs[need.Key])
                    {
                        costs = costs * (1 + administrative_efficiency * tariffs);
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = true;
                    }
                    else
                    {
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = false;
                    }
                    lifecosts += costs;
                    LifeNeedsList.Items.Add(temp);
                    if (unemployed) subsidies += 2 * unemployment_benifit * administrative_efficiency * need.Key.Price * need.Value;
                }
                Life_Costs_Box.Text = lifecosts.Normalize().ToString();
                foreach (KeyValuePair<Good, decimal> need in selected.Everyday_Needs)
                {
                    temp = new ListViewItem(need.Key.Name);
                    temp.SubItems.Add(need.Value.ToString());
                    temp.SubItems.Add(need.Key.Price.ToString());
                    costs = need.Key.Price * need.Value * modifier * (1 + inventions * invention_impact_on_demand);
                    if (everyday_needs_tariffs[need.Key])
                    {
                        costs = costs * (1 + administrative_efficiency * tariffs);
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = true;
                    }
                    else
                    {
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = false;
                    }
                    everydaycosts += costs;
                    EverydayNeedsList.Items.Add(temp);
                }
                Everyday_Costs_Box.Text = everydaycosts.Normalize().ToString();
                Life_And_Everyday_Costs_Box.Text = (lifecosts + everydaycosts).Normalize().ToString();
                foreach (KeyValuePair<Good, decimal> need in selected.Luxury_Needs)
                {
                    temp = new ListViewItem(need.Key.Name);
                    temp.SubItems.Add(need.Value.ToString());
                    temp.SubItems.Add(need.Key.Price.ToString());
                    costs = need.Key.Price * need.Value * modifier * (1 + inventions * invention_impact_on_demand);
                    if (luxury_needs_tariffs[need.Key])
                    {
                        costs = costs * (1 + administrative_efficiency * tariffs);
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = true;
                    }
                    else
                    {
                        temp.SubItems.Add(costs.Normalize().ToString());
                        temp.Checked = false;
                    }
                    luxurycosts += costs;
                    LuxuryNeedsList.Items.Add(temp);
                }
                Luxury_Costs_Box.Text = luxurycosts.Normalize().ToString();
                Total_Costs_Box.Text = (lifecosts + everydaycosts + luxurycosts).Normalize().ToString();
                total_income = (income + subsidies * POP_size / 200000) * (1 - effective_tax);
                Total_Income_Box.Text = total_income.Normalize().ToString();
                if (total_income > lifecosts)
                {
                    Life_Needs_Satisfaction_Box.Text = "100%";
                    total_income -= lifecosts;
                    if (total_income > everydaycosts)
                    {
                        Everyday_Needs_Satisfaction_Box.Text = "100%";
                        total_income -= everydaycosts;
                        if (total_income > luxurycosts)
                            Luxury_Needs_Satisfaction_Box.Text = "100%";
                        else
                            Luxury_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / luxurycosts).Normalize(), 8).ToString() + '%';
                    }
                    else
                    {
                        Everyday_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / everydaycosts).Normalize(), 8).ToString() + '%';
                        Luxury_Needs_Satisfaction_Box.Text = "0%";
                    }
                }
                else
                {
                    Life_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / lifecosts).Normalize(), 8).ToString() + '%';
                    Everyday_Needs_Satisfaction_Box.Text = Luxury_Needs_Satisfaction_Box.Text = "0%";
                }
            }

            LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
            EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
            LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
        }

        private void UpdateCostsOnly()
        {
            LifeNeedsList.ItemCheck -= LifeNeedsList_ItemCheck;
            EverydayNeedsList.ItemCheck -= EverydayNeedsList_ItemCheck;
            LuxuryNeedsList.ItemCheck -= LuxuryNeedsList_ItemCheck;

            decimal subsidies = 0, modifier = (1 + plurality) * (1 + consciousness / 10) * base_good_demand * POP_size / 200000, costs, lifecosts = 0, everydaycosts = 0, luxurycosts = 0;
            ListViewItem temp;
            foreach (KeyValuePair<Good, decimal> need in selected.Life_Needs)
            {
                temp = LifeNeedsList.FindItemWithText(need.Key.Name);
                costs = need.Key.Price * need.Value * modifier;
                if (life_needs_tariffs[need.Key])
                    costs = costs * (1 + administrative_efficiency * tariffs);
                temp.SubItems[3].Text = costs.Normalize().ToString();
                lifecosts += costs;
                if (unemployed) subsidies += 2 * unemployment_benifit * administrative_efficiency * need.Key.Price * need.Value;
            }
            Life_Costs_Box.Text = lifecosts.Normalize().ToString();
            foreach (KeyValuePair<Good, decimal> need in selected.Everyday_Needs)
            {
                temp = EverydayNeedsList.FindItemWithText(need.Key.Name);
                costs = need.Key.Price * need.Value * modifier * (1 + inventions * invention_impact_on_demand);
                if (everyday_needs_tariffs[need.Key])
                    costs = costs * (1 + administrative_efficiency * tariffs);
                temp.SubItems[3].Text = costs.Normalize().ToString();
                everydaycosts += costs;
            }
            Everyday_Costs_Box.Text = everydaycosts.Normalize().ToString();
            Life_And_Everyday_Costs_Box.Text = (lifecosts + everydaycosts).Normalize().ToString();
            foreach (KeyValuePair<Good, decimal> need in selected.Luxury_Needs)
            {
                temp = LuxuryNeedsList.FindItemWithText(need.Key.Name);
                costs = need.Key.Price * need.Value * modifier * (1 + inventions * invention_impact_on_demand);
                if (luxury_needs_tariffs[need.Key])
                    costs = costs * (1 + administrative_efficiency * tariffs);
                temp.SubItems[3].Text = costs.Normalize().ToString();
                luxurycosts += costs;
            }
            Luxury_Costs_Box.Text = luxurycosts.Normalize().ToString();
            Total_Costs_Box.Text = (lifecosts + everydaycosts + luxurycosts).Normalize().ToString();
            total_income = (income + subsidies * POP_size / 200000) * (1 - effective_tax);
            Total_Income_Box.Text = total_income.Normalize().ToString();
            if (total_income > lifecosts)
            {
                Life_Needs_Satisfaction_Box.Text = "100%";
                total_income -= lifecosts;
                if (total_income > everydaycosts)
                {
                    Everyday_Needs_Satisfaction_Box.Text = "100%";
                    total_income -= everydaycosts;
                    if (total_income > luxurycosts)
                        Luxury_Needs_Satisfaction_Box.Text = "100%";
                    else
                        Luxury_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / luxurycosts).Normalize(), 8).ToString() + '%';
                }
                else
                {
                    Everyday_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / everydaycosts).Normalize(), 8).ToString() + '%';
                    Luxury_Needs_Satisfaction_Box.Text = "0%";
                }
            }
            else
            {
                Life_Needs_Satisfaction_Box.Text = Math.Round((100 * total_income / lifecosts).Normalize(), 8).ToString() + '%';
                Everyday_Needs_Satisfaction_Box.Text = Luxury_Needs_Satisfaction_Box.Text = "0%";
            }

            LifeNeedsList.ItemCheck += LifeNeedsList_ItemCheck;
            EverydayNeedsList.ItemCheck += EverydayNeedsList_ItemCheck;
            LuxuryNeedsList.ItemCheck += LuxuryNeedsList_ItemCheck;
        }

        private void SizeBox_TextChanged(object sender, EventArgs e)
        {
            ready_0 = uint.TryParse(Size_Box.Text, out POP_size);
            UpdateAll();
        }

        private void Consciousness_Box_TextChanged(object sender, EventArgs e)
        {
            ready_1 = decimal.TryParse(Consciousness_Box.Text, out consciousness);
            UpdateAll();
        }

        private void Plurality_Box_TextChanged(object sender, EventArgs e)
        {
            ready_2 = decimal.TryParse(Plurality_Box.Text.TrimEnd('%'), out plurality);
            if (ready_2) plurality /= 100;
            UpdateAll();
        }

        private void Base_Goods_Demand_Box_TextChanged(object sender, EventArgs e)
        {
            ready_3 = decimal.TryParse(Base_Goods_Demand_Box.Text, out base_good_demand);
            UpdateAll();
        }

        private void Invention_Impact_On_Demand_Box_TextChanged(object sender, EventArgs e)
        {
            ready_4 = decimal.TryParse(Invention_Impact_On_Demand_Box.Text, out invention_impact_on_demand);
            UpdateAll();
        }

        private void Inventions_Box_TextChanged(object sender, EventArgs e)
        {
            ready_5 = uint.TryParse(Inventions_Box.Text, out inventions);
            UpdateAll();
        }

        private void Unemployement_Benifit_Box_TextChanged(object sender, EventArgs e)
        {
            ready_6 = decimal.TryParse(Unemployement_Benifit_Box.Text.TrimEnd('%'), out unemployment_benifit);
            if (ready_6) unemployment_benifit /= 100;
            UpdateAll();
        }

        private void Administrative_Efficiency_Box_TextChanged(object sender, EventArgs e)
        {
            ready_7 = decimal.TryParse(Administrative_Efficiency_Box.Text.TrimEnd('%'), out administrative_efficiency);
            if (ready_7) administrative_efficiency /= 100;
            UpdateAll();
        }

        private void IncomeBox_TextChanged(object sender, EventArgs e)
        {
            ready_8 = decimal.TryParse(Income_Box.Text, out income);
            UpdateAll();
        }

        private void Effective_Tax_Box_TextChanged(object sender, EventArgs e)
        {
            ready_9 = decimal.TryParse(Effective_Tax_Box.Text.TrimEnd('%'), out effective_tax);
            if (ready_9) effective_tax /= 100;
            UpdateAll();
        }

        private void Tariffs_Box_TextChanged(object sender, EventArgs e)
        {
            ready_10 = decimal.TryParse(Tariffs_Box.Text.TrimEnd('%'), out tariffs);
            if (ready_10) tariffs /= 100;
            UpdateAll();
        }

        private void Unemployed_Box_CheckedChanged(object sender, EventArgs e)
        {
            unemployed = Unemployed_Box.Checked;
            UpdateAll();
        }

        private void LifeNeedsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            life_needs_tariffs[life_needs_tariffs.Keys.First(x => x.Name == LifeNeedsList.Items[e.Index].Text)] = (e.NewValue == CheckState.Checked);
            UpdateCostsOnly();
        }

        private void EverydayNeedsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            everyday_needs_tariffs[everyday_needs_tariffs.Keys.First(x => x.Name == EverydayNeedsList.Items[e.Index].Text)] = (e.NewValue == CheckState.Checked);
            UpdateCostsOnly();
        }

        private void LuxuryNeedsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            luxury_needs_tariffs[luxury_needs_tariffs.Keys.First(x => x.Name == LuxuryNeedsList.Items[e.Index].Text)] = (e.NewValue == CheckState.Checked);
            UpdateCostsOnly();
        }
    }
}
