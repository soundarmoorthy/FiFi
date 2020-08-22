using System;
using System.IO;

namespace FiFi
{
    internal class InvalidCharsFixer : IFixer
    {

        public FixerInfo Info { get; }

        public InvalidCharsFixer()
        {
            Info = new FixerInfo();
            Info.Name = Consts.InvalidCharsFixer_Tag;
        }

        public void Fix(string fullPathToFile)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                FixInternal(fullPathToFile, ms);
                Info.Success = true;
            }
            catch (Exception ex)
            {
                Info.Success = false;
                Info.Exception = ex;
            }
            finally
            {
                ms.Close();
            }
        }

        private void FixInternal(string fullPathToFile, MemoryStream ms)
        {
            try
            {
                foreach (var ch in File.ReadAllBytes(fullPathToFile))
                {
                    if (ch > 127 && ch <= 255)
                    {
                        Info.HasIssues = true;
                        continue;
                    }
                    ms.WriteByte(ch);
                }

                if (Info.HasIssues)
                {
                    File.WriteAllBytes(fullPathToFile, ms.ToArray());
                }

                Info.Success = true;
            }
            catch (Exception ex)
            {
                Info.Exception = ex;
                Info.Success = false;
            }
        }
    }
}