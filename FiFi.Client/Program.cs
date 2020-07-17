using System;
using System.Text;

namespace FiFi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSources = FileSources.New()
                .Add(args[1], "*.sql");

            FiFiRunner.New()
                .FixEncoding(Encoding.UTF8)
                .FixInvalidCharacters()
                .FixLineEndings(LineEndingMode.Windows)
                .ForFiles(fileSources);
        }
    }
}
