﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FiFi
{
    public class RunBook
    {

        internal static RunBook New(List<IFixer> fixers)
        {
            return new RunBook(fixers);
        }

        readonly IList<IFixer> fixers;
        private RunBook(List<IFixer> fixers)
        {
            this.files = new HashSet<string>();
            this.fixers = fixers;
        }

        HashSet<string> files;
        public void Record(string file)
        {
            files.Add(file);
        }

        private const int oddWidth = 20;
        private const int pad = oddWidth / 2;

        internal static string Console(
            IEnumerable<FiFiFileResult> results)
        {
            if (results == null || !results.Any())
                return "Nothing to show";

            StringBuilder builder = new StringBuilder();
            StringBuilder header = new StringBuilder();
            foreach (var item in results.ElementAt(0).Fixers)
                header.Append(GetName(item.Name));

            header.Append(Environment.NewLine);
            foreach (var item in results.ElementAt(0).Fixers)
                header.Append($"{"Issues",pad * 2}{"Fixed",pad * 2}");

            header.Append("FileName");

            builder.Append(header.ToString());
            builder.Append(Environment.NewLine);

            foreach (var item in results)
            {
                foreach (var v in item.Fixers)
                {
                    builder.Append(Format(v.HasIssues));
                    builder.Append(Format(v.Success));
                }
                builder.Append(item.FileName);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        private static string GetName(string name)
        {
            var len = oddWidth - name.Length;
            name = name.PadLeft(len, ' ');
            name = name.PadRight(len, ' ');
            return name;

        }

        private static string Format(bool value)
        {
            var ch = value ? "Y" : "N";
            return string.Format($"{' ',pad}{ch}{' ',pad}");
        }

        internal static string Json(string rootDir,
            Dictionary<string, IFixer[]> runMap)
        {
            if (runMap == null)
                return "{}";

            return string.Empty;
        }
    }
}