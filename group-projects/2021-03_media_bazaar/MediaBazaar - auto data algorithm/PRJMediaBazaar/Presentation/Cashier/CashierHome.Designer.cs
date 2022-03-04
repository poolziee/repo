
namespace PRJMediaBazaar
{
    partial class CashierHome
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
            this.lbScannedItems = new System.Windows.Forms.ListBox();
            this.lbAllItems = new System.Windows.Forms.ListBox();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbSubcategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScannedItems
            // 
            this.lbScannedItems.FormattingEnabled = true;
            this.lbScannedItems.Location = new System.Drawing.Point(12, 112);
            this.lbScannedItems.Name = "lbScannedItems";
            this.lbScannedItems.Size = new System.Drawing.Size(384, 329);
            this.lbScannedItems.TabIndex = 0;
            // 
            // lbAllItems
            // 
            this.lbAllItems.FormattingEnabled = true;
            this.lbAllItems.Location = new System.Drawing.Point(441, 112);
            this.lbAllItems.Name = "lbAllItems";
            this.lbAllItems.Size = new System.Drawing.Size(381, 329);
            this.lbAllItems.TabIndex = 1;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.lblLogOut);
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Location = new System.Drawing.Point(-2, -2);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(855, 47);
            this.pnlNavbar.TabIndex = 7;
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.BackColor = System.Drawing.Color.Black;
            this.lblLogOut.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLogOut.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLogOut.Location = new System.Drawing.Point(742, 11);
            this.lblLogOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(102, 30);
            this.lblLogOut.TabIndex = 1;
            this.lblLogOut.Text = "Log Out";
            this.lblLogOut.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(362, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(441, 85);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(143, 21);
            this.cbCategory.TabIndex = 8;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // cbSubcategory
            // 
            this.cbSubcategory.FormattingEnabled = true;
            this.cbSubcategory.Location = new System.Drawing.Point(592, 85);
            this.cbSubcategory.Name = "cbSubcategory";
            this.cbSubcategory.Size = new System.Drawing.Size(143, 21);
            this.cbSubcategory.TabIndex = 9;
            this.cbSubcategory.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(590, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Subcategory :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(438, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Quantity :";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(508, 444);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(52, 20);
            this.tbQuantity.TabIndex = 14;
            this.tbQuantity.ValueChanged += new System.EventHandler(this.tbQuantity_ValueChanged);
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(441, 470);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(294, 37);
            this.btnScan.TabIndex = 15;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 448);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(88, 16);
            this.lblTotalPrice.TabIndex = 16;
            this.lblTotalPrice.Text = "Total Price:";
            // 
            // btnSell
            // 
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.Location = new System.Drawing.Point(12, 470);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(294, 37);
            this.btnSell.TabIndex = 17;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Scanned Items :";
            // 
            // CashierHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 540);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSubcategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.lbAllItems);
            this.Controls.Add(this.lbScannedItems);
            this.Name = "CashierHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockerHome_FormClosing);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScannedItems;
        private System.Windows.Forms.ListBox lbAllItems;
        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Label lblLogOut;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbSubcategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tbQuantity;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label6;
    }
}