using System.Collections.Generic;
using System.Linq;

namespace FiFi
{
    public sealed class FiFiResult
    {
        public string ConsoleResult { get; internal set; }

        public IEnumerable<FiFiFileResult> FileResults
        { get; internal set; }

        public IEnumerable<FiFiFileResult> Failures()
        {
            foreach (var result in FileResults)
            {
                var fixers = result.Fixers.Where(x => !x.Success);
                if (fixers.Any())
                    yield return new FiFiFileResult(result.FileName, fixers);
            }
        }

        public bool Success()
        {
            return !(Failures().Any());
        }
    }
}