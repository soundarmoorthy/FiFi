using System;
using System.IO;

namespace FiFi
{
    public class Not
    {
        public static bool Processable(string fileName, out Exception e)
        {
            e = null;
            try
            {
                using var f = new FileInfo(fileName).Open(
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.ReadWrite);
                return f == null;

            }
            catch (Exception ex)
            {
                e = ex;
                return false;
            }
        }
    }
}
