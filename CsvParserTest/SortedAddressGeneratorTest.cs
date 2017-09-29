using System.Linq;
using CsvParser;
using Xunit;

namespace CsvParserTest
{
   public  class SortedAddressGeneratorTest
    {
        [Fact]
        public void SortedAddressGenerator_Add_Address_By_StreetName()
        {
            var sut = new SortedAddressGenerator();
            sut.AddStreetAddressInList("102 Long Lane");
            sut.AddStreetAddressInList("65 Ambling Way");
            sut.AddStreetAddressInList("82 Stewart St");
            sut.AddStreetAddressInList("12 Howard St");
            sut.AddStreetAddressInList("105 Pine St");
            sut.AddStreetAddressInList("78 Short Lane");
            sut.AddStreetAddressInList("49 Sutherland St");
            sut.AddStreetAddressInList("8 Crimson Rd");
            sut.AddStreetAddressInList("120 Pine St");
            sut.AddStreetAddressInList("94 Roland St");
            var sortedAddressBySreetName = sut.AddressListSortedByStreetName.ToArray();
            Assert.Equal(sortedAddressBySreetName[0].Value, "65 Ambling Way", true);
            Assert.Equal(sortedAddressBySreetName[1].Value, "8 Crimson Rd", true);
            Assert.Equal(sortedAddressBySreetName[2].Value, "12 Howard St", true);
            Assert.Equal(sortedAddressBySreetName[3].Value, "102 Long Lane", true);
            Assert.Equal(sortedAddressBySreetName[4].Value, "120 Pine St", true);
            Assert.Equal(sortedAddressBySreetName[5].Value, "105 Pine St", true);
            Assert.Equal(sortedAddressBySreetName[6].Value, "94 Roland St", true);
            Assert.Equal(sortedAddressBySreetName[7].Value, "78 Short Lane", true);
            Assert.Equal(sortedAddressBySreetName[8].Value, "82 Stewart St", true);
            Assert.Equal(sortedAddressBySreetName[9].Value, "49 Sutherland St", true);
        }
    }
}
