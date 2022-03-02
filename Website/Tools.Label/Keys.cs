using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Tools.Label
{
    public class Keys
    {
        private const string PLACEHOLDER_PATTERN = @"{([^}]*)}";
        private JObject keyValues;

        /// <summary>
        ///     Initialize the language object for a specific culture
        /// </summary>
        /// <param name="languageContent">String content that has the YAML language</param>
        public Keys(string languageContent)
        {
            initialize(languageContent);
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                var value = GetValue(key);

                //var placeholders = Regex.Matches(value, PLACEHOLDER_PATTERN);

                //if (placeholders.Count > 0)
                //    throw new ArgumentException("Value contains placeholders, use the overload Keys indexer to pass values, to learn more check the Interpolation documentation: https://github.com/aksoftware98/multilanguages");

                return value;
            }
        }

        public string this[string key, IDictionary<string, object> values, bool setEmptyForNull = false]
        {
            get
            {
                if (values == null) throw new ArgumentNullException(nameof(values));
                var caseInvariantValues = new Dictionary<string, object>(values, new StringComparerIgnoreCase());
                var localizedString = GetValue(key);
                var matches = Regex.Matches(localizedString, PLACEHOLDER_PATTERN);
                foreach (Match item in matches)
                {
                    var replacementKey = item.Value.Replace("{", "").Replace("}", "");

                    var replacementObject = caseInvariantValues[replacementKey];
                    if (replacementObject == null && !setEmptyForNull)
                        throw new ArgumentNullException(nameof(item.Value));
                    var replacementValue = replacementObject == null ? string.Empty : replacementObject.ToString();
                    localizedString = localizedString.Replace($"{item.Value}", replacementValue);
                }

                return localizedString;
            }
        }


        public string this[string key, object keyValues, bool setEmptyForNull = false]
        {
            get
            {
                if (keyValues == null)
                    throw new ArgumentNullException(nameof(keyValues));

                var properties = keyValues.GetType().GetProperties();

                var keyValue = GetValue(key);
                var processedValue = keyValue;

                var matches = Regex.Matches(keyValue, PLACEHOLDER_PATTERN);
                foreach (Match item in matches)
                {
                    var internalValue = item.Value.Replace("{", "").Replace("}", "");
                    // Get the corresponding property 
                    var matchedProperties = properties.Where(p =>
                        p.Name.Equals(internalValue, StringComparison.InvariantCultureIgnoreCase)).ToArray();
                    if (matchedProperties.Length > 1)
                        throw new AmbiguousMatchException(
                            $"Multiple properties have the same name to be replaced '{item.Value}'");

                    var propertyValue = matchedProperties.First().GetValue(keyValues);
                    var propertyValueAsString = string.Empty;
                    if (propertyValue == null && !setEmptyForNull)
                        throw new ArgumentNullException(nameof(item.Value));
                    propertyValueAsString = propertyValue?.ToString();

                    processedValue = processedValue.Replace($"{item.Value}", propertyValueAsString);
                }

                return processedValue;
            }
        }

        /// <summary>
        ///     Initialize the language file from the selected culture
        /// </summary>
        /// <param name="languageContent">String content that has the YAML language</param>
        private void initialize(string languageContent)
        {
            // var dynamicResult = new Deserializer().Deserialize<dynamic>(languageContent);
            // var json = JsonConvert.SerializeObject(dynamicResult);
            // keyValues = JObject.Parse(json);
        }


        private string GetValue(string key)
        {
            try
            {
                if (key.Contains(":"))
                {
                    var nestedKey = key.Split(':');
                    var nestedValue = (JObject) keyValues[nestedKey[0]];
                    var value = string.Empty;
                    for (var i = 1; i < nestedKey.Length; i++)
                    {
                        if (i == nestedKey.Length - 1)
                        {
                            var result = nestedValue[nestedKey[i]];
                            if (result == null)
                                return nestedKey[nestedKey.Length - 1];

                            return (string) result;
                        }

                        nestedValue = (JObject) nestedValue[nestedKey[i]];
                    }

                    return value;
                }

                {
                    var result = keyValues[key];
                    if (result == null)
                        return key;

                    return (string) result;
                }
            }
            catch
            {
                return key;
            }
        }

        public class StringComparerIgnoreCase : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                if (x != null && y != null) return x.ToLowerInvariant() == y.ToLowerInvariant();
                return false;
            }

            public int GetHashCode(string obj)
            {
                return obj.ToLowerInvariant().GetHashCode();
            }
        }
    }
}