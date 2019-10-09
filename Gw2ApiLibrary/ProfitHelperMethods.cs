using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class ProfitHelperMethods
    {
        public static void CalculateProfit(IList<ItemModel> list)
        {
            foreach (ItemModel item in list)
            {
                item.ProfitCalc();
            }
        }

        public static void ItemProfitDisplay(IList<ItemModel> ItemList, Dictionary<int, string> NameValues)
        {
            foreach (ItemModel item in ItemList)
            {
                if (item.ProfitCoins > 0)
                {
                    Console.WriteLine($"{NameValues[item.Id]} - {item.GoldFormat()} profit ({item.ProfitPercent})");
                }
            }
        }
    }
}
