using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Shared.Converters
{
    public class GenericListTypeConverter<T> : TypeConverter
    {
        protected readonly TypeConverter _typeConverter;

        public GenericListTypeConverter()
        {
            _typeConverter = TypeDescriptor.GetConverter(typeof(T));
            if (_typeConverter == null)
                throw new InvalidOperationException("No type converter exists for type " + typeof(T).FullName);
        }

        protected virtual List<string> GetStringArray(string input)
        {
            if (string.IsNullOrEmpty(input)) return new List<string>();
            var result = input.Split(',').ToList();
            return result.Select(s => s.Trim()).ToList();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType != typeof(string)) return base.CanConvertFrom(context, sourceType);
            var items = GetStringArray(sourceType.ToString());
            return items.Any();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is not string) return base.ConvertFrom(context, culture, value);
            var result = new List<T>();
            GetStringArray((string) value).ForEach(s =>
            {
                var item = _typeConverter.ConvertFromInvariantString(s);
                if (item != null) result.Add((T) item);
            });


            return result;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            var result = string.Empty;
            if ((IList<T>) value == null) return result;
            for (var i = 0; i < ((IList<T>) value).Count; i++)
            {
                var str1 = Convert.ToString(((IList<T>) value)[i], CultureInfo.InvariantCulture);
                result += str1;
                //don't add comma after the last element
                if (i != ((IList<T>) value).Count - 1)
                    result += ",";
            }

            return result;
        }
    }
}