using System;
using System.Collections;
using System.Collections.Generic;

namespace FiFi.Lib.Tests
{
    public class LineEndingDataProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var values = Enum.GetValues(typeof(LineEndingMode));
            foreach (var value in values)
            {
                yield return new object[] { value };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //Calls the other enumerator function
            return this.GetEnumerator();
        }
    }
}
