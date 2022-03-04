namespace BV_Housing
{
    partial class studentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentView));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnComplains = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.tbTask = new System.Windows.Forms.ComboBox();
            this.tbYear = new System.Windows.Forms.ComboBox();
            this.tbMonth = new System.Windows.Forms.ComboBox();
            this.tbDay = new System.Windows.Forms.ComboBox();
            this.btnShowMyTasks = new System.Windows.Forms.Button();
            this.btnShowAllTasks = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PanelTableScroll = new System.Windows.Forms.Panel();
            this.TaskTable = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.panelComplain = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSendComplain = new System.Windows.Forms.Button();
            this.rbAgency = new System.Windows.Forms.RadioButton();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.tbComplain = new System.Windows.Forms.TextBox();
            this.panelRules = new System.Windows.Forms.Panel();
            this.lbStudentRules = new System.Windows.Forms.ListBox();
            this.lblRules = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelTasks.SuspendLayout();
            this.PanelTableScroll.SuspendLayout();
            this.panelComplain.SuspendLayout();
            this.panelRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnComplains);
            this.panelMenu.Controls.Add(this.btnLogOut);
            this.panelMenu.Controls.Add(this.btnRules);
            this.panelMenu.Controls.Add(this.btnTasks);
            this.panelMenu.Controls.Add(this.lblUser);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(938, 34);
            this.panelMenu.TabIndex = 6;
            // 
            // btnComplains
            // 
            this.btnComplains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplains.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnComplains.FlatAppearance.BorderSize = 2;
            this.btnComplains.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnComplains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplains.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplains.ForeColor = System.Drawing.Color.White;
            this.btnComplains.Location = new System.Drawing.Point(363, 0);
            this.btnComplains.Name = "btnComplains";
            this.btnComplains.Size = new System.Drawing.Size(95, 34);
            this.btnComplains.TabIndex = 4;
            this.btnComplains.Text = "Complains";
            this.btnComplains.UseVisualStyleBackColor = true;
            this.btnComplains.Click += new System.EventHandler(this.btnComplains_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogOut.FlatAppearance.BorderSize = 2;
            this.btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(553, 0);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(99, 34);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnRules
            // 
            this.btnRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRules.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRules.FlatAppearance.BorderSize = 2;
            this.btnRules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.ForeColor = System.Drawing.Color.White;
            this.btnRules.Location = new System.Drawing.Point(456, 0);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(99, 34);
            this.btnRules.TabIndex = 2;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTasks.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTasks.FlatAppearance.BorderSize = 2;
            this.btnTasks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasks.ForeColor = System.Drawing.Color.White;
            this.btnTasks.Location = new System.Drawing.Point(272, 0);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(94, 34);
            this.btnTasks.TabIndex = 0;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblUser.Location = new System.Drawing.Point(3, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(157, 25);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Current user :";
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.lblTaskID);
            this.panelTasks.Controls.Add(this.label4);
            this.panelTasks.Controls.Add(this.label1);
            this.panelTasks.Controls.Add(this.btnUpdateTask);
            this.panelTasks.Controls.Add(this.tbTask);
            this.panelTasks.Controls.Add(this.tbYear);
            this.panelTasks.Controls.Add(this.tbMonth);
            this.panelTasks.Controls.Add(this.tbDay);
            this.panelTasks.Controls.Add(this.btnShowMyTasks);
            this.panelTasks.Controls.Add(this.btnShowAllTasks);
            this.panelTasks.Controls.Add(this.label8);
            this.panelTasks.Controls.Add(this.label7);
            this.panelTasks.Controls.Add(this.label6);
            this.panelTasks.Controls.Add(this.label5);
            this.panelTasks.Controls.Add(this.PanelTableScroll);
            this.panelTasks.Controls.Add(this.label3);
            this.panelTasks.Controls.Add(this.label2);
            this.panelTasks.Controls.Add(this.btnAddTask);
            this.panelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTasks.Location = new System.Drawing.Point(0, 34);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(938, 416);
            this.panelTasks.TabIndex = 7;
            this.panelTasks.Visible = false;
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskID.ForeColor = System.Drawing.Color.White;
            this.lblTaskID.Location = new System.Drawing.Point(1, 63);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(134, 13);
            this.lblTaskID.TabIndex = 38;
            this.lblTaskID.Text = "Editing Task with ID : ";
            this.lblTaskID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(223, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "TaskID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(869, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Options";
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateTask.FlatAppearance.BorderSize = 2;
            this.btnUpdateTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnUpdateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTask.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTask.Location = new System.Drawing.Point(95, 208);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(75, 35);
            this.btnUpdateTask.TabIndex = 35;
            this.btnUpdateTask.Text = "Update";
            this.btnUpdateTask.UseVisualStyleBackColor = true;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // tbTask
            // 
            this.tbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbTask.FormattingEnabled = true;
            this.tbTask.Location = new System.Drawing.Point(14, 111);
            this.tbTask.Name = "tbTask";
            this.tbTask.Size = new System.Drawing.Size(121, 21);
            this.tbTask.TabIndex = 34;
            // 
            // tbYear
            // 
            this.tbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbYear.FormattingEnabled = true;
            this.tbYear.Items.AddRange(new object[] {
            "2021",
            "2022"});
            this.tbYear.Location = new System.Drawing.Point(132, 162);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(59, 21);
            this.tbYear.TabIndex = 33;
            // 
            // tbMonth
            // 
            this.tbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbMonth.FormattingEnabled = true;
            this.tbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July ",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.tbMonth.Location = new System.Drawing.Point(48, 162);
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(78, 21);
            this.tbMonth.TabIndex = 32;
            // 
            // tbDay
            // 
            this.tbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbDay.FormattingEnabled = true;
            this.tbDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.tbDay.Location = new System.Drawing.Point(4, 162);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(38, 21);
            this.tbDay.TabIndex = 31;
            // 
            // btnShowMyTasks
            // 
            this.btnShowMyTasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowMyTasks.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShowMyTasks.FlatAppearance.BorderSize = 2;
            this.btnShowMyTasks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnShowMyTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMyTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMyTasks.ForeColor = System.Drawing.Color.White;
            this.btnShowMyTasks.Location = new System.Drawing.Point(31, 341);
            this.btnShowMyTasks.Name = "btnShowMyTasks";
            this.btnShowMyTasks.Size = new System.Drawing.Size(104, 42);
            this.btnShowMyTasks.TabIndex = 30;
            this.btnShowMyTasks.Text = "Show my tasks";
            this.btnShowMyTasks.UseVisualStyleBackColor = true;
            this.btnShowMyTasks.Click += new System.EventHandler(this.btnShowMyTasks_Click);
            // 
            // btnShowAllTasks
            // 
            this.btnShowAllTasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAllTasks.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShowAllTasks.FlatAppearance.BorderSize = 2;
            this.btnShowAllTasks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnShowAllTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAllTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllTasks.ForeColor = System.Drawing.Color.White;
            this.btnShowAllTasks.Location = new System.Drawing.Point(31, 287);
            this.btnShowAllTasks.Name = "btnShowAllTasks";
            this.btnShowAllTasks.Size = new System.Drawing.Size(104, 37);
            this.btnShowAllTasks.TabIndex = 29;
            this.btnShowAllTasks.Text = "Show all tasks";
            this.btnShowAllTasks.UseVisualStyleBackColor = true;
            this.btnShowAllTasks.Click += new System.EventHandler(this.btnShowAllTasks_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(779, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Due by";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(658, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(506, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Task";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(337, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Name";
            // 
            // PanelTableScroll
            // 
            this.PanelTableScroll.AutoScroll = true;
            this.PanelTableScroll.Controls.Add(this.TaskTable);
            this.PanelTableScroll.Location = new System.Drawing.Point(186, 35);
            this.PanelTableScroll.Name = "PanelTableScroll";
            this.PanelTableScroll.Size = new System.Drawing.Size(745, 381);
            this.PanelTableScroll.TabIndex = 24;
            // 
            // TaskTable
            // 
            this.TaskTable.AutoSize = true;
            this.TaskTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TaskTable.ColumnCount = 6;
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.TaskTable.ForeColor = System.Drawing.Color.White;
            this.TaskTable.Location = new System.Drawing.Point(7, 0);
            this.TaskTable.Name = "TaskTable";
            this.TaskTable.RowCount = 1;
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TaskTable.Size = new System.Drawing.Size(733, 39);
            this.TaskTable.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(35, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "due to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Task Name";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddTask.FlatAppearance.BorderSize = 2;
            this.btnAddTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Location = new System.Drawing.Point(14, 208);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 35);
            this.btnAddTask.TabIndex = 17;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // panelComplain
            // 
            this.panelComplain.Controls.Add(this.label9);
            this.panelComplain.Controls.Add(this.btnSendComplain);
            this.panelComplain.Controls.Add(this.rbAgency);
            this.panelComplain.Controls.Add(this.rbStudent);
            this.panelComplain.Controls.Add(this.tbComplain);
            this.panelComplain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComplain.Location = new System.Drawing.Point(0, 34);
            this.panelComplain.Name = "panelComplain";
            this.panelComplain.Size = new System.Drawing.Size(938, 416);
            this.panelComplain.TabIndex = 8;
            this.panelComplain.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(351, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "Write your complain here :";
            // 
            // btnSendComplain
            // 
            this.btnSendComplain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendComplain.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSendComplain.FlatAppearance.BorderSize = 2;
            this.btnSendComplain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSendComplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendComplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendComplain.ForeColor = System.Drawing.Color.White;
            this.btnSendComplain.Location = new System.Drawing.Point(465, 297);
            this.btnSendComplain.Name = "btnSendComplain";
            this.btnSendComplain.Size = new System.Drawing.Size(167, 57);
            this.btnSendComplain.TabIndex = 11;
            this.btnSendComplain.Text = "Send complain";
            this.btnSendComplain.UseVisualStyleBackColor = true;
            this.btnSendComplain.Click += new System.EventHandler(this.btnSendComplain_Click);
            // 
            // rbAgency
            // 
            this.rbAgency.AutoSize = true;
            this.rbAgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAgency.ForeColor = System.Drawing.Color.White;
            this.rbAgency.Location = new System.Drawing.Point(252, 348);
            this.rbAgency.Name = "rbAgency";
            this.rbAgency.Size = new System.Drawing.Size(158, 20);
            this.rbAgency.TabIndex = 10;
            this.rbAgency.TabStop = true;
            this.rbAgency.Text = "Complain about BV";
            this.rbAgency.UseVisualStyleBackColor = true;
            this.rbAgency.CheckedChanged += new System.EventHandler(this.rbAgency_CheckedChanged);
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStudent.ForeColor = System.Drawing.Color.White;
            this.rbStudent.Location = new System.Drawing.Point(252, 297);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(188, 20);
            this.rbStudent.TabIndex = 9;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Complain about student";
            this.rbStudent.UseVisualStyleBackColor = true;
            this.rbStudent.CheckedChanged += new System.EventHandler(this.rbStudent_CheckedChanged);
            // 
            // tbComplain
            // 
            this.tbComplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComplain.Location = new System.Drawing.Point(226, 63);
            this.tbComplain.Multiline = true;
            this.tbComplain.Name = "tbComplain";
            this.tbComplain.Size = new System.Drawing.Size(463, 197);
            this.tbComplain.TabIndex = 8;
            // 
            // panelRules
            // 
            this.panelRules.Controls.Add(this.lbStudentRules);
            this.panelRules.Controls.Add(this.lblRules);
            this.panelRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRules.Location = new System.Drawing.Point(0, 34);
            this.panelRules.Name = "panelRules";
            this.panelRules.Size = new System.Drawing.Size(938, 416);
            this.panelRules.TabIndex = 9;
            // 
            // lbStudentRules
            // 
            this.lbStudentRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStudentRules.FormattingEnabled = true;
            this.lbStudentRules.ItemHeight = 20;
            this.lbStudentRules.Location = new System.Drawing.Point(226, 99);
            this.lbStudentRules.Name = "lbStudentRules";
            this.lbStudentRules.Size = new System.Drawing.Size(517, 224);
            this.lbStudentRules.TabIndex = 2;
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.Color.White;
            this.lblRules.Location = new System.Drawing.Point(442, 60);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(71, 27);
            this.lblRules.TabIndex = 1;
            this.lblRules.Text = "Rules:";
            // 
            // studentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelRules);
            this.Controls.Add(this.panelTasks);
            this.Controls.Add(this.panelComplain);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "studentView";
            this.Text = "BV Housing";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            this.PanelTableScroll.ResumeLayout(false);
            this.PanelTableScroll.PerformLayout();
            this.panelComplain.ResumeLayout(false);
            this.panelComplain.PerformLayout();
            this.panelRules.ResumeLayout(false);
            this.panelRules.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.Panel panelComplain;
        private System.Windows.Forms.Panel panelRules;
        private System.Windows.Forms.Button btnComplains;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.ListBox lbStudentRules;
        private System.Windows.Forms.Button btnSendComplain;
        private System.Windows.Forms.RadioButton rbAgency;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.TextBox tbComplain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PanelTableScroll;
        private System.Windows.Forms.TableLayoutPanel TaskTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnShowMyTasks;
        private System.Windows.Forms.Button btnShowAllTasks;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox tbYear;
        private System.Windows.Forms.ComboBox tbMonth;
        private System.Windows.Forms.ComboBox tbDay;
        private System.Windows.Forms.ComboBox tbTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.Label label9;
    }
}