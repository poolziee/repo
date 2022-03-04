
namespace PRJMediaBazaar
{
    partial class StockerHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockerHome));
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblexpectedRestocks = new System.Windows.Forms.Label();
            this.lblWaitingList = new System.Windows.Forms.Label();
            this.lblRR = new System.Windows.Forms.Label();
            this.lblRefill = new System.Windows.Forms.Label();
            this.pnlWaitingList = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMissingStockArrived = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lbWL = new System.Windows.Forms.ListBox();
            this.pnRR = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSpacesInShop = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnMoveItems = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendRestocks = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lbRestocks = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pnlExpectedRestocks = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tbActuallyArrived = new System.Windows.Forms.TextBox();
            this.btnQNotAll = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnQArrived = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lbExpRestocks = new System.Windows.Forms.ListBox();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlWaitingList.SuspendLayout();
            this.pnRR.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlExpectedRestocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.pnlNavbar.Controls.Add(this.pictureBox1);
            this.pnlNavbar.Controls.Add(this.label8);
            this.pnlNavbar.Controls.Add(this.lblTitle1);
            this.pnlNavbar.Controls.Add(this.lblexpectedRestocks);
            this.pnlNavbar.Controls.Add(this.lblWaitingList);
            this.pnlNavbar.Controls.Add(this.lblRR);
            this.pnlNavbar.Controls.Add(this.lblRefill);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(984, 48);
            this.pnlNavbar.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(914, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.label8.Location = new System.Drawing.Point(83, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 30);
            this.label8.TabIndex = 34;
            this.label8.Text = "BAZAAR";
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
            this.lblTitle1.TabIndex = 33;
            this.lblTitle1.Text = "MEDIA";
            // 
            // lblexpectedRestocks
            // 
            this.lblexpectedRestocks.AutoSize = true;
            this.lblexpectedRestocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblexpectedRestocks.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblexpectedRestocks.ForeColor = System.Drawing.SystemColors.Control;
            this.lblexpectedRestocks.Location = new System.Drawing.Point(760, 17);
            this.lblexpectedRestocks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblexpectedRestocks.Name = "lblexpectedRestocks";
            this.lblexpectedRestocks.Size = new System.Drawing.Size(121, 20);
            this.lblexpectedRestocks.TabIndex = 32;
            this.lblexpectedRestocks.Text = "Expected Items";
            this.lblexpectedRestocks.Click += new System.EventHandler(this.lblexpectedRestocks_Click);
            // 
            // lblWaitingList
            // 
            this.lblWaitingList.AutoSize = true;
            this.lblWaitingList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblWaitingList.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWaitingList.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWaitingList.Location = new System.Drawing.Point(554, 16);
            this.lblWaitingList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWaitingList.Name = "lblWaitingList";
            this.lblWaitingList.Size = new System.Drawing.Size(94, 20);
            this.lblWaitingList.TabIndex = 31;
            this.lblWaitingList.Text = "Waiting List";
            this.lblWaitingList.Click += new System.EventHandler(this.lblWaitingList_Click);
            // 
            // lblRR
            // 
            this.lblRR.AutoSize = true;
            this.lblRR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblRR.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRR.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRR.Location = new System.Drawing.Point(374, 16);
            this.lblRR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRR.Name = "lblRR";
            this.lblRR.Size = new System.Drawing.Size(138, 20);
            this.lblRR.TabIndex = 30;
            this.lblRR.Text = "Restock Requests";
            this.lblRR.Click += new System.EventHandler(this.lblRR_Click);
            // 
            // lblRefill
            // 
            this.lblRefill.AutoSize = true;
            this.lblRefill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblRefill.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRefill.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRefill.Location = new System.Drawing.Point(687, 16);
            this.lblRefill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRefill.Name = "lblRefill";
            this.lblRefill.Size = new System.Drawing.Size(45, 20);
            this.lblRefill.TabIndex = 29;
            this.lblRefill.Text = "Refill";
            this.lblRefill.Click += new System.EventHandler(this.lblRefill_Click);
            // 
            // pnlWaitingList
            // 
            this.pnlWaitingList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlWaitingList.Controls.Add(this.label9);
            this.pnlWaitingList.Controls.Add(this.btnMissingStockArrived);
            this.pnlWaitingList.Controls.Add(this.lbWL);
            this.pnlWaitingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWaitingList.Location = new System.Drawing.Point(0, 0);
            this.pnlWaitingList.Name = "pnlWaitingList";
            this.pnlWaitingList.Size = new System.Drawing.Size(984, 643);
            this.pnlWaitingList.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(157, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Items on waiting list: ";
            // 
            // btnMissingStockArrived
            // 
            this.btnMissingStockArrived.AutoSize = true;
            this.btnMissingStockArrived.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMissingStockArrived.Depth = 0;
            this.btnMissingStockArrived.Icon = null;
            this.btnMissingStockArrived.Location = new System.Drawing.Point(408, 519);
            this.btnMissingStockArrived.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMissingStockArrived.Name = "btnMissingStockArrived";
            this.btnMissingStockArrived.Primary = true;
            this.btnMissingStockArrived.Size = new System.Drawing.Size(124, 36);
            this.btnMissingStockArrived.TabIndex = 2;
            this.btnMissingStockArrived.Text = "Stock Arrived";
            this.btnMissingStockArrived.UseVisualStyleBackColor = true;
            this.btnMissingStockArrived.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // lbWL
            // 
            this.lbWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWL.FormattingEnabled = true;
            this.lbWL.HorizontalScrollbar = true;
            this.lbWL.ItemHeight = 18;
            this.lbWL.Location = new System.Drawing.Point(160, 118);
            this.lbWL.Name = "lbWL";
            this.lbWL.Size = new System.Drawing.Size(648, 364);
            this.lbWL.TabIndex = 0;
            // 
            // pnRR
            // 
            this.pnRR.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnRR.Controls.Add(this.label4);
            this.pnRR.Controls.Add(this.label2);
            this.pnRR.Controls.Add(this.label1);
            this.pnRR.Controls.Add(this.lbSpacesInShop);
            this.pnRR.Controls.Add(this.materialLabel1);
            this.pnRR.Controls.Add(this.btnMoveItems);
            this.pnRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRR.Location = new System.Drawing.Point(0, 0);
            this.pnRR.Name = "pnRR";
            this.pnRR.Size = new System.Drawing.Size(984, 643);
            this.pnRR.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "↓";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 51);
            this.label2.TabIndex = 17;
            this.label2.Text = "*By clicking the button you are moving items from the\r\nwarehouse to the shelves, " +
    "thus influencing the amount \r\ndisplayed in the shop !\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "*The items that appear here are either DEPLETED or are CLOSE to depletion !";
            // 
            // lbSpacesInShop
            // 
            this.lbSpacesInShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpacesInShop.FormattingEnabled = true;
            this.lbSpacesInShop.HorizontalScrollbar = true;
            this.lbSpacesInShop.ItemHeight = 18;
            this.lbSpacesInShop.Location = new System.Drawing.Point(207, 193);
            this.lbSpacesInShop.Name = "lbSpacesInShop";
            this.lbSpacesInShop.Size = new System.Drawing.Size(548, 220);
            this.lbSpacesInShop.TabIndex = 9;
            this.lbSpacesInShop.SelectedIndexChanged += new System.EventHandler(this.lbSpacesInShop_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(306, 151);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(243, 19);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Replenish those items for the shop";
            // 
            // btnMoveItems
            // 
            this.btnMoveItems.AutoSize = true;
            this.btnMoveItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveItems.Depth = 0;
            this.btnMoveItems.Icon = null;
            this.btnMoveItems.Location = new System.Drawing.Point(409, 443);
            this.btnMoveItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveItems.Name = "btnMoveItems";
            this.btnMoveItems.Primary = true;
            this.btnMoveItems.Size = new System.Drawing.Size(103, 36);
            this.btnMoveItems.TabIndex = 15;
            this.btnMoveItems.Text = "Move items";
            this.btnMoveItems.UseVisualStyleBackColor = true;
            this.btnMoveItems.Click += new System.EventHandler(this.btnMoveItems_Click);
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlDashboard.Controls.Add(this.label7);
            this.pnlDashboard.Controls.Add(this.label5);
            this.pnlDashboard.Controls.Add(this.label6);
            this.pnlDashboard.Controls.Add(this.label3);
            this.pnlDashboard.Controls.Add(this.btnSendRestocks);
            this.pnlDashboard.Controls.Add(this.lbRestocks);
            this.pnlDashboard.Controls.Add(this.materialLabel2);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 48);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(984, 595);
            this.pnlDashboard.TabIndex = 13;
            this.pnlDashboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDashboard_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(600, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 37);
            this.label7.TabIndex = 28;
            this.label7.Text = "↲";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(602, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 26);
            this.label5.TabIndex = 26;
            this.label5.Text = "↓";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(307, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(384, 34);
            this.label6.TabIndex = 27;
            this.label6.Text = "BY CLICKING THE BUTTON YOU CONFIRM THE SENDING\r\nOF THE RESTOCK REQUEST TO THE MAN" +
    "AGER !";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(441, 36);
            this.label3.TabIndex = 25;
            this.label3.Text = "*Items that appear here have been checked by the system\r\nand were deemed as resto" +
    "ckable !";
            // 
            // btnSendRestocks
            // 
            this.btnSendRestocks.AutoSize = true;
            this.btnSendRestocks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendRestocks.Depth = 0;
            this.btnSendRestocks.Icon = null;
            this.btnSendRestocks.Location = new System.Drawing.Point(408, 513);
            this.btnSendRestocks.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendRestocks.Name = "btnSendRestocks";
            this.btnSendRestocks.Primary = true;
            this.btnSendRestocks.Size = new System.Drawing.Size(182, 36);
            this.btnSendRestocks.TabIndex = 24;
            this.btnSendRestocks.Text = "Send Restock Request";
            this.btnSendRestocks.UseVisualStyleBackColor = true;
            this.btnSendRestocks.Click += new System.EventHandler(this.btnSendRestocks_Click_1);
            // 
            // lbRestocks
            // 
            this.lbRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestocks.FormattingEnabled = true;
            this.lbRestocks.HorizontalScrollbar = true;
            this.lbRestocks.ItemHeight = 16;
            this.lbRestocks.Location = new System.Drawing.Point(36, 206);
            this.lbRestocks.Name = "lbRestocks";
            this.lbRestocks.Size = new System.Drawing.Size(917, 244);
            this.lbRestocks.TabIndex = 22;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(347, 149);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(258, 19);
            this.materialLabel2.TabIndex = 23;
            this.materialLabel2.Text = "Send restock request for these items";
            // 
            // pnlExpectedRestocks
            // 
            this.pnlExpectedRestocks.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlExpectedRestocks.Controls.Add(this.label10);
            this.pnlExpectedRestocks.Controls.Add(this.lbQuantity);
            this.pnlExpectedRestocks.Controls.Add(this.btnConfirm);
            this.pnlExpectedRestocks.Controls.Add(this.tbActuallyArrived);
            this.pnlExpectedRestocks.Controls.Add(this.btnQNotAll);
            this.pnlExpectedRestocks.Controls.Add(this.btnQArrived);
            this.pnlExpectedRestocks.Controls.Add(this.lbExpRestocks);
            this.pnlExpectedRestocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExpectedRestocks.Location = new System.Drawing.Point(0, 0);
            this.pnlExpectedRestocks.Name = "pnlExpectedRestocks";
            this.pnlExpectedRestocks.Size = new System.Drawing.Size(984, 643);
            this.pnlExpectedRestocks.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Expected Restocks:";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(590, 254);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(142, 18);
            this.lbQuantity.TabIndex = 11;
            this.lbQuantity.Text = "Quantity that arrived:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(593, 293);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(271, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tbActuallyArrived
            // 
            this.tbActuallyArrived.Location = new System.Drawing.Point(775, 256);
            this.tbActuallyArrived.Name = "tbActuallyArrived";
            this.tbActuallyArrived.Size = new System.Drawing.Size(139, 20);
            this.tbActuallyArrived.TabIndex = 3;
            // 
            // btnQNotAll
            // 
            this.btnQNotAll.AutoSize = true;
            this.btnQNotAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQNotAll.Depth = 0;
            this.btnQNotAll.Icon = null;
            this.btnQNotAll.Location = new System.Drawing.Point(593, 189);
            this.btnQNotAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQNotAll.Name = "btnQNotAll";
            this.btnQNotAll.Primary = true;
            this.btnQNotAll.Size = new System.Drawing.Size(205, 36);
            this.btnQNotAll.TabIndex = 2;
            this.btnQNotAll.Text = "not all quantity arrived";
            this.btnQNotAll.UseVisualStyleBackColor = true;
            this.btnQNotAll.Click += new System.EventHandler(this.btnQNotAll_Click);
            // 
            // btnQArrived
            // 
            this.btnQArrived.AutoSize = true;
            this.btnQArrived.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQArrived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(151)))), ((int)(((byte)(172)))));
            this.btnQArrived.Depth = 0;
            this.btnQArrived.Icon = null;
            this.btnQArrived.Location = new System.Drawing.Point(593, 129);
            this.btnQArrived.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQArrived.Name = "btnQArrived";
            this.btnQArrived.Primary = true;
            this.btnQArrived.Size = new System.Drawing.Size(174, 36);
            this.btnQArrived.TabIndex = 1;
            this.btnQArrived.Text = "all quantity arrived";
            this.btnQArrived.UseVisualStyleBackColor = false;
            this.btnQArrived.Click += new System.EventHandler(this.btnQArrived_Click);
            // 
            // lbExpRestocks
            // 
            this.lbExpRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpRestocks.FormattingEnabled = true;
            this.lbExpRestocks.HorizontalScrollbar = true;
            this.lbExpRestocks.ItemHeight = 18;
            this.lbExpRestocks.Location = new System.Drawing.Point(12, 101);
            this.lbExpRestocks.Name = "lbExpRestocks";
            this.lbExpRestocks.Size = new System.Drawing.Size(547, 508);
            this.lbExpRestocks.TabIndex = 0;
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // StockerHome
            // 
            this.ClientSize = new System.Drawing.Size(984, 643);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlWaitingList);
            this.Controls.Add(this.pnlExpectedRestocks);
            this.Controls.Add(this.pnRR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StockerHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockerHome_FormClosing);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlWaitingList.ResumeLayout(false);
            this.pnlWaitingList.PerformLayout();
            this.pnRR.ResumeLayout(false);
            this.pnRR.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.pnlExpectedRestocks.ResumeLayout(false);
            this.pnlExpectedRestocks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.ListBox lbSpacesInShop;
        private MaterialSkin.Controls.MaterialRaisedButton btnMoveItems;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel pnRR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton btnSendRestocks;
        private System.Windows.Forms.ListBox lbRestocks;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Label lblRR;
        private System.Windows.Forms.Label lblRefill;
        private System.Windows.Forms.Label lblWaitingList;
        private System.Windows.Forms.Panel pnlWaitingList;
        private MaterialSkin.Controls.MaterialRaisedButton btnMissingStockArrived;
        private System.Windows.Forms.ListBox lbWL;
        private System.Windows.Forms.Label lblexpectedRestocks;
        private System.Windows.Forms.Panel pnlExpectedRestocks;
        private MaterialSkin.Controls.MaterialRaisedButton btnQNotAll;
        private MaterialSkin.Controls.MaterialRaisedButton btnQArrived;
        private System.Windows.Forms.ListBox lbExpRestocks;
        private System.Windows.Forms.TextBox tbActuallyArrived;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Timer godTimer;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}