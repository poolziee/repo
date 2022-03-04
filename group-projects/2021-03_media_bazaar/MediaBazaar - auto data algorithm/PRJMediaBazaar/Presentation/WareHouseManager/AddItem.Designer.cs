
namespace PRJMediaBazaar
{
    partial class AddItem
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbxItem = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRoomShop = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRoomStorage = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.cbSubcategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbModel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbStockPrice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbMinimumAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbPrice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.pbxItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(40, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(68, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Brand :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(64, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Selling Price :";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(43, 438);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(807, 42);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbxItem
            // 
            this.pbxItem.Location = new System.Drawing.Point(525, 123);
            this.pbxItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxItem.Name = "pbxItem";
            this.pbxItem.Size = new System.Drawing.Size(284, 213);
            this.pbxItem.TabIndex = 17;
            this.pbxItem.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(65, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Model : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(19, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Description :";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(149, 194);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbDescription.Size = new System.Drawing.Size(267, 48);
            this.tbDescription.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(120, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Room In Shop : ";
            // 
            // tbRoomShop
            // 
            this.tbRoomShop.Location = new System.Drawing.Point(292, 341);
            this.tbRoomShop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRoomShop.Name = "tbRoomShop";
            this.tbRoomShop.Size = new System.Drawing.Size(208, 22);
            this.tbRoomShop.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(96, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Room In Storage : ";
            // 
            // tbRoomStorage
            // 
            this.tbRoomStorage.Location = new System.Drawing.Point(292, 370);
            this.tbRoomStorage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRoomStorage.Name = "tbRoomStorage";
            this.tbRoomStorage.Size = new System.Drawing.Size(208, 22);
            this.tbRoomStorage.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(520, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(270, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "Drag Picture of An Item Here :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(16, 407);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(251, 25);
            this.label11.TabIndex = 30;
            this.label11.Text = "Minimum Amount In Stock :";
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Electronics",
            "Fashion",
            "Furniture",
            "Sports and Outdoors",
            "Software"});
            this.cbCategory.Location = new System.Drawing.Point(152, 39);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(209, 24);
            this.cbCategory.TabIndex = 31;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // cbBrand
            // 
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(152, 113);
            this.cbBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(208, 24);
            this.cbBrand.TabIndex = 32;
            // 
            // cbSubcategory
            // 
            this.cbSubcategory.FormattingEnabled = true;
            this.cbSubcategory.Items.AddRange(new object[] {
            "Electronics",
            "Fashion",
            "Furniture",
            "Sports and Outdoors",
            "Software"});
            this.cbSubcategory.Location = new System.Drawing.Point(152, 71);
            this.cbSubcategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSubcategory.Name = "cbSubcategory";
            this.cbSubcategory.Size = new System.Drawing.Size(209, 24);
            this.cbSubcategory.TabIndex = 34;
            this.cbSubcategory.SelectedIndexChanged += new System.EventHandler(this.cbSubcategory_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(8, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 25);
            this.label5.TabIndex = 33;
            this.label5.Text = "Subcategory :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(73, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Stock Price :";
            // 
            // tbModel
            // 
            this.tbModel.Depth = 0;
            this.tbModel.Hint = "";
            this.tbModel.Location = new System.Drawing.Point(149, 153);
            this.tbModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbModel.MaxLength = 32767;
            this.tbModel.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbModel.Name = "tbModel";
            this.tbModel.PasswordChar = '\0';
            this.tbModel.SelectedText = "";
            this.tbModel.SelectionLength = 0;
            this.tbModel.SelectionStart = 0;
            this.tbModel.Size = new System.Drawing.Size(268, 28);
            this.tbModel.TabIndex = 37;
            this.tbModel.TabStop = false;
            this.tbModel.UseSystemPasswordChar = false;
            // 
            // tbStockPrice
            // 
            this.tbStockPrice.Depth = 0;
            this.tbStockPrice.Hint = "";
            this.tbStockPrice.Location = new System.Drawing.Point(208, 258);
            this.tbStockPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbStockPrice.MaxLength = 32767;
            this.tbStockPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbStockPrice.Name = "tbStockPrice";
            this.tbStockPrice.PasswordChar = '\0';
            this.tbStockPrice.SelectedText = "";
            this.tbStockPrice.SelectionLength = 0;
            this.tbStockPrice.SelectionStart = 0;
            this.tbStockPrice.Size = new System.Drawing.Size(268, 28);
            this.tbStockPrice.TabIndex = 38;
            this.tbStockPrice.TabStop = false;
            this.tbStockPrice.UseSystemPasswordChar = false;
            // 
            // tbMinimumAmount
            // 
            this.tbMinimumAmount.Depth = 0;
            this.tbMinimumAmount.Hint = "";
            this.tbMinimumAmount.Location = new System.Drawing.Point(292, 407);
            this.tbMinimumAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMinimumAmount.MaxLength = 32767;
            this.tbMinimumAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbMinimumAmount.Name = "tbMinimumAmount";
            this.tbMinimumAmount.PasswordChar = '\0';
            this.tbMinimumAmount.SelectedText = "";
            this.tbMinimumAmount.SelectionLength = 0;
            this.tbMinimumAmount.SelectionStart = 0;
            this.tbMinimumAmount.Size = new System.Drawing.Size(268, 28);
            this.tbMinimumAmount.TabIndex = 39;
            this.tbMinimumAmount.TabStop = false;
            this.tbMinimumAmount.UseSystemPasswordChar = false;
            // 
            // tbPrice
            // 
            this.tbPrice.Depth = 0;
            this.tbPrice.Hint = "";
            this.tbPrice.Location = new System.Drawing.Point(208, 294);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPrice.MaxLength = 32767;
            this.tbPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.PasswordChar = '\0';
            this.tbPrice.SelectedText = "";
            this.tbPrice.SelectionLength = 0;
            this.tbPrice.SelectionStart = 0;
            this.tbPrice.Size = new System.Drawing.Size(268, 28);
            this.tbPrice.TabIndex = 40;
            this.tbPrice.TabStop = false;
            this.tbPrice.UseSystemPasswordChar = false;
            // 
            // AddItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 494);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbMinimumAmount);
            this.Controls.Add(this.tbStockPrice);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSubcategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbRoomStorage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRoomShop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbxItem);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddItem";
            this.Text = "AddItem";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AddItem_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AddItem_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbxItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomStorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pbxItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown tbRoomShop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown tbRoomStorage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer godTimer;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.ComboBox cbSubcategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbModel;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbStockPrice;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbMinimumAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbPrice;
    }
}