
#### Introduction
FiFi is a File Fixer library that can be used to make consistent Line Endings, File Encoding and Remove Invalid ASCII characters. It provides an easy to use Fluent API's that can be easily setup and called in couple of lines of code. FiFi is based on .NET standard and can run in Windows, Mac, and Unix.

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
