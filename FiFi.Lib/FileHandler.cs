using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FiFi
{
    public class FileSources
    {
        private FileSources()
        {
            files = new HashSet<string>();
        }

        public static FileSources New()
        {
            return new FileSources();
        }

        private HashSet<string> files;
        internal IEnumerable<string> All() => files.AsEnumerable();

        public FileSources Add(IEnumerable<string> files)
        {
            foreach (var file in files)
                Add(file);
            return this;
        }

        public FileSources Add(string file)
        {
            this.files.Add(file);
            return this;
        }

        /// <summary>
        /// Adds all the files inside a given directory to the file source. If
        /// the filter is empty or null
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="filter">To include all files pass "*.*".For
        /// more information please refer https://docs.microsoft.com/en-us
        ///dotnet/api/system.io.directory.enumeratefiles?view=netcore-3.1
        ///</param>
        /// <returns></returns>
        public FileSources Add(string dir, string filter)
        {
            var files = FilteredFiles(dir, filter);
            this.Add(files);
            return this;
        }

        private IEnumerable<string> FilteredFiles(string dir, string filter)
            => new FileFilterProcessor(dir, filter);
    }
}