using System;
using System.Collections.Generic;

namespace FiFi
{
    internal static class FiFiRunnerFacade
    {
        internal static FiFiResult Run(TargetConfig config, FileSources sources)
        {
            List<IFixer> fixers = GetFixers(config);

            var items = new Dictionary<string, List<IFixer>>();
            foreach (var file in sources.All())
            {
                foreach (var fixer in fixers)
                {
                    fixer.Fix(file);
                }
                items.Add(file, fixers);
            }

            return Results(items);
        }

        private static FiFiResult Results(Dictionary<string, List<IFixer>> items)
        {
            var result = RunBook.Console(items);
            return new FiFiResult() { ConsoleResult = result };
        }

        private static List<IFixer> GetFixers(TargetConfig config)
        {
            List<IFixer> fixers = new List<IFixer>();

            if (config.RemoveNonprintableChars)
                fixers.Add(new InvalidCharsFixer());

            if (config.LineEnding != null)
                fixers.Add(new LineEndingsFixer(config.LineEnding.Value));

            if (config.Encoding != null)
                fixers.Add(new FileEncodingFixer(config.Encoding));
            return fixers;
        }
    }
}