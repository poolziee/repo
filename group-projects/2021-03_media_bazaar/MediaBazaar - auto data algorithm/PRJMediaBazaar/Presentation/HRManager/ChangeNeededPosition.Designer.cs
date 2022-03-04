namespace PRJMediaBazaar
{
    partial class ChangeNeededPosition
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMorning = new System.Windows.Forms.TextBox();
            this.tbMidday = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEvening = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.godTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(17, 47);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(341, 29);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Changing positon : posito, day:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Morning: ";
            // 
            // tbMorning
            // 
            this.tbMorning.Location = new System.Drawing.Point(65, 116);
            this.tbMorning.Margin = new System.Windows.Forms.Padding(4);
            this.tbMorning.Name = "tbMorning";
            this.tbMorning.Size = new System.Drawing.Size(73, 22);
            this.tbMorning.TabIndex = 1;
            // 
            // tbMidday
            // 
            this.tbMidday.Location = new System.Drawing.Point(173, 116);
            this.tbMidday.Margin = new System.Windows.Forms.Padding(4);
            this.tbMidday.Name = "tbMidday";
            this.tbMidday.Size = new System.Drawing.Size(73, 22);
            this.tbMidday.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Midday:";
            // 
            // tbEvening
            // 
            this.tbEvening.Location = new System.Drawing.Point(288, 116);
            this.tbEvening.Margin = new System.Windows.Forms.Padding(4);
            this.tbEvening.Name = "tbEvening";
            this.tbEvening.Size = new System.Drawing.Size(73, 22);
            this.tbEvening.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Evening:";
            // 
            // godTimer
            // 
            this.godTimer.Enabled = true;
            this.godTimer.Interval = 2500;
            this.godTimer.Tick += new System.EventHandler(this.godTimer_Tick);
            // 
            // ChangeNeededPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbEvening);
            this.Controls.Add(this.tbMidday);
            this.Controls.Add(this.tbMorning);
            this.Controls.Add(this.lblInfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeNeededPosition";
            this.Text = "ChangeNeededPosition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMorning;
        private System.Windows.Forms.TextBox tbMidday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEvening;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer godTimer;
    }
}