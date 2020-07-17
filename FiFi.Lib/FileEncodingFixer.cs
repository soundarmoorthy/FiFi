using System;
using System.IO;
using System.Text;

namespace FiFi
{
    internal class FileEncodingFixer : IFixer
    {
        public string Name => "Encoding";


        private bool hasIssues = false;
        public bool HasIssues()
        {
            return hasIssues;
        }

        private bool success;
        public bool Success()
        {
            return success;
        }

        private readonly Encoding target;
        public FileEncodingFixer(Encoding target)
        {
            this.target = target;
        }

        public void Fix(string fullPathToFile)
        {
            if (!File.Exists(fullPathToFile))
            {
                success = false;
                throw new FileNotFoundException(fullPathToFile);
            }

            string contents = string.Empty;
            using (var reader = new StreamReader(fullPathToFile, true))
            {
                if (reader.CurrentEncoding == target)
                {
                    success = true;
                    hasIssues = false;
                    return;
                }
                contents = reader.ReadToEnd();
            }

            File.WriteAllText(fullPathToFile, contents, target);
            hasIssues = true;
            success = true;
        }
    }
}
