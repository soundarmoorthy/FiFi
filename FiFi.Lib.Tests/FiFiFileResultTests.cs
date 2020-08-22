using System;
using System.Linq;

using Xunit;

namespace FiFi.Lib.Tests
{
    public class FiFiFileResultTests
    {
        [Fact]
        public void FiFiFileResultReturnsFileInfoForGivenName()
        {
            FiFiFileResult result = new FiFiFileResult
                (
                    "/usr/local/test/foo.txt",
                    new[] { new InvalidCharsFixer().Info }
                );

            Assert.NotNull(result.FileName);
        }

        [Fact]
        public void FiFiFileResultReturnsFixerInfoForGivenFixer()
        {
            FiFiFileResult result = new FiFiFileResult
                (
                    "/usr/local/test/foo.txt",
                    new[] { new InvalidCharsFixer().Info }
                );

            Assert.NotNull(result.Fixers);
            Assert.Equal(result.Fixers.First().Name
                , Consts.InvalidCharsFixer_Tag);
        }
    }
}
