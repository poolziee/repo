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
using System.IO;
using System.Threading;

namespace PRJMediaBazaar
{
    //public delegate void Xhandler();
     partial class WRHSHome : Form
    {
        public static event PRJMediaBazaar.Presentation.RestockHandler SendRestockForCheck;
        //public static event Xhandler SendRestockForCheck;


        private ItemControl itemControl;
        private LogIn login;
        private Item thisItem;
        private Item[] items;
        private Employee manager;

        public static Restock restock;
        List<Item> allItems;
        private List<Button> buttons;
        private List<System.Windows.Forms.Timer> timers;
        public WRHSHome(LogIn login, Employee whmanager, ItemControl itemControl)
        {
            InitializeComponent();
            this.lblItems.ForeColor = Color.Gray;
            this.login = login;
            this.itemControl = itemControl;
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();
            allItems = itemControl.GetItems();
            LoadItemsLESGOO();
            restock = new Restock(itemControl);
            LoadRestockingList();
            manager = whmanager;
            StockerHome.UpdateWarehouseInfo += LoadRestockingList;
            StockerHome.ChangeColorLabel += ChangeColor;
            this.pnlItems.BringToFront();
            this.pnlNavbar.BringToFront();
           
        }

        public void LoadRestockingList()
        {
            this.lbRestockRequests.Items.Clear();
            foreach(Item i in restock.GetItemsForRestock())
            {
                lbRestockRequests.Items.Add(i.RestockInfo());
            }
            this.lblTotalRestockCost.Text = restock.GetTotalCost().ToString() + " euro";

            if (restock.GetItemsForRestock().Count() > 0)
            {
                this.lblRestock.BackColor = Color.Red;
            }
            else
            {
                this.lblRestock.BackColor = Color.FromArgb(43, 45, 66);
            }
        }
        public void LoadRestockingList(String category)
        {
            this.lbRestockRequests.Items.Clear();
            foreach(Item i in restock.GetItemsForRestock())
            {
                if (i.Category == category)
                {
                    lbRestockRequests.Items.Add(i.RestockInfo());
                }
            }
            this.lblTotalRestockCost.Text = restock.GetTotalCost().ToString() + " euro";
            if (restock.GetItemsForRestock().Count() > 0)
            {
                if (this.lblRestock.ForeColor == Color.Gray)
                {
                    this.lblRestock.ForeColor = Color.Red;
                }
                this.lblRestock.ForeColor = Color.Red;
            }
        }
        public void LoadRestockingListBySubcategory(String subcategory)
        {
            this.lbRestockRequests.Items.Clear();
            foreach (Item i in restock.GetItemsForRestock())
            {
                if (i.Subcategory == subcategory)
                {
                    lbRestockRequests.Items.Add(i.RestockInfo());
                }
            }
            this.lblTotalRestockCost.Text = restock.GetTotalCost().ToString() + " euro";
            if (restock.GetItemsForRestock().Count() > 0)
            {
                this.lblRestock.BackColor = Color.Red;
            }
        }
        public void ChangeColor()
        {
            this.lblRestock.BackColor = Color.Red;
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
            System.Windows.Forms.Timer temp = new System.Windows.Forms.Timer();
            timers.Add(temp);
            temp.Start();
        }
        public void LoadItemsLESGOO()
        {
            this.cbCategories.Items.Clear();
            List<String> categories = this.itemControl.GetCategories();
            this.cbCategories.Items.AddRange(categories.ToArray());
        }
        private void lblItems_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = true;
            this.pnlRestock.Visible = false;
            this.lblItems.ForeColor = Color.Gray;
            this.lblRestock.ForeColor = Color.White;

            this.pnlItems.BringToFront();
            this.pnlNavbar.BringToFront();
        }

        private void lblStatistics_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlRestock.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
        }

        private void lblRestock_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlRestock.Visible = true;

            this.lblItems.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.Gray;

            this.pnlRestock.BringToFront();
            this.pnlNavbar.BringToFront();
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlRestock.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
        }

        private void WRHSHome_Load(object sender, EventArgs e)
        {

        }

        private void WRHSHome_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lbItems.Items.Clear();
                this.cbSubcategory.SelectedItem = null;
                this.cbBrand.SelectedItem = null;
                this.cbSubcategory.Items.Clear();
                this.cbBrand.Items.Clear();
                foreach (Item temp in allItems)
                {
                    if (temp.Category == this.cbCategories.SelectedItem.ToString())
                    {
                        this.lbItems.Items.Add(temp.ToString());
                    }
                }
                this.cbSubcategory.Enabled = true;
                List<String> subcategories = this.itemControl.GetSubcategories(this.cbCategories.SelectedItem.ToString());
                this.cbSubcategory.Items.AddRange(subcategories.ToArray());
            }
            catch (Exception ex)
            {
                StatusFunction("An error occured!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<buttons.Count;i++)
            {
                if (timers[i].Enabled==true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }
        public ItemControl GetItemControl()
        {
            return this.itemControl;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem add = new AddItem(this, itemControl);
            add.Show();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.lbItems.SelectedItem == null)
                StatusFunction("Select an item!", -6, -1, 900, 28, Color.Red);
            else
            {
                string id1 = new string(this.lbItems.SelectedItem.ToString().SkipWhile(c => !char.IsDigit(c))
                        .TakeWhile(c => char.IsDigit(c))
                        .ToArray());
                int id = Convert.ToInt32(id1);
                thisItem = this.itemControl.GetItem(id);
                if (thisItem != null)
                {
                    EditItem edit = new EditItem(this, thisItem, itemControl);
                    edit.Show();
                }
                else
                    StatusFunction("No item found!", -6, -1, 900, 28, Color.Red);
            }
           
        }

        //private void cbBrands_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.cbModel.SelectedItem != null)
        //    {
        //        this.lbItems.Items.Clear();
        //        this.cbModel.SelectedItem = null;
        //        foreach (Item temp in allItems)
        //        {
        //            if (temp.Subcategory == this.cbBrandd.SelectedItem.ToString())
        //            {
        //                this.lbItems.Items.Add(temp.ToString());
        //            }
        //        }
        //        this.cbModel.Enabled = true;
        //        List<String> models = this.itemControl.GetModels(this.cbBrandd.SelectedItem.ToString());
        //        this.cbModel.Items.AddRange(models.ToArray());

        //    }
           
        //}

        //private void cbModels_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.cbBrandd.SelectedItem != null)
        //    {
        //        this.lbItems.Items.Clear();
        //        foreach (Item temp in allItems)
        //        {

        //            if (temp.Model == this.cbModel.SelectedItem.ToString())
        //            {
        //                this.lbItems.Items.Add(temp.ToString());

        //            }
        //        }
        //    }

            
        //}

        private void label5_Click(object sender, EventArgs e)
        {

        }






        public void ChangeComboBoxes()
        {
            this.cbSubcategory.Enabled = false;
            this.cbBrand.Enabled = false;
            this.lbItems.Items.Clear();
            this.cbCategories.Text = "";
            this.cbSubcategory.Text = "";
            this.cbBrand.Text = "";
        }


        private void cbSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbSubcategory.SelectedItem != null)
                {
                    this.lbItems.Items.Clear();
                    this.cbBrand.SelectedItem = null;
                    this.cbBrand.Items.Clear();
                    foreach (Item temp in allItems)
                    {
                        if (temp.Subcategory == this.cbSubcategory.SelectedItem.ToString() && temp.Category == this.cbCategories.SelectedItem.ToString())
                        {
                            this.lbItems.Items.Add(temp.ToString());
                        }
                    }
                    this.cbBrand.Enabled = true;
                    List<String> brands = this.itemControl.GetBrands(this.cbSubcategory.SelectedItem.ToString());
                    this.cbBrand.Items.AddRange(brands.ToArray());

                }
            }
            catch (Exception ex)
            {
                StatusFunction("An error occured!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbBrand.SelectedItem != null)
                {
                    this.lbItems.Items.Clear();
                    foreach (Item temp in allItems)
                    {

                        if (temp.Brand == this.cbBrand.SelectedItem.ToString() && temp.Subcategory == this.cbSubcategory.SelectedItem.ToString())
                        {
                            this.lbItems.Items.Add(temp.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StatusFunction("An error occured!", -6, -1, 900, 28, Color.Red);
            }
        }

        private void pnlItems_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditAmount_Click(object sender, EventArgs e)
        {
            if (this.lbRestockRequests.SelectedItem != null)
            {
                string info = this.lbRestockRequests.SelectedItem.ToString();
                string[] cut = info.Split(' ');
                int id = Convert.ToInt32(cut[1]);
                Item item = itemControl.GetItem(id);
                PRJMediaBazaar.Presentation.WareHouseManager.EditRestock form = new Presentation.WareHouseManager.EditRestock(item,this);
                form.Show();
            }
            else
            {
                StatusFunction("Please select an item!", -6, -1, 900, 28, Color.Red);
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (this.lbRestockRequests.SelectedItem == null && this.cbCategories_Restock.Text == "")
            //{
            //    if (restock.GetItemsForRestock().Count() > 0)
            //    {
            //        itemControl.NewRestock(restock, manager.Id);
            //        restock = null;
            //        restock = new Restock(itemControl);

                   
            //        StatusFunction("Successfully sent restock", -6, -1, 900, 28, Color.Green);
                   
            //        SendRestockForCheck?.Invoke(restock);

            //        restock = null;
            //        restock = new Restock(itemControl);

            //        LoadRestockingList();


            //        if (this.lblRestock.ForeColor == Color.Red)
            //        {
            //            this.lblRestock.ForeColor = Color.White;
            //        }

            //        if (restock.GetItemsForRestock().Count() == 0)
            //        {
            //            this.lblRestock.BackColor = Color.Black;
            //        }
            //    }
            //    else
            //    {
            //        StatusFunction("No items for restock", -6, -1, 900, 28, Color.Red);
            //    }
            //}
            //else
            //{
            //    this.lbRestockRequests.Items.Remove(this.lbRestockRequests.SelectedItem);
            //    StatusFunction("Successfully sent restock", -6, -1, 900, 28, Color.Green);
            //}


            //............

            if (restock.GetItemsForRestock().Count() > 0)
            {
                itemControl.NewRestock(restock, manager.Id);



                SendRestockForCheck?.Invoke(restock);
                restock = null;
                restock = new Restock(itemControl);
                StatusFunction("Successfully sent restock", -6, -1, 900, 28, Color.Green);
                LoadRestockingList();
               
            }
            else
            {
                StatusFunction("No items for restock", -6, -1, 900, 28, Color.Red);
            }


        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.cbBrand.Text = "";
            this.cbCategories.Text = "";
            this.cbSubcategory.Text = "";
            this.cbBrand.Enabled = false;
            this.cbSubcategory.Enabled = false;
            this.lbItems.Items.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }
    }
}
