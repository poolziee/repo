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

namespace PRJMediaBazaar.Presentation.WareHouseManager
{
     partial class EditRestock : Form
    {
        private Item _item;
        private ItemControl _itemControl;
        private WRHSHome _whs;
        private List<Button> buttons;
        private List<Timer> timers;
        public EditRestock(Item item, WRHSHome whs)
        {
            InitializeComponent();
            _item = item;
            _whs = whs;

            buttons = new List<Button>();
            timers = new List<Timer>();

            this.lblItemInfo.Text = _item.ToString();
            this.lbItemInfo.Items.Add($"Available in shop: {_item.InShopAmount}/{_item.RoomInShop} items");
            this.lbItemInfo.Items.Add($"Available in storage: {_item.InStorageAmount}/{_item.RoomInStorage} items");
            this.lbItemInfo.Items.Add($"MAX to restock: {_item.GetMaxFreeSpaceInStorage()} items");
            this.tbOldAmount.Text = _item.AmountToRestock.ToString();
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
        private void btnChangeAmount_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            Helper.ValidateInteger(tbNewAmount.Text, "RoomShop", errors);

            if (errors.Any())
            {
                StatusFunction("Please enter a valid number!", -6, -1, 700, 28, Color.Red);
            }
            else
            {
                int newAMount = Convert.ToInt32(this.tbNewAmount.Text);
                if (newAMount <= _item.GetMaxFreeSpaceInStorage())
                {
                    _item.AmountToRestock = newAMount;
                   
                    _whs.LoadRestockingList();
                    this.Close();
                }
                else
                {
                    StatusFunction("Not enough available space in storage!", -6, -1, 700, 28, Color.Red);
                }
            } 

          
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++)
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
