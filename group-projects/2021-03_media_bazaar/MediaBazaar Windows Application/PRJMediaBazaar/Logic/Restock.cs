using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Restock
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
            //itemsToRestock = _itemControl.GetItemsByState("checking");
            return itemsToRestock;

        }

        public Item[] GetItemsForExpected()
        {
            itemsToRestock = _itemControl.GetItemsByState("checking");
            return itemsToRestock;
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
