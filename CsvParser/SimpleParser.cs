using System;
using System.IO;
using System.Linq;

namespace CsvParser
{
    //Main Responsibility of this class is to parse CSV file.
    public class SimpleParser
    {
        private const char DefaultFieldSeperator= ',';
        public const string FirstNameHeaderValue = "firstname";
        public const string LasttNameHeaderValue = "lastname";
        public const string AddressHeaderValue = "address";
        public const string PhoneNumberHeaderValue = "phonenumber";
        private readonly FirstNameAndLastNameFrequencyCalculator _frequencyCalculator = new FirstNameAndLastNameFrequencyCalculator();
        private readonly SortedAddressGenerator _sortedAddressGenerator = new SortedAddressGenerator();

        public const byte FirstNameInHeaderSequence =0;
        public const byte LastNameInHeaderSequence = 1;
        public const byte AddressInHeaderSequence = 2;
        public const byte PhoneNumberInHeaderSequence =3;

       

        public string FileName { get; set; } = Directory.GetCurrentDirectory() + @"\data.csv";
        public char FieldSeperator { get; set; } = DefaultFieldSeperator;
       
        public bool IsFileNameAndPathValid()
        {
            try
            {
                var isFileNameEmptyOrNullstring = string.IsNullOrEmpty(FileName);
                var isFileNameWhiteSpace = string.IsNullOrWhiteSpace(FileName);
                var hasFilePathInvalidCharacters = FileName != null && FileName.IndexOfAny(Path.GetInvalidPathChars()) >= 0;
                var fileName = Path.GetFileName(FileName);
                var hasFileNameInvalidCharacters = fileName != null && fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
                var doesFileNameHasCsvExtension = FileName != null && Path.GetExtension(FileName).EndsWith(".csv");

                var result = !isFileNameEmptyOrNullstring && !isFileNameWhiteSpace
                              && !hasFilePathInvalidCharacters && !hasFileNameInvalidCharacters
                              && doesFileNameHasCsvExtension;

                return result;
            }
            catch (Exception )
            {
                return false;
                
            }
           

        }

        public bool IsFilePathTooLong()
        {
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(FileName);
            }
            catch (ArgumentException) { }
            catch (PathTooLongException) { }
            catch (NotSupportedException) { }
            return ReferenceEquals(fi, null);
        }
        public bool DoesFileHaveValidHeaderRow()
        {
            var headerLine = File.ReadLines(FileName).FirstOrDefault();
            var fields = headerLine?.Split(DefaultFieldSeperator);

            if (fields?.Length == 4)
            {
                return
                    fields[0].ToLower() == FirstNameHeaderValue  &&
                    fields[1].ToLower() == LasttNameHeaderValue  &&
                    fields[2].ToLower() == AddressHeaderValue  &&
                    fields[3].ToLower() == PhoneNumberHeaderValue;
            }
            return false;
        }

        public bool  ParseCsv()
        {
            if (!IsFileNameAndPathValid() || !DoesFileHaveValidHeaderRow() || IsFilePathTooLong()) return false;
            //read lines of file
            var lines = File.ReadLines(FileName)
                            .Where((item, index) => index > 0);
            //Iterate each line and extract fields' value of each line by spliting line with Field seperator
            //Add firstname and last name fields in dictionary and update their frequncey
            foreach (var line in lines)
            {
                var fieldsValueOfLine = line.Split(DefaultFieldSeperator);
               _frequencyCalculator.CalculateFirstNameAndLastNameFrequencies(fieldsValueOfLine[FirstNameInHeaderSequence]);
               _frequencyCalculator.CalculateFirstNameAndLastNameFrequencies(fieldsValueOfLine[LastNameInHeaderSequence]);
               _sortedAddressGenerator.AddStreetAddressInList(fieldsValueOfLine[AddressInHeaderSequence]); 
            }
            return true;
        }

        public bool WriteOutPutFileForGivenCsv()
        {
           
            using (var file = new StreamWriter(Directory.GetCurrentDirectory() + "\\outputOfCsv.txt"))
            {
                file.WriteLine("Order by frequency descending, First Name or Last Name Ascending");
                foreach (var item in _frequencyCalculator.GetFrequenciesValueDescendingAndFirstNameLastNameAscending())
                {
                    file.WriteLine($"{item.Value}\t{item.Key}");
                }
                file.WriteLine("=====================================================================");
                file.WriteLine("Address Order By Street Name");
                foreach (var item in _sortedAddressGenerator.AddressListSortedByStreetName)
                {
                    file.WriteLine($"{item.Value}");
                }
               
            }
           
            return true;
        }
    }
}
