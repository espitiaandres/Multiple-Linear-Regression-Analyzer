namespace MultipleLinearRegressionFantasyBasketballGUI
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.browseRawDataFileButton = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.createAllSpreadSheetsAndPlotsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(393, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1255, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fantasy Basketball 2018-2019 Multiple Linear Regression";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(738, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Raw Data File with average stats: (FG%, FT%...)";
            // 
            // browseRawDataFileButton
            // 
            this.browseRawDataFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.browseRawDataFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.browseRawDataFileButton.Location = new System.Drawing.Point(403, 208);
            this.browseRawDataFileButton.Name = "browseRawDataFileButton";
            this.browseRawDataFileButton.Size = new System.Drawing.Size(1245, 55);
            this.browseRawDataFileButton.TabIndex = 2;
            this.browseRawDataFileButton.Text = "Browse Raw Data File (Must Have Dashes Between Words!)";
            this.browseRawDataFileButton.UseVisualStyleBackColor = true;
            this.browseRawDataFileButton.Click += new System.EventHandler(this.browseRawDataFileButton_Click);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.domainUpDown1.Location = new System.Drawing.Point(81, 307);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(1880, 35);
            this.domainUpDown1.TabIndex = 3;
            this.domainUpDown1.Text = "File Name";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // createAllSpreadSheetsAndPlotsButton
            // 
            this.createAllSpreadSheetsAndPlotsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createAllSpreadSheetsAndPlotsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createAllSpreadSheetsAndPlotsButton.Location = new System.Drawing.Point(391, 419);
            this.createAllSpreadSheetsAndPlotsButton.Name = "createAllSpreadSheetsAndPlotsButton";
            this.createAllSpreadSheetsAndPlotsButton.Size = new System.Drawing.Size(1245, 55);
            this.createAllSpreadSheetsAndPlotsButton.TabIndex = 4;
            this.createAllSpreadSheetsAndPlotsButton.Text = "Click to create all Spreadsheets and Plots";
            this.createAllSpreadSheetsAndPlotsButton.UseVisualStyleBackColor = true;
            this.createAllSpreadSheetsAndPlotsButton.Click += new System.EventHandler(this.createAllSpreadSheetsAndPlotsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(403, 619);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1245, 658);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(493, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1057, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "The Raw Data File entered should look similar to this (where x1, x2, are the regr" +
    "essors and so on):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(2041, 1346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.createAllSpreadSheetsAndPlotsButton);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.browseRawDataFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.AliceBlue;
            this.Name = "Form1";
            this.Text = "Multiple Linear Regression Fantasy Basketball GUI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseRawDataFileButton;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Button createAllSpreadSheetsAndPlotsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

