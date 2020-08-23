using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        public void FiFiRunner_FixEncoding_Returns_Config_Correctly
            (Encoding expected)
        {
            var runner = FiFiRunner.New();
            var config = runner
                .FixEncoding(expected)
                .GetConfig();

            Assert.Equal(expected, config.Encoding);
        }

        [Fact]
        public void FiFiRunner_FixInvalidChars_Returns_Config_Correctly()
        {
            var runner = FiFiRunner.New();
            var config = runner
                .FixInvalidCharacters()
                .GetConfig();

            Assert.True(config.RemoveNonprintableChars);
        }

        [Fact]
        public void FiFiRunner_Return_Default_Configuration_When_No_Action()
        {
            var runner = FiFiRunner.New();
            var config = runner.GetConfig();

            Assert.NotNull(config);
            Assert.False(config.RemoveNonprintableChars);
            Assert.Null(config.Encoding);
            Assert.Null(config.LineEnding);
        }

        [Fact]
        public void FiFiRunner_Source_Files_Is_Empty_By_Default()
        {
            var runner = TestData.RunnerWithNoFiles();
            Assert.NotNull(runner.GetFiles());
            Assert.Empty(runner.GetFiles().All());
        }

        [Fact]
        public void FiFiRunner_Source_Files_Are_Configured_Properly()
        {
            var runner = TestData.RunnerWithSingleFile();
            var result = runner.GetFiles().All();
            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
