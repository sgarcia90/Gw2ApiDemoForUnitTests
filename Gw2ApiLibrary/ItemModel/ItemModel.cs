using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class ItemModel
    {
        public int Id { get; set; }
        public ItemBuysModel Buys { get; set; }
        public ItemSellsModel Sells { get; set; }
        public int ProfitCoins;
        public string ProfitPercent;
        public ItemModel(int i, ItemBuysModel b, ItemSellsModel s)
        {
            Id = i;
            Buys = b;
            Sells = s;
        }

        public void ProfitCalc()
        {
            FindProfitInCoins();
            CalcProfitPercent();
        }

        public int FindActualSellValue()
        {
            int sellValue = Convert.ToInt32(Sells.Unit_Price * .85);
            return sellValue;
        }

        // find profit when buying at buy value and selling at sell value(NOT buy value)
        public void FindProfitInCoins()
        {
            int sellValue = FindActualSellValue();
            ProfitCoins = sellValue - Buys.Unit_Price;
        }

        public void CalcProfitPercent()
        {
            if (ProfitCoins > 0)
            {
                double PercentValue = ((double)ProfitCoins / Buys.Unit_Price) * 100;
                ProfitPercent = $"{ PercentValue.ToString("#.##") }%";
            }
            else
                ProfitPercent = "0%";
        }


        public string GoldFormat()
        {
            int ProfitCoinsAbs = Math.Abs(ProfitCoins);
            int g = ProfitCoinsAbs / 10000;
            int s = (ProfitCoinsAbs - (g * 10000)) / 100;
            int c = (ProfitCoinsAbs - (g * 10000) - (s * 100));

            if (ProfitCoins >= 0)
            {
                return $"{g}g {s}s {c}c";
            }
            return $"-{g}g {s}s {c}c";

        }
    }
}
