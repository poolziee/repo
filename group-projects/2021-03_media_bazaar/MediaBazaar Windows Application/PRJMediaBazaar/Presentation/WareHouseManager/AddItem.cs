using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using PRJMediaBazaar.Logic;
using System.Globalization;

namespace PRJMediaBazaar
{
    partial class AddItem : Form
    {

        private ItemControl _itemControl;
        private WRHSHome _wh;
        private List<Button> buttons;
        private List<System.Windows.Forms.Timer> timers;


        public AddItem(WRHSHome wh, ItemControl itemControl)
        {
            InitializeComponent();
            _itemControl = itemControl;
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();
            _wh = wh;
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
        /*Functions*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                List<string> errors = new List<string>();
                Helper.ValidateInteger(tbRoomShop.Text, "RoomShop", errors);
                Helper.ValidateInteger(tbRoomStorage.Text, "RoomStorage", errors);
                Helper.ValidateInteger(tbMinimumAmount.Text, "MinimumAmount", errors);
                Helper.ValidateString(cbCategory.Text, "Category", errors);
                Helper.ValidateString(cbSubcategory.Text, "Subcategory", errors);
                Helper.ValidateString(cbBrand.Text, "Brand", errors);
                Helper.ValidateString(tbStockPrice.Text, "Stock_Price", errors);
                Helper.ValidateString(tbModel.Text, "Model", errors);
                Helper.ValidateString(tbDescription.Text, "Description", errors);
                Helper.ValidateDouble(tbPrice.Text, "Price", errors);

                if (errors.Any())
                {
                    throw new InputException(errors);
                }
                string category = this.cbCategory.Text;
                string subcategory = this.cbSubcategory.Text;
                string brand = this.cbBrand.Text;
                string model = tbModel.Text;
                string description = tbDescription.Text;
                tbPrice.Text = tbPrice.Text.Replace('.', ',');
                double price = Helper.ToDouble(tbPrice.Text); // investigate double.tryparse
                double stock_price = Helper.ToDouble(tbStockPrice.Text);
                String restock_state = "manager";
                int roomShop = Convert.ToInt32(tbRoomShop.Text);
                int roomStorage = Convert.ToInt32(tbRoomStorage.Text);
                int minAmount = Convert.ToInt32(tbMinimumAmount.Text);
                if (stock_price > (3 * price) / 5)
                {
                    throw new Exception("Stock Price needs to be at least 60% of Selling Price!");
                }
                if (roomShop > roomStorage/2)
                {
                    throw new Exception("Room in shop needs to be less than 50% of room in storage!");
                }
                _itemControl.AddAnItem(category,subcategory ,brand, model, description,stock_price ,price,restock_state,
                    roomShop, roomStorage, minAmount);
                _wh.LoadItemsLESGOO();
                _wh.LoadRestockingList();

                _wh.ChangeComboBoxes();
                if(WRHSHome.restock == null)
                {
                    WRHSHome.restock = new Restock(_wh.GetItemControl());
                }
                //throw custom exception if img == null
                //throw other exceptions for the other variables(empty/short strings, low values in stock, etc.)

                //add the item through itemControl.
                StatusFunction("Item added!", -6, -1, 700, 28, Color.Green);
            }
            catch (InputException ex)
            {
                StatusFunction(ex.ToString(), -6, -1, 700, 28, Color.Red);
            }
            catch (Exception ex)
            {
                StatusFunction(ex.Message, -6, -1, 700, 28, Color.Red);
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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbBrand.Items.Clear();
            this.cbSubcategory.Items.Clear();
            this.cbBrand.Text = null;
            switch (this.cbCategory.SelectedItem.ToString())
            {
                case ("Electronics"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Laptop", "Desktop", "Monitor", "TV", "Phone", "Smart-Watch"});
                    this.cbBrand.Items.AddRange(new String[] { "Asus", "Samsung","Acer","LG","Hama","Apple","Microsoft"});
                    break;
                case ("Fashion"):
                    this.cbSubcategory.Items.AddRange(new String[] { "T-Shirt", "Jacket", "Dress", "Shoe", "Pants", "Hoodie" });
                    this.cbBrand.Items.AddRange(new String[] { "Balenciaga", "Versace", "Palm Angels", "Louis Vuitton", "Off-White", "Nike", "Addidas" });
                    break;
                case ("Furniture"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Table", "Chair", "Sofa", "Armchair", "Desk", "Bench" });
                    this.cbBrand.Items.AddRange(new String[] { "Ikea", "Poly & Bark", "Thuma", "RH" });
                    break;
                case ("Sports and Outdoors"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Ball", "Racket", "Disk", "Net", "Rod", "Skateboard" });
                    this.cbBrand.Items.AddRange(new String[] { "Addidas", "Nike", "Under Armour", "Salomon", "Puma", "Rebook" });
                    break;
                case ("Software"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Windows", "Linux", "Mac", "NOD32", "BitDefender", "Avast" });
                    this.cbBrand.Items.AddRange(new String[] { "Microsoft", "Apple", "Steam", "IBM" });
                    break;
                case ("Accessories"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Controller", "Flash drive", "Microphone", "Cable", "Printer", "eBook" });
                    this.cbBrand.Items.AddRange(new String[] { "Microsoft", "Samsung", "Playstation", "XBox" });
                    break;
                default:
                    break;
            }
        }

        private void cbSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
