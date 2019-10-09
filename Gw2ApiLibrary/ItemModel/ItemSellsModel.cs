using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class ItemSellsModel
    {
        public int Quantity { get; set; }
        public int Unit_Price { get; set; }
        public ItemSellsModel(int q, int u)
        {
            Quantity = q;
            Unit_Price = u;
        }
    }
}
