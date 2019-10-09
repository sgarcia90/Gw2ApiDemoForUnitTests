using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gw2ApiLibrary;
using Xunit;

namespace Gw2ApiLibrary.Tests
{
    public class ItemModelTests
    {
        [Theory]
        [InlineData(1, 10200)]
        [InlineData(2, 483)]
        [InlineData(3, 19044771)]
        public void FindActualSellValue_ReturnSellValueAfterTaxes(int modelNumber, int expected)
        {
            // Arrange
            ItemModel fakeModel = TestHelperMethods.DefaultItemModelFactory(modelNumber);

            // Act
            int actual = fakeModel.FindActualSellValue();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 200)] //10000
        [InlineData(2, 11)] //472
        [InlineData(3, -2951953)] //21996724
        public void FindProfitInCoins_SellValueActualAndBuyValueShouldCalculate(int modelNumber, int expected)
        {
            ItemModel fakeModel = TestHelperMethods.DefaultItemModelFactory(modelNumber);
            fakeModel.FindProfitInCoins();

            int actual = fakeModel.ProfitCoins;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "2%")]
        [InlineData(2, "2.33%")]
        [InlineData(3, "0%")]
        public void CalcProfitPercent_SetPercentProfitAppropriately(int modelNumber, string expected)
        {
            ItemModel fakeModel = TestHelperMethods.DefaultItemModelFactory(modelNumber);
            fakeModel.FindProfitInCoins();
            fakeModel.CalcProfitPercent();

            string actual = fakeModel.ProfitPercent;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "0g 2s 0c")]
        [InlineData(2, "0g 0s 11c")]
        [InlineData(3, "-295g 19s 53c")]
        public void GoldFormat_DispalyFormattedStringOfCoins(int modelNumber, string expected)
        {
            ItemModel fakeModel = TestHelperMethods.DefaultItemModelFactory(modelNumber);
            fakeModel.FindProfitInCoins();

            string actual = fakeModel.GoldFormat();

            Assert.Equal(expected, actual);
        }
    }
}
