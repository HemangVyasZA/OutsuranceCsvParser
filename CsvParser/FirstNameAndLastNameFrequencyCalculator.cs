using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    public class FirstNameAndLastNameFrequencyCalculator
    {
        public  readonly Dictionary<string, int> FirstNameAndLastNameFrequncies = new Dictionary<string, int>();

        public  void CalculateFirstNameAndLastNameFrequencies(string name)
        {
            var caseInsensitiveKey = name.ToLower();
            if (!FirstNameAndLastNameFrequncies.ContainsKey(caseInsensitiveKey))
            {
                FirstNameAndLastNameFrequncies.Add(caseInsensitiveKey, 1);
            }
            else
            {
                FirstNameAndLastNameFrequncies[caseInsensitiveKey]++;
            }
        }

        public IOrderedEnumerable<KeyValuePair<string, int>>
            GetFrequenciesValueDescendingAndFirstNameLastNameAscending()
        {

            return from item in FirstNameAndLastNameFrequncies
                orderby item.Value descending, item.Key 
                select item;
        }
    }
}
