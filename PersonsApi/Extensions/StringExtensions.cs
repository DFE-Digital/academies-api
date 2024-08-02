namespace PersonsApi.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.TryParse(value, out var result) ? result : 0;
        }
    }
}
