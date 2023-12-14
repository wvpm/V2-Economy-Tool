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
    public partial class Production_type_form : Form
    {
        public Production_type_form(ProductionType production_type)
        {
            InitializeComponent();
            this.Text = production_type.Name;
            Input_List.Columns.Add("Good", 100);
            Input_List.Columns.Add("Amount", 50);
            Input_List.Columns.Add("Price", 50);
            Input_List.Columns.Add("Total", 70);
            Output_Good_Box.Text = production_type.Output.Key.Name;
            Output_Amount_Box.Text = production_type.Output.Value.ToString();
            Price_Box.Text = production_type.Output.Key.Price.ToString();
            ListViewItem temp;
            decimal inputcosts = 0, maintenancecosts = 0, revenue = production_type.Output.Value * production_type.Output.Key.Price, profit, temp2;
            foreach (KeyValuePair<Good, decimal> item in production_type.Inputs)
            {
                temp = new ListViewItem(item.Key.Name);
                temp.SubItems.Add(Program.Normalize(item.Value).ToString());
                temp.SubItems.Add(Program.Normalize(item.Key.Price).ToString());
                temp2 = item.Key.Price * item.Value;
                inputcosts += temp2;
                temp.SubItems.Add(Program.Normalize(temp2).ToString());
                Input_List.Items.Add(temp);
            }
            foreach (KeyValuePair<Good, decimal> item in production_type.Template.Maintenance)
            {
                temp = new ListViewItem(item.Key.Name);
                temp.SubItems.Add(Program.Normalize(item.Value).ToString());
                temp.SubItems.Add(Program.Normalize(item.Key.Price).ToString());
                temp2 = item.Key.Price * item.Value;
                maintenancecosts += temp2;
                temp.SubItems.Add(Program.Normalize(temp2).ToString());
                Input_List.Items.Add(temp);
            }
            profit = revenue - inputcosts;
            string stats = string.Empty;
            stats += "Input costs\t" + Program.Normalize(inputcosts);
            stats += Environment.NewLine + "Maintenance costs\t" + Program.Normalize(maintenancecosts);
            stats += Environment.NewLine + "Revenue\t\t" + Program.Normalize(revenue);
            stats += Environment.NewLine + "Profit\t\t" + Program.Normalize(profit);
            if (inputcosts != 0) {
				stats += Environment.NewLine + "Profitability\t" + Math.Round(100 * revenue / (inputcosts + maintenancecosts), 3) + '%';
			}

			Stat_Box.Text = stats;
        }
    }
}
