using System;
using System.IO;
using System.Text;

namespace FiFi
{
    internal class FileEncodingFixer : IFixer
    {
        public FixerInfo Info { get; }

        private readonly Encoding target;
        public FileEncodingFixer(Encoding target)
        {
            this.target = target;
            Info = new FixerInfo();
            Info.Name = "Encoding Fixer";
        }

        public void Fix(string fullPathToFile)
        {
            try
            {
                string contents = string.Empty;
                using (var reader = new StreamReader(fullPathToFile, true))
                {
                    if (reader.CurrentEncoding == target)
                    {
                        Info.HasIssues = false;
                        Info.Success = true;
                    }
                    else
                    {
                        Info.HasIssues = true;
                        contents = reader.ReadToEnd();
                    }
                }

                if (Info.HasIssues)
                {
                    File.WriteAllText(fullPathToFile, contents, target);
                    Info.Success = true;
                }
            }
            catch (Exception ex)
            {
                Info.Success = false;
                Info.Exception = ex;
            }
        }
    }
}
