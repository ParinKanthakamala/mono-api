using System;

namespace Molecular.Parameters
{
    /// <summary>
    ///     A combination of a flag and a value. This replaces FlagValue (where value is string)
    ///     And opens up other types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Flag<T>
    {
        public string Name;
        public T Value;

        public Flag(string name, T value, bool isSet = true)
        {
            Name = name;
            Value = value;
            IsSet = isSet;
            //this.HasFlag = hasflag;
            //this.HasValue = hasvalue;
        }

        [Obsolete("If the flag has no value, it won't parse as a valid route, so it can only have one value")]
        public bool HasValue => IsSet; // the value was set

        [Obsolete("Replaced by IsSet")] public bool HasFlag => IsSet; // the flag was provided

        public bool IsSet { get; }

        public static Flag<T> NotGiven => new(null, default, false);

        //public static Flag<T> WithoutValue => new Flag<T>(null, default, true, );

        public static implicit operator T(Flag<T> flag)
        {
            return flag.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}