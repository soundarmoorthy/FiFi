using System;
using Xunit;
using System.Linq;

namespace FiFi.Lib.Tests
{
    public class FiFiResultTests
    {
        [Fact]
        public void FiFiResults_Failures_Return_False_When_No_Failures()
        {
            var file = TestData.SuccessFileResult();
            var overallResult = new FiFiResult()
            {
                ConsoleResult = "Dummy",
                FileResults = new[] { file }
            };

            Assert.NotNull(overallResult);
            Assert.Empty(overallResult.Failures());
        }

        [Fact]
        public void FiFiResults_Failures_Return_True_When_With_Failures()
        {
            var file = TestData.FailureFileResult();
            var overallResult = new FiFiResult()
            {
                ConsoleResult = "Dummy",
                FileResults = new[] { file }
            };

            Assert.NotNull(overallResult);
            Assert.NotEmpty(overallResult.Failures());
        }
    }
}
