using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvParser
{
   public  class SortedAddressGenerator
    {
        
       public  readonly  SortedList< string,string  > AddressListSortedByStreetName = new SortedList<string, string>(new DuplicateKeyComparer<string>());

        public void AddStreetAddressInList(string address)
        {
            //here we are assuming address will always be in <streetNumber> <streetName> <streetNameSuffix> format
            //In short Addres always will have three components.
            var arrayAddressSplit = address.Split(' ');
            AddressListSortedByStreetName.Add(arrayAddressSplit[1],address);

        }

      

        /// <summary>
        /// It might possible that street name will be duplicate. so create comparare which
        /// allow duplicate street name as key
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        private class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;  
                else
                    return result;
            }

       }
    }
}
