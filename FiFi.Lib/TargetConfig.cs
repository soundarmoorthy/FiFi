using System.Text;

namespace FiFi
{
    internal class TargetConfig
    {
        internal LineEndingMode? LineEnding { get; set; } = null;

        internal Encoding Encoding { get; set; } = null;

        internal bool RemoveNonprintableChars { get; set; } = false;

        internal TargetConfig()
        {
        }
    }
}
