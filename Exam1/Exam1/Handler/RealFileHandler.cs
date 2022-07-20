using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Exam1.Handler
{
    public class RealFileHandler
    {
        public async Task<List<string>> RunAsync(Stream stream)
        {
            List<string> content = new List<string>();
            await Task.Run(() =>
            {
                using (var reader = new StreamReader(stream))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        content.Add(line);
                    }
                }
            });
            return content;
        }
    }
}
