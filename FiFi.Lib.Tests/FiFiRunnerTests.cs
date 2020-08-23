using System;
using FiFi;
using Xunit;

namespace FiFi.Lib.Tests
{
    public class FiFiRunnerTests
    {
        [Fact]
        public void FiFiRunner_New_Returns_New_Session_Every_Time()
        {
            var expected = FiFiRunner.New();
            var actual = FiFiRunner.New();

            Assert.NotSame(expected, actual);
        }
    }
}
