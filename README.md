
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
            FiFiRunner.New()
                .FixEncoding(Encoding.UTF8)
                .FixInvalidCharacters()
                .FixLineEndings(LineEndingMode.Windows)
                .ForFiles(fileSources);

```

The above code fragment will take the list of files and run the fixers on those files. The fixers configured in the above file are Encoding, InvalidChars and LineEndings. You can ignore a fixer by not calling it (ignoring it)
