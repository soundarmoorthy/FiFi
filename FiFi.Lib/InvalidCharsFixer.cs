using System;
using System.IO;

namespace FiFi
{
    internal class InvalidCharsFixer : IFixer
    {
        private bool hasIssues = false;
        public bool HasIssues()
        {
            return hasIssues;
        }

        private bool success = false;
        public bool Success()
        {
            return success;
        }

        public string Name => "Invalid Chars";

        public void Fix(string fullPathToFile)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                FixInternal(fullPathToFile, ms);
                success = true;
            }
            finally
            {
                ms.Close();
            }
        }

        private void FixInternal(string fullPathToFile, MemoryStream ms)
        {
            foreach (var ch in File.ReadAllBytes(fullPathToFile))
            {
                if (ch > 127 && ch <= 255)
                {
                    hasIssues = true;
                    continue;
                }
                ms.WriteByte(ch);
            }

            if (hasIssues)
            {
                File.WriteAllBytes(fullPathToFile, ms.ToArray());
            }
        }
    }
}