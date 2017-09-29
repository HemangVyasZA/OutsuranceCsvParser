using System.IO;
using CsvParser;
using Xunit;

namespace CsvParserTest
{
    public class SimpleParserTest
    {
        [Fact]
        public void FileName_Must_Not_Empty()
        {
            var sut = new SimpleParser();
            var result = sut.IsFileNameAndPathValid();
            Assert.True(result);
        }

        [Fact]
        public void FileNameAndPath_Should_Valid()
        {
            var sut = new SimpleParser();
            var result = sut.IsFileNameAndPathValid();
            Assert.True(result);

        }

        [Fact]
        public void FileName_Must_Have_Csv_Extension()
        {
            var sut = new SimpleParser();
            var result = sut.IsFileNameAndPathValid();
            Assert.True(result);
        }

        [Fact]
        public void File_Must_Be_Exist()
        {   
            var sut = new SimpleParser();
            Assert.True(File.Exists(sut.FileName));
        }

        [Fact]
        public void CheckIfFileNameIsTooLong()
        {
            var sut = new SimpleParser
            {
                FileName =
                    @"c:\fadsfklads\adjkflkaldsf\dhfkadsjfa\iffds89\dfadsfkj\adfadsklfhadsfhadsfkladsfakjdshflasdf\rwieriyoqwer\vnadljkflkjads\fadsf3r34\fdaslfajkdsf\nvnkfkadsfnlk\adfjkadjsklf\dfjadsjlfjklas\dfalksdfljkasdf\afldsalfewurw\dlfasdjf09\kdsfaweiruwe\dljfadsjkflasdf\uoirouiter454358034\lddjkfjldkglkfdsgjsdf\549583945\lgjsljkgklsfdg\59430543\eljretreltwerlkt\ljgsfdkjlgsfdj\somecsv.csv"
            };
            Assert.True(sut.IsFilePathTooLong());
        }
        [Fact]
        public void File_Should_Have_Valid_Header()
        {
            var sut = new SimpleParser();
            Assert.True(sut.DoesFileHaveValidHeaderRow());
        }

        
        [Fact]
        public void File_should_parse()
        {
            var sut = new SimpleParser();
            Assert.True(sut.ParseCsv());
        }

        [Fact]
        public void OutputFile_should_write()
        {
            var sut = new SimpleParser();
            sut.ParseCsv();
            Assert.True(sut.WriteOutPutFileForGivenCsv());
        }
    }
}
