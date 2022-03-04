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
        private bool validData;

        private string path;
        private Image image;
        private Thread getImageThread;
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

        /*Drag And Drop events*/
        private void AddItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        private void AddItem_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pbxItem.Image = ScaleImage(image);
                image = pbxItem.Image;
                byte[] img = ImageToBinary(image);
                //MessageBox.Show($"Img size: {img.Length}");
            }
        }

        /*Helping methods for the image*/
      
        private void LoadImage()
        {
            image = new Bitmap(path);
        }
        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }
        private Image ScaleImage(Image image)
        {
            int height = this.pbxItem.Height;
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
        private byte[] ImageToBinary(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /*Functions*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            if (image != null)
            {
                img = ImageToBinary(image);
            }
            try
            {
                if(img == null)
                {
                    throw new InvalidImageException();
                }

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
                    roomShop, roomStorage, minAmount, img);
                _wh.LoadItemsLESGOO();
                _wh.LoadRestockingList();

                StatusFunction("Item added!", -6, -1, 900, 28, Color.Red);
                if(WRHSHome.restock == null)
                {
                    WRHSHome.restock = new Restock(_wh.GetItemControl());
                }
                //throw custom exception if img == null
                //throw other exceptions for the other variables(empty/short strings, low values in stock, etc.)

                //add the item through itemControl.
            }
            catch (InvalidImageException)
            {
                StatusFunction("You should provide an image !", -6, -1, 900, 28, Color.Red);
            }
            catch (InputException ex)
            {
                StatusFunction(ex.ToString(), -6, -1, 900, 28, Color.Red);
            }
            //catch (Exception ex)
            //{
            //    StatusFunction(ex.Message, -6, -1, 900, 28, Color.Red);
            //}
            
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
                default:
                    break;
            }
        }

        private void cbSubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
