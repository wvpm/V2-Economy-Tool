namespace V2_Economy_Tool
{
    partial class Production_type_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Output_Amount_Box = new System.Windows.Forms.TextBox();
            this.Output_Good_Box = new System.Windows.Forms.TextBox();
            this.Input_List = new System.Windows.Forms.ListView();
            this.Price_Label = new System.Windows.Forms.Label();
            this.Price_Box = new System.Windows.Forms.TextBox();
            this.Stat_Box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inputs:";
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Location = new System.Drawing.Point(406, 13);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(55, 17);
            this.Output_Label.TabIndex = 1;
            this.Output_Label.Text = "Output:";
            // 
            // Output_Amount_Box
            // 
            this.Output_Amount_Box.Location = new System.Drawing.Point(468, 13);
            this.Output_Amount_Box.Name = "Output_Amount_Box";
            this.Output_Amount_Box.ReadOnly = true;
            this.Output_Amount_Box.Size = new System.Drawing.Size(100, 22);
            this.Output_Amount_Box.TabIndex = 2;
            // 
            // Output_Good_Box
            // 
            this.Output_Good_Box.Location = new System.Drawing.Point(574, 13);
            this.Output_Good_Box.Name = "Output_Good_Box";
            this.Output_Good_Box.ReadOnly = true;
            this.Output_Good_Box.Size = new System.Drawing.Size(100, 22);
            this.Output_Good_Box.TabIndex = 3;
            // 
            // Input_List
            // 
            this.Input_List.Location = new System.Drawing.Point(17, 42);
            this.Input_List.Name = "Input_List";
            this.Input_List.Size = new System.Drawing.Size(364, 475);
            this.Input_List.TabIndex = 4;
            this.Input_List.UseCompatibleStateImageBehavior = false;
            this.Input_List.View = System.Windows.Forms.View.Details;
            // 
            // Price_Label
            // 
            this.Price_Label.AutoSize = true;
            this.Price_Label.Location = new System.Drawing.Point(409, 42);
            this.Price_Label.Name = "Price_Label";
            this.Price_Label.Size = new System.Drawing.Size(44, 17);
            this.Price_Label.TabIndex = 5;
            this.Price_Label.Text = "Price:";
            // 
            // Price_Box
            // 
            this.Price_Box.Location = new System.Drawing.Point(468, 42);
            this.Price_Box.Name = "Price_Box";
            this.Price_Box.ReadOnly = true;
            this.Price_Box.Size = new System.Drawing.Size(100, 22);
            this.Price_Box.TabIndex = 6;
            // 
            // Stat_Box
            // 
            this.Stat_Box.Location = new System.Drawing.Point(412, 93);
            this.Stat_Box.Multiline = true;
            this.Stat_Box.Name = "Stat_Box";
            this.Stat_Box.Size = new System.Drawing.Size(261, 424);
            this.Stat_Box.TabIndex = 7;
            // 
            // Production_type_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 550);
            this.Controls.Add(this.Stat_Box);
            this.Controls.Add(this.Price_Box);
            this.Controls.Add(this.Price_Label);
            this.Controls.Add(this.Input_List);
            this.Controls.Add(this.Output_Good_Box);
            this.Controls.Add(this.Output_Amount_Box);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.label1);
            this.Name = "Production_type_form";
            this.Text = "Production_type_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.TextBox Output_Amount_Box;
        private System.Windows.Forms.TextBox Output_Good_Box;
        private System.Windows.Forms.ListView Input_List;
        private System.Windows.Forms.Label Price_Label;
        private System.Windows.Forms.TextBox Price_Box;
        private System.Windows.Forms.TextBox Stat_Box;
    }
}