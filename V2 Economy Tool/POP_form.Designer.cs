namespace V2_Economy_Tool
{
    partial class POP_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.Unemployed_Box = new System.Windows.Forms.CheckBox();
			this.POP_Type_Box = new System.Windows.Forms.ComboBox();
			this.LifeNeedsList = new System.Windows.Forms.ListView();
			this.EverydayNeedsList = new System.Windows.Forms.ListView();
			this.LuxuryNeedsList = new System.Windows.Forms.ListView();
			this.Income_Box = new System.Windows.Forms.TextBox();
			this.Income_Label = new System.Windows.Forms.Label();
			this.POPSize_Label = new System.Windows.Forms.Label();
			this.Size_Box = new System.Windows.Forms.TextBox();
			this.Consciousness_Box = new System.Windows.Forms.TextBox();
			this.Consciousness_Label = new System.Windows.Forms.Label();
			this.Plurality_Label = new System.Windows.Forms.Label();
			this.Plurality_Box = new System.Windows.Forms.TextBox();
			this.Base_Goods_Demand_Label = new System.Windows.Forms.Label();
			this.Base_Goods_Demand_Box = new System.Windows.Forms.TextBox();
			this.Invention_Impact_On_Demand_Box = new System.Windows.Forms.TextBox();
			this.Invention_Impact_On_Demand_Label = new System.Windows.Forms.Label();
			this.Unemployment_Benifit_Label = new System.Windows.Forms.Label();
			this.Unemployement_Benifit_Box = new System.Windows.Forms.TextBox();
			this.Administrative_Efficiency_Label = new System.Windows.Forms.Label();
			this.Administrative_Efficiency_Box = new System.Windows.Forms.TextBox();
			this.Inventions_Label = new System.Windows.Forms.Label();
			this.Inventions_Box = new System.Windows.Forms.TextBox();
			this.Total_Income_Label = new System.Windows.Forms.Label();
			this.Total_Income_Box = new System.Windows.Forms.TextBox();
			this.Effective_Tax_Label = new System.Windows.Forms.Label();
			this.Effective_Tax_Box = new System.Windows.Forms.TextBox();
			this.Tariff_Label = new System.Windows.Forms.Label();
			this.Tariffs_Box = new System.Windows.Forms.TextBox();
			this.Life_Costs_Box = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Everyday_Costs_Box = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Luxury_Costs_Box = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Life_And_Everyday_Costs_Box = new System.Windows.Forms.TextBox();
			this.Total_Costs_Box = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Life_Needs_Satisfaction_Box = new System.Windows.Forms.TextBox();
			this.Everyday_Needs_Satisfaction_Box = new System.Windows.Forms.TextBox();
			this.Luxury_Needs_Satisfaction_Box = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.PDEF_Base_Con_Box = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Unemployed_Box
			// 
			this.Unemployed_Box.AutoSize = true;
			this.Unemployed_Box.Location = new System.Drawing.Point(623, 14);
			this.Unemployed_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Unemployed_Box.Name = "Unemployed_Box";
			this.Unemployed_Box.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Unemployed_Box.Size = new System.Drawing.Size(85, 17);
			this.Unemployed_Box.TabIndex = 0;
			this.Unemployed_Box.TabStop = false;
			this.Unemployed_Box.Text = "Unemployed";
			this.Unemployed_Box.UseVisualStyleBackColor = true;
			this.Unemployed_Box.CheckedChanged += new System.EventHandler(this.Unemployed_Box_CheckedChanged);
			// 
			// POP_Type_Box
			// 
			this.POP_Type_Box.FormattingEnabled = true;
			this.POP_Type_Box.Location = new System.Drawing.Point(9, 10);
			this.POP_Type_Box.Margin = new System.Windows.Forms.Padding(2);
			this.POP_Type_Box.MaxDropDownItems = 13;
			this.POP_Type_Box.Name = "POP_Type_Box";
			this.POP_Type_Box.Size = new System.Drawing.Size(92, 21);
			this.POP_Type_Box.TabIndex = 1;
			this.POP_Type_Box.SelectedIndexChanged += new System.EventHandler(this.POP_Type_Box_SelectedIndexChanged);
			// 
			// LifeNeedsList
			// 
			this.LifeNeedsList.CheckBoxes = true;
			this.LifeNeedsList.HideSelection = false;
			this.LifeNeedsList.Location = new System.Drawing.Point(9, 205);
			this.LifeNeedsList.Margin = new System.Windows.Forms.Padding(2);
			this.LifeNeedsList.Name = "LifeNeedsList";
			this.LifeNeedsList.Size = new System.Drawing.Size(241, 385);
			this.LifeNeedsList.TabIndex = 0;
			this.LifeNeedsList.TabStop = false;
			this.LifeNeedsList.UseCompatibleStateImageBehavior = false;
			this.LifeNeedsList.View = System.Windows.Forms.View.Details;
			this.LifeNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LifeNeedsList_ItemCheck);
			// 
			// EverydayNeedsList
			// 
			this.EverydayNeedsList.CheckBoxes = true;
			this.EverydayNeedsList.HideSelection = false;
			this.EverydayNeedsList.Location = new System.Drawing.Point(268, 205);
			this.EverydayNeedsList.Margin = new System.Windows.Forms.Padding(2);
			this.EverydayNeedsList.Name = "EverydayNeedsList";
			this.EverydayNeedsList.Size = new System.Drawing.Size(241, 385);
			this.EverydayNeedsList.TabIndex = 0;
			this.EverydayNeedsList.TabStop = false;
			this.EverydayNeedsList.UseCompatibleStateImageBehavior = false;
			this.EverydayNeedsList.View = System.Windows.Forms.View.Details;
			this.EverydayNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EverydayNeedsList_ItemCheck);
			// 
			// LuxuryNeedsList
			// 
			this.LuxuryNeedsList.CheckBoxes = true;
			this.LuxuryNeedsList.HideSelection = false;
			this.LuxuryNeedsList.Location = new System.Drawing.Point(528, 205);
			this.LuxuryNeedsList.Margin = new System.Windows.Forms.Padding(2);
			this.LuxuryNeedsList.Name = "LuxuryNeedsList";
			this.LuxuryNeedsList.Size = new System.Drawing.Size(241, 385);
			this.LuxuryNeedsList.TabIndex = 0;
			this.LuxuryNeedsList.TabStop = false;
			this.LuxuryNeedsList.UseCompatibleStateImageBehavior = false;
			this.LuxuryNeedsList.View = System.Windows.Forms.View.Details;
			this.LuxuryNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LuxuryNeedsList_ItemCheck);
			// 
			// Income_Box
			// 
			this.Income_Box.Location = new System.Drawing.Point(693, 81);
			this.Income_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Income_Box.Name = "Income_Box";
			this.Income_Box.Size = new System.Drawing.Size(76, 20);
			this.Income_Box.TabIndex = 11;
			this.Income_Box.TextChanged += new System.EventHandler(this.IncomeBox_TextChanged);
			// 
			// Income_Label
			// 
			this.Income_Label.AutoSize = true;
			this.Income_Label.Location = new System.Drawing.Point(646, 84);
			this.Income_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Income_Label.Name = "Income_Label";
			this.Income_Label.Size = new System.Drawing.Size(45, 13);
			this.Income_Label.TabIndex = 0;
			this.Income_Label.Text = "Income:";
			// 
			// POPSize_Label
			// 
			this.POPSize_Label.AutoSize = true;
			this.POPSize_Label.Location = new System.Drawing.Point(138, 17);
			this.POPSize_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.POPSize_Label.Name = "POPSize_Label";
			this.POPSize_Label.Size = new System.Drawing.Size(55, 13);
			this.POPSize_Label.TabIndex = 0;
			this.POPSize_Label.Text = "POP Size:";
			// 
			// Size_Box
			// 
			this.Size_Box.Location = new System.Drawing.Point(196, 14);
			this.Size_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Size_Box.Name = "Size_Box";
			this.Size_Box.Size = new System.Drawing.Size(76, 20);
			this.Size_Box.TabIndex = 2;
			this.Size_Box.TextChanged += new System.EventHandler(this.SizeBox_TextChanged);
			// 
			// Consciousness_Box
			// 
			this.Consciousness_Box.Location = new System.Drawing.Point(196, 62);
			this.Consciousness_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Consciousness_Box.Name = "Consciousness_Box";
			this.Consciousness_Box.Size = new System.Drawing.Size(76, 20);
			this.Consciousness_Box.TabIndex = 4;
			this.Consciousness_Box.TextChanged += new System.EventHandler(this.Consciousness_Box_TextChanged);
			// 
			// Consciousness_Label
			// 
			this.Consciousness_Label.AutoSize = true;
			this.Consciousness_Label.Location = new System.Drawing.Point(112, 64);
			this.Consciousness_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Consciousness_Label.Name = "Consciousness_Label";
			this.Consciousness_Label.Size = new System.Drawing.Size(81, 13);
			this.Consciousness_Label.TabIndex = 0;
			this.Consciousness_Label.Text = "Consciousness:";
			// 
			// Plurality_Label
			// 
			this.Plurality_Label.AutoSize = true;
			this.Plurality_Label.Location = new System.Drawing.Point(146, 40);
			this.Plurality_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Plurality_Label.Name = "Plurality_Label";
			this.Plurality_Label.Size = new System.Drawing.Size(46, 13);
			this.Plurality_Label.TabIndex = 0;
			this.Plurality_Label.Text = "Plurality:";
			// 
			// Plurality_Box
			// 
			this.Plurality_Box.Location = new System.Drawing.Point(196, 38);
			this.Plurality_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Plurality_Box.Name = "Plurality_Box";
			this.Plurality_Box.Size = new System.Drawing.Size(76, 20);
			this.Plurality_Box.TabIndex = 3;
			this.Plurality_Box.TextChanged += new System.EventHandler(this.Plurality_Box_TextChanged);
			// 
			// Base_Goods_Demand_Label
			// 
			this.Base_Goods_Demand_Label.AutoSize = true;
			this.Base_Goods_Demand_Label.Location = new System.Drawing.Point(58, 113);
			this.Base_Goods_Demand_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Base_Goods_Demand_Label.Name = "Base_Goods_Demand_Label";
			this.Base_Goods_Demand_Label.Size = new System.Drawing.Size(136, 13);
			this.Base_Goods_Demand_Label.TabIndex = 0;
			this.Base_Goods_Demand_Label.Text = "BASE_GOODS_DEMAND:";
			// 
			// Base_Goods_Demand_Box
			// 
			this.Base_Goods_Demand_Box.Location = new System.Drawing.Point(196, 110);
			this.Base_Goods_Demand_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Base_Goods_Demand_Box.Name = "Base_Goods_Demand_Box";
			this.Base_Goods_Demand_Box.Size = new System.Drawing.Size(76, 20);
			this.Base_Goods_Demand_Box.TabIndex = 6;
			this.Base_Goods_Demand_Box.TextChanged += new System.EventHandler(this.Base_Goods_Demand_Box_TextChanged);
			// 
			// Invention_Impact_On_Demand_Box
			// 
			this.Invention_Impact_On_Demand_Box.Location = new System.Drawing.Point(196, 132);
			this.Invention_Impact_On_Demand_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Invention_Impact_On_Demand_Box.Name = "Invention_Impact_On_Demand_Box";
			this.Invention_Impact_On_Demand_Box.Size = new System.Drawing.Size(76, 20);
			this.Invention_Impact_On_Demand_Box.TabIndex = 7;
			this.Invention_Impact_On_Demand_Box.TextChanged += new System.EventHandler(this.Invention_Impact_On_Demand_Box_TextChanged);
			// 
			// Invention_Impact_On_Demand_Label
			// 
			this.Invention_Impact_On_Demand_Label.AutoSize = true;
			this.Invention_Impact_On_Demand_Label.Location = new System.Drawing.Point(3, 135);
			this.Invention_Impact_On_Demand_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Invention_Impact_On_Demand_Label.Name = "Invention_Impact_On_Demand_Label";
			this.Invention_Impact_On_Demand_Label.Size = new System.Drawing.Size(190, 13);
			this.Invention_Impact_On_Demand_Label.TabIndex = 0;
			this.Invention_Impact_On_Demand_Label.Text = "INVENTION_IMPACT_ON_DEMAND:";
			// 
			// Unemployment_Benifit_Label
			// 
			this.Unemployment_Benifit_Label.AutoSize = true;
			this.Unemployment_Benifit_Label.Location = new System.Drawing.Point(571, 38);
			this.Unemployment_Benifit_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Unemployment_Benifit_Label.Name = "Unemployment_Benifit_Label";
			this.Unemployment_Benifit_Label.Size = new System.Drawing.Size(118, 13);
			this.Unemployment_Benifit_Label.TabIndex = 0;
			this.Unemployment_Benifit_Label.Text = "Unemployement Benifit:";
			// 
			// Unemployement_Benifit_Box
			// 
			this.Unemployement_Benifit_Box.Location = new System.Drawing.Point(693, 36);
			this.Unemployement_Benifit_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Unemployement_Benifit_Box.Name = "Unemployement_Benifit_Box";
			this.Unemployement_Benifit_Box.Size = new System.Drawing.Size(76, 20);
			this.Unemployement_Benifit_Box.TabIndex = 9;
			this.Unemployement_Benifit_Box.TextChanged += new System.EventHandler(this.Unemployement_Benifit_Box_TextChanged);
			// 
			// Administrative_Efficiency_Label
			// 
			this.Administrative_Efficiency_Label.AutoSize = true;
			this.Administrative_Efficiency_Label.Location = new System.Drawing.Point(566, 61);
			this.Administrative_Efficiency_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Administrative_Efficiency_Label.Name = "Administrative_Efficiency_Label";
			this.Administrative_Efficiency_Label.Size = new System.Drawing.Size(124, 13);
			this.Administrative_Efficiency_Label.TabIndex = 0;
			this.Administrative_Efficiency_Label.Text = "Administrative Efficiency:";
			// 
			// Administrative_Efficiency_Box
			// 
			this.Administrative_Efficiency_Box.Location = new System.Drawing.Point(693, 58);
			this.Administrative_Efficiency_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Administrative_Efficiency_Box.Name = "Administrative_Efficiency_Box";
			this.Administrative_Efficiency_Box.Size = new System.Drawing.Size(76, 20);
			this.Administrative_Efficiency_Box.TabIndex = 10;
			this.Administrative_Efficiency_Box.TextChanged += new System.EventHandler(this.Administrative_Efficiency_Box_TextChanged);
			// 
			// Inventions_Label
			// 
			this.Inventions_Label.AutoSize = true;
			this.Inventions_Label.Location = new System.Drawing.Point(133, 158);
			this.Inventions_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Inventions_Label.Name = "Inventions_Label";
			this.Inventions_Label.Size = new System.Drawing.Size(59, 13);
			this.Inventions_Label.TabIndex = 0;
			this.Inventions_Label.Text = "Inventions:";
			// 
			// Inventions_Box
			// 
			this.Inventions_Box.Location = new System.Drawing.Point(196, 155);
			this.Inventions_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Inventions_Box.Name = "Inventions_Box";
			this.Inventions_Box.Size = new System.Drawing.Size(76, 20);
			this.Inventions_Box.TabIndex = 8;
			this.Inventions_Box.TextChanged += new System.EventHandler(this.Inventions_Box_TextChanged);
			// 
			// Total_Income_Label
			// 
			this.Total_Income_Label.AutoSize = true;
			this.Total_Income_Label.Location = new System.Drawing.Point(619, 151);
			this.Total_Income_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Total_Income_Label.Name = "Total_Income_Label";
			this.Total_Income_Label.Size = new System.Drawing.Size(72, 13);
			this.Total_Income_Label.TabIndex = 0;
			this.Total_Income_Label.Text = "Total Income:";
			// 
			// Total_Income_Box
			// 
			this.Total_Income_Box.Location = new System.Drawing.Point(693, 149);
			this.Total_Income_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Total_Income_Box.Name = "Total_Income_Box";
			this.Total_Income_Box.ReadOnly = true;
			this.Total_Income_Box.Size = new System.Drawing.Size(76, 20);
			this.Total_Income_Box.TabIndex = 0;
			this.Total_Income_Box.TabStop = false;
			// 
			// Effective_Tax_Label
			// 
			this.Effective_Tax_Label.AutoSize = true;
			this.Effective_Tax_Label.Location = new System.Drawing.Point(619, 106);
			this.Effective_Tax_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Effective_Tax_Label.Name = "Effective_Tax_Label";
			this.Effective_Tax_Label.Size = new System.Drawing.Size(73, 13);
			this.Effective_Tax_Label.TabIndex = 0;
			this.Effective_Tax_Label.Text = "Effective Tax:";
			// 
			// Effective_Tax_Box
			// 
			this.Effective_Tax_Box.Location = new System.Drawing.Point(693, 104);
			this.Effective_Tax_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Effective_Tax_Box.Name = "Effective_Tax_Box";
			this.Effective_Tax_Box.Size = new System.Drawing.Size(76, 20);
			this.Effective_Tax_Box.TabIndex = 12;
			this.Effective_Tax_Box.TextChanged += new System.EventHandler(this.Effective_Tax_Box_TextChanged);
			// 
			// Tariff_Label
			// 
			this.Tariff_Label.AutoSize = true;
			this.Tariff_Label.Location = new System.Drawing.Point(650, 128);
			this.Tariff_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Tariff_Label.Name = "Tariff_Label";
			this.Tariff_Label.Size = new System.Drawing.Size(39, 13);
			this.Tariff_Label.TabIndex = 0;
			this.Tariff_Label.Text = "Tariffs:";
			// 
			// Tariffs_Box
			// 
			this.Tariffs_Box.Location = new System.Drawing.Point(693, 126);
			this.Tariffs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Tariffs_Box.Name = "Tariffs_Box";
			this.Tariffs_Box.Size = new System.Drawing.Size(76, 20);
			this.Tariffs_Box.TabIndex = 13;
			this.Tariffs_Box.TextChanged += new System.EventHandler(this.Tariffs_Box_TextChanged);
			// 
			// Life_Costs_Box
			// 
			this.Life_Costs_Box.Location = new System.Drawing.Point(49, 178);
			this.Life_Costs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Life_Costs_Box.Name = "Life_Costs_Box";
			this.Life_Costs_Box.ReadOnly = true;
			this.Life_Costs_Box.Size = new System.Drawing.Size(76, 20);
			this.Life_Costs_Box.TabIndex = 0;
			this.Life_Costs_Box.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 180);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Costs:";
			// 
			// Everyday_Costs_Box
			// 
			this.Everyday_Costs_Box.Location = new System.Drawing.Point(305, 178);
			this.Everyday_Costs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Everyday_Costs_Box.Name = "Everyday_Costs_Box";
			this.Everyday_Costs_Box.ReadOnly = true;
			this.Everyday_Costs_Box.Size = new System.Drawing.Size(76, 20);
			this.Everyday_Costs_Box.TabIndex = 0;
			this.Everyday_Costs_Box.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(266, 180);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Costs:";
			// 
			// Luxury_Costs_Box
			// 
			this.Luxury_Costs_Box.Location = new System.Drawing.Point(566, 178);
			this.Luxury_Costs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Luxury_Costs_Box.Name = "Luxury_Costs_Box";
			this.Luxury_Costs_Box.ReadOnly = true;
			this.Luxury_Costs_Box.Size = new System.Drawing.Size(76, 20);
			this.Luxury_Costs_Box.TabIndex = 0;
			this.Luxury_Costs_Box.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(526, 180);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Costs:";
			// 
			// Life_And_Everyday_Costs_Box
			// 
			this.Life_And_Everyday_Costs_Box.Location = new System.Drawing.Point(385, 178);
			this.Life_And_Everyday_Costs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Life_And_Everyday_Costs_Box.Name = "Life_And_Everyday_Costs_Box";
			this.Life_And_Everyday_Costs_Box.ReadOnly = true;
			this.Life_And_Everyday_Costs_Box.Size = new System.Drawing.Size(76, 20);
			this.Life_And_Everyday_Costs_Box.TabIndex = 0;
			this.Life_And_Everyday_Costs_Box.TabStop = false;
			// 
			// Total_Costs_Box
			// 
			this.Total_Costs_Box.Location = new System.Drawing.Point(645, 178);
			this.Total_Costs_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Total_Costs_Box.Name = "Total_Costs_Box";
			this.Total_Costs_Box.ReadOnly = true;
			this.Total_Costs_Box.Size = new System.Drawing.Size(76, 20);
			this.Total_Costs_Box.TabIndex = 0;
			this.Total_Costs_Box.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(391, 40);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Satisfaction";
			// 
			// Life_Needs_Satisfaction_Box
			// 
			this.Life_Needs_Satisfaction_Box.Location = new System.Drawing.Point(385, 61);
			this.Life_Needs_Satisfaction_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Life_Needs_Satisfaction_Box.Name = "Life_Needs_Satisfaction_Box";
			this.Life_Needs_Satisfaction_Box.ReadOnly = true;
			this.Life_Needs_Satisfaction_Box.Size = new System.Drawing.Size(76, 20);
			this.Life_Needs_Satisfaction_Box.TabIndex = 0;
			this.Life_Needs_Satisfaction_Box.TabStop = false;
			// 
			// Everyday_Needs_Satisfaction_Box
			// 
			this.Everyday_Needs_Satisfaction_Box.Location = new System.Drawing.Point(385, 84);
			this.Everyday_Needs_Satisfaction_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Everyday_Needs_Satisfaction_Box.Name = "Everyday_Needs_Satisfaction_Box";
			this.Everyday_Needs_Satisfaction_Box.ReadOnly = true;
			this.Everyday_Needs_Satisfaction_Box.Size = new System.Drawing.Size(76, 20);
			this.Everyday_Needs_Satisfaction_Box.TabIndex = 0;
			this.Everyday_Needs_Satisfaction_Box.TabStop = false;
			// 
			// Luxury_Needs_Satisfaction_Box
			// 
			this.Luxury_Needs_Satisfaction_Box.Location = new System.Drawing.Point(385, 106);
			this.Luxury_Needs_Satisfaction_Box.Margin = new System.Windows.Forms.Padding(2);
			this.Luxury_Needs_Satisfaction_Box.Name = "Luxury_Needs_Satisfaction_Box";
			this.Luxury_Needs_Satisfaction_Box.ReadOnly = true;
			this.Luxury_Needs_Satisfaction_Box.Size = new System.Drawing.Size(76, 20);
			this.Luxury_Needs_Satisfaction_Box.TabIndex = 0;
			this.Luxury_Needs_Satisfaction_Box.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(320, 63);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Life Needs:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(306, 109);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Luxury Needs:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(293, 86);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Everyday Needs:";
			// 
			// PDEF_Base_Con_Box
			// 
			this.PDEF_Base_Con_Box.Location = new System.Drawing.Point(196, 86);
			this.PDEF_Base_Con_Box.Margin = new System.Windows.Forms.Padding(2);
			this.PDEF_Base_Con_Box.Name = "PDEF_Base_Con_Box";
			this.PDEF_Base_Con_Box.Size = new System.Drawing.Size(76, 20);
			this.PDEF_Base_Con_Box.TabIndex = 5;
			this.PDEF_Base_Con_Box.TextChanged += new System.EventHandler(this.PDEF_Base_Con_Box_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(93, 89);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(101, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "PDEF_BASE_CON:";
			// 
			// POP_form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 599);
			this.Controls.Add(this.PDEF_Base_Con_Box);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Luxury_Needs_Satisfaction_Box);
			this.Controls.Add(this.Everyday_Needs_Satisfaction_Box);
			this.Controls.Add(this.Life_Needs_Satisfaction_Box);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Total_Costs_Box);
			this.Controls.Add(this.Life_And_Everyday_Costs_Box);
			this.Controls.Add(this.Luxury_Costs_Box);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Everyday_Costs_Box);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Life_Costs_Box);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Tariff_Label);
			this.Controls.Add(this.Tariffs_Box);
			this.Controls.Add(this.Effective_Tax_Label);
			this.Controls.Add(this.Effective_Tax_Box);
			this.Controls.Add(this.Total_Income_Box);
			this.Controls.Add(this.Total_Income_Label);
			this.Controls.Add(this.Inventions_Box);
			this.Controls.Add(this.Inventions_Label);
			this.Controls.Add(this.Administrative_Efficiency_Box);
			this.Controls.Add(this.Administrative_Efficiency_Label);
			this.Controls.Add(this.Unemployement_Benifit_Box);
			this.Controls.Add(this.Unemployment_Benifit_Label);
			this.Controls.Add(this.Invention_Impact_On_Demand_Box);
			this.Controls.Add(this.Invention_Impact_On_Demand_Label);
			this.Controls.Add(this.Base_Goods_Demand_Box);
			this.Controls.Add(this.Base_Goods_Demand_Label);
			this.Controls.Add(this.Plurality_Label);
			this.Controls.Add(this.Plurality_Box);
			this.Controls.Add(this.Consciousness_Label);
			this.Controls.Add(this.Consciousness_Box);
			this.Controls.Add(this.Size_Box);
			this.Controls.Add(this.POPSize_Label);
			this.Controls.Add(this.Income_Label);
			this.Controls.Add(this.Income_Box);
			this.Controls.Add(this.LuxuryNeedsList);
			this.Controls.Add(this.EverydayNeedsList);
			this.Controls.Add(this.LifeNeedsList);
			this.Controls.Add(this.POP_Type_Box);
			this.Controls.Add(this.Unemployed_Box);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "POP_form";
			this.Text = "POP";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Unemployed_Box;
        private System.Windows.Forms.ComboBox POP_Type_Box;
        private System.Windows.Forms.ListView LifeNeedsList;
        private System.Windows.Forms.ListView EverydayNeedsList;
        private System.Windows.Forms.ListView LuxuryNeedsList;
        private System.Windows.Forms.TextBox Income_Box;
        private System.Windows.Forms.Label Income_Label;
        private System.Windows.Forms.Label POPSize_Label;
        private System.Windows.Forms.TextBox Size_Box;
        private System.Windows.Forms.TextBox Consciousness_Box;
        private System.Windows.Forms.Label Consciousness_Label;
        private System.Windows.Forms.Label Plurality_Label;
        private System.Windows.Forms.TextBox Plurality_Box;
        private System.Windows.Forms.Label Base_Goods_Demand_Label;
        private System.Windows.Forms.TextBox Base_Goods_Demand_Box;
        private System.Windows.Forms.TextBox Invention_Impact_On_Demand_Box;
        private System.Windows.Forms.Label Invention_Impact_On_Demand_Label;
        private System.Windows.Forms.Label Unemployment_Benifit_Label;
        private System.Windows.Forms.TextBox Unemployement_Benifit_Box;
        private System.Windows.Forms.Label Administrative_Efficiency_Label;
        private System.Windows.Forms.TextBox Administrative_Efficiency_Box;
        private System.Windows.Forms.Label Inventions_Label;
        private System.Windows.Forms.TextBox Inventions_Box;
        private System.Windows.Forms.Label Total_Income_Label;
        private System.Windows.Forms.TextBox Total_Income_Box;
        private System.Windows.Forms.Label Effective_Tax_Label;
        private System.Windows.Forms.TextBox Effective_Tax_Box;
        private System.Windows.Forms.Label Tariff_Label;
        private System.Windows.Forms.TextBox Tariffs_Box;
        private System.Windows.Forms.TextBox Life_Costs_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Everyday_Costs_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Luxury_Costs_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Life_And_Everyday_Costs_Box;
        private System.Windows.Forms.TextBox Total_Costs_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Life_Needs_Satisfaction_Box;
        private System.Windows.Forms.TextBox Everyday_Needs_Satisfaction_Box;
        private System.Windows.Forms.TextBox Luxury_Needs_Satisfaction_Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox PDEF_Base_Con_Box;
		private System.Windows.Forms.Label label8;
	}
}