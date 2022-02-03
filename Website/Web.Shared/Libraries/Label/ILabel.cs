using System.Collections.Generic;
using System.Globalization;

namespace Web.Shared.Libraries.Label
{
    public interface ILabel
    {
        CultureInfo CurrentCulture { get; }
        Keys Keys { get; }
        string this[string key] { get; }
        string this[string key, object keyValues, bool setEmptyIfNull = false] { get; }
        string this[string key, IDictionary<string, object> keyValues, bool setEmptyIfNull = false] { get; }
        void SetLanguage(CultureInfo culture);
        void AddExtension(IExtension extension);
    }
}