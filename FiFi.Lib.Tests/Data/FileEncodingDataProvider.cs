using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FiFi.Lib.Tests
{
    public class FileEncodingDataProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var encoding in Encoding.GetEncodings())
            {
                yield return new object[] { encoding.GetEncoding() };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
