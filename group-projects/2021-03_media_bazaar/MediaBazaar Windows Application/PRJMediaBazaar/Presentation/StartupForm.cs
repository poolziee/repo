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
using System.Net.NetworkInformation;

namespace PRJMediaBazaar.Presentation
{
    public delegate void EventHandlerVoid();
    public delegate void RestockHandler(Restock restock);
    partial class StartupForm : Form
    {
        private Dictionary<string, string> credentials;
        private List<LogIn> forms;
        public StartupForm()
        {
            InitializeComponent();
            forms = new List<LogIn>();
            credentials = new Dictionary<string, string>();
            credentials.Add("matthew.murdock@mail.com", "matthew1");
            credentials.Add("daniel.burton@mail.com", "daniel1");
            credentials.Add("daniel.meachum@mail.com", "daniel1");

        }

        public static bool VPNisON()
        {
            return ((NetworkInterface.GetIsNetworkAvailable())
                    && NetworkInterface.GetAllNetworkInterfaces()
                                       .FirstOrDefault(ni => ni.Description.Contains("Cisco"))?.OperationalStatus == OperationalStatus.Up);
        }

        private void btnSingleLogin_Click(object sender, EventArgs e)
        {
            //if (VPNisON())
            //{
                ItemControl itemControl = new ItemControl();
                LogIn first = new LogIn(this,itemControl, "","");
                forms.Add(first);
                first.Show();
                this.Hide();
            //}
           
        }

        private void btnMultipleLogin_Click(object sender, EventArgs e)
        {
            //if (VPNisON())
            //{
                ItemControl itemControl = new ItemControl();
                LogIn first = new LogIn(this, itemControl, credentials.ElementAt(0).Key,credentials.ElementAt(0).Value );
                LogIn second = new LogIn(this, itemControl, credentials.ElementAt(1).Key, credentials.ElementAt(1).Value);
                LogIn third = new LogIn(this, itemControl, credentials.ElementAt(2).Key, credentials.ElementAt(2).Value);
                first.Show();
                second.Show();
                third.Show();
                forms.Add(first);
                forms.Add(second);
                forms.Add(third);


                this.Hide();
            //}
          
        }

        public void RemoveLogin(LogIn login)
        {
            forms.Remove(login);
            if(forms.Count == 0)
            {
                this.Close();
            }
        }

    

        private void StartupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
