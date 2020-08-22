using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FiFi
{

    internal class LineEndingsFixer : IFixer
    {

        private readonly LineEndingMode lineEndingMode;

        private readonly Dictionary<LineEndingMode, string>
            lineEndingsMap = new Dictionary<LineEndingMode, string>();


        public LineEndingsFixer(LineEndingMode target)
        {
            lineEndingsMap[LineEndingMode.Windows] = "\r\n";
            lineEndingsMap[LineEndingMode.Mac] = "\r";
            lineEndingsMap[LineEndingMode.Unix] = "\n"; lineEndingMode = target;

            Info = new FixerInfo();
            Info.Name = "Line Endings Fixer";
        }

        public FixerInfo Info { get; }

        public void Fix(string fullPathToFile)
        {
            SetScriptLineEndings(fullPathToFile, lineEndingMode);
        }

        private void SetScriptLineEndings(string scriptPath,
            LineEndingMode mode)
        {
            try
            {
                var scriptContents = File.ReadAllText(scriptPath);
                var unifiedContents = Regex.Replace(scriptContents,
                    @"\r\n|\n\r|\n|\r", lineEndingsMap[mode]);

                if (scriptContents.Equals(unifiedContents,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    Info.HasIssues = false;
                    Info.Success = true;
                }
                else
                {
                    Info.HasIssues = true;
                    File.WriteAllText(scriptPath, unifiedContents);
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
