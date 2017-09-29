using System.Linq;
using CsvParser;
using Xunit;

namespace CsvParserTest
{
    public class FirstNameAndLastNameFrequencyCalculatorTest
    {
        [Fact]
        public void FrequencyCalculator_Should_Calculate_FirstName_LastName_Freuquency()
        {
            var sut = new FirstNameAndLastNameFrequencyCalculator();
            CreateFirstNameLastNameDictionary(sut);

            var firstNameLastNameWithFrequency2 = from item in sut.FirstNameAndLastNameFrequncies
                where item.Value == 2
                select item;
            var firstNameLastNameWithFrequency1 = from item in sut.FirstNameAndLastNameFrequncies
                where item.Value == 1
                select item;

            Assert.Equal(firstNameLastNameWithFrequency2.Count(), 2);
            Assert.Equal(firstNameLastNameWithFrequency1.Count(), 5);
        }

        [Fact]
        public void FrequencyCalculator_Should_Create_Order_By_Frequency_Desc_FirstNameLastName_Asc()
        {
            var sut = new FirstNameAndLastNameFrequencyCalculator();
            CreateFirstNameLastNameDictionary(sut);

            var orderByFrequencyAndFirstNameLastName = sut.GetFrequenciesValueDescendingAndFirstNameLastNameAscending();
            var  arrayOfFrequencyDescFirstNameLastNameAsc = orderByFrequencyAndFirstNameLastName.ToArray();
            Assert.Equal(arrayOfFrequencyDescFirstNameLastNameAsc.Length,7);

            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[0].Key =="bill" && arrayOfFrequencyDescFirstNameLastNameAsc[0].Value ==2);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[1].Key == "john" && arrayOfFrequencyDescFirstNameLastNameAsc[1].Value == 2);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[2].Key == "gates" && arrayOfFrequencyDescFirstNameLastNameAsc[2].Value == 1);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[3].Key == "mark" && arrayOfFrequencyDescFirstNameLastNameAsc[3].Value == 1);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[4].Key == "wick" && arrayOfFrequencyDescFirstNameLastNameAsc[4].Value == 1);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[5].Key == "woo" && arrayOfFrequencyDescFirstNameLastNameAsc[5].Value == 1);
            Assert.True(arrayOfFrequencyDescFirstNameLastNameAsc[6].Key == "zuckerberg" && arrayOfFrequencyDescFirstNameLastNameAsc[6].Value == 1);

        }

        private static void CreateFirstNameLastNameDictionary(FirstNameAndLastNameFrequencyCalculator sut)
        {
            sut.CalculateFirstNameAndLastNameFrequencies("John");
            sut.CalculateFirstNameAndLastNameFrequencies("wick");
            sut.CalculateFirstNameAndLastNameFrequencies("Bill");
            sut.CalculateFirstNameAndLastNameFrequencies("Mark");
            sut.CalculateFirstNameAndLastNameFrequencies("Zuckerberg");
            sut.CalculateFirstNameAndLastNameFrequencies("bill");
            sut.CalculateFirstNameAndLastNameFrequencies("gates");
            sut.CalculateFirstNameAndLastNameFrequencies("John");
            sut.CalculateFirstNameAndLastNameFrequencies("woo");
        }
    }
}
