using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    public interface IRestockData
    {
        Item[] GetItemsByState(string state);
    }
}
