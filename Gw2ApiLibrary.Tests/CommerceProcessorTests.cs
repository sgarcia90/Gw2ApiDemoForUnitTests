using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gw2ApiLibrary.Tests
{
    public class CommerceProcessorTests
    {
        [Fact]
        public async void GetItemPriceInfo_CallGw2ApiAndReturnListOfItemModels()
        {
            // Arrange
            ApiHelper.InitializeClient();
            int[] fakeMatsArray = { 19700, 19722, 30689 };


            // Act
            IList<ItemModel> itemModels = await CommerceProcessor.getItemPriceInfo(fakeMatsArray);


            // Assert
            Assert.True(itemModels.Count == 3);
            Assert.Equal(19700, itemModels[0].Id);
        }

        [Fact]
        public async void GetItemPriceInfo_CallGw2ApiWithInvalidIdShouldFail()
        {
            ApiHelper.InitializeClient();
            int[] fakeMatsArray = { int.MaxValue };

            await Assert.ThrowsAsync<Exception>(async () => await CommerceProcessor.getItemPriceInfo(fakeMatsArray));
        }
    }
}
