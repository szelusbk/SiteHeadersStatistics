using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace HeadersStatistics.Helpers
{
    public class CsvProcessor
    {
        public void SaveStatisticsToCsv(IEnumerable<KeyValuePair<char, int>> statistics)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Header_Statistics\";
            Directory.CreateDirectory(directory);
            DeleteOldFiles(directory);

            string fileName =  DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";

            using (var writer = new StreamWriter(directory + fileName))
            using (var csv = new CsvWriter(writer))
                csv.WriteRecords(statistics);
        }

        private void DeleteOldFiles(string path)
        {
            var files = new DirectoryInfo(path).GetFiles("*.csv", SearchOption.TopDirectoryOnly)
                .OrderByDescending(x => x.CreationTime)
                .Skip(4);

            foreach (var f in files)
                f.Delete();
        }
    }
}
