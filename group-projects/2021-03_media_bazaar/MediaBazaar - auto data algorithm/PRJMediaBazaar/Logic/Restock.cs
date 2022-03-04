using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class Restock
    {
        private IRestockData _itemControl;
        private Item[] itemsToRestock;

        public Restock(IRestockData itemControl)
        {
            _itemControl = itemControl;
           
        }

        public Item[] GetItemsForRestock()
        {
            itemsToRestock = _itemControl.GetItemsByState("manager");
            return itemsToRestock;

        }

        public Item[] GetItemsForAutoRestock()
        {
            itemsToRestock = _itemControl.GetItemsByState("stocker");
            return itemsToRestock;

        }

        public double GetTotalCostAuto()
        {
            double value = 0;

            foreach (Item i in GetItemsForAutoRestock())
            {
                value += i.AmountToRestock * i.Stock_Price;
            }
            return value;
        }

        public double GetTotalCost()
        {
            double value = 0;

            foreach(Item i in itemsToRestock)
            {
                value += i.AmountToRestock * i.Stock_Price;
            }
            return value;
        }
    }
}
