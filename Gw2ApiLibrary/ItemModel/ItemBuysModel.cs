using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class ItemBuysModel
    {
        public int Quantity { get; set; }
        public int Unit_Price { get; set; }

        public ItemBuysModel(int q, int u)
        {
            Quantity = q;
            Unit_Price = u;
        }
    }
}
