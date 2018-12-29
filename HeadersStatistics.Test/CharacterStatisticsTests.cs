using System;
using System.Collections.Generic;
using HeadersStatistics.Helpers;
using NUnit.Framework;

namespace HeadersStatistics.Test
{
    [TestFixture]
    public class CharacterStatisticsTests
    {
        [Test]
        public void GetCollectionOfCharacterStatistics_PassListOfStrings_GetCorrectCharacterStatistics()
        {
            CharacterStatistics characterStatistics = new CharacterStatistics();
            List<string> headers = new List<string>()
            {
                "ala ma kota",
                "kot ma mysz"
            };
            IEnumerable<KeyValuePair<char, int>> expectedStatistics = new List<KeyValuePair<char, int>>
            {
                new KeyValuePair<char, int>('a', 5),
                new KeyValuePair<char, int>('m', 3),
                new KeyValuePair<char, int>('k', 2),
                new KeyValuePair<char, int>('o', 2),
                new KeyValuePair<char, int>('t', 2),
                new KeyValuePair<char, int>('l', 1),
                new KeyValuePair<char, int>('y', 1),
                new KeyValuePair<char, int>('s', 1),
                new KeyValuePair<char, int>('z', 1),

            };

            IEnumerable<KeyValuePair<char, int>> results = characterStatistics.GetCollectionOfCharacterStatistics(headers);

            Assert.AreEqual(expectedStatistics, results);
        }
    }
}
