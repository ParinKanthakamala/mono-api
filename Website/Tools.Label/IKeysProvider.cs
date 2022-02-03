using System.Globalization;

namespace Tools.Label
{
    public interface IKeysProvider
    {
        Keys GetKeys(CultureInfo cultureInfo);
        Keys GetKeys(string cultureName);
    }
}