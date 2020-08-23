using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public void FiFiRunner_New_Initializes_State_Properly()
        {
            var runner = FiFiRunner.New();
            Assert.NotNull(runner.GetConfig());
            Assert.NotNull(runner.GetFiles());
            Assert.Empty(runner.GetFiles().All());
        }

        [Theory]
        [ClassData(typeof(LineEndingDataProvider))]
        public void FiFiRunner_FixLineEndings_Returns_Config_Correctly
            (LineEndingMode expected)
        {
            var runner = FiFiRunner.New();
            var config = runner
                .FixLineEndings(expected)
                .GetConfig();

            Assert.Equal(expected, config.LineEnding);
        }

        [Theory]
        [ClassData(typeof(FileEncodingDataProvider))]
        public void FiFiRunner_FixEncoding_Returns_ConfigCorrectly
            (Encoding expected)
        {
            var runner = FiFiRunner.New();
            var config = runner
                .FixEncoding(expected)
                .GetConfig();

            Assert.Equal(expected, config.Encoding);
        }
    }
}
