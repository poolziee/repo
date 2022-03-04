namespace PRJMediaBazaar.Presentation.WareHouseManager
{
    partial class EditRestock
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
            this.lblItemInfo = new MaterialSkin.Controls.MaterialLabel();
            this.tbOldAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnChangeAmount = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lbItemInfo = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tbNewAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemInfo
            // 
            this.lblItemInfo.AutoSize = true;
            this.lblItemInfo.Depth = 0;
            this.lblItemInfo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblItemInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemInfo.Location = new System.Drawing.Point(12, 99);
            this.lblItemInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemInfo.Name = "lblItemInfo";
            this.lblItemInfo.Size = new System.Drawing.Size(43, 19);
            this.lblItemInfo.TabIndex = 1;
            this.lblItemInfo.Text = "Item:";
            // 
            // tbOldAmount
            // 
            this.tbOldAmount.Depth = 0;
            this.tbOldAmount.Enabled = false;
            this.tbOldAmount.Hint = "";
            this.tbOldAmount.Location = new System.Drawing.Point(420, 178);
            this.tbOldAmount.MaxLength = 32767;
            this.tbOldAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbOldAmount.Name = "tbOldAmount";
            this.tbOldAmount.PasswordChar = '\0';
            this.tbOldAmount.SelectedText = "";
            this.tbOldAmount.SelectionLength = 0;
            this.tbOldAmount.SelectionStart = 0;
            this.tbOldAmount.Size = new System.Drawing.Size(105, 23);
            this.tbOldAmount.TabIndex = 2;
            this.tbOldAmount.TabStop = false;
            this.tbOldAmount.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(323, 185);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "For restock: ";
            // 
            // btnChangeAmount
            // 
            this.btnChangeAmount.AutoSize = true;
            this.btnChangeAmount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChangeAmount.Depth = 0;
            this.btnChangeAmount.Icon = null;
            this.btnChangeAmount.Location = new System.Drawing.Point(327, 250);
            this.btnChangeAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeAmount.Name = "btnChangeAmount";
            this.btnChangeAmount.Primary = true;
            this.btnChangeAmount.Size = new System.Drawing.Size(137, 36);
            this.btnChangeAmount.TabIndex = 3;
            this.btnChangeAmount.Text = "Change amount";
            this.btnChangeAmount.UseVisualStyleBackColor = true;
            this.btnChangeAmount.Click += new System.EventHandler(this.btnChangeAmount_Click);
            // 
            // lbItemInfo
            // 
            this.lbItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemInfo.FormattingEnabled = true;
            this.lbItemInfo.ItemHeight = 15;
            this.lbItemInfo.Location = new System.Drawing.Point(12, 139);
            this.lbItemInfo.Name = "lbItemInfo";
            this.lbItemInfo.Size = new System.Drawing.Size(185, 139);
            this.lbItemInfo.TabIndex = 4;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(323, 211);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(102, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "New amount: ";
            // 
            // tbNewAmount
            // 
            this.tbNewAmount.Depth = 0;
            this.tbNewAmount.Hint = "";
            this.tbNewAmount.Location = new System.Drawing.Point(420, 207);
            this.tbNewAmount.MaxLength = 32767;
            this.tbNewAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNewAmount.Name = "tbNewAmount";
            this.tbNewAmount.PasswordChar = '\0';
            this.tbNewAmount.SelectedText = "";
            this.tbNewAmount.SelectionLength = 0;
            this.tbNewAmount.SelectionStart = 0;
            this.tbNewAmount.Size = new System.Drawing.Size(105, 23);
            this.tbNewAmount.TabIndex = 2;
            this.tbNewAmount.TabStop = false;
            this.tbNewAmount.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblTitle1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 52);
            this.panel1.TabIndex = 58;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.label10.Location = new System.Drawing.Point(84, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 30);
            this.label10.TabIndex = 60;
            this.label10.Text = "BAZAAR";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle1.Location = new System.Drawing.Point(2, 12);
            this.lblTitle1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(90, 30);
            this.lblTitle1.TabIndex = 59;
            this.lblTitle1.Text = "MEDIA";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(239, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Edit Restock Amount";
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // EditRestock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(574, 309);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbItemInfo);
            this.Controls.Add(this.btnChangeAmount);
            this.Controls.Add(this.tbNewAmount);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.tbOldAmount);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lblItemInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditRestock";
            this.Text = "EditRestock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblItemInfo;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbOldAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnChangeAmount;
        private System.Windows.Forms.ListBox lbItemInfo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbNewAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer godTimer;
    }
}