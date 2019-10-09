using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class CommerceProcessor
    {
        public static async Task<IList<ItemModel>> getItemPriceInfo(int[] itemIdList)
        {
            if (itemIdList.Length < 1)
                throw new ArgumentException("Provided list has no entries.", "itemIdList");

            string url = $"v2/commerce/prices?ids={itemIdList[0]}";

            if (itemIdList.Length > 1)
            {
                for (int i = 1; i < itemIdList.Length; i++)
                {
                    url = $"{url},{itemIdList[i]}";
                }
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    string results = await response.Content.ReadAsStringAsync();
                    IList<ItemModel> data = JsonConvert.DeserializeObject<IList<ItemModel>>(results);

                    return data;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
