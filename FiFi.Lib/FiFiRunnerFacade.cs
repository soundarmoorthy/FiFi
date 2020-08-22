using System;
using System.Linq;
using System.Collections.Generic;

namespace FiFi
{
    internal static class FiFiRunnerFacade
    {
        internal static FiFiResult Run(
            TargetConfig config,
            FileSources sources)
        {
            var items = new List<FiFiFileResult>();

            var fixers = GetFixers(config);
            foreach (var file in sources.All())
            {
                if (Not.Processable(file, out Exception ex))
                {
                    continue;
                }

                foreach (var fixer in fixers)
                {
                    fixer.Fix(file);
                }
                items.Add(new FiFiFileResult(file, Info(fixers)));
            }
            return Results(items);
        }

        private static IEnumerable<FixerInfo> Info(IEnumerable<IFixer> fixers)
        {
            return fixers.Select(x => x.Info);
        }

        private static FiFiResult Results
            (IEnumerable<FiFiFileResult> items)
        {
            var result = RunBook.Console(items);
            return new FiFiResult()
            {
                ConsoleResult = result,
                FileResults = items
            };
        }

        internal static IEnumerable<IFixer> GetFixers(TargetConfig config)
        {
            List<IFixer> fixers = new List<IFixer>();

            if (config.RemoveNonprintableChars)
                fixers.Add(new InvalidCharsFixer());

            if (config.LineEnding != null)
                fixers.Add(new LineEndingsFixer(config.LineEnding.Value));

            if (config.Encoding != null)
                fixers.Add(new FileEncodingFixer(config.Encoding));

            return fixers.AsEnumerable();
        }
    }
}