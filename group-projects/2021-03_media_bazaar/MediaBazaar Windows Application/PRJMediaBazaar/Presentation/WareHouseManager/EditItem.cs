using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;
using System.IO;

namespace PRJMediaBazaar
{
     partial class EditItem : Form
    {

        private WRHSHome wh;
        private Item x;
        private ItemControl _itemControl;

        private List<Button> buttons;
        private List<System.Windows.Forms.Timer> timers;
        public EditItem(WRHSHome wh,Item x, ItemControl itemControl)
        {
            InitializeComponent();
            _itemControl = itemControl;
            this.wh = wh;
            this.x = x;
            buttons = new List<Button>();
            timers = new List<System.Windows.Forms.Timer>();
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
        private void EditItem_Load(object sender, EventArgs e)
        {
            this.cbCategory.Text = x.Category;
            this.cbSubcategory.Text = x.Subcategory; // maybe make method to get trait by name
            this.cbBrand.Text = x.Brand; // maybe make method to get trait by name
            this.tbModel.Text = x.Model; // maybe make method to get trait by name
            this.tbDescription.Text = x.Description;
            this.tbStockPrice.Text = x.Stock_Price.ToString();
            this.tbPrice.Text = x.Price.ToString();
            this.tbRoomShop.Value = x.RoomInShop;
            this.tbRoomStorage.Value = x.RoomInStorage;
            this.tbMinimumAmount.Text = x.MinimumAmountInStock.ToString();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>();
                Helper.ValidateInteger(tbRoomShop.Text, "RoomShop", errors);
                Helper.ValidateInteger(tbRoomStorage.Text, "RoomStorage", errors);
                Helper.ValidateInteger(tbMinimumAmount.Text, "MinimumAmount", errors);
                Helper.ValidateString(cbCategory.Text, "Category", errors);
                Helper.ValidateString(cbCategory.Text, "Brand", errors);
                Helper.ValidateString(tbModel.Text, "Model", errors);
                Helper.ValidateString(tbStockPrice.Text, "Stock_Price", errors);
                Helper.ValidateString(tbDescription.Text, "Description", errors);
                Helper.ValidateDouble(tbPrice.Text, "Price", errors);

                if (errors.Any())
                {
                    throw new InputException(errors);
                }

                int id = x.ID;
                string category = cbCategory.Text;
                string subcategory = cbSubcategory.Text;
                string brand = cbBrand.Text;
                string model = tbModel.Text;
                string description = tbDescription.Text;
                double stock_price = Convert.ToDouble(this.tbStockPrice.Text);
                double price = Convert.ToDouble(tbPrice.Text);
                int roomShop = Convert.ToInt32(tbRoomShop.Text);
                int roomStorage = Convert.ToInt32(tbRoomStorage.Text);
                int minAmount = Convert.ToInt32(tbMinimumAmount.Text);
                String restock_state = "manager";
                if (stock_price > (3 * price) / 5)
                {
                    throw new Exception("Stock Price needs to be at least 60% of Selling Price!");
                }
                if (roomShop > roomStorage / 2)
                {
                    throw new Exception("Room in shop needs to be less than 50% of room in storage!");
                }
                _itemControl.UpdateAnItem(id, category, subcategory ,brand, model, description,stock_price, price, restock_state,
                     roomShop, roomStorage, minAmount);
                wh.LoadItemsLESGOO();
                wh.ChangeComboBoxes();
                StatusFunction("Item updated!", -6, -1, 700, 28, Color.Green);

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
            this.cbBrand.Text = null;
            this.cbSubcategory.Items.Clear();
            this.cbSubcategory.Text = null;
            switch (this.cbCategory.SelectedItem.ToString())
            {
                case ("Electronics"):
                    this.cbSubcategory.Items.AddRange(new String[] { "Laptop", "Desktop", "Monitor", "TV", "Phone", "Smart-Watch" });
                    this.cbBrand.Items.AddRange(new String[] { "Asus", "Samsung", "Acer", "LG", "Hama", "Apple", "Microsoft" });
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
    }
}
