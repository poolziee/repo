using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BV_Housing
{
    public partial class studentView : Form
    {

        Service BvService;
        String complainAbout; // either "BV" or "student" (from radioButtons)
        private Task taskToUpdate; // assigned value in EditTask(line 190) , assigned null in btnUpdateTask_Click(line 304)

        public studentView(Service s)
        {

            InitializeComponent();
            this.BvService = s;
            this.lblUser.Text = "Current user: " + Service.currentUser.Name;
            this.btnUpdateTask.Enabled = false;
            this.tbTask.Items.Clear();
            this.tbTask.Items.AddRange(this.BvService.ListTaskNames.ToArray());
            showMyList();
            showRules();
          
            
        }
        //Tab menu
        
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Service.currentUser = null;
            Program.loginForm.Show();
            Close();
        }

        private void btnComplains_Click(object sender, EventArgs e)
        {
            this.panelComplain.Visible = true;
            this.panelTasks.Visible = false;
            this.panelRules.Visible = false;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            this.panelComplain.Visible = false;
            this.panelTasks.Visible = false;
            this.panelRules.Visible = true;
            showRules();
        }
        private void showRules()
        {
            this.lbStudentRules.Items.Clear();
            for (int i = 0; i < BvService.ListRules.Count; i++)
            {

                lbStudentRules.Items.Add(i + 1 + ". " + BvService.ListRules.ElementAt(i).TheRule);
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            this.tbTask.Items.Clear();
            this.tbTask.Items.AddRange(this.BvService.ListTaskNames.ToArray());
            this.panelComplain.Visible = false;
            this.panelTasks.Visible = true;
            this.panelRules.Visible = false;
            showProposal();
            DoubleBuffered = true;
            TaskTable.Visible = true;
        }
        //Complains

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            this.complainAbout = "student";
        }

        private void rbAgency_CheckedChanged(object sender, EventArgs e)
        {
            this.complainAbout = "BV";
        }

        private void btnSendComplain_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbComplain.Text))
            { MessageBox.Show("Empty complains can't be sent"); }

            else
            {
                String complainToAdd = this.tbComplain.Text;
                if (BvService.addComplain(complainToAdd, complainAbout))
                {
                    MessageBox.Show("Complain successfully sent");
                    this.tbComplain.Text = "";
                }

                else
                {
                    MessageBox.Show("Please select who is the complain about");
                }
            }
        }
        //TASKS
        private void addTask()
        {
            String dueBy = $"{this.tbDay.Text} {this.tbMonth.Text} {this.tbYear.Text}";
            this.BvService.addTask(this.tbTask.Text, dueBy);
            //Show list with tasks
            showMyList();
            clearComboBoxes();
        }

        private void updateTask()
        {
            String dueBy = $"{this.tbDay.Text} {this.tbMonth.Text} {this.tbYear.Text}";
            String before = taskToUpdate.GetInfo();
            this.BvService.editTask(taskToUpdate, this.tbTask.Text, dueBy);
            String after = taskToUpdate.GetInfo();
            this.btnAddTask.Enabled = true;
            this.btnShowAllTasks.Enabled = true;
            this.btnShowMyTasks.Enabled = true;
            this.TaskTable.Enabled = true;


            this.btnUpdateTask.Enabled = false;
            clearComboBoxes();
            this.lblTaskID.Visible = false;
            showMyList();
            MessageBox.Show($"Task with ID: {this.taskToUpdate.TaskID} {Environment.NewLine} {before} {Environment.NewLine} " +
                $"Changed to : {Environment.NewLine} {after}");
            this.taskToUpdate = null;
        }
        //Adding a task
        private void btnAddTask_Click(object sender, EventArgs e)
        {

            //Create task object and add  to list
            if (String.IsNullOrEmpty(this.tbTask.Text))//check if the field is empty
            {
                MessageBox.Show("Enter Task!");
            }

            else
            {
                if (this.tbDay.Text == "" || this.tbMonth.Text == "" || this.tbYear.Text == "")
                {//checks if one of the date fields is empty then continues
                    MessageBox.Show("Enter valid date!");
                }
                else
                {
                    if (DateIsCorrect()) // checks the amount of days for the selected month
                    {
                        Task taskWithName = this.BvService.TaskWithName(this.tbTask.Text);
                        if (taskWithName == null)
                        {
                            addTask();
                        }
                        else
                        {
                            //create dialog box with 2 buttons - yes or no
                            DialogResult res = MessageBox.Show($"{taskWithName.User.Name} already has this task , are you shure you want to add another one?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            //after the user has chosen Yes or No certain code is executed
                            if (res == DialogResult.Yes)
                            {
                                addTask();
                            }
                        }
                    }

                }
            }
        }

        //Removing a task
        private void RemoveTask(object sender2, EventArgs e2, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);
            if (task.Status.Contains("Proposed to") == false)
            {
                //create dialog box with 2 buttons - yes or no
                DialogResult res = MessageBox.Show("Are you sure you want to remove the task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //after the user has chosen Yes or No certain code is executed
                if (res == DialogResult.Yes)
                {
                    this.BvService.ListTasks.Remove(task);
                    showMyList();
                }
            }
            else { MessageBox.Show("Can't remove a task that is proposed for exchange!"); }
        }

        //Editing a task
        private void EditTask(object sender2, EventArgs e2, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);

            if (task.Status == "Not Done")
            {

                taskToUpdate = task;

                giveTaskToComboboxes(taskToUpdate);
                this.btnAddTask.Enabled = false;
                this.btnShowAllTasks.Enabled = false;
                this.btnShowMyTasks.Enabled = false;
                this.TaskTable.Enabled = false;
                this.btnUpdateTask.Enabled = true;
                this.lblTaskID.Visible = true;
                this.lblTaskID.Text = $"Editing Task with ID : {task.TaskID}";

            }


            else if (task.Status == "Done")
            {
                MessageBox.Show($"Can't edit tasks that are already done.{Environment.NewLine} " +
                $"If you didn't do the task, please mark it as Not Done.");
            }

            else { MessageBox.Show("Can't edit tasks that are proposed for exchange"); }
            showMyList();
        }

        //Applying the changes made in void EditTask
        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (this.tbTask.Text != "" && this.tbDay.Text != "" && this.tbMonth.Text != "" && this.tbYear.Text != "")
            {
                if (DateIsCorrect())
                {
                    Task taskWithName = this.BvService.TaskWithName(this.tbTask.Text);
                    if (taskWithName == null)
                    {
                        updateTask();
                    }
                    else
                    {
                        if (taskWithName != taskToUpdate)
                        {
                            //create dialog box with 2 buttons - yes or no
                            DialogResult res = MessageBox.Show($"{taskWithName.User.Name} already has this task , are you shure you want to add another one?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            //after the user has chosen Yes or No certain code is executed
                            if (res == DialogResult.Yes)
                            {
                                updateTask();
                            }
                        }
                        else { updateTask(); }
                    }
                }
            }
            else { MessageBox.Show("Please fill in all fields!"); }
        }
        //Propose task for exchange
        private void ProposeExchange(object sender2, EventArgs e2, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);

            if (task.Status != "Done")
            {
                //if the task is not proposed , show the prompt for exchange
                if (task.Status.Contains("Proposed") == false)
                {
                    string promptValue = Prompt.ProposalWindow("Task Exchange", this.BvService, task, this);
                }
                //if the task is pending , inform the user
                else
                { MessageBox.Show($"Task is already proposed to {task.UserToExchangeWith.Name}"); }
            }
            else { MessageBox.Show("Only tasks that are Not Done can be proposed"); }

        }

        private void CancelProposal(object sender2, EventArgs e2, int taskHash)
        {
            Task t = getTaskFromHash(taskHash);
            this.BvService.denyProposal(t);
            showMyList();
        }

        //Status changer
        private void MarkNotDone(object sender2, EventArgs e2, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);
            task.Status = "Not Done";
            showMyList();
        }

        private void MarkAsDone(object sender2, EventArgs e2, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);
            task.Status = "Done";
            showMyList();
        }


        //Button for Status changer

        private void OpenOptions_Click(object sender, EventArgs e, int taskHash)
        {
            Task t = getTaskFromHash(taskHash);

            var button = sender as Button;
            int row = TaskTable.GetRow(button);
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            if (t.Status == "Done" || t.Status == "Not Done")
            {
                contextMenuStrip.Items.Add("Mark Done", null, delegate (object sender2, EventArgs e2) { MarkAsDone(sender2, e2, taskHash); });
                contextMenuStrip.Items.Add("Mark Not Done", null, delegate (object sender2, EventArgs e2) { MarkNotDone(sender2, e2, taskHash); });
            }
            else if (t.Status.Contains("Proposed to"))
            { contextMenuStrip.Items.Add("Cancel proposal", null, delegate (object sender2, EventArgs e2) { CancelProposal(sender2, e2, taskHash); }); }
            contextMenuStrip.Show(Cursor.Position);
        }

        // Button for editing/removing/exchanging a task
        private void OpenProperties_Click(object sender, EventArgs e, int taskHash)
        {
            Task task = getTaskFromHash(taskHash);

            var button = sender as Button;
            int row = TaskTable.GetRow(button);
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Remove Task", null, delegate (object sender2, EventArgs e2) { RemoveTask(sender2, e2, taskHash); });
            contextMenuStrip.Items.Add("Edit Task", null, delegate (object sender2, EventArgs e2) { EditTask(sender2, e2, taskHash); });
            contextMenuStrip.Items.Add("Propose exchange", null, delegate (object sender2, EventArgs e2) { ProposeExchange(sender2, e2, taskHash); });
            contextMenuStrip.Show(Cursor.Position);
        }



        private void btnShowAllTasks_Click(object sender, EventArgs e)
        {
            ShowList();
            this.label1.Visible = false;
        }

        private void btnShowMyTasks_Click(object sender, EventArgs e)
        {
            showMyList();
            this.label1.Visible = true;
        }

        //Helping methods

        private bool DateIsCorrect() // check if the month contains the selected day
        {
            try
            {
                int month = this.tbMonth.SelectedIndex + 1;
                int year = Int32.Parse(this.tbYear.Text);
                int day = Int32.Parse(this.tbDay.Text);
                int days = DateTime.DaysInMonth(year, month);
                if (days == 28 && day > 28)
                {
                    MessageBox.Show("The month has 28 days");
                    return false;
                }
                else if (days == 30 && day > 30)
                {
                    MessageBox.Show("The month has 30 days");
                    return false;
                }

                return true;

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please enter valid date");
                return false;
            }
        }

        private void clearComboBoxes()
        {
            this.tbTask.SelectedIndex = -1;
            this.tbDay.SelectedIndex = -1;
            this.tbMonth.SelectedIndex = -1;
            this.tbYear.SelectedIndex = -1;
        }

        private void giveTaskToComboboxes(Task t)
        {
            String date = t.DueTo;
            this.tbTask.Text = t.TaskName;
            string[] result = date.Split(' ');
            this.tbDay.Text = result[0];
            this.tbMonth.Text = result[1];
            this.tbYear.Text = result[2];
        }

        private Task getTaskFromHash(int hashCode)
        {
            foreach (Task t in this.BvService.ListTasks)
            {
                if (t.GetHashCode() == hashCode)
                { return t; }
            }
            return null;
        }

        private void showProposal()
        {
            Task t = this.BvService.ProposalFor(Service.currentUser);
            if (t != null)
            {
                //create dialog box with 2 buttons - yes or no
                DialogResult res = MessageBox.Show($"Proposal from {t.User.Name} :  {t.GetInfo()}  {Environment.NewLine}  Do you accept?",
                    "Task Exchange Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //after the user has chosen Yes or No certain code is executed
                if (res == DialogResult.Yes)
                {
                    this.BvService.exchangeTask(t);
                    showMyList();
                }
                if (res == DialogResult.No)
                {
                    this.BvService.denyProposal(t);
                }
            }
        }

        //TaskTable settings

        public void showMyList() // the current user table with options
        {
            //Clear Table and suspend rendering is easier then editing each row
            TaskTable.SuspendLayout();
            TaskTable.Parent.SuspendLayout();
            TaskTable.Visible = false;
            TaskTable.Controls.Clear();
            TaskTable.RowCount = 0;
            TaskTable.ColumnCount = 6;

            //Create copy list for sorting purposes
            List<Task> CopyTask = this.BvService.CurrentUserTasks();
            CopyTask = CopyTask.OrderBy(s => s.Status).ToList();

            //Iterate thru all tasks
            foreach (Task task in CopyTask)
            {

                //if the assigned person for the task is the user who logged in , add the task to the table
               
                    //Label list
                    List<Label> labels = this.Labels(task);

                    //Status button

                    Button StatusOptionButton = new Button()
                    {
                        Cursor = System.Windows.Forms.Cursors.Hand,
                        FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                        Dock = DockStyle.Fill,
                        Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new System.Drawing.Point(0, 0),
                        Name = "StatusOptionButton",
                        TabIndex = 0,
                        Text = task.Status,
                        UseVisualStyleBackColor = true,
                        Size = new System.Drawing.Size(365, 38)
                    };
                    StatusOptionButton.FlatAppearance.BorderSize = 0;
                    StatusOptionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    StatusOptionButton.Click += delegate (object sender, EventArgs e) { OpenOptions_Click(sender, e, task.GetHashCode()); };

                    Button Properties = new Button()
                    {
                        Cursor = System.Windows.Forms.Cursors.Hand,
                        FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                        Dock = DockStyle.Fill,
                        Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new System.Drawing.Point(0, 0),
                        Name = "Properties",
                        TabIndex = 0,
                        Text = "...",
                        UseVisualStyleBackColor = true
                    };
                    Properties.FlatAppearance.BorderSize = 0;
                    Properties.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    Properties.Click += delegate (object sender, EventArgs e) { OpenProperties_Click(sender, e, task.GetHashCode()); };



                    //Insert values into the row
                    TaskTable.Controls.Add(labels[0], 0, TaskTable.RowCount - 1);
                    TaskTable.Controls.Add(labels[1], 1, TaskTable.RowCount - 1);
                    TaskTable.Controls.Add(labels[2], 2, TaskTable.RowCount - 1);
                    TaskTable.Controls.Add(StatusOptionButton, 3, TaskTable.RowCount - 1);
                    TaskTable.Controls.Add(labels[3], 4, TaskTable.RowCount - 1);
                    TaskTable.Controls.Add(Properties, 5, TaskTable.RowCount - 1);

            }

            //Enable rendering after inserting rows
            TaskTable.Visible = true;
            TaskTable.Parent.ResumeLayout();
            TaskTable.ResumeLayout();
        }

        public void ShowList()
        {
            //Clear Table and suspend rendering is easier then editing each row
            TaskTable.SuspendLayout();
            TaskTable.Parent.SuspendLayout();
            TaskTable.Visible = false;
            TaskTable.Controls.Clear();
            TaskTable.RowCount = 0;
            TaskTable.ColumnCount = 5;

            //Create copy list for sorting purposes
            List<Task> CopyTask = this.BvService.ListTasks;
            CopyTask = CopyTask.OrderBy(s => s.Status).ToList();

            //Iterate thru all tasks
            foreach (Task task in CopyTask)
            {
                //Label list
                List<Label> labels = this.Labels(task);

                //Status button
                Label StatusOptionLabel = new Label()
                {

                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = System.Drawing.Color.White,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "StatusOptionButton",
                    TabIndex = 0,
                    Text = task.Status,

                };

                //Insert values into the row
                TaskTable.Controls.Add(labels[0], 0, TaskTable.RowCount - 1);
                TaskTable.Controls.Add(labels[1], 1, TaskTable.RowCount - 1);
                TaskTable.Controls.Add(labels[2], 2, TaskTable.RowCount - 1);
                TaskTable.Controls.Add(StatusOptionLabel, 3, TaskTable.RowCount - 1);
                TaskTable.Controls.Add(labels[3], 4, TaskTable.RowCount - 1);
            }

            //Enable rendering after inserting rows
            TaskTable.Visible = true;
            TaskTable.Parent.ResumeLayout();
            TaskTable.ResumeLayout();

        }

        private List<Label> Labels(Task task)
        {
            List<Label> labels = new List<Label>();

            Label TaskIDLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(4, 1),
                Name = "TaskIDLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = task.TaskID.ToString(),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            //Name label
            Label NameLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(4, 1),
                Name = "NameLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = task.User.Name,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            //Taskname label
            Label TaskNameLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(4, 1),
                Name = "TaskNameLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = task.TaskName,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            Label DueByLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(4, 1),
                Name = "DueByLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = task.DueTo,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            labels.Add(TaskIDLabel);
            labels.Add(NameLabel);
            labels.Add(TaskNameLabel);
            labels.Add(DueByLabel);
            return labels;
        }

    }
}
