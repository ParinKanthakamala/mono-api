using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tools.Label
{
    public class LanguageContainer : ILabel
    {
        private readonly List<IExtension> _extensions;

        private readonly IKeysProvider _keysProvider;


        public LanguageContainer(CultureInfo culture, IKeysProvider keyProvider) : this(keyProvider)
        {
            SetLanguage(culture, true);
        }


        public LanguageContainer(IKeysProvider keysProvider)
        {
            _keysProvider = keysProvider;
            _extensions = new List<IExtension>();
            SetLanguage(CultureInfo.CurrentCulture, true);
        }

        public string this[object key, object keyValues] => Keys[(string) key, keyValues];


        public Keys Keys { get; private set; }


        public CultureInfo CurrentCulture { get; private set; }

        public string this[string key] => Keys[key];

        public string this[string key, object keyValues, bool setEmptyIfNull = false] =>
            Keys[key, keyValues, setEmptyIfNull];

        public string this[string key, IDictionary<string, object> keyValues, bool setEmptyIfNull] =>
            Keys[key, keyValues, setEmptyIfNull];


        public void SetLanguage(CultureInfo culture)
        {
            CurrentCulture = culture;
            Keys = _keysProvider.GetKeys(culture.Name);
            InvokeExtensions();
        }

        public void AddExtension(IExtension extension)
        {
            // Add the extension if it is not exists 
            var value = _extensions.SingleOrDefault(r => r == extension);
            if (value == null)
                _extensions.Add(extension);
        }


        private void SetLanguage(CultureInfo culture, bool isDefault)
        {
            CurrentCulture = culture;
            Keys = _keysProvider.GetKeys(culture);
            //NB:  Not sure if this should be called here...
            InvokeExtensions();
        }

        // TODO: Remove the destroyed component from the extensions list 
        private void InvokeExtensions()
        {
            if (!_extensions.Any()) return;
            foreach (var item in _extensions.ToArray())
            {
                if (item.Component == null)
                {
                    _extensions.Remove(item);
                    continue;
                }

                item.Action.Invoke(item.Component);
            }
        }
    }
}