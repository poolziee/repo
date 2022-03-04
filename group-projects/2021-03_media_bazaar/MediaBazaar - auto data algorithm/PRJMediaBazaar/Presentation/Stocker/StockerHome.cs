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

namespace PRJMediaBazaar
{
     partial class StockerHome : Form
    {
        public static event  PRJMediaBazaar.Presentation.EventHandlerVoid UpdateWarehouseInfo;
        public static event PRJMediaBazaar.Presentation.EventHandlerVoid UpdateCashierInfo;

        private Employee _stocker;
        private ItemControl _itemControl;
        LogIn _login;
        public StockerHome(LogIn login, Employee stocker, ItemControl itemControl)
        {
            InitializeComponent();
            _login = login;
            _stocker = stocker;
            _itemControl = itemControl;
          
            this.pnlDashboard.Visible = true;
            this.pnlDashboard.BringToFront();
            CashierHome.UpdateStockerInfo += UpdateAvailableForMovingListbox;
            WRHSHome.UpdateInfo += UpdateAvailableForMovingListbox;
            UpdateAvailableForMovingListbox();
            UpdateRestockRequestListbox();
           
        }

        private void UpdateAvailableForMovingListbox()
        {
            this.lbSpacesInShop.Items.Clear();
            foreach (Item i in _itemControl.GetItemsForMovingToShop())
            {
                this.lbSpacesInShop.Items.Add(i.MovingInfo());
            }
        }

        private void UpdateRestockRequestListbox()
        {
            this.lbRestocks.Items.Clear();
            foreach (Item i in _itemControl.GetItemsByState("stocker"))
            {
                this.lbRestocks.Items.Add(i.RestockInfo());
            }
        }


        private void btnMoveItems_Click(object sender, EventArgs e)
        {
            if(this.lbSpacesInShop.Items.Count > 0)
            {
                foreach (string info in this.lbSpacesInShop.Items)
                {
                    Item item = _itemControl.GetItemByMovingInfo(info);
                    _itemControl.MoveItemToShop(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateCashierInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("No items to move");
            }
           
        }


        private void btnSendRestocks_Click(object sender, EventArgs e)
        {
            if (this.lbRestocks.Items.Count > 0)
            {
                foreach (string info in this.lbRestocks.Items)
                {
                    Item item = _itemControl.GetItemByRestockInfo(info);
                    _itemControl.SendToManager(item);
                }
                UpdateRestockRequestListbox();
                UpdateAvailableForMovingListbox();
                UpdateWarehouseInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("No items to send a restock");
            }
           
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void lbSpacesInShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lbSpacesInShop.SelectedIndex >= 0)
            {
                Item item = _itemControl.GetItemByRestockInfo(lbSpacesInShop.SelectedItem.ToString());
            }
        }

      
    }
}
