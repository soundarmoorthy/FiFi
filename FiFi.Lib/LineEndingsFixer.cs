using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FiFi
{

    internal class LineEndingsFixer : IFixer
    {

        private readonly LineEndingMode s_lineEndingMode;

        private readonly Dictionary<LineEndingMode, string>
            s_lineEndingsMap = new Dictionary<LineEndingMode, string>();

        public string Name => "Line Endings";
        public LineEndingsFixer(LineEndingMode target)
        {
            s_lineEndingsMap[LineEndingMode.Windows] = "\r\n";
            s_lineEndingsMap[LineEndingMode.Mac] = "\r";
            s_lineEndingsMap[LineEndingMode.Unix] = "\n";

            s_lineEndingMode = target;
        }

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

        public void Fix(string fullPathToFile)
        {
            SetScriptLineEndings(fullPathToFile, s_lineEndingMode);
        }

        private void SetScriptLineEndings(string scriptPath, LineEndingMode mode)
        {
            var scriptContents = File.ReadAllText(scriptPath);
            var unifiedContents = Regex.Replace(scriptContents,
                @"\r\n|\n\r|\n|\r", s_lineEndingsMap[mode]);

            if (scriptContents.Equals(unifiedContents,
                StringComparison.CurrentCultureIgnoreCase))
            {
                success = true;
                return;
            }

            hasIssues = false;
            File.WriteAllText(scriptPath, unifiedContents);
            success = true;
        }
    }
}
