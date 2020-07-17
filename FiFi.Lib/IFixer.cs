using System;
namespace FiFi
{
    internal interface IFixer
    {
        bool HasIssues();
        bool Success();
        void Fix(string fullPathToFile);
        string Name { get; }
    }
}
