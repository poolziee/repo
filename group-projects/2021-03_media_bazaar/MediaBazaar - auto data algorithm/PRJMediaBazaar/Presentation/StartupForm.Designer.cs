namespace PRJMediaBazaar.Presentation
{
    partial class StartupForm
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
            this.btnSingleLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMultipleLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // btnSingleLogin
            // 
            this.btnSingleLogin.AutoSize = true;
            this.btnSingleLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSingleLogin.Depth = 0;
            this.btnSingleLogin.Icon = null;
            this.btnSingleLogin.Location = new System.Drawing.Point(24, 25);
            this.btnSingleLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSingleLogin.Name = "btnSingleLogin";
            this.btnSingleLogin.Primary = true;
            this.btnSingleLogin.Size = new System.Drawing.Size(103, 36);
            this.btnSingleLogin.TabIndex = 1;
            this.btnSingleLogin.Text = "Singe Login";
            this.btnSingleLogin.UseVisualStyleBackColor = true;
            this.btnSingleLogin.Click += new System.EventHandler(this.btnSingleLogin_Click);
            // 
            // btnMultipleLogin
            // 
            this.btnMultipleLogin.AutoSize = true;
            this.btnMultipleLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMultipleLogin.Depth = 0;
            this.btnMultipleLogin.Icon = null;
            this.btnMultipleLogin.Location = new System.Drawing.Point(151, 25);
            this.btnMultipleLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMultipleLogin.Name = "btnMultipleLogin";
            this.btnMultipleLogin.Primary = true;
            this.btnMultipleLogin.Size = new System.Drawing.Size(129, 36);
            this.btnMultipleLogin.TabIndex = 1;
            this.btnMultipleLogin.Text = "Multiple Login";
            this.btnMultipleLogin.UseVisualStyleBackColor = true;
            this.btnMultipleLogin.Click += new System.EventHandler(this.btnMultipleLogin_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 97);
            this.Controls.Add(this.btnMultipleLogin);
            this.Controls.Add(this.btnSingleLogin);
            this.Name = "StartupForm";
            this.Text = "StartupForm";
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnSingleLogin;
        private MaterialSkin.Controls.MaterialRaisedButton btnMultipleLogin;
    }
}