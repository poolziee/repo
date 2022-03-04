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
        public EditRestock(Item item, WRHSHome whs)
        {
            InitializeComponent();
            _item = item;
            _whs = whs;

            this.lblItemInfo.Text = _item.ToString();
            this.lbItemInfo.Items.Add($"Available in shop: {_item.InShopAmount}/{_item.RoomInShop} items");
            this.lbItemInfo.Items.Add($"Available in storage: {_item.InStorageAmount}/{_item.RoomInStorage} items");
            this.lbItemInfo.Items.Add($"MAX to restock: {_item.GetMaxFreeSpaceInStorage()} items");
            this.tbOldAmount.Text = _item.AmountToRestock.ToString();
        }

        private void btnChangeAmount_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            Helper.ValidateInteger(tbNewAmount.Text, "RoomShop", errors);

            if (errors.Any())
            {
                MessageBox.Show("Please enter valid number");
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
                    MessageBox.Show("Not enough available space in storage");
                }
            }

          
        }
    }
}
