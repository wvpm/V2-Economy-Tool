namespace V2_Economy_Tool
{
    partial class Main_form
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
            this.filepath_label = new System.Windows.Forms.Label();
            this.filepath_Box = new System.Windows.Forms.TextBox();
            this.load_Button = new System.Windows.Forms.Button();
            this.GoodsList = new System.Windows.Forms.ListView();
            this.Production_typesList = new System.Windows.Forms.ListView();
            this.POP_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filepath_label
            // 
            this.filepath_label.AutoSize = true;
            this.filepath_label.Location = new System.Drawing.Point(13, 13);
            this.filepath_label.Name = "filepath_label";
            this.filepath_label.Size = new System.Drawing.Size(98, 17);
            this.filepath_label.TabIndex = 0;
            this.filepath_label.Text = "Mod directory:";
            // 
            // filepath_Box
            // 
            this.filepath_Box.Location = new System.Drawing.Point(118, 13);
            this.filepath_Box.Name = "filepath_Box";
            this.filepath_Box.Size = new System.Drawing.Size(492, 22);
            this.filepath_Box.TabIndex = 1;
            this.filepath_Box.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Victoria 2\\mod\\WVPM";
            // 
            // load_Button
            // 
            this.load_Button.Location = new System.Drawing.Point(616, 13);
            this.load_Button.Name = "load_Button";
            this.load_Button.Size = new System.Drawing.Size(75, 23);
            this.load_Button.TabIndex = 2;
            this.load_Button.Text = "Load";
            this.load_Button.UseVisualStyleBackColor = true;
            this.load_Button.Click += new System.EventHandler(this.load_Button_Click);
            // 
            // GoodsList
            // 
            this.GoodsList.Location = new System.Drawing.Point(16, 80);
            this.GoodsList.Name = "GoodsList";
            this.GoodsList.Size = new System.Drawing.Size(250, 443);
            this.GoodsList.TabIndex = 3;
            this.GoodsList.UseCompatibleStateImageBehavior = false;
            this.GoodsList.View = System.Windows.Forms.View.Details;
            this.GoodsList.SelectedIndexChanged += new System.EventHandler(this.GoodsList_SelectedIndexChanged);
            // 
            // Production_typesList
            // 
            this.Production_typesList.Location = new System.Drawing.Point(354, 80);
            this.Production_typesList.Name = "Production_typesList";
            this.Production_typesList.Size = new System.Drawing.Size(337, 443);
            this.Production_typesList.TabIndex = 4;
            this.Production_typesList.UseCompatibleStateImageBehavior = false;
            this.Production_typesList.View = System.Windows.Forms.View.Details;
            this.Production_typesList.DoubleClick += new System.EventHandler(this.Production_typesList_DoubleClick);
            // 
            // POP_Button
            // 
            this.POP_Button.Location = new System.Drawing.Point(16, 540);
            this.POP_Button.Name = "POP_Button";
            this.POP_Button.Size = new System.Drawing.Size(95, 32);
            this.POP_Button.TabIndex = 5;
            this.POP_Button.Text = "POP screen";
            this.POP_Button.UseVisualStyleBackColor = true;
            this.POP_Button.Click += new System.EventHandler(this.POP_Button_Click);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 584);
            this.Controls.Add(this.POP_Button);
            this.Controls.Add(this.Production_typesList);
            this.Controls.Add(this.GoodsList);
            this.Controls.Add(this.load_Button);
            this.Controls.Add(this.filepath_Box);
            this.Controls.Add(this.filepath_label);
            this.Name = "Main_form";
            this.Text = "V2 Economy Tool by WVPM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filepath_label;
        private System.Windows.Forms.TextBox filepath_Box;
        private System.Windows.Forms.Button load_Button;
        private System.Windows.Forms.ListView GoodsList;
        private System.Windows.Forms.ListView Production_typesList;
        private System.Windows.Forms.Button POP_Button;
    }
}

