namespace Gateway.Libraries.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }

            var len = end - start;

            // Return new array.
            var res = new T[len];
            for (var i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }

            return res;
        }
    }
}