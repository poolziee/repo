using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
    partial class ExplainDenial : Form
    {
        private DayOff dayOff;
        private AbsenceControl ab;
        private HRHome hr;
        private List<Button> buttons;
        private List<Timer> timers;
        public ExplainDenial(DayOff d, AbsenceControl ab, HRHome hr)
        {
            InitializeComponent();
            buttons = new List<Button>();
            timers = new List<Timer>();
            this.dayOff = d;
            this.ab = ab;
            this.hr = hr;
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


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void ExplainDenial_Load(object sender, EventArgs e)
        {

        }

     

        private void timer1_Tick_1(object sender, EventArgs e)
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

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if(this.tbExplain.Text == "" || this.tbExplain.Text.Length < 5)
            {
                MessageBox.Show("Please type a reason");
            }
            else
            {
                this.ab.DenyDayOffRequest(dayOff.RequestId, this.tbExplain.Text);
                hr.RemoveDayOff(dayOff);
                hr.StatusFunction("Day off denied", -6, -1, 900, 28, Color.Green);
                this.Close();
                hr.CheckDayOffLabel();
            }
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
    }
}