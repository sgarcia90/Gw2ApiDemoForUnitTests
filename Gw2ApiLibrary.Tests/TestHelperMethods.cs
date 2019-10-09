using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary.Tests
{
    public static class TestHelperMethods
    {
        public static ItemModel DefaultItemModelFactory(int modelNumber)
        {
            int id = 19000;
            int bQuantity = 100;
            int sQuantity = 100;
            int bValue;
            int sValue;
            
            if (modelNumber == 1)
            {
                bValue = 10000;
                sValue = 12000;
            }
            else if (modelNumber == 2)
            {
                bValue = 472;
                sValue = 568;
            }
            else if (modelNumber == 3)
            {
                bValue = 21996724;
                sValue = 22405613;
            }
            else
            {
                throw new Exception("Enter a modelNumber between 1 and 3, inclusive.");
            }

            return new ItemModel(id, new ItemBuysModel(bQuantity, bValue), new ItemSellsModel(sQuantity, sValue));
        }
    }
}
