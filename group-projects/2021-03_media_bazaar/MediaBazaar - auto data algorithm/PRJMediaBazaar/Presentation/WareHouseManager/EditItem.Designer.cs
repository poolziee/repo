
namespace PRJMediaBazaar
{
    partial class EditItem
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
            this.label10 = new System.Windows.Forms.Label();
            this.pbxCurrentImage = new System.Windows.Forms.PictureBox();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.pbxNewImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbMinimumAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbStockPrice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbModel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubcategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRoomStorage = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRoomShop = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCurrentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomShop)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(392, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Current Image :";
            // 
            // pbxCurrentImage
            // 
            this.pbxCurrentImage.Location = new System.Drawing.Point(396, 96);
            this.pbxCurrentImage.Name = "pbxCurrentImage";
            this.pbxCurrentImage.Size = new System.Drawing.Size(213, 173);
            this.pbxCurrentImage.TabIndex = 39;
            this.pbxCurrentImage.TabStop = false;
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateItem.Location = new System.Drawing.Point(20, 343);
            this.btnUpdateItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(981, 34);
            this.btnUpdateItem.TabIndex = 38;
            this.btnUpdateItem.Text = "Update Item";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // pbxNewImage
            // 
            this.pbxNewImage.Location = new System.Drawing.Point(679, 96);
            this.pbxNewImage.Name = "pbxNewImage";
            this.pbxNewImage.Size = new System.Drawing.Size(213, 173);
            this.pbxNewImage.TabIndex = 53;
            this.pbxNewImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(675, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Drag Picture of An Item Here :";
            // 
            // tbPrice
            // 
            this.tbPrice.Depth = 0;
            this.tbPrice.Hint = "";
            this.tbPrice.Location = new System.Drawing.Point(151, 222);
            this.tbPrice.MaxLength = 32767;
            this.tbPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.PasswordChar = '\0';
            this.tbPrice.SelectedText = "";
            this.tbPrice.SelectionLength = 0;
            this.tbPrice.SelectionStart = 0;
            this.tbPrice.Size = new System.Drawing.Size(201, 23);
            this.tbPrice.TabIndex = 74;
            this.tbPrice.TabStop = false;
            this.tbPrice.UseSystemPasswordChar = false;
            // 
            // tbMinimumAmount
            // 
            this.tbMinimumAmount.Depth = 0;
            this.tbMinimumAmount.Hint = "";
            this.tbMinimumAmount.Location = new System.Drawing.Point(214, 314);
            this.tbMinimumAmount.MaxLength = 32767;
            this.tbMinimumAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbMinimumAmount.Name = "tbMinimumAmount";
            this.tbMinimumAmount.PasswordChar = '\0';
            this.tbMinimumAmount.SelectedText = "";
            this.tbMinimumAmount.SelectionLength = 0;
            this.tbMinimumAmount.SelectionStart = 0;
            this.tbMinimumAmount.Size = new System.Drawing.Size(201, 23);
            this.tbMinimumAmount.TabIndex = 73;
            this.tbMinimumAmount.TabStop = false;
            this.tbMinimumAmount.UseSystemPasswordChar = false;
            // 
            // tbStockPrice
            // 
            this.tbStockPrice.Depth = 0;
            this.tbStockPrice.Hint = "";
            this.tbStockPrice.Location = new System.Drawing.Point(151, 193);
            this.tbStockPrice.MaxLength = 32767;
            this.tbStockPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbStockPrice.Name = "tbStockPrice";
            this.tbStockPrice.PasswordChar = '\0';
            this.tbStockPrice.SelectedText = "";
            this.tbStockPrice.SelectionLength = 0;
            this.tbStockPrice.SelectionStart = 0;
            this.tbStockPrice.Size = new System.Drawing.Size(201, 23);
            this.tbStockPrice.TabIndex = 72;
            this.tbStockPrice.TabStop = false;
            this.tbStockPrice.UseSystemPasswordChar = false;
            // 
            // tbModel
            // 
            this.tbModel.Depth = 0;
            this.tbModel.Hint = "";
            this.tbModel.Location = new System.Drawing.Point(107, 107);
            this.tbModel.MaxLength = 32767;
            this.tbModel.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbModel.Name = "tbModel";
            this.tbModel.PasswordChar = '\0';
            this.tbModel.SelectedText = "";
            this.tbModel.SelectionLength = 0;
            this.tbModel.SelectionStart = 0;
            this.tbModel.Size = new System.Drawing.Size(201, 23);
            this.tbModel.TabIndex = 71;
            this.tbModel.TabStop = false;
            this.tbModel.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(50, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "Stock Price :";
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
            this.cbSubcategory.Location = new System.Drawing.Point(109, 41);
            this.cbSubcategory.Name = "cbSubcategory";
            this.cbSubcategory.Size = new System.Drawing.Size(158, 21);
            this.cbSubcategory.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(1, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "Subcategory :";
            // 
            // cbBrand
            // 
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(109, 75);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(157, 21);
            this.cbBrand.TabIndex = 67;
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
            this.cbCategory.Location = new System.Drawing.Point(109, 15);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(158, 21);
            this.cbCategory.TabIndex = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(7, 314);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(203, 20);
            this.label11.TabIndex = 65;
            this.label11.Text = "Minimum Amount In Stock :";
            // 
            // tbRoomStorage
            // 
            this.tbRoomStorage.Location = new System.Drawing.Point(214, 284);
            this.tbRoomStorage.Margin = new System.Windows.Forms.Padding(2);
            this.tbRoomStorage.Name = "tbRoomStorage";
            this.tbRoomStorage.Size = new System.Drawing.Size(156, 20);
            this.tbRoomStorage.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(67, 280);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 63;
            this.label9.Text = "Room In Storage : ";
            // 
            // tbRoomShop
            // 
            this.tbRoomShop.Location = new System.Drawing.Point(214, 260);
            this.tbRoomShop.Margin = new System.Windows.Forms.Padding(2);
            this.tbRoomShop.Name = "tbRoomShop";
            this.tbRoomShop.Size = new System.Drawing.Size(156, 20);
            this.tbRoomShop.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(85, 260);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Room In Shop : ";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(107, 141);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbDescription.Size = new System.Drawing.Size(201, 40);
            this.tbDescription.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(9, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Description :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(44, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "Model : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(95, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Price :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(46, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Brand :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(25, 12);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 55;
            this.label12.Text = "Category :";
            // 
            // EditItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 398);
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
            this.Controls.Add(this.tbRoomStorage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRoomShop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbxNewImage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pbxCurrentImage);
            this.Controls.Add(this.btnUpdateItem);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditItem";
            this.Text = "EditItem";
            this.Load += new System.EventHandler(this.EditItem_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EditItem_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EditItem_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCurrentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomShop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbxCurrentImage;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Timer godTimer;
        private System.Windows.Forms.PictureBox pbxNewImage;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbPrice;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbMinimumAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbStockPrice;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSubcategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown tbRoomStorage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown tbRoomShop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
    }
}