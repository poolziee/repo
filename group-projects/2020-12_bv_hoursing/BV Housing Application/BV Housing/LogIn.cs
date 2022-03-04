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
    public partial class LogIn : Form
    {
        Service BVservice;
       
        public LogIn()
        {
            InitializeComponent();
            BVservice = new Service("BV Housing");
            this.BVservice.addUser("Tomislav", "tomi", "tomi");
            this.BVservice.addUser("Jean-Marc", "jean", "jean");
            this.BVservice.addUser("Plamen", "paco", "paco");
            List<User> users = this.BVservice.ListUsers;
            List<String> taskNames = this.BVservice.ListTaskNames;
            this.BVservice.addTask(taskNames[0], "4 April 2021" , users[0]);
            this.BVservice.addTask(taskNames[1], "2 May 2021", users[0]);
            this.BVservice.addTask(taskNames[2], "3 February 2021" , users[1]);
            this.BVservice.addTask(taskNames[3], "3 February 2021" , users[1]);
            this.BVservice.addTask(taskNames[4], "4 June 2021", users[2]);
            this.BVservice.addTask(taskNames[5], "14 June 2021", users[2]);
            this.BVservice.addRule("Parties are strongly forbidden!");
            this.BVservice.addRule("Do not disturb your roommates!");
            this.BVservice.addRule("Always check the General Task Schedule before adding a Task!");
            this.BVservice.addRule("First do the task , and then mark it as 'Done'! ");
            this.BVservice.addRule("Every week arrange a meeting with a supervisor at: +31888100200");
            this.BVservice.addComplain("Tomislav consistently throws parties", "student");
            this.BVservice.addComplain("Tomislav doesn't update his tasks", "student");
            this.BVservice.addComplain("Plamen is constantly sending exchange proposals", "student");
            this.BVservice.addComplain("Last week nobody came for weekly check", "BV");
            this.BVservice.addComplain("The washing machine is broken", "BV");
            this.BVservice.addComplain("The internet is too slow", "BV");

        }


        private void btnLogIn_Click_1(object sender, EventArgs e)
        {

            if (this.BVservice.identifyStudent(this.tbUsername.Text, this.tbPass.Text))
            {
                studentView studentForm = new studentView(this.BVservice);
                studentForm.Show();
                tbUsername.Text = "";
                tbPass.Text = "";
                Hide();
            }
            else if (this.BVservice.IsAdmin(this.tbUsername.Text, this.tbPass.Text))
            {
                AdminView adminForm = new AdminView(this.BVservice);
                adminForm.Show();
                tbUsername.Text = "";
                tbPass.Text = "";
                Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }
    }
}
