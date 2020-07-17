using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FiFi
{
    internal class FileFilterProcessor :
        IEnumerator<string>,
        IEnumerable<string>
    {
        private string filter;
        private IEnumerable<string> files;

        public FileFilterProcessor(string directory, string filter)
        {
            this.filter = filter;
            files = Directory.EnumerateFiles(directory,
                filter, SearchOption.AllDirectories);

        }

        int index = 0;
        public bool MoveNext()
        {
            if (index++ < files.Count() - 1)
                return true;

            return false;
        }

        public void Reset() => index = 0;

        public void Dispose() => files = null;

        public IEnumerator GetEnumerator() => this;

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => this;

        public object Current => files.ElementAt(index);

        string IEnumerator<string>.Current => files.ElementAt(index);

    }
}