using System;
using System.Linq;
using System.IO;
using System.Text;

namespace FiFi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = string.Empty;
            if (args.Length == 0)
            {
                dir = "/Users/sdhaksh5/trunk/Application/Loader/Loader.Shell/";
                Console.WriteLine("Enter directory path");
            }
            dir = args[0].Trim();
            if (!Directory.Exists(dir))
                Console.WriteLine("Directory does't exist");

            var fileSources = FileSources.New()
                .Add(dir, "*.sql");

            var result = FiFiRunner.New()
                .FixEncoding(Encoding.UTF8)
                .FixInvalidCharacters()
                .FixLineEndings(LineEndingMode.Windows)
                .ForFiles(fileSources)
                .Run();

            var failures = result.Failures();


            Console.WriteLine(result.ConsoleResult);
        }
    }
}
