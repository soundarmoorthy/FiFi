using System;
using System.Linq;
using System.IO;
namespace FiFi.Lib.Tests
{
    public static class TestData
    {
        public static FiFiFileResult SuccessFileResult()
        {
            var fixers = new[] { new DummyFixer(success: true).Info };

            return new FiFiFileResult(Path.GetTempFileName(),
                fixers
                );
        }

        public static FiFiFileResult FailureFileResult()
        {
            var fixers = new[] { new DummyFixer(success: false).Info };

            return new FiFiFileResult(Path.GetTempFileName(),
                fixers
                );
        }

        public static FiFiResult Result()
        {
            var result = new FiFiResult()
            {
                ConsoleResult = "Dummy",
                FileResults = new[] { TestData.SuccessFileResult() }
            };
            return result;
        }
    }

    internal sealed class DummyFixer : IFixer
    {
        public FixerInfo Info { get; private set; }

        internal DummyFixer(string name = "Dummy", bool success = true, bool
            hasIssues = false, Exception exception = null)
        {
            this.Info = new FixerInfo();
            Info.Success = success;
            Info.Name = name;
            Info.HasIssues = hasIssues;
            Info.Exception = exception;
        }

        public void Fix(string fullPathToFile)
        {
        }
    }
}
