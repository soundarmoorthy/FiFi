using System;
using System.IO;
namespace FiFi
{
    public class FixerInfo
    {
        public string Name { get; internal set; }
        public bool HasIssues { get; internal set; }
        public bool Success { get; internal set; }
        public Exception Exception { get; internal set; }

        internal FixerInfo()
        {
        }
    }

    internal interface IFixer
    {
        void Fix(string fullPathToFile);

        FixerInfo Info { get; }
    }
}
