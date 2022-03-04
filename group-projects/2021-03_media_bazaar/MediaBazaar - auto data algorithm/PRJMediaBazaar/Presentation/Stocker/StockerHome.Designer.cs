
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
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.btnSendRestocks = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMoveItems = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lbRestocks = new System.Windows.Forms.ListBox();
            this.lbSpacesInShop = new System.Windows.Forms.ListBox();
            this.pnlNavbar.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlNavbar.Controls.Add(this.lblTitle);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1308, 48);
            this.pnlNavbar.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(528, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Media Bazaar";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.btnSendRestocks);
            this.pnlDashboard.Controls.Add(this.btnMoveItems);
            this.pnlDashboard.Controls.Add(this.materialLabel2);
            this.pnlDashboard.Controls.Add(this.materialLabel1);
            this.pnlDashboard.Controls.Add(this.lbRestocks);
            this.pnlDashboard.Controls.Add(this.lbSpacesInShop);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1308, 369);
            this.pnlDashboard.TabIndex = 13;
            // 
            // btnSendRestocks
            // 
            this.btnSendRestocks.AutoSize = true;
            this.btnSendRestocks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendRestocks.Depth = 0;
            this.btnSendRestocks.Icon = null;
            this.btnSendRestocks.Location = new System.Drawing.Point(853, 318);
            this.btnSendRestocks.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendRestocks.Name = "btnSendRestocks";
            this.btnSendRestocks.Primary = true;
            this.btnSendRestocks.Size = new System.Drawing.Size(182, 36);
            this.btnSendRestocks.TabIndex = 15;
            this.btnSendRestocks.Text = "Send Restock Request";
            this.btnSendRestocks.UseVisualStyleBackColor = true;
            this.btnSendRestocks.Click += new System.EventHandler(this.btnSendRestocks_Click);
            // 
            // btnMoveItems
            // 
            this.btnMoveItems.AutoSize = true;
            this.btnMoveItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMoveItems.Depth = 0;
            this.btnMoveItems.Icon = null;
            this.btnMoveItems.Location = new System.Drawing.Point(191, 330);
            this.btnMoveItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMoveItems.Name = "btnMoveItems";
            this.btnMoveItems.Primary = true;
            this.btnMoveItems.Size = new System.Drawing.Size(103, 36);
            this.btnMoveItems.TabIndex = 15;
            this.btnMoveItems.Text = "Move items";
            this.btnMoveItems.UseVisualStyleBackColor = true;
            this.btnMoveItems.Click += new System.EventHandler(this.btnMoveItems_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(849, 84);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(127, 19);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Restock Request:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(23, 57);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(169, 19);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Available spots in shop:";
            // 
            // lbRestocks
            // 
            this.lbRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestocks.FormattingEnabled = true;
            this.lbRestocks.ItemHeight = 16;
            this.lbRestocks.Location = new System.Drawing.Point(671, 116);
            this.lbRestocks.Name = "lbRestocks";
            this.lbRestocks.Size = new System.Drawing.Size(545, 196);
            this.lbRestocks.TabIndex = 9;
            // 
            // lbSpacesInShop
            // 
            this.lbSpacesInShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpacesInShop.FormattingEnabled = true;
            this.lbSpacesInShop.ItemHeight = 16;
            this.lbSpacesInShop.Location = new System.Drawing.Point(27, 84);
            this.lbSpacesInShop.Name = "lbSpacesInShop";
            this.lbSpacesInShop.Size = new System.Drawing.Size(487, 244);
            this.lbSpacesInShop.TabIndex = 9;
            this.lbSpacesInShop.SelectedIndexChanged += new System.EventHandler(this.lbSpacesInShop_SelectedIndexChanged);
            // 
            // StockerHome
            // 
            this.ClientSize = new System.Drawing.Size(1308, 369);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlDashboard);
            this.Name = "StockerHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockerHome_FormClosing);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.ListBox lbSpacesInShop;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialRaisedButton btnSendRestocks;
        private MaterialSkin.Controls.MaterialRaisedButton btnMoveItems;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ListBox lbRestocks;
    }
}