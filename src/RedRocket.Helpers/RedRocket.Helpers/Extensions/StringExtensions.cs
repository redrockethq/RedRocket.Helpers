using System;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace RedRocket.Helpers
{
    public static class StringExtensions
    {
        [StringFormatMethod("input")]
        public static string P(this string input, params object[] args)
        {
            return string.Format(input, args);
        }

        public static string ToCamelCase(this string input, params string[] separators)
        {
            var output = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                var elements = input.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < elements.Length; i++)
                {
                    var element = elements.ElementAt(i);
                    var elementCharacters = element.ToCharArray();
                    if (elementCharacters.Any() && char.IsLetter(elementCharacters.First()) && char.IsLower(elementCharacters.First()))
                        elementCharacters[0] = Char.ToUpper(elementCharacters[0]);

                    elements[i] = new string(elementCharacters);
                }
                return string.Join(string.Empty, elements);
            }
            return output;
        }

        public static string RemoveAccents(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(input);
                return System.Text.Encoding.ASCII.GetString(bytes);
            }
            return string.Empty;
        }

        public static string ToUrlFriendly(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                // Lowercase and Remove Accents
                input = input.ToLowerInvariant().RemoveAccents();

                // Remove Spaces
                input = Regex.Replace(input, @"\s", "-", RegexOptions.Compiled);

                //Remove invalid chars
                input = Regex.Replace(input, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

                //Trim dashes from end
                input = input.Trim('-', '_');

                //Replace double occurences of - or _
                input = Regex.Replace(input, @"([-_]){2,}", "$1", RegexOptions.Compiled);

                return input;
            }
            return string.Empty;
        }
    }
}
