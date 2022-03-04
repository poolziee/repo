
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblRestock = new System.Windows.Forms.Label();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbVerifyNewPassword = new System.Windows.Forms.TextBox();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlRestock = new System.Windows.Forms.Panel();
            this.lblTotalRestockCost = new System.Windows.Forms.Label();
            this.btnEditAmount = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbRestockRequests = new System.Windows.Forms.ListBox();
            this.pnlItems = new System.Windows.Forms.Panel();
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
            this.btnAutoOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlNavbar.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlRestock.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Controls.Add(this.lblAccount);
            this.pnlNavbar.Controls.Add(this.lblItems);
            this.pnlNavbar.Controls.Add(this.lblRestock);
            this.pnlNavbar.Controls.Add(this.lblStatistics);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(674, 48);
            this.pnlNavbar.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(250, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.Black;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAccount.Location = new System.Drawing.Point(543, 11);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(90, 26);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Account";
            this.lblAccount.Click += new System.EventHandler(this.lblAccount_Click);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.BackColor = System.Drawing.Color.Black;
            this.lblItems.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblItems.ForeColor = System.Drawing.SystemColors.Control;
            this.lblItems.Location = new System.Drawing.Point(10, 11);
            this.lblItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(65, 26);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Items";
            this.lblItems.Click += new System.EventHandler(this.lblItems_Click);
            // 
            // lblRestock
            // 
            this.lblRestock.AutoSize = true;
            this.lblRestock.BackColor = System.Drawing.Color.Black;
            this.lblRestock.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRestock.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRestock.Location = new System.Drawing.Point(427, 11);
            this.lblRestock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRestock.Name = "lblRestock";
            this.lblRestock.Size = new System.Drawing.Size(86, 26);
            this.lblRestock.TabIndex = 3;
            this.lblRestock.Text = "Restock";
            this.lblRestock.Click += new System.EventHandler(this.lblRestock_Click);
            // 
            // lblStatistics
            // 
            this.lblStatistics.AutoSize = true;
            this.lblStatistics.BackColor = System.Drawing.Color.Black;
            this.lblStatistics.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatistics.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStatistics.Location = new System.Drawing.Point(122, 12);
            this.lblStatistics.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(98, 26);
            this.lblStatistics.TabIndex = 2;
            this.lblStatistics.Text = "Statistics";
            this.lblStatistics.Click += new System.EventHandler(this.lblStatistics_Click);
            // 
            // pnlAccount
            // 
            this.pnlAccount.Controls.Add(this.btnAutoOrder);
            this.pnlAccount.Controls.Add(this.btnLogOut);
            this.pnlAccount.Controls.Add(this.btnChangePassword);
            this.pnlAccount.Controls.Add(this.lblConfirmNewPassword);
            this.pnlAccount.Controls.Add(this.label4);
            this.pnlAccount.Controls.Add(this.lblNewPassword);
            this.pnlAccount.Controls.Add(this.tbVerifyNewPassword);
            this.pnlAccount.Controls.Add(this.tbCurrentPassword);
            this.pnlAccount.Controls.Add(this.tbNewPassword);
            this.pnlAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccount.Location = new System.Drawing.Point(0, 48);
            this.pnlAccount.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(674, 504);
            this.pnlAccount.TabIndex = 18;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(24, 247);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(217, 28);
            this.btnLogOut.TabIndex = 17;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnChangePassword.Location = new System.Drawing.Point(24, 196);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(217, 28);
            this.btnChangePassword.TabIndex = 16;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(21, 132);
            this.lblConfirmNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(156, 17);
            this.lblConfirmNewPassword.TabIndex = 13;
            this.lblConfirmNewPassword.Text = "Confirm New Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(21, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Current Password:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNewPassword.Location = new System.Drawing.Point(21, 78);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(104, 17);
            this.lblNewPassword.TabIndex = 15;
            this.lblNewPassword.Text = "New Password:";
            // 
            // tbVerifyNewPassword
            // 
            this.tbVerifyNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbVerifyNewPassword.Location = new System.Drawing.Point(24, 150);
            this.tbVerifyNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbVerifyNewPassword.Name = "tbVerifyNewPassword";
            this.tbVerifyNewPassword.PasswordChar = '*';
            this.tbVerifyNewPassword.Size = new System.Drawing.Size(218, 23);
            this.tbVerifyNewPassword.TabIndex = 10;
            this.tbVerifyNewPassword.UseSystemPasswordChar = true;
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbCurrentPassword.Location = new System.Drawing.Point(24, 42);
            this.tbCurrentPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.Size = new System.Drawing.Size(218, 23);
            this.tbCurrentPassword.TabIndex = 11;
            this.tbCurrentPassword.UseSystemPasswordChar = true;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNewPassword.Location = new System.Drawing.Point(24, 97);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(218, 23);
            this.tbNewPassword.TabIndex = 12;
            this.tbNewPassword.UseSystemPasswordChar = true;
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Controls.Add(this.label3);
            this.pnlStatistics.Controls.Add(this.label2);
            this.pnlStatistics.Controls.Add(this.chart2);
            this.pnlStatistics.Controls.Add(this.chart1);
            this.pnlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatistics.Location = new System.Drawing.Point(0, 0);
            this.pnlStatistics.Margin = new System.Windows.Forms.Padding(2);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(674, 552);
            this.pnlStatistics.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(405, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Most Expensive Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(70, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Most Sold Items";
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(390, 77);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(225, 244);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(40, 77);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(225, 244);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // pnlRestock
            // 
            this.pnlRestock.Controls.Add(this.lblTotalRestockCost);
            this.pnlRestock.Controls.Add(this.btnEditAmount);
            this.pnlRestock.Controls.Add(this.btnConfirm);
            this.pnlRestock.Controls.Add(this.lbRestockRequests);
            this.pnlRestock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRestock.Location = new System.Drawing.Point(0, 0);
            this.pnlRestock.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRestock.Name = "pnlRestock";
            this.pnlRestock.Size = new System.Drawing.Size(674, 552);
            this.pnlRestock.TabIndex = 9;
            // 
            // lblTotalRestockCost
            // 
            this.lblTotalRestockCost.AutoSize = true;
            this.lblTotalRestockCost.Location = new System.Drawing.Point(77, 419);
            this.lblTotalRestockCost.Name = "lblTotalRestockCost";
            this.lblTotalRestockCost.Size = new System.Drawing.Size(57, 13);
            this.lblTotalRestockCost.TabIndex = 10;
            this.lblTotalRestockCost.Text = "Total cost:";
            // 
            // btnEditAmount
            // 
            this.btnEditAmount.Location = new System.Drawing.Point(450, 417);
            this.btnEditAmount.Name = "btnEditAmount";
            this.btnEditAmount.Size = new System.Drawing.Size(139, 31);
            this.btnEditAmount.TabIndex = 9;
            this.btnEditAmount.Text = "Edit Amount";
            this.btnEditAmount.UseVisualStyleBackColor = true;
            this.btnEditAmount.Click += new System.EventHandler(this.btnEditAmount_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(55, 434);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(280, 32);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbRestockRequests
            // 
            this.lbRestockRequests.FormattingEnabled = true;
            this.lbRestockRequests.Location = new System.Drawing.Point(55, 109);
            this.lbRestockRequests.Margin = new System.Windows.Forms.Padding(2);
            this.lbRestockRequests.Name = "lbRestockRequests";
            this.lbRestockRequests.Size = new System.Drawing.Size(536, 303);
            this.lbRestockRequests.TabIndex = 7;
            // 
            // pnlItems
            // 
            this.pnlItems.BackColor = System.Drawing.SystemColors.Info;
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
            this.pnlItems.Size = new System.Drawing.Size(674, 552);
            this.pnlItems.TabIndex = 13;
            this.pnlItems.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlItems_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(534, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Brand :";
            // 
            // cbBrand
            // 
            this.cbBrand.Enabled = false;
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(537, 51);
            this.cbBrand.Margin = new System.Windows.Forms.Padding(2);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(117, 21);
            this.cbBrand.TabIndex = 18;
            this.cbBrand.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // cbSubcategory
            // 
            this.cbSubcategory.Enabled = false;
            this.cbSubcategory.FormattingEnabled = true;
            this.cbSubcategory.Location = new System.Drawing.Point(408, 51);
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
            this.label5.Location = new System.Drawing.Point(404, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subcategory :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.PeachPuff;
            this.btnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditItem.Location = new System.Drawing.Point(277, 153);
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
            this.btnAddItem.BackColor = System.Drawing.Color.PeachPuff;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Location = new System.Drawing.Point(277, 117);
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
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(277, 51);
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
            this.label1.Location = new System.Drawing.Point(273, 29);
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
            this.lbItems.Location = new System.Drawing.Point(2, 222);
            this.lbItems.Margin = new System.Windows.Forms.Padding(2);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(666, 228);
            this.lbItems.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.Location = new System.Drawing.Point(2, 200);
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
            // btnAutoOrder
            // 
            this.btnAutoOrder.AutoSize = true;
            this.btnAutoOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAutoOrder.Depth = 0;
            this.btnAutoOrder.Icon = null;
            this.btnAutoOrder.Location = new System.Drawing.Point(440, 85);
            this.btnAutoOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAutoOrder.Name = "btnAutoOrder";
            this.btnAutoOrder.Primary = true;
            this.btnAutoOrder.Size = new System.Drawing.Size(104, 36);
            this.btnAutoOrder.TabIndex = 18;
            this.btnAutoOrder.Text = "Auto Order";
            this.btnAutoOrder.UseVisualStyleBackColor = true;
            this.btnAutoOrder.Click += new System.EventHandler(this.btnAutoOrder_Click);
            // 
            // WRHSHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 552);
            this.Controls.Add(this.pnlAccount);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlRestock);
            this.Controls.Add(this.pnlStatistics);
            this.Controls.Add(this.pnlItems);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WRHSHome";
            this.Text = "WRHSHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WRHSHome_FormClosing_1);
            this.Load += new System.EventHandler(this.WRHSHome_Load);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlAccount.ResumeLayout(false);
            this.pnlAccount.PerformLayout();
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlRestock.ResumeLayout(false);
            this.pnlRestock.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblRestock;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlAccount;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbVerifyNewPassword;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
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
        private MaterialSkin.Controls.MaterialRaisedButton btnAutoOrder;
    }
}