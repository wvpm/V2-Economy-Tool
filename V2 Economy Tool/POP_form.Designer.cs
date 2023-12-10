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
            this.SuspendLayout();
            // 
            // Unemployed_Box
            // 
            this.Unemployed_Box.AutoSize = true;
            this.Unemployed_Box.Location = new System.Drawing.Point(831, 17);
            this.Unemployed_Box.Name = "Unemployed_Box";
            this.Unemployed_Box.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Unemployed_Box.Size = new System.Drawing.Size(109, 21);
            this.Unemployed_Box.TabIndex = 0;
            this.Unemployed_Box.TabStop = false;
            this.Unemployed_Box.Text = "Unemployed";
            this.Unemployed_Box.UseVisualStyleBackColor = true;
            this.Unemployed_Box.CheckedChanged += new System.EventHandler(this.Unemployed_Box_CheckedChanged);
            // 
            // POP_Type_Box
            // 
            this.POP_Type_Box.FormattingEnabled = true;
            this.POP_Type_Box.Location = new System.Drawing.Point(12, 12);
            this.POP_Type_Box.MaxDropDownItems = 13;
            this.POP_Type_Box.Name = "POP_Type_Box";
            this.POP_Type_Box.Size = new System.Drawing.Size(121, 24);
            this.POP_Type_Box.TabIndex = 1;
            this.POP_Type_Box.SelectedIndexChanged += new System.EventHandler(this.POP_Type_Box_SelectedIndexChanged);
            // 
            // LifeNeedsList
            // 
            this.LifeNeedsList.CheckBoxes = true;
            this.LifeNeedsList.Location = new System.Drawing.Point(12, 252);
            this.LifeNeedsList.Name = "LifeNeedsList";
            this.LifeNeedsList.Size = new System.Drawing.Size(320, 473);
            this.LifeNeedsList.TabIndex = 0;
            this.LifeNeedsList.TabStop = false;
            this.LifeNeedsList.UseCompatibleStateImageBehavior = false;
            this.LifeNeedsList.View = System.Windows.Forms.View.Details;
            this.LifeNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LifeNeedsList_ItemCheck);
            // 
            // EverydayNeedsList
            // 
            this.EverydayNeedsList.CheckBoxes = true;
            this.EverydayNeedsList.Location = new System.Drawing.Point(357, 252);
            this.EverydayNeedsList.Name = "EverydayNeedsList";
            this.EverydayNeedsList.Size = new System.Drawing.Size(320, 473);
            this.EverydayNeedsList.TabIndex = 0;
            this.EverydayNeedsList.TabStop = false;
            this.EverydayNeedsList.UseCompatibleStateImageBehavior = false;
            this.EverydayNeedsList.View = System.Windows.Forms.View.Details;
            this.EverydayNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EverydayNeedsList_ItemCheck);
            // 
            // LuxuryNeedsList
            // 
            this.LuxuryNeedsList.CheckBoxes = true;
            this.LuxuryNeedsList.Location = new System.Drawing.Point(704, 252);
            this.LuxuryNeedsList.Name = "LuxuryNeedsList";
            this.LuxuryNeedsList.Size = new System.Drawing.Size(320, 473);
            this.LuxuryNeedsList.TabIndex = 0;
            this.LuxuryNeedsList.TabStop = false;
            this.LuxuryNeedsList.UseCompatibleStateImageBehavior = false;
            this.LuxuryNeedsList.View = System.Windows.Forms.View.Details;
            this.LuxuryNeedsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LuxuryNeedsList_ItemCheck);
            // 
            // Income_Box
            // 
            this.Income_Box.Location = new System.Drawing.Point(924, 100);
            this.Income_Box.Name = "Income_Box";
            this.Income_Box.Size = new System.Drawing.Size(100, 22);
            this.Income_Box.TabIndex = 10;
            this.Income_Box.TextChanged += new System.EventHandler(this.IncomeBox_TextChanged);
            // 
            // Income_Label
            // 
            this.Income_Label.AutoSize = true;
            this.Income_Label.Location = new System.Drawing.Point(861, 103);
            this.Income_Label.Name = "Income_Label";
            this.Income_Label.Size = new System.Drawing.Size(57, 17);
            this.Income_Label.TabIndex = 0;
            this.Income_Label.Text = "Income:";
            // 
            // POPSize_Label
            // 
            this.POPSize_Label.AutoSize = true;
            this.POPSize_Label.Location = new System.Drawing.Point(184, 44);
            this.POPSize_Label.Name = "POPSize_Label";
            this.POPSize_Label.Size = new System.Drawing.Size(72, 17);
            this.POPSize_Label.TabIndex = 0;
            this.POPSize_Label.Text = "POP Size:";
            // 
            // Size_Box
            // 
            this.Size_Box.Location = new System.Drawing.Point(262, 41);
            this.Size_Box.Name = "Size_Box";
            this.Size_Box.Size = new System.Drawing.Size(100, 22);
            this.Size_Box.TabIndex = 2;
            this.Size_Box.TextChanged += new System.EventHandler(this.SizeBox_TextChanged);
            // 
            // Consciousness_Box
            // 
            this.Consciousness_Box.Location = new System.Drawing.Point(262, 69);
            this.Consciousness_Box.Name = "Consciousness_Box";
            this.Consciousness_Box.Size = new System.Drawing.Size(100, 22);
            this.Consciousness_Box.TabIndex = 3;
            this.Consciousness_Box.TextChanged += new System.EventHandler(this.Consciousness_Box_TextChanged);
            // 
            // Consciousness_Label
            // 
            this.Consciousness_Label.AutoSize = true;
            this.Consciousness_Label.Location = new System.Drawing.Point(149, 72);
            this.Consciousness_Label.Name = "Consciousness_Label";
            this.Consciousness_Label.Size = new System.Drawing.Size(107, 17);
            this.Consciousness_Label.TabIndex = 0;
            this.Consciousness_Label.Text = "Consciousness:";
            // 
            // Plurality_Label
            // 
            this.Plurality_Label.AutoSize = true;
            this.Plurality_Label.Location = new System.Drawing.Point(194, 100);
            this.Plurality_Label.Name = "Plurality_Label";
            this.Plurality_Label.Size = new System.Drawing.Size(62, 17);
            this.Plurality_Label.TabIndex = 0;
            this.Plurality_Label.Text = "Plurality:";
            // 
            // Plurality_Box
            // 
            this.Plurality_Box.Location = new System.Drawing.Point(262, 97);
            this.Plurality_Box.Name = "Plurality_Box";
            this.Plurality_Box.Size = new System.Drawing.Size(100, 22);
            this.Plurality_Box.TabIndex = 4;
            this.Plurality_Box.TextChanged += new System.EventHandler(this.Plurality_Box_TextChanged);
            // 
            // Base_Goods_Demand_Label
            // 
            this.Base_Goods_Demand_Label.AutoSize = true;
            this.Base_Goods_Demand_Label.Location = new System.Drawing.Point(81, 128);
            this.Base_Goods_Demand_Label.Name = "Base_Goods_Demand_Label";
            this.Base_Goods_Demand_Label.Size = new System.Drawing.Size(175, 17);
            this.Base_Goods_Demand_Label.TabIndex = 0;
            this.Base_Goods_Demand_Label.Text = "BASE_GOODS_DEMAND:";
            // 
            // Base_Goods_Demand_Box
            // 
            this.Base_Goods_Demand_Box.Location = new System.Drawing.Point(262, 125);
            this.Base_Goods_Demand_Box.Name = "Base_Goods_Demand_Box";
            this.Base_Goods_Demand_Box.Size = new System.Drawing.Size(100, 22);
            this.Base_Goods_Demand_Box.TabIndex = 5;
            this.Base_Goods_Demand_Box.TextChanged += new System.EventHandler(this.Base_Goods_Demand_Box_TextChanged);
            // 
            // Invention_Impact_On_Demand_Box
            // 
            this.Invention_Impact_On_Demand_Box.Location = new System.Drawing.Point(262, 153);
            this.Invention_Impact_On_Demand_Box.Name = "Invention_Impact_On_Demand_Box";
            this.Invention_Impact_On_Demand_Box.Size = new System.Drawing.Size(100, 22);
            this.Invention_Impact_On_Demand_Box.TabIndex = 6;
            this.Invention_Impact_On_Demand_Box.TextChanged += new System.EventHandler(this.Invention_Impact_On_Demand_Box_TextChanged);
            // 
            // Invention_Impact_On_Demand_Label
            // 
            this.Invention_Impact_On_Demand_Label.AutoSize = true;
            this.Invention_Impact_On_Demand_Label.Location = new System.Drawing.Point(16, 156);
            this.Invention_Impact_On_Demand_Label.Name = "Invention_Impact_On_Demand_Label";
            this.Invention_Impact_On_Demand_Label.Size = new System.Drawing.Size(240, 17);
            this.Invention_Impact_On_Demand_Label.TabIndex = 0;
            this.Invention_Impact_On_Demand_Label.Text = "INVENTION_IMPACT_ON_DEMAND:";
            // 
            // Unemployment_Benifit_Label
            // 
            this.Unemployment_Benifit_Label.AutoSize = true;
            this.Unemployment_Benifit_Label.Location = new System.Drawing.Point(761, 47);
            this.Unemployment_Benifit_Label.Name = "Unemployment_Benifit_Label";
            this.Unemployment_Benifit_Label.Size = new System.Drawing.Size(157, 17);
            this.Unemployment_Benifit_Label.TabIndex = 0;
            this.Unemployment_Benifit_Label.Text = "Unemployement Benifit:";
            // 
            // Unemployement_Benifit_Box
            // 
            this.Unemployement_Benifit_Box.Location = new System.Drawing.Point(924, 44);
            this.Unemployement_Benifit_Box.Name = "Unemployement_Benifit_Box";
            this.Unemployement_Benifit_Box.Size = new System.Drawing.Size(100, 22);
            this.Unemployement_Benifit_Box.TabIndex = 8;
            this.Unemployement_Benifit_Box.TextChanged += new System.EventHandler(this.Unemployement_Benifit_Box_TextChanged);
            // 
            // Administrative_Efficiency_Label
            // 
            this.Administrative_Efficiency_Label.AutoSize = true;
            this.Administrative_Efficiency_Label.Location = new System.Drawing.Point(754, 75);
            this.Administrative_Efficiency_Label.Name = "Administrative_Efficiency_Label";
            this.Administrative_Efficiency_Label.Size = new System.Drawing.Size(164, 17);
            this.Administrative_Efficiency_Label.TabIndex = 0;
            this.Administrative_Efficiency_Label.Text = "Administrative Efficiency:";
            // 
            // Administrative_Efficiency_Box
            // 
            this.Administrative_Efficiency_Box.Location = new System.Drawing.Point(924, 72);
            this.Administrative_Efficiency_Box.Name = "Administrative_Efficiency_Box";
            this.Administrative_Efficiency_Box.Size = new System.Drawing.Size(100, 22);
            this.Administrative_Efficiency_Box.TabIndex = 9;
            this.Administrative_Efficiency_Box.TextChanged += new System.EventHandler(this.Administrative_Efficiency_Box_TextChanged);
            // 
            // Inventions_Label
            // 
            this.Inventions_Label.AutoSize = true;
            this.Inventions_Label.Location = new System.Drawing.Point(180, 184);
            this.Inventions_Label.Name = "Inventions_Label";
            this.Inventions_Label.Size = new System.Drawing.Size(76, 17);
            this.Inventions_Label.TabIndex = 0;
            this.Inventions_Label.Text = "Inventions:";
            // 
            // Inventions_Box
            // 
            this.Inventions_Box.Location = new System.Drawing.Point(262, 181);
            this.Inventions_Box.Name = "Inventions_Box";
            this.Inventions_Box.Size = new System.Drawing.Size(100, 22);
            this.Inventions_Box.TabIndex = 7;
            this.Inventions_Box.TextChanged += new System.EventHandler(this.Inventions_Box_TextChanged);
            // 
            // Total_Income_Label
            // 
            this.Total_Income_Label.AutoSize = true;
            this.Total_Income_Label.Location = new System.Drawing.Point(825, 186);
            this.Total_Income_Label.Name = "Total_Income_Label";
            this.Total_Income_Label.Size = new System.Drawing.Size(93, 17);
            this.Total_Income_Label.TabIndex = 0;
            this.Total_Income_Label.Text = "Total Income:";
            // 
            // Total_Income_Box
            // 
            this.Total_Income_Box.Location = new System.Drawing.Point(924, 183);
            this.Total_Income_Box.Name = "Total_Income_Box";
            this.Total_Income_Box.ReadOnly = true;
            this.Total_Income_Box.Size = new System.Drawing.Size(100, 22);
            this.Total_Income_Box.TabIndex = 24;
            this.Total_Income_Box.TabStop = false;
            // 
            // Effective_Tax_Label
            // 
            this.Effective_Tax_Label.AutoSize = true;
            this.Effective_Tax_Label.Location = new System.Drawing.Point(825, 131);
            this.Effective_Tax_Label.Name = "Effective_Tax_Label";
            this.Effective_Tax_Label.Size = new System.Drawing.Size(93, 17);
            this.Effective_Tax_Label.TabIndex = 0;
            this.Effective_Tax_Label.Text = "Effective Tax:";
            // 
            // Effective_Tax_Box
            // 
            this.Effective_Tax_Box.Location = new System.Drawing.Point(924, 128);
            this.Effective_Tax_Box.Name = "Effective_Tax_Box";
            this.Effective_Tax_Box.Size = new System.Drawing.Size(100, 22);
            this.Effective_Tax_Box.TabIndex = 11;
            this.Effective_Tax_Box.TextChanged += new System.EventHandler(this.Effective_Tax_Box_TextChanged);
            // 
            // Tariff_Label
            // 
            this.Tariff_Label.AutoSize = true;
            this.Tariff_Label.Location = new System.Drawing.Point(866, 158);
            this.Tariff_Label.Name = "Tariff_Label";
            this.Tariff_Label.Size = new System.Drawing.Size(52, 17);
            this.Tariff_Label.TabIndex = 0;
            this.Tariff_Label.Text = "Tariffs:";
            // 
            // Tariffs_Box
            // 
            this.Tariffs_Box.Location = new System.Drawing.Point(924, 155);
            this.Tariffs_Box.Name = "Tariffs_Box";
            this.Tariffs_Box.Size = new System.Drawing.Size(100, 22);
            this.Tariffs_Box.TabIndex = 12;
            this.Tariffs_Box.TextChanged += new System.EventHandler(this.Tariffs_Box_TextChanged);
            // 
            // Life_Costs_Box
            // 
            this.Life_Costs_Box.Location = new System.Drawing.Point(65, 219);
            this.Life_Costs_Box.Name = "Life_Costs_Box";
            this.Life_Costs_Box.ReadOnly = true;
            this.Life_Costs_Box.Size = new System.Drawing.Size(100, 22);
            this.Life_Costs_Box.TabIndex = 0;
            this.Life_Costs_Box.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Costs:";
            // 
            // Everyday_Costs_Box
            // 
            this.Everyday_Costs_Box.Location = new System.Drawing.Point(407, 219);
            this.Everyday_Costs_Box.Name = "Everyday_Costs_Box";
            this.Everyday_Costs_Box.ReadOnly = true;
            this.Everyday_Costs_Box.Size = new System.Drawing.Size(100, 22);
            this.Everyday_Costs_Box.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Costs:";
            // 
            // Luxury_Costs_Box
            // 
            this.Luxury_Costs_Box.Location = new System.Drawing.Point(754, 219);
            this.Luxury_Costs_Box.Name = "Luxury_Costs_Box";
            this.Luxury_Costs_Box.ReadOnly = true;
            this.Luxury_Costs_Box.Size = new System.Drawing.Size(100, 22);
            this.Luxury_Costs_Box.TabIndex = 0;
            this.Luxury_Costs_Box.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(701, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Costs:";
            // 
            // Life_And_Everyday_Costs_Box
            // 
            this.Life_And_Everyday_Costs_Box.Location = new System.Drawing.Point(513, 219);
            this.Life_And_Everyday_Costs_Box.Name = "Life_And_Everyday_Costs_Box";
            this.Life_And_Everyday_Costs_Box.ReadOnly = true;
            this.Life_And_Everyday_Costs_Box.Size = new System.Drawing.Size(100, 22);
            this.Life_And_Everyday_Costs_Box.TabIndex = 0;
            this.Life_And_Everyday_Costs_Box.TabStop = false;
            // 
            // Total_Costs_Box
            // 
            this.Total_Costs_Box.Location = new System.Drawing.Point(860, 219);
            this.Total_Costs_Box.Name = "Total_Costs_Box";
            this.Total_Costs_Box.ReadOnly = true;
            this.Total_Costs_Box.Size = new System.Drawing.Size(100, 22);
            this.Total_Costs_Box.TabIndex = 0;
            this.Total_Costs_Box.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Satisfaction";
            // 
            // Life_Needs_Satisfaction_Box
            // 
            this.Life_Needs_Satisfaction_Box.Location = new System.Drawing.Point(513, 75);
            this.Life_Needs_Satisfaction_Box.Name = "Life_Needs_Satisfaction_Box";
            this.Life_Needs_Satisfaction_Box.ReadOnly = true;
            this.Life_Needs_Satisfaction_Box.Size = new System.Drawing.Size(100, 22);
            this.Life_Needs_Satisfaction_Box.TabIndex = 25;
            this.Life_Needs_Satisfaction_Box.TabStop = false;
            // 
            // Everyday_Needs_Satisfaction_Box
            // 
            this.Everyday_Needs_Satisfaction_Box.Location = new System.Drawing.Point(513, 103);
            this.Everyday_Needs_Satisfaction_Box.Name = "Everyday_Needs_Satisfaction_Box";
            this.Everyday_Needs_Satisfaction_Box.ReadOnly = true;
            this.Everyday_Needs_Satisfaction_Box.Size = new System.Drawing.Size(100, 22);
            this.Everyday_Needs_Satisfaction_Box.TabIndex = 26;
            this.Everyday_Needs_Satisfaction_Box.TabStop = false;
            // 
            // Luxury_Needs_Satisfaction_Box
            // 
            this.Luxury_Needs_Satisfaction_Box.Location = new System.Drawing.Point(513, 131);
            this.Luxury_Needs_Satisfaction_Box.Name = "Luxury_Needs_Satisfaction_Box";
            this.Luxury_Needs_Satisfaction_Box.ReadOnly = true;
            this.Luxury_Needs_Satisfaction_Box.Size = new System.Drawing.Size(100, 22);
            this.Luxury_Needs_Satisfaction_Box.TabIndex = 27;
            this.Luxury_Needs_Satisfaction_Box.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Life Needs:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Luxury Needs:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(391, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Everyday Needs:";
            // 
            // POP_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 737);
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
    }
}