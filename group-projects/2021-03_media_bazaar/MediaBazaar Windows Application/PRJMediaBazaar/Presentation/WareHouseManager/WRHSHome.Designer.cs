
namespace PRJMediaBazaar
{
    partial class WRHSHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WRHSHome));
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblRestock = new System.Windows.Forms.Label();
            this.pnlRestock = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalRestockCost = new System.Windows.Forms.Label();
            this.btnEditAmount = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbRestockRequests = new System.Windows.Forms.ListBox();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.cbSubcategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlRestock.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.pnlNavbar.Controls.Add(this.pictureBox1);
            this.pnlNavbar.Controls.Add(this.label2);
            this.pnlNavbar.Controls.Add(this.lblTitle1);
            this.pnlNavbar.Controls.Add(this.lblItems);
            this.pnlNavbar.Controls.Add(this.lblRestock);
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(674, 48);
            this.pnlNavbar.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(626, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(83, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 30);
            this.label2.TabIndex = 36;
            this.label2.Text = "BAZAAR";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle1.Location = new System.Drawing.Point(0, 9);
            this.lblTitle1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(90, 30);
            this.lblTitle1.TabIndex = 35;
            this.lblTitle1.Text = "MEDIA";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblItems.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblItems.ForeColor = System.Drawing.SystemColors.Control;
            this.lblItems.Location = new System.Drawing.Point(424, 12);
            this.lblItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(49, 20);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Items";
            this.lblItems.Click += new System.EventHandler(this.lblItems_Click);
            // 
            // lblRestock
            // 
            this.lblRestock.AutoSize = true;
            this.lblRestock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblRestock.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRestock.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRestock.Location = new System.Drawing.Point(515, 12);
            this.lblRestock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRestock.Name = "lblRestock";
            this.lblRestock.Size = new System.Drawing.Size(67, 20);
            this.lblRestock.TabIndex = 3;
            this.lblRestock.Text = "Restock";
            this.lblRestock.Click += new System.EventHandler(this.lblRestock_Click);
            // 
            // pnlRestock
            // 
            this.pnlRestock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlRestock.Controls.Add(this.label6);
            this.pnlRestock.Controls.Add(this.lblTotalRestockCost);
            this.pnlRestock.Controls.Add(this.btnEditAmount);
            this.pnlRestock.Controls.Add(this.btnConfirm);
            this.pnlRestock.Controls.Add(this.lbRestockRequests);
            this.pnlRestock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRestock.Location = new System.Drawing.Point(0, 0);
            this.pnlRestock.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRestock.Name = "pnlRestock";
            this.pnlRestock.Size = new System.Drawing.Size(674, 591);
            this.pnlRestock.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(455, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "*Here you will see the Restock Requests sent by the stokers !\r\n";
            // 
            // lblTotalRestockCost
            // 
            this.lblTotalRestockCost.AutoSize = true;
            this.lblTotalRestockCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRestockCost.Location = new System.Drawing.Point(31, 466);
            this.lblTotalRestockCost.Name = "lblTotalRestockCost";
            this.lblTotalRestockCost.Size = new System.Drawing.Size(82, 20);
            this.lblTotalRestockCost.TabIndex = 10;
            this.lblTotalRestockCost.Text = "Total cost:";
            // 
            // btnEditAmount
            // 
            this.btnEditAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnEditAmount.FlatAppearance.BorderSize = 0;
            this.btnEditAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAmount.Location = new System.Drawing.Point(497, 440);
            this.btnEditAmount.Name = "btnEditAmount";
            this.btnEditAmount.Size = new System.Drawing.Size(139, 31);
            this.btnEditAmount.TabIndex = 9;
            this.btnEditAmount.Text = "Edit Amount";
            this.btnEditAmount.UseVisualStyleBackColor = false;
            this.btnEditAmount.Click += new System.EventHandler(this.btnEditAmount_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(30, 486);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(606, 32);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbRestockRequests
            // 
            this.lbRestockRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestockRequests.FormattingEnabled = true;
            this.lbRestockRequests.HorizontalScrollbar = true;
            this.lbRestockRequests.ItemHeight = 18;
            this.lbRestockRequests.Location = new System.Drawing.Point(30, 142);
            this.lbRestockRequests.Margin = new System.Windows.Forms.Padding(2);
            this.lbRestockRequests.Name = "lbRestockRequests";
            this.lbRestockRequests.Size = new System.Drawing.Size(606, 274);
            this.lbRestockRequests.TabIndex = 7;
            // 
            // pnlItems
            // 
            this.pnlItems.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlItems.Controls.Add(this.label10);
            this.pnlItems.Controls.Add(this.label8);
            this.pnlItems.Controls.Add(this.cbBrand);
            this.pnlItems.Controls.Add(this.cbSubcategory);
            this.pnlItems.Controls.Add(this.label5);
            this.pnlItems.Controls.Add(this.btnEditItem);
            this.pnlItems.Controls.Add(this.btnAddItem);
            this.pnlItems.Controls.Add(this.cbCategories);
            this.pnlItems.Controls.Add(this.label1);
            this.pnlItems.Controls.Add(this.lbItems);
            this.pnlItems.Controls.Add(this.lblInfo);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 0);
            this.pnlItems.Margin = new System.Windows.Forms.Padding(2);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(674, 591);
            this.pnlItems.TabIndex = 13;
            this.pnlItems.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlItems_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(641, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "X";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(516, 133);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Brand :";
            // 
            // cbBrand
            // 
            this.cbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBrand.Enabled = false;
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(519, 151);
            this.cbBrand.Margin = new System.Windows.Forms.Padding(2);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(117, 21);
            this.cbBrand.TabIndex = 18;
            this.cbBrand.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // cbSubcategory
            // 
            this.cbSubcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSubcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSubcategory.Enabled = false;
            this.cbSubcategory.FormattingEnabled = true;
            this.cbSubcategory.Location = new System.Drawing.Point(397, 151);
            this.cbSubcategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubcategory.Name = "cbSubcategory";
            this.cbSubcategory.Size = new System.Drawing.Size(117, 21);
            this.cbSubcategory.TabIndex = 17;
            this.cbSubcategory.SelectedIndexChanged += new System.EventHandler(this.cbSubcategory_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(397, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subcategory :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnEditItem.FlatAppearance.BorderSize = 0;
            this.btnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(277, 222);
            this.btnEditItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(235, 22);
            this.btnEditItem.TabIndex = 12;
            this.btnEditItem.Text = "Edit Current Item";
            this.btnEditItem.UseVisualStyleBackColor = false;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(277, 187);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(235, 22);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add a New Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCategories.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(276, 151);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(117, 21);
            this.cbCategories.TabIndex = 10;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(273, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category :";
            // 
            // lbItems
            // 
            this.lbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.HorizontalScrollbar = true;
            this.lbItems.ItemHeight = 16;
            this.lbItems.Location = new System.Drawing.Point(5, 290);
            this.lbItems.Margin = new System.Windows.Forms.Padding(2);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(666, 196);
            this.lbItems.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.Location = new System.Drawing.Point(2, 268);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(111, 20);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Information :";
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // WRHSHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(674, 591);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlRestock);
            this.Controls.Add(this.pnlItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "WRHSHome";
            this.Text = "WRHSHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WRHSHome_FormClosing_1);
            this.Load += new System.EventHandler(this.WRHSHome_Load);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlRestock.ResumeLayout(false);
            this.pnlRestock.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblRestock;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Panel pnlRestock;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListBox lbRestockRequests;
        private System.Windows.Forms.Timer godTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.ComboBox cbSubcategory;
        private System.Windows.Forms.Label lblTotalRestockCost;
        private System.Windows.Forms.Button btnEditAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle1;
    }
}