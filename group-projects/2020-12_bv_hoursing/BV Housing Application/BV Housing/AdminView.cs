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
    public partial class AdminView : Form
    {
        //some testing 
        //lallala
        Service BVservice;
        private int counter = 0, index, counterRule = 0, indexRule;
        private int counterTaskName = 0;
        private int indexTaskName = 0;
        public AdminView(Service s)
        {
            InitializeComponent();
            this.BVservice = s;
            showComplains();
            showRules();
            ShowAccounts();
            ShowTasks();
        }
                                        //Tab Menu
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Program.loginForm.Show();
            Close();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            this.panelAddUser.Visible = false;
            this.panelComplains.Visible = false;
            this.panelRules.Visible = false;
            this.panelTasks.Visible = true;
            ShowTasks();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            this.panelRules.Visible = true;
            this.panelAddUser.Visible = false;
            this.panelComplains.Visible = false;
            this.panelTasks.Visible = false;
        }

        private void btnComplains_Click(object sender, EventArgs e)
        {
            this.panelRules.Visible = false;
            this.panelAddUser.Visible = false;
            this.panelTasks.Visible = false;
            this.panelComplains.Visible = true;
            showComplains();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            this.panelRules.Visible = false;
            this.panelComplains.Visible = false;
            this.panelTasks.Visible = false;
            this.panelAddUser.Visible = true;
            ShowAccounts();
        }
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            if (BVservice.addRule(this.tbRules.Text))
            {
                showRules();
                this.tbRules.Text = "";
            }
            else
            { MessageBox.Show("Text field is empty. Please write the rule"); }
        }


        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            indexRule = this.lbAdminRules.SelectedIndex;
            if (indexRule >= 0)
            {//first check if there is something chosen from the listbox
                //then it dialog box pops up to ask if the user is sure
                DialogResult res = MessageBox.Show("Are you sure you want to remove a rule?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    this.BVservice.removeRuleAtIndex(indexRule);
                    showRules();
                }
            }
            else
            {
                MessageBox.Show("You haven't selected rule to remove");
            }
        }

        private void btnUpdateRule_Click(object sender, EventArgs e)
        {
            if (counterRule == 0)
            {
                indexRule = lbAdminRules.SelectedIndex;
                if (indexRule >= 0)
                {
                    this.tbRules.Text = this.BVservice.ListRules[indexRule].TheRule;
                    counterRule = 1;
                    this.btnUpdateRule.Text = "Update";
                    this.btnAddRule.Enabled = false;
                    this.btnRemoveRule.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You haven't selected which rule you want to change!");
                }
            }
            else
            {
                if (this.tbRules.Text == "")
                {
                    MessageBox.Show("Text field is empty.Please write the rule");
                }
                else
                {
                    this.BVservice.ListRules[indexRule].TheRule = this.tbRules.Text;
                    counterRule = 0;
                    this.tbRules.Text = "";
                    this.btnAddRule.Enabled = true;
                    this.btnRemoveRule.Enabled = true;
                    this.btnUpdateRule.Text = "Update selected rule";
                    showRules();
                }
            }
        }


        private void btnAddTaskName_Click(object sender, EventArgs e)
        {

                string textInput = this.txtBoxTasks.Text;
            if (this.txtBoxTasks.Text == "")
            { MessageBox.Show("Please type the task name"); }

            else if (this.BVservice.ListTaskNames.Contains(this.txtBoxTasks.Text))
            { MessageBox.Show("Task name already exists"); }

            else
            {
                    this.BVservice.AddTaskName(textInput);
                ShowTasks();
                this.txtBoxTasks.Text = "";
            }
            
        }
       
        private void btnSaveTaskName_Click(object sender, EventArgs e)
        {
            if (counterTaskName == 0)
            {
                indexTaskName = listBoxTasks.SelectedIndex;
                if (indexTaskName >= 0)
                {
                    this.txtBoxTasks.Text = this.BVservice.ListTaskNames[indexTaskName];
                    counterTaskName = 1;
                    this.btnSaveTaskName.Text = "Save";
                    this.btnAddTaskName.Enabled = false;
                    this.btnRemoveTaskNames.Enabled = false;
                    this.labelTaskName.Text = $"Editing task: {this.txtBoxTasks.Text} ";
                }
                else
                {
                    MessageBox.Show("You haven't selected which task you want to change!");
                }
            }
            else
            {
                if (this.txtBoxTasks.Text == "")
                { MessageBox.Show("Please type the task name"); }

                else if (this.BVservice.GetTaskName(this.txtBoxTasks.Text) != null && this.BVservice.ListTaskNames[indexTaskName] != this.BVservice.GetTaskName(this.txtBoxTasks.Text))
                { MessageBox.Show("Task name already exists"); }
               
                else
                {
                    this.BVservice.ListTaskNames[indexTaskName] = this.txtBoxTasks.Text;
                    counterTaskName = 0;
                    this.txtBoxTasks.Text = "";
                    this.btnSaveTaskName.Text = "Edit";
                    this.btnAddTaskName.Enabled = true;
                    this.btnRemoveTaskNames.Enabled = true;
                    this.labelTaskName.Text = "Task Name :";

                }

            }
            ShowTasks();
        }

        private void btnRemoveTaskNames_Click(object sender, EventArgs e)
        {
            
            int indexTaskName = listBoxTasks.SelectedIndex;
            if (indexTaskName >= 0)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to remove a Task Name?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    this.BVservice.removeTaskNameAtIndex(indexTaskName);
                    ShowTasks();
                }
            }
            else
            {
                MessageBox.Show("You haven't selected which task you want to delete!");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.BVservice.getByUsername(this.tbUsername.Text) == null)
            {
                if (this.BVservice.addUser(this.tbName.Text, this.tbUsername.Text, this.tbPassword.Text))
                {
                    ShowAccounts();
                    this.tbName.Text = "";
                    this.tbUsername.Text = "";
                    this.tbPassword.Text = "";
                }

                else
                {
                    MessageBox.Show("Please fill in all fields!");
                }
            }
            else
            { MessageBox.Show("Username is already taken!"); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            index = lbUsers.SelectedIndex;
            if (index >= 0)
            {//first check if there is something chosen from the listbox
                //then it dialog box pops up to ask if the user is sure
                DialogResult res = MessageBox.Show("Are you sure you want to remove an user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    this.BVservice.removeUserAtIndex(index);
                    ShowAccounts();
                }
            }
            else
            {
                MessageBox.Show("You haven't selected user to remove");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (counter == 0)
            {
                index = lbUsers.SelectedIndex;

                if (index >= 0)
                {
                        this.tbPassword.Text = this.BVservice.ListUsers[index].Password;
                    this.tbName.Text = this.BVservice.ListUsers[index].Name;
                    this.tbUsername.Text = this.BVservice.ListUsers[index].Username;
                        counter = 1;
                    this.btnUpdate.Text = "Update";
                    this.btnAddUser.Enabled = false;
                    this.btnRemove.Enabled = false;
                    this.tbName.Enabled = false;
                    this.tbUsername.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You haven't selected which password you want to change!");
                }
            }
            else
            {
                this.BVservice.ListUsers[index].Password = this.tbPassword.Text;
                this.tbPassword.Text = "";
                counter = 0;
                this.btnAddUser.Enabled = true;
                this.btnRemove.Enabled = true;
                this.tbName.Enabled = true;
                this.tbUsername.Enabled = true;
                this.tbName.Text = "";
                this.tbUsername.Text = "";
                this.tbPassword.Text = "";
                this.btnUpdate.Text = "Update selected password";
            }
            ShowAccounts();
        }
                                                //Helping Methods
        private void showRules()
        {
            this.lbAdminRules.Items.Clear();
            for (int i = 0; i < BVservice.ListRules.Count; i++)
            {
                //also possible to be - allRules.rules[i].getRule()
                lbAdminRules.Items.Add(i + 1 + ". " + BVservice.ListRules.ElementAt(i).TheRule);
            }
        }

        private void showComplains()
        {
            this.lbStudents.Items.Clear();
            this.lbAgency.Items.Clear();
            for (int i = 0; i < BVservice.ListComplainsStudent.Count; i++)
            {
                this.lbStudents.Items.Add($" \t    Student Complain ID : {i + 1}");
                this.lbStudents.Items.Add(BVservice.ListComplainsStudent[i].TheComplain);
            }
            for (int i = 0; i < BVservice.ListComplainsAgency.Count; i++)
            {
                this.lbAgency.Items.Add($" \t     BV Complain ID : {i + 1}");
                this.lbAgency.Items.Add(BVservice.ListComplainsAgency[i].TheComplain);
            }
        }
        private void ShowAccounts()
        {
            lbUsers.Items.Clear();
            foreach (User u in BVservice.ListUsers)
            {
                lbUsers.Items.Add($"{u.Name} with username {u.Username} and password {u.Password}");
            }
        }

        private void ShowTasks()
        {
            this.listBoxTasks.Items.Clear();
            foreach (string taskname in BVservice.ListTaskNames)
            {
                this.listBoxTasks.Items.Add(taskname);
            }
        }

    }
}
