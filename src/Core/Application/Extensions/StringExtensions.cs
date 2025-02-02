using System.Text;

namespace Application.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Converts a singular noun to its plural form based on American English rules.
    /// </summary>
    /// <param name="word">The singular noun to be converted to plural.</param>
    /// <returns>The plural form of the given singular noun.</returns>
    public static string ToPlural(this string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        // Use StringBuilder for better performance in string manipulation
        var sb = new StringBuilder(word);

        // Apply specific pluralization rules based on American English
        if (word.EndsWith("y", StringComparison.OrdinalIgnoreCase) &&
            !IsVowel(word[word.Length - 2]))
        {
            // If the word ends with 'y' and the preceding character is not a vowel, replace 'y' with 'ies'
            sb.Remove(word.Length - 1, 1).Append("ies");
        }
        else if (word.EndsWith("s", StringComparison.OrdinalIgnoreCase) ||
                 word.EndsWith("sh", StringComparison.OrdinalIgnoreCase) ||
                 word.EndsWith("ch", StringComparison.OrdinalIgnoreCase) ||
                 word.EndsWith("x", StringComparison.OrdinalIgnoreCase) ||
                 word.EndsWith("z", StringComparison.OrdinalIgnoreCase))
        {
            // If the word ends with 's', 'sh', 'ch', 'x', or 'z', append 'es'
            sb.Append("es");
        }
        else if (word.EndsWith("f", StringComparison.OrdinalIgnoreCase))
        {
            // If the word ends with 'f', replace 'f' with 'ves'
            sb.Remove(word.Length - 1, 1).Append("ves");
        }
        else if (word.EndsWith("fe", StringComparison.OrdinalIgnoreCase))
        {
            // If the word ends with 'fe', replace 'fe' with 'ves'
            sb.Remove(word.Length - 2, 2).Append("ves");
        }
        else
        {
            // For all other cases, simply append 's'
            sb.Append("s");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Checks if a character is a vowel.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns>True if the character is a vowel, otherwise false.</returns>
    private static bool IsVowel(char c)
    {
        return "aeiouAEIOU".Contains(c);
    }
}
