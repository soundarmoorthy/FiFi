using System.IO;
using System.Collections.Generic;
using System;

namespace FiFi
{
    public sealed class FiFiFileResult
    {
        public IEnumerable<FixerInfo> Fixers { get; private set; }
        public string FileName { get; private set; }

        public FiFiFileResult(string fileName,
             IEnumerable<FixerInfo> fixers)
        {
            this.FileName = fileName;
            this.Fixers = fixers;
        }
    }
}