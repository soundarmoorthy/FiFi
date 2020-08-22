
#### Introduction
FiFi is a File Fixer library that can be used to fix files for the following
* consistent Line Endings, 
* File Encoding 
* Remove Invalid ASCII characters. 

It provides an easy to use Fluent API's that can be easily setup and called in couple of lines of code. FiFi is based on .NET standard 2.1 and can run in .NET Core 3.0 and .NET Core 4.6.1 or above

#### Usage

```c#
            //First define the list of files that you want to fix
            var fileSources = FileSources.New()
                .Add(directory, "*.cs")
                .Add("/users/sdha/file.xml")
                .Add(new[] {"/users/duck/boo.bar","/opt/exe/foo.sh"});

            //Now configure FiFi with the list of fixers to run on the files mentioned above
            var runner = FiFiRunner.New()
                .FixEncoding(Encoding.UTF8)
                .FixInvalidCharacters()
                .FixLineEndings(LineEndingMode.Windows)
                .ForFiles(fileSources);

            if(!runner.Success())
            {
                foreach(var result in runner.FileResults) //Enumerate all files that failed to perform
                {
                    Console.WriteLine(result.FileName);
                    foreach(var fixer in result.Fixers) //Enumerate all the fixers for a file that failed
                    {
                           Console.WriteLine(fixer.Exception);
                    }
                }
            }


```

The above code fragment will take the list of files and run the fixers on those files. The fixers configured in the above file are Encoding, InvalidChars and LineEndings. You can ignore a fixer by not calling it (ignoring it). When complete, you can enumerate through the results and see what succeeded and failed , exceptions etc.,

#### Disclaimer
This is a community package and i don't hold any accountability for the code, it's success and failures. Use it with your own discreation. I don't mind if oyou fork and use it by yourself.
