using Gw2ApiLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApiHelper.InitializeClient();

            // get project directory path
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // parse file containing item id and name info into dictionary
            Dictionary<int, string> parsedItemList = TextFileReader.ParseText(File.OpenRead($"{ projectDirectory }/ItemIdList.txt"));

            // strip ids from dictionairy keys to an array
            int[] mats= parsedItemList.Keys.ToArray();

            // get list of item models to parse through
            IList<ItemModel> itemModels = await CommerceProcessor.getItemPriceInfo(mats);

            ProfitHelperMethods.CalculateProfit(itemModels);
            ProfitHelperMethods.ItemProfitDisplay(itemModels, parsedItemList);
        }
    }
}
