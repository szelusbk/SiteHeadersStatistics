using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadersStatistics.Helpers
{
    public class CharacterStatistics
    {
        private Dictionary<char, int> statistics;

        public IEnumerable<KeyValuePair<char, int>> GetCollectionOfCharacterStatistics(List<string> headers)
        {
            statistics = new Dictionary<char, int>();

            foreach(string s in headers)
            {
                CalculateString(s);
            }

            return statistics.OrderByDescending(x => x.Value);
        }

        private void CalculateString(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (currentChar == ' ')
                    continue;

                if (statistics.ContainsKey(currentChar))
                    statistics[currentChar]++;
                else
                    statistics.Add(currentChar, 1);
            }
        }
    }
}
