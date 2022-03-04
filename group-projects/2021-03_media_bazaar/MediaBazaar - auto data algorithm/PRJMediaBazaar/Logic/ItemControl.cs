using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;


namespace PRJMediaBazaar.Logic
{
    class ItemControl : IRestockData
    {
        private List<Item> items;
        private ItemDAL itemDAL;
        public ItemControl()
        {
            items = new List<Item>();
            itemDAL = new ItemDAL();
            LoadItems();

        }
        public void LoadItems()
        {
            this.items = itemDAL.SelectAllItems();
        }


        public Item GetItem(int id)
        {
            return items.FirstOrDefault(i => i.ID == id);
        }

        public Item[] GetItemsByState(string state)
        {
            List<Item> temp = new List<Item>();
            foreach (Item i in items)
            {
                if (i.Restock_State == state)
                {
                    temp.Add(i);
                }
            }
            return temp.ToArray();
        }

        public Item[] GetItemsForMovingToShop()
        {
            List<Item> temp = new List<Item>();
            foreach (Item i in items)
            {
                if (i.InShopAmount < i.RoomInShop && i.GetMovingAmount() > 0)
                {
                    temp.Add(i);
                }
            }
            return temp.ToArray();
        }

        public Item GetItemByMovingInfo(string info)
        {
            return items.FirstOrDefault(i => i.MovingInfo() == info);
        }

        public Item GetItemByRestockInfo(string info)
        {
            return items.FirstOrDefault(i => i.RestockInfo() == info);
        }



        public void AddAnItem(String category, String subcategory ,String brand, String model, String description, double stock_price
                    , double price, String restock_state, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image)
        {
            itemDAL.AddItem(category,subcategory ,brand,model,description,stock_price.ToString(), price.ToString(), restock_state,
                roomInShop,roomInStorage,minimumAmountInStock,image);
            int id = itemDAL.LastItemId();
            Item temp = new Item(id, category,subcategory ,brand, model, description, stock_price, price, restock_state,
                roomInShop, roomInStorage, minimumAmountInStock,0, 0);
            temp.Image = image;
            items.Add(temp);
        }
        public bool DeleteAnItem(int id)
        {
            if (itemDAL.DeleteItem(id)==true)
            {
                for (int i=0;i<items.Count;i++)
                {
                    if (items[i].ID == id)
                    {
                        items.Remove(items[i]);
                        break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool UpdateAnItem(int id, String category, String subcategory ,String brand, String model, String description, double stock_price
                    , double price, String restock_state, int roomInShop, int roomInStorage,
                    int minimumAmountInStock, byte[] image)
        {
            if (itemDAL.UpdateItem(category, subcategory, brand, model, description, stock_price.ToString() , price.ToString(), restock_state,
                roomInShop, roomInStorage, minimumAmountInStock,image, id) ==true)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        items[i].Category = category;
                        items[i].Subcategory = subcategory;
                        items[i].Brand = brand;
                        items[i].Model = model;
                        items[i].Description = description;
                        items[i].Stock_Price = stock_price;
                        items[i].Price = price;
                        items[i].Restock_State = restock_state;
                        items[i].RoomInShop = roomInShop;
                        items[i].RoomInStorage = roomInStorage;
                        items[i].MinimumAmountInStock = minimumAmountInStock;

                        return true;
                    }
                }
                return false;
                
            }
            return false;
        }

        public bool NewRestock(Restock restock, int managerId)
        {
            return itemDAL.InsertNewRestock(restock, managerId);
        }

        public bool MoveItemToShop(Item item)
        {
            int movingAmount = item.GetMovingAmount();
            int newInShopAmount = item.InShopAmount + movingAmount;
            int newInStorageAmount = item.InStorageAmount -movingAmount;
            item.InShopAmount = newInShopAmount;
            item.InStorageAmount = newInStorageAmount;
            item.AmountToRestock = item.GetMaxFreeSpaceInStorage();
            if (itemDAL.UpdateItemAmounts(item.ID, newInShopAmount, newInStorageAmount))
            {
                if (item.InStorageAmount <= item.MinimumAmountInStock && item.Restock_State != "stocker")
                {
                    item.Restock_State = "stocker";
                    return itemDAL.UpdateItemState(item.ID, "stocker");
                }
            }
            return false;

        }

        public bool SendToManager(Item item)
        {
            item.Restock_State = "manager";
            return itemDAL.UpdateItemState(item.ID, "manager");
        }

        public bool NewOrder(Order order, int cashieerId)
        {
            return itemDAL.InsertNewOrder(order, cashieerId);
        }
      
        public List<String> GetCategories()
        {
            return itemDAL.GetCategories();
        }

        public List<Item> GetItems()
        {
            return this.items;
        }
        public List<Item> GetAvailableItems()
        {
            List<Item> temp = new List<Item>();
            foreach(Item item in this.items)
            {
                if(item.InShopAmount > 0)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
        public Item[] Items { get { return this.items.ToArray(); } }

        public byte[] GetItemImage(int itemID)
        {
            return this.itemDAL.GetItemImage(itemID);
        }
      
        public List<String> GetBrands(String subcategory)
        {
            return itemDAL.GetBrandsBySubcategory(subcategory);
        }
        public List<String> GetModels(String brand)
        {
            return itemDAL.GetModelsByBrand(brand);
        }

        public List<String> GetSubcategories(String category)
        {
            return itemDAL.GetSubcategoriesByCategory(category);
        }

        public void GenerateWorkday(Day day, int managerId, int cashierId)
        {
            //get a copy of the available items
            Item[] copy = GetAvailableItems().ToArray();
            List<Item> availableItems = copy.ToList();

            //shuffle the list
            availableItems.Shuffle();

            //generate orders for the day
            Random rnd = new Random();
            int rndOrdersCount = rnd.Next(5, 10);
            if(day.Date.Month == 8 && (day.Date.DayOfWeek == DayOfWeek.Friday || day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                rndOrdersCount = rnd.Next(10, 20);
            }
            else if (day.Date.Month == 12 && (day.Date.DayOfWeek == DayOfWeek.Friday || day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                rndOrdersCount = rnd.Next(10, 20);
            }
            else if (day.Date.Month == 1 && (day.Date.DayOfWeek == DayOfWeek.Friday || day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                rndOrdersCount = rnd.Next(10, 20);
            }
            for (int i = 1; i <= rndOrdersCount; i++)
            {
                if(GenerateOrder(cashierId, day.Date, availableItems))
                {
                     copy = GetAvailableItems().ToArray();
                    availableItems = copy.ToList();
                    availableItems.Shuffle();
                }
                else
                {
                    break;
                }
            }

            Item[] restocking = GetItemsByState("stocker");

            if (restocking.Count() > 0)
            {
                //restock the items (+ auto moving to shop)
                Restock restock = new Restock(this);
                itemDAL.InsertNewAutoRestock(restock, managerId, day.Date);

            }
        }


        public bool GenerateOrder(int cashierId, DateTime date, List<Item> availableItems)
        {
            if (availableItems.Count() == 0) return false;
            Random rnd = new Random();
            //create the ordered items list
            List<Item> cart = new List<Item>();

            //choose a ranom amount of items for the order
            int rndItemsCount = rnd.Next(2, 5);

            //loop the chosen amount of items
            for (int i = 1; i <= rndItemsCount; i++)
            { 

                Item item = availableItems[i];

                if(item.InShopAmount > 0)
                {
                    int scan = rnd.Next(1, 3);

                    if (item.InShopAmount >= scan)
                    {
                        item.ScannedAmount = scan;
                    }
                    else
                    {
                        item.ScannedAmount = item.InShopAmount;
                    }

                    //add it to the cart
                    cart.Add(item);
                }

            }

            if(cart.Count() > 0)
            {
                //send the order(+ auto moving to shop)
                Order order = new Order(cart);
                itemDAL.InsertNewAutoOrder(order, cashierId, date);
                return true;
            }
            return false;

        }


    }








    public static class Extensions
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
