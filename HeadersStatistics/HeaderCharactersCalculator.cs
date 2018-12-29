using HeadersStatistics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadersStatistics
{
    public class HeaderCharactersCalculator
    {
        private HeaderParser headerParser = new HeaderParser();
        private CharacterStatistics characterStatistics = new CharacterStatistics();
        private CsvProcessor csvProcessor = new CsvProcessor();

        public void Run()
        {
            //Get latest 20 headers 
            List<string> headers = headerParser.GetLatestHeaders();

            //Get character statistics of headers
            IEnumerable<KeyValuePair<char, int>> characters = characterStatistics.GetCollectionOfCharacterStatistics(headers);

            //Save statistics to csv file
            csvProcessor.SaveStatisticsToCsv(characters);

            //Display statistics in console
            Console.WriteLine("------------------START: " + DateTime.Now + "--------------------");
            foreach (var c in characters)
                Console.WriteLine(c.ToString());
        }
    }
}
