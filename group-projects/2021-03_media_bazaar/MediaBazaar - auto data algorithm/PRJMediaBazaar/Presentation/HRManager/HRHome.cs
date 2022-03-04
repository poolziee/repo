using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;
using Day = PRJMediaBazaar.Logic.Day;
using System.Text.RegularExpressions;
using System.Threading;

namespace PRJMediaBazaar
{
    partial class HRHome : Form
    {
        private static string[] positions = new string[] { "Security", "Cashier", "Stocker", "SalesAssistant", "WarehouseManager" };

        private EmployeeControl _empControl;
        private AbsenceControl _absenceControl;
        private ScheduleControl _scheduleControl;
        private Employee[] _employees;
        private Employee thisEmployee;
        private Employee HRManager;
        private Schedule _currentSchedule;

        private NamesRow[] _tableRows;
        private LogIn _loginForm;
        private Button x;

        private List<DayOff> daysOff;
        private List<SickReport> sickReports;
        private List<Button> buttons;

        public HRHome(LogIn loginForm,EmployeeControl _empControl,Employee HRManager)
        {
            InitializeComponent();
            this.btnAddEmployee.AutoSize = false;
            this.btnEditEmployee.AutoSize = false;
            ShiftAssigning.ReloadForm += new ShiftAssigning.ShiftAssigningHandler(ReloadShiftAssigningForm_Event);
            buttons = new List<Button>();
            _loginForm = loginForm;
            this._empControl = _empControl;
            this.HRManager = HRManager;
            thisEmployee = null;
            _currentSchedule = null;
            LoadEmployees();
            _scheduleControl = new ScheduleControl(_empControl);
            _absenceControl = new AbsenceControl(_scheduleControl);
            cbPosition.Text = "Security";
            this.btnChangeNeededPosition.Enabled = false;
            this.btnGenerateSchedule.Enabled = false;
            this.btnDeleteSchedule.Enabled = false;
            this.lblWelcome.Text = "Welcome, " + HRManager.FullName + "!";
            foreach (Schedule s in _scheduleControl.Schedules)
            {
                this.cbSchedule.Items.Add(s);
            }
            LoadDayOffRequests();
            LoadSickReports();

            if (sickReports.Count > 0)
            {
                MessageBox.Show("New Sick Reports! Please check which shifts are dismissed and re-assign other employees!");
                this.lblSickReports.BackColor = Color.Red;
            }
            if (daysOff.Count > 0)
            {
                this.lblDayOffReports.BackColor = Color.Red;
            }


        }
        public void AddNameToCB(String name)
        {
            this.cbEmployees.Items.Add(name);
           // List<String> items = this.cbEmployees.Items.ToString();
        }
        private void ReloadShiftAssigningForm_Event(Shift shift, string jobPosition, Day day)
        {
            ShiftAssigning form = new ShiftAssigning(_scheduleControl, _empControl.GetEmployeesByPosition(jobPosition).ToList(), shift, jobPosition, this, day);
            form.Show();
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
        }
        public void LoadEmployees()
        {
            _employees = _empControl.Employees;
            for (int i = 0; i < _employees.Length; i++)
            {
                this.cbEmployees.Items.Add(_employees[i].FullName);
            }

        }
        public void AddEmployee(Employee temp)
        {
            List<Employee> temp1;
            temp1 = _employees.ToList();
            temp1.Add(temp);
            _employees = temp1.ToArray();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = true;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.Gray;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = false;
            this.pnlDayOff.Visible = false;
            this.panelSickReports.Visible = true;
            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.Gray;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.pnlDayOff.Visible = true;
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;

            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.Gray;

            LoadDayOffRequests();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = true;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
            this.lblSchedule.ForeColor = Color.Gray;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void HRHome_Load(object sender, EventArgs e)
        {
            this.lblEmployees.ForeColor = Color.Gray;
            this.panelEmployees.Visible = true;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
        }

        private void lblAllEmployees_Click(object sender, EventArgs e)
        {

        }
        private void LoadEmployeeListboxes(Employee currentEmployee)
        {
            this.lbEmployeeInfo.Items.Clear();
            this.lbGeneralInfo.Items.Clear();

            this.lbEmployeeInfo.Items.Add("ID : " + currentEmployee.Id);
            this.lbEmployeeInfo.Items.Add("First Name : " + currentEmployee.FirstName);
            this.lbEmployeeInfo.Items.Add("Last Name : " + currentEmployee.LastName);
            this.lbEmployeeInfo.Items.Add("Email : " + currentEmployee.Email);
            this.lbEmployeeInfo.Items.Add("Job Position : " + currentEmployee.JobPosition);
            this.lbEmployeeInfo.Items.Add("Salary : " + currentEmployee.Salary);
            this.lbEmployeeInfo.Items.Add("Contract : " + currentEmployee.Contract);
            this.lbEmployeeInfo.Items.Add($"Days Off :{currentEmployee.DaysOffLeft} left, {currentEmployee.DaysOff} allowed");
            this.lbEmployeeInfo.Items.Add("Contract Hours : " + currentEmployee.ContractHours);

            this.lbGeneralInfo.Items.Add("Birth Date : " + currentEmployee.BirthDate);
            this.lbGeneralInfo.Items.Add("Phone Number : " + currentEmployee.PhoneNumber);
            this.lbGeneralInfo.Items.Add("Address : " + currentEmployee.Address);
            this.lbGeneralInfo.Items.Add("Gender : " + currentEmployee.Gender);
            this.lbGeneralInfo.Items.Add("Education : " + currentEmployee.Education);
        }

        private void lbEmployeeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelEmployees_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSickReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSchedule_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule schedule = (Schedule)cbSchedule.SelectedItem;
            int scheduleId = schedule.Id;
            UpdateDaysCheckbox(scheduleId);
            if (cbDay.Text == "")
            {
                ShiftsTable.Controls.Clear();
                this.btnGenerateSchedule.Enabled = false;
            }
            _currentSchedule = schedule;
            UpdateDaysInfo();
            this.ActiveControl = null;
        }


        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

            //reload the table layout panel, based on the day and position
            //if All is selected, disable the change position button.
            //enable the button if All is not selected.
            Day day = (Day)this.cbDay.SelectedItem;
            if (day != null)
            {
                if (cbPosition.Text != "All")
                {
                    LoadTableByPosition(day, cbPosition.Text);
                    this.btnChangeNeededPosition.Enabled = true;
                }
                else
                {
                    this.btnChangeNeededPosition.Enabled = false;
                }
            }
            this.ActiveControl = null;

        }

        private void cbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if a position is selected, reload the table layout panel, based on the day and position
            Day day = (Day)this.cbDay.SelectedItem;
            if (cbPosition.Text != "All")
            {
                LoadTableByPosition(day, cbPosition.Text);
            }
            if (_scheduleControl.DayStatus(day) == "empty")
            {
                this.btnGenerateSchedule.Enabled = true;
                this.btnDeleteSchedule.Enabled = false;
            }
            else
            {
                this.btnGenerateSchedule.Enabled = false;
                this.btnDeleteSchedule.Enabled = true;
            }
            cbPosition.Invalidate();
            this.ActiveControl = null;

        }


        private void btnChangeNeededPosition_Click(object sender, EventArgs e)
        {

            //based on the selected position and day, open a new form to change the needed amount of that the position
            ChangeNeededPosition form = new ChangeNeededPosition(this.cbPosition.Text, (Day)cbDay.SelectedItem, _tableRows, this, ((Schedule)cbSchedule.SelectedItem).Id, cbDay.SelectedIndex);
            form.Show();

        }


        public void LoadTableByPosition(Day day, string jobPosition)
        {
            try
            {
                Duty neededAmounts = day.GetDuty(jobPosition);

                EmployeeWorkday[] workdays = _scheduleControl.GetEmployeesShifts(day.WeekId, day.Id, jobPosition);
                ShiftSeparator ssp = new ShiftSeparator(workdays, neededAmounts.MaxValue());
                NamesRow[] namesRows = ssp.GetNamesRows();
                _tableRows = namesRows;

                //Clear Table and suspend rendering is easier then editing each row
                ShiftsTable.SuspendLayout();
                ShiftsTable.Parent.SuspendLayout();
                ShiftsTable.Visible = false;
                ShiftsTable.Controls.Clear();
                ShiftsTable.RowCount = 0;
                ShiftsTable.ColumnCount = 4;
                for (int i = 0; i < namesRows.Count(); i++)
                {
                    Button MorningShiftButton = null;
                    Button MiddayShiftButton = null;
                    Button EveningShiftButton = null;
                    //label with the position
                    Label JobPositionLabel = new Label()
                    {
                        BackColor = System.Drawing.Color.Transparent,
                        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new System.Drawing.Point(4, 1),
                        Name = "JobPositionLabel",
                        Size = new System.Drawing.Size(365, 38),
                        TabIndex = 0,
                        Text = jobPosition,
                        TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    };

                    if (namesRows[i].Morning == null && namesRows[i].Midday == null && namesRows[i].Evening == null) // row with unassigned shifts
                    {
                        MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                        MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                        EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);

                    }

                    else //row with assigned shifts
                    {
                        int emptyEmployeeIndex = GetEmptyShiftIndex(namesRows[i].Morning, namesRows[i].Midday, namesRows[i].Evening);
                        int busyEmployeeIndex = GetBusyShiftIndex(namesRows[i].Morning, namesRows[i].Midday, namesRows[i].Evening);

                        if (emptyEmployeeIndex != -1) //2 assigned buttons, 1 unassigned button
                        {
                            //separate the buttons
                            switch (emptyEmployeeIndex)
                            {
                                case 1:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                                case 2:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                                case 3:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                            }
                        }
                        else if (busyEmployeeIndex != -1) //2 unassigned buttons, 1 assigned button
                        {
                            //separate the buttons
                            switch (busyEmployeeIndex)
                            {
                                case 1:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                                case 2:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                                case 3:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                            }
                        }
                        else //row is full
                        {
                            MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                            MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                            EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                        }
                    }

                    if (i + 1 > neededAmounts.MorningNeeded)
                    {
                        MorningShiftButton.Enabled = false;
                        MorningShiftButton.BackColor = Color.Silver;
                        MorningShiftButton.ForeColor = Color.Silver;
                        MorningShiftButton.Text = "";


                    }
                    if (i + 1 > neededAmounts.MiddayNeeded)
                    {
                        MiddayShiftButton.Enabled = false;
                        MiddayShiftButton.BackColor = Color.Silver;
                        MiddayShiftButton.ForeColor = Color.Silver;
                        MiddayShiftButton.Text = "";

                    }
                    if (i + 1 > neededAmounts.EveningNeeded)
                    {
                        EveningShiftButton.Enabled = false;
                        EveningShiftButton.BackColor = Color.Silver;
                        EveningShiftButton.ForeColor = Color.Silver;
                        EveningShiftButton.Text = "";

                    }



                    ShiftsTable.Controls.Add(JobPositionLabel, 0, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(MorningShiftButton, 1, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(MiddayShiftButton, 2, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(EveningShiftButton, 3, ShiftsTable.RowCount - 1);



                }

                //Enable rendering after inserting rows
                ShiftsTable.Visible = true;
                ShiftsTable.Parent.ResumeLayout();
                ShiftsTable.ResumeLayout();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private Button GetUnassignedShiftButton(Day day, Shift shift, string jobPosition)
        {
            Button UnassignedShiftButton = new Button()
            {
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(0, 0),
                Name = "UnassignedShiftButton",
                TabIndex = 0,
                Text = "Unassigned",
                UseVisualStyleBackColor = true,
                Size = new System.Drawing.Size(365, 38)
            };
            UnassignedShiftButton.FlatAppearance.BorderSize = 0;
            UnassignedShiftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            UnassignedShiftButton.Click += delegate (object sender, EventArgs e) { UnassignedShiftButton_Click(sender, e, new ShiftAssigning(_scheduleControl, _empControl.GetEmployeesByPosition(jobPosition).ToList(), shift, jobPosition, this, day)); };
            return UnassignedShiftButton;


        }

        private Button GetAssignedShiftButton(Day day, Shift shift, string jobPosition, Employee employee)
        {
            Button AssignedShiftButton = new Button()
            {
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(0, 0),
                Name = "AssignedShiftButton",
                TabIndex = 0,
                Text = employee.FirstName + " " + employee.LastName,
                UseVisualStyleBackColor = true,
                Size = new System.Drawing.Size(365, 38)
            };
            AssignedShiftButton.FlatAppearance.BorderSize = 0;
            AssignedShiftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            AssignedShiftButton.Click += delegate (object sender, EventArgs e) { AssignedShiftButton_Click(sender, e, employee, shift); };
            return AssignedShiftButton;
        }


        private void UnassignedShiftButton_Click(object sender, EventArgs e, ShiftAssigning assigningForm)
        {
            ShiftsTable.Enabled = false;
            assigningForm.Show();
        }

        private void AssignedShiftButton_Click(object sender, EventArgs e, Employee employee, Shift shift)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Remove Employee", null, delegate (object sender2, EventArgs e2) { RemoveShift(shift, employee); });
            contextMenuStrip.Show(Cursor.Position);
        }

        private void RemoveShift(Shift shift, Employee employee)
        {

            _scheduleControl.RemoveShift(shift.ToString(), ((Day)cbDay.SelectedItem), employee);
            LoadTableByPosition((Day)cbDay.SelectedItem, employee.JobPosition);
            StatusFunction($"Removed {employee.FullName}'s {shift.ToString()} shift", -6, -1, 900, 28, Color.Green);
            UpdateDaysInfo();
        }

        public void UpdateDaysCheckbox(int scheduleId)
        {
            Day[] days = _scheduleControl.GetDays(scheduleId);
            this.cbDay.Items.Clear();
            foreach (Day d in days)
            {
                this.cbDay.Items.Add(d);
            }
        }


        public void UpdateDaysInfo()
        {
            cbSchedule.Invalidate();
            cbDay.Invalidate();
            cbPosition.Invalidate();
            this.ActiveControl = null;
        }


        private int GetEmptyShiftIndex(Employee morning, Employee mid, Employee evening)
        {
            if (morning != null && mid != null && evening == null)
            {
                return 3;
            }
            else if (morning != null && mid == null && evening != null)
            {
                return 2;
            }
            else if (morning == null && mid != null && evening != null)
            {
                return 1;
            }
            return -1;
        }

        private int GetBusyShiftIndex(Employee morning, Employee mid, Employee evening)
        {

            if (morning != null && mid == null && evening == null)
            {
                return 1;
            }
            else if (morning == null && mid == null && evening != null)
            {
                return 3;
            }
            else if (morning == null && mid != null && evening == null)
            {
                return 2;
            }
            return -1;
        }

        private void btnAddPromotionPoints_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAddLatePoints_Click(object sender, EventArgs e)
        {
        }

        private void HRHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Close();
        }

        private void cbAllEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddNoteToEmployee(Employee temp, String note)

        {
            temp.Note = note;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panelSchedule_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pnlDayOff_Paint(object sender, PaintEventArgs e)
        {
        }

        public void CheckDayOffLabel()
        {
            if (this.lbDayOff.Items.Count == 0)
            {
                this.lblDayOffReports.BackColor = Color.Black;
            }
        }

        private void btnConfirmDayOff_Click(object sender, EventArgs e)
        {
            
        }

        public void RemoveDayOff(DayOff d)
        {
            this.lbDayOff.Items.Remove(d);
        }

        private void LoadDayOffRequests()
        {
            lbDayOff.Items.Clear();
            _absenceControl.LoadPendingDaysOff();
            daysOff = _absenceControl.DaysOffRequests;
           foreach(DayOff d in daysOff)
            {
                this.lbDayOff.Items.Add(d);
            }
        }

        private void LoadSickReports()
        {
            lbSickReports.Items.Clear();
            _absenceControl.LoadNewSickReports();
            sickReports = _absenceControl.SickReports;
            foreach (SickReport sr in sickReports)
            {
                this.lbSickReports.Items.Add(sr);
            }
        }

        private void btnDenyDayOff_Click(object sender, EventArgs e)
        {
           
        }

        private void cbSchedule_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            if (e.Index < 0) { return; }

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            string status = _scheduleControl.ScheduleStatus(_scheduleControl.Schedules[e.Index]);
            // Determine the forecolor
            Brush brush;
            if (status == "empty")
            {
                brush = Brushes.Red;
            }
            else if (status == "started")
            {
                brush = Brushes.Yellow;
            }
            else
            {
                brush = Brushes.Green;
            }

            // Draw the text    
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);

        }

        private void cbDay_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            if (e.Index < 0) { return; }

            Brush brush;
            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            Day day = (Day)((ComboBox)sender).Items[e.Index];

            // Determine the forecolor
            string status = _scheduleControl.DayStatus(day);
            if ( status == "empty")// compare  date with your list.  
            {
                brush = Brushes.Red;
            }
            else if (status == "started")
            {
                brush = Brushes.Yellow;
            }
            else
            {
                brush = Brushes.Green;
            }

            // Draw the text    
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            int month = 1;
            int count = 0;
            int days = 0;
            int week = 0;
            foreach(Schedule schedule in _scheduleControl.Schedules)
            {
                foreach(Day day in schedule.Days)
                {
                    _scheduleControl.GenerateSchedule(day);
                    days++;
                    if(days == 7)
                    {
                        days = 0;
                        week++;
                        Application.DoEvents(); //allow windows to execute all pending tasks
                        Thread.Sleep(5000);
                    }

                }
                count++;
                if(count == 2)
                {
                    month++;
                    count = 0;
                }

            }

            LoadTableByPosition((Day)cbDay.SelectedItem, "Security");
            UpdateDaysInfo();
            this.btnGenerateSchedule.Enabled = false;
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            _scheduleControl.RemoveSchedule((Day)cbDay.SelectedItem);
            LoadTableByPosition((Day)cbDay.SelectedItem, "Security");
            UpdateDaysInfo();
        }

    
        private void cbPosition_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            if (e.Index < 0) { return; }

            Brush brush = Brushes.White;

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            Day day = (Day)cbDay.SelectedItem;
            // Determine the forecolor

            if(day != null)
            {
                string status = day.PositionStatus(text);
                if (status == "empty")
                {
                    brush = Brushes.Red;
                }
                else if (status == "started")
                {
                    brush = Brushes.Yellow;
                }
                else
                {
                    brush = Brushes.Green;
                }
            }
           
            // Draw the text    
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void cbSchedule_DropDownClosed(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void cbDay_DropDownClosed(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void cbPosition_DropDownClosed(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }


        private void godTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void tbEmployee_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbEmployees.SelectedItem == null)
                {
                    StatusFunction("Please select an employee!", -6, -1, 900, 28, Color.Red);
                    throw new EmptyComboBoxException();
                }
                thisEmployee = _empControl.GetEmployeeByName(this.cbEmployees.SelectedItem.ToString());
                LoadEmployeeListboxes(thisEmployee);
                
            }
            catch (Exception ex)
            {
                StatusFunction("No employee found!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void btnDeniedRequests_Click(object sender, EventArgs e)
        {
           
        }

        private void btnConfirmedRequests_Click(object sender, EventArgs e)
        {
           

        }

        private void btnOldReports_Click(object sender, EventArgs e)
        {
            RequestsOverview form = new RequestsOverview(_absenceControl.GetOldSickReports(), "Old Reports:");
            form.Show();
        }

        private void btnMarkAsSeen_Click_1(object sender, EventArgs e)
        {
            SickReport report = (SickReport)this.lbSickReports.SelectedItem;
            if(report != null)
            {
                _absenceControl.MarkAsSeen(report.ReportId);
                lbSickReports.Items.Remove(report);
                report.MarkAsSeen();
                if(this.lbSickReports.Items.Count == 0)
                {
                    this.lblSickReports.BackColor = Color.Black;
                }
            }
           
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployees addEmployees = new AddEmployees(this, _empControl, _employees.ToList());
            addEmployees.Show();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (thisEmployee == null)
            {
                StatusFunction("Please select an employee!", -6, -1, 900, 28, Color.Red);
            }
            else
            {
                EditNote editNote = new EditNote(thisEmployee, _empControl, this, this.HRManager);
                editNote.Show();
            }
        }

        private void btnConfirmDayOff_Click_1(object sender, EventArgs e)
        {
            /* CONFIRM DAY OFF REQUEST */

            DayOff req = (DayOff)this.lbDayOff.SelectedItem;

            if (req != null)
            {

                _absenceControl.ConfirmDayOffRequest(req);
                _absenceControl.DaysOffRequests.Remove(req);
                LoadDayOffRequests();
                StatusFunction("Day Off Confirmed!", -6, -1, 900, 28, Color.Green);

            }
            else
            {
                StatusFunction("Select a day off request!", -6, -1, 900, 28, Color.Red);
            }

            if (this.lbDayOff.Items.Count == 0)
            {
                this.lblDayOffReports.BackColor = Color.Black;
            }
        }

        private void sd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbDayOff.SelectedItem == null)
                {
                    StatusFunction("Select a request!", -6, -1, 900, 28, Color.Red);
                    throw new EmptyComboBoxException();
                }

                else
                {
                    ExplainDenial explain = new ExplainDenial((DayOff)this.lbDayOff.SelectedItem, _absenceControl, this);
                    explain.Show();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnDeniedRequests_Click_1(object sender, EventArgs e)
        {
            RequestsOverview form = new RequestsOverview(_absenceControl.GetDeniedDaysOff(), "Denied Requests:");
            form.Show();
        }

        private void btnConfirmedRequests_Click_1(object sender, EventArgs e)
        {
            RequestsOverview form = new RequestsOverview(_absenceControl.GetConfirmedDaysOff(), "Confirmed Requests:");
            form.Show();
        }

        private void btnDeniedRequests_MouseEnter(object sender, EventArgs e)
        {
            this.btnDeniedRequests.ForeColor = Color.Red;
        }
    }
}
