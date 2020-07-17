using System.Text;

namespace FiFi
{
    public class FiFiRunner
    {
        private TargetConfig config;
        private FileSources files;

        private FiFiRunner()
        {
            config = new TargetConfig();
            files = FileSources.New();
        }

        public static FiFiRunner New()
        {
            return new FiFiRunner();
        }

        public FiFiRunner FixLineEndings(LineEndingMode lineEnding)
        {
            config.LineEnding = lineEnding;
            return this;
        }

        public FiFiRunner FixEncoding(Encoding encoding)
        {
            config.Encoding = encoding;
            return this;
        }

        public FiFiRunner FixInvalidCharacters()
        {
            config.RemoveNonprintableChars = true;
            return this;
        }

        public FiFiRunner ForFiles(FileSources fileSources)
        {
            this.files = fileSources;
            return this;
        }

        public FiFiResult Run()
        {
            return FiFiRunnerFacade.Run(config, files);
        }
    }
}
