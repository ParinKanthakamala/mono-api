namespace Molecular.Parameters
{
    public class Assignment
    {
        public static Assignment NotProvided = new() {Key = null, Value = null, Provided = false};

        public Assignment(string name, string value)
        {
            Key = name;
            Value = value;

            Provided = true;
        }

        private Assignment()
        {
        } // to allow assignment construction

        public string Key { get; private set; }
        public string Value { get; private set; }
        public bool Provided { get; private set; }

        public static implicit operator bool(Assignment assignment)
        {
            return assignment.Provided;
        }

        public static implicit operator string(Assignment assignment)
        {
            return assignment.Value;
        }

        public override string ToString()
        {
            if (!Provided) return "(Not provided)";
            return Value;
        }

        public bool Match(string name)
        {
            return string.Compare(Key, name, true) == 0;
        }
    }
}