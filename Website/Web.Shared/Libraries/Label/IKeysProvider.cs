using System.Globalization;

namespace Web.Shared.Libraries.Label
{
    public interface IKeysProvider
    {
        Keys GetKeys(CultureInfo cultureInfo);
        Keys GetKeys(string cultureName);
    }
}