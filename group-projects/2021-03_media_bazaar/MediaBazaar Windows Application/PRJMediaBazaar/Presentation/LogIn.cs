using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    partial class LogIn : Form
    {
        private List<Button> buttons;
        private List<Timer> timers;
        private EmployeeControl emp;
        private ItemControl _itemControl;
        private PRJMediaBazaar.Presentation.StartupForm _startup;
        public LogIn(PRJMediaBazaar.Presentation.StartupForm startup, ItemControl itemControl, string username, string pass )
        {
            InitializeComponent();
            buttons = new List<Button>();
            timers = new List<Timer>();
            _itemControl = itemControl;
            _startup = startup;
            this.tbUsername.Text = username;
            this.tbPassword.Text = pass;
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
            Timer temp = new Timer();
            timers.Add(temp);
            temp.Start();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LogIn_Load(object sender, EventArgs e)
        {
           
        }
        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }

        public static bool VPNisON()
        {
            return ((NetworkInterface.GetIsNetworkAvailable())
                    && NetworkInterface.GetAllNetworkInterfaces()
                                       .FirstOrDefault(ni => ni.Description.Contains("Cisco"))?.OperationalStatus == OperationalStatus.Up);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //if (VPNisON())
            //{
                emp = new EmployeeControl();
                if (emp.Login(this.tbUsername.Text, this.tbPassword.Text) == "HRManager")
                {
                    Employee hrmanager = emp.GetEmployeeByEmailAndPassword(this.tbUsername.Text, this.tbPassword.Text);
                    HRHome home = new HRHome(this, emp, hrmanager);
                    home.Show();
                    this.Hide();
                }
                else if (emp.Login(this.tbUsername.Text, this.tbPassword.Text) == "WarehouseManager")
                {
                    Employee whmanager = emp.GetEmployeeByEmailAndPassword(this.tbUsername.Text, this.tbPassword.Text);
                    WRHSHome home = new WRHSHome(this,whmanager, _itemControl);
                    home.Show();
                    this.Hide();

                }
                else if (emp.Login(this.tbUsername.Text, this.tbPassword.Text) == "Cashier")
                {
                    Employee casheer = emp.GetEmployeeByEmailAndPassword(this.tbUsername.Text, this.tbPassword.Text);
                    CashierHome home = new CashierHome(this, casheer, _itemControl);
                    home.Show();
                    this.Hide();
                }
                else if (emp.Login(this.tbUsername.Text, this.tbPassword.Text) == "Stocker")
                {
                    Employee stocker = emp.GetEmployeeByEmailAndPassword(this.tbUsername.Text, this.tbPassword.Text);
                    StockerHome home = new StockerHome(this,stocker, _itemControl);
                    home.Show();
                    this.Hide();
                }
                else
                {
                    StatusFunction("Invalid Credentials", -60, -5, 508, 28, Color.Red);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Please start Cisco AnyConnect!");
            //}
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            _startup.RemoveLogin(this);
        }
    }
}
