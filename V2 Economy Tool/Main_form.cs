using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V2_Economy_Tool
{
    public partial class Main_form : Form
    {
        private string goodspath, POPspath, production_typespath;
        private List<Good> goods;
        private List<Production_type> production_types;
        private List<POP> pops;

        public Main_form()
        {
            InitializeComponent();
            Production_typesList.Columns.Add("Name", 120);
            Production_typesList.Columns.Add("Profit", 60);
            Production_typesList.Columns.Add("Profitability", 70);
            GoodsList.Columns.Add("Name", 100);
            GoodsList.Columns.Add("Price", 60);
        }

        private void load_Button_Click(object sender, EventArgs e)
        {
            if (Program.Process_filepath(filepath_Box.Text, out goodspath, out POPspath, out production_typespath))
            {
                GoodsList.Items.Clear();
                filepath_Box.BackColor = Color.Empty;
                goods = Program.LoadGoods(goodspath);
                pops = Program.LoadPOPs(POPspath, goods);
                production_types = Program.LoadProduction_types(production_typespath, goods);
                ListViewItem temp;
                foreach (Good item in goods)
                {
                    temp = new ListViewItem(item.Name);
                    temp.SubItems.Add(item.Price.ToString());
                    GoodsList.Items.Add(temp);
                }
            }
            else
                filepath_Box.BackColor = Color.Red;
        }

        private void GoodsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem temp;
            decimal revenue, profit, profitability, inputcosts;
            Production_typesList.Items.Clear();
            foreach (Production_type item in production_types)
            {
                if (item.Output.Key.Name == GoodsList.FocusedItem.Text)
                {
                    temp = new ListViewItem(item.Name);
                    inputcosts = 0;
                    revenue = item.Output.Value * item.Output.Key.Price;
                    foreach (KeyValuePair<Good, decimal> item2 in item.Inputs)
                        inputcosts += item2.Key.Price * item2.Value;
                    foreach (KeyValuePair<Good, decimal> item2 in item.Template.Maintenance)
                        inputcosts += item2.Key.Price * item2.Value;
                    profit = Math.Round(revenue - inputcosts, 3);
                    temp.SubItems.Add(profit.ToString());
                    if (profit > 0) temp.BackColor = Color.Green;
                    else if (profit < 0) temp.BackColor = Color.Red;
                    else temp.BackColor = Color.Empty;
                    if (inputcosts != 0)
                    {
                        profitability = Math.Round(100 * revenue / inputcosts, 3);
                        temp.SubItems.Add(profitability.ToString() + '%');
                        if (profitability > 100) temp.BackColor = Color.Green;
                        else if (profitability < 100) temp.BackColor = Color.Red;
                        else temp.BackColor = Color.Empty;
                    }
                    else
                    {
                        temp.SubItems.Add("#DIV/0!");
                        temp.BackColor = Color.Green;
                    }
                    Production_typesList.Items.Add(temp);
                }
            }
        }

        private void Production_typesList_DoubleClick(object sender, EventArgs e)
        {
            if (Production_typesList.SelectedItems.Count == 1)
            {
                Production_type_form form = new Production_type_form(production_types.Find(x => x.Name == Production_typesList.FocusedItem.Text));
                form.Show();
            }
        }

        private void POP_Button_Click(object sender, EventArgs e)
        {
            POP_form form = new POP_form(pops);
            form.Show();
        }
    }
}
