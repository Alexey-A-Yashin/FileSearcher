using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FileSearcher
{
    internal static class RegexFileSearcher
    {
        public static async IAsyncEnumerable<string> FindFilesAsync(AutoResetEvent waitHandler, CancellationToken token, string path, string searchPattern = "")
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                if (token.IsCancellationRequested)
                    break;

                waitHandler.WaitOne();
                if (await Task.Run(() => CheckFile(file.Remove(0, file.LastIndexOf("\\") + 1), searchPattern)))
                {
                    waitHandler.Set();
                    yield return file;
                }
                waitHandler.Set();
            }
            waitHandler.Set();
        }

        private static bool CheckFile(string file, string pattern)
            => Regex.IsMatch(file, pattern);
    }
}
