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
                if (i.Restock_State == state && i.Missing == false)
                {
                    temp.Add(i);
                }
            }
            return temp.ToArray();
        }

        public Item[] GetMissingItemsByState(string state)
        {
            List<Item> temp = new List<Item>();
            foreach (Item i in items)
            {
                if (i.Restock_State == state && i.Missing == false)
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
            String id = new String(info.SkipWhile(c => !char.IsDigit(c))
                         .TakeWhile(c => char.IsDigit(c))
                         .ToArray());
            return this.GetItem(Convert.ToInt32(id));
        }

        public Item GetItemByExpectedRestockInfo(string info)
        {
            return items.FirstOrDefault(i => i.ExpectedRestockInfo() == info);
        }

        public Item GetItemByWaitingInfo(string info)
        {
            return items.FirstOrDefault(i => i.WaitingInfo() == info);
        }

        public Item GetItemByExpectedInfo(string info)
        {
            return items.FirstOrDefault(i => i.ArrivedInfo() == info);
        }



        public void AddAnItem(String category, String subcategory ,String brand, String model, String description, double stock_price
                    , double price, String restock_state, int roomInShop, int roomInStorage,
                    int minimumAmountInStock)
        {
            itemDAL.AddItem(category,subcategory ,brand,model,description,stock_price.ToString(), price.ToString(), restock_state,
                roomInShop,roomInStorage,minimumAmountInStock);
            int id = itemDAL.LastItemId();
            Item temp = new Item(id, category,subcategory ,brand, model, description, stock_price, price, restock_state,
                roomInShop, roomInStorage, minimumAmountInStock,0, 0);
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
                    int minimumAmountInStock)
        {
            if (itemDAL.UpdateItem(category, subcategory, brand, model, description, stock_price.ToString() , price.ToString(), restock_state,
                roomInShop, roomInStorage, minimumAmountInStock, id) ==true)
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

        public bool UpdateItemState(Item item, string newState)
        {
            item.Restock_State = newState;
            return itemDAL.UpdateItemState(item.ID, newState);
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

        public void UpdateItemStorageQuantity(int id, int amount)
        {
            itemDAL.UpdateItemStorageQuantity(id, amount);
        }

    }
}
