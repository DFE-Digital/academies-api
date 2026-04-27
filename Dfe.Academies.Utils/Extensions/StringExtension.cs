using System.Text.RegularExpressions;

namespace Dfe.Academies.Utils.Extensions;

public static partial class StringExtension
{
    public static string ToAdName(this string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return string.Empty;

        var tokens = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Extract digits in order from entire string
        var digits = new string([.. fullName.Where(char.IsDigit)]);

        // Extract letters-only versions of tokens
        var cleanTokens = tokens
            .Select(t => RegexInstance().Replace(t, ""))
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .ToArray();

        if (cleanTokens.Length == 0)
            return digits; // fallback

        string adName;

        // If first token starts with a letter, use initial
        if (char.IsLetter(tokens[0][0]))
        {
            var firstInitial = char.ToUpper(cleanTokens[0][0]);

            var lastName = cleanTokens.Length > 1
                ? cleanTokens[^1]
                : cleanTokens[0];

            adName = $"{firstInitial}{lastName}";
        }
        else
        {
            // If name starts with number (e.g. "7 Lastname")
            var lastName = cleanTokens[^1];
            adName = lastName;
        }

        // Append digits at the end (if any)
        adName += digits;

        return adName;
    }

    [GeneratedRegex(@"\d")]
    private static partial Regex RegexInstance();
}
