namespace MenuTools.TableBuilder
{
    public static class StringExtension 
    {
        public static object StringCut(this string str, int value)
        {
            if (value > 3 && str.Length > value)
            {
                return string.Concat(str.AsSpan(0, value - 3), "...");
            }
            else
            {
                return str;
            }
        }
    }
}