using System.Security.Cryptography;
using System.Text;

namespace Dfe.Academies.Utils.Caching
{
    public static class CacheKeyHelper
    {
        /// <summary>
        /// Generates a hashed cache key for any given input string.
        /// </summary>
        /// <param name="input">The input string to be hashed.</param>
        /// <returns>A hashed string that can be used as a cache key.</returns>
        public static string GenerateHashedCacheKey(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty", nameof(input));
            }

            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Generates a hashed cache key for a collection of strings by concatenating them.
        /// </summary>
        /// <param name="inputs">A collection of strings to be concatenated and hashed.</param>
        /// <returns>A hashed string that can be used as a cache key.</returns>
        public static string GenerateHashedCacheKey(IEnumerable<string> inputs)
        {
            if (inputs == null || !inputs.Any())
            {
                throw new ArgumentException("Input collection cannot be null or empty", nameof(inputs));
            }

            var concatenatedInput = string.Join(",", inputs);

            return GenerateHashedCacheKey(concatenatedInput);
        }
    }

}
