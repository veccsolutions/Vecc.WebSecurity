using System;

namespace Vecc.WebSecurity.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        ///     If the flag is in the value, it will append the text with a space
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <param name="flag">Flag to look for</param>
        /// <param name="text">Text to append to the end</param>
        /// <returns>The text or the default value attribute text appended to the value if the flag is set, otherwise just the text</returns>
        public static string AppendDefaultValueIfFlagged(this Enum value, Enum flag, string text)
        {
            if (value.HasFlag(flag))
            {
                var defaultValue = flag.GetDefaultValue();

                if (defaultValue == null)
                {
                    return text;
                }
                var defaultValueText = defaultValue as string;
                var result = defaultValueText ?? defaultValue.ToString();

                if (string.IsNullOrWhiteSpace(text))
                {
                    return result;
                }

                return text + " " + result;
            }

            return text;
        }
    }
}