using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Order
    {
        
        private List<Item> boughtItems;

        public Order(List<Item> itemsToBuy)
        {
            boughtItems = itemsToBuy;
        }

        public List<Item> BoughtItems { get { return this.boughtItems; } }

        public void AddItemToOrder(Item item)
        {
            this.boughtItems.Add(item);
          
        }


        /// <summary>
        /// 
        /// ScanedAmmount represents the amount of times an item has been scaned. If we continue to
        /// go with this option we will have to add a new column in the database. Possibly there is a
        /// simpler way to do this!
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetTotalPrice()
        {
            double value = 0;

            foreach (Item i in boughtItems)
            {
                value += i.ScannedAmount * i.Price;
            }
            return value;
        }

    }
}
