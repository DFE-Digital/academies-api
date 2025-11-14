using System.Globalization;

namespace Dfe.Academies.Utils.Extensions
{
    public static class DateExtensions
    {
        public static string? ToResponseDate(this DateTime? date)
        {
            if (date == null)
                return null;

            return date.Value.ToString("d", new CultureInfo("en-GB"));
        }
        public static string? ToISO8601DateTime(this DateTime? date)
        {
            if (date == null)
                return null;

            return date.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", new CultureInfo("en-GB"));
        }
        public static string? ToISODateOnly(this DateTime? date)
        {
            if (date == null)
                return null;

            return date.Value.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
        }
    }
}
