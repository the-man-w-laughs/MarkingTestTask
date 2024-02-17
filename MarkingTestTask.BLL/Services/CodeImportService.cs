using MarkingTestTask.BLL.Contracts;
using System.IO;

namespace MarkingTestTask.BLL.Services
{
    public class CodeImportService : ICodeImportService
    {
        private const int GTINLength = 14;
        public List<string> ImportCodesFromFile(string filename, string gtin)
        {
            if (gtin.Length != GTINLength)
                throw new ArgumentException($"GTIN must be {GTINLength} digits long.", nameof(gtin));

            var prefix = "01" + gtin;
            var suffix = "21";

            var codes = new List<string>();
            using (var fileReader = new StreamReader(filename))
            {
                string? line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    if (line.StartsWith(prefix) && line.Substring(prefix.Length, suffix.Length) == suffix)
                    {
                        codes.Add(line);
                    }
                }
            }

            return codes;
        }
    }

}
