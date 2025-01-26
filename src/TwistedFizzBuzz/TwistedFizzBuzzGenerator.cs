using System.Reflection.Metadata;
using System;
using System.Text.Json;

namespace TwistedFizzBuzz
{
    /// <summary>
    /// A generator for creating custom FizzBuzz outputs based on user-defined tokens and divisors.
    /// </summary>
    public class TwistedFizzBuzzGenerator
    {
        private readonly Dictionary<int, string> tokens = [];

        /// <summary>
        /// Registers a divisor-token pair to the generator.<br/>
        /// Throws an <see cref="ArgumentException"/> if the divisor is zero.
        /// </summary>
        /// <param name="divisor">The divisor for the token.</param>
        /// <param name="token">The string token to associate with the divisor.</param>
        /// <returns>The generator instance for method chaining.</returns>
        /// <exception cref="ArgumentException">Thrown when the divisor is zero.</exception>
        public TwistedFizzBuzzGenerator RegisterToken(int divisor, string token)
        {
            if(divisor == 0)
            {
                throw new ArgumentException($"Divisor cannot be zero.", nameof(divisor));
            }

            tokens[divisor] = token;
            return this;
        }

        /// <summary>
        ///Generates FizzBuzz output for a range of integers from start to end, inclusive.<br/>
        ///Handles both ascending and descending ranges.
        /// </summary>
        public IEnumerable<string> GenerateFizzBuzzInRange(int start, int end)
        {
            var range = GenerateRange(start, end);
            return GenerateFizzBuzz(range);
        }

        /// <summary>
        /// Generates an array of integers representing a range from start to end, inclusive.
        /// Handles both ascending and descending ranges.
        /// </summary>
        private static int[] GenerateRange(int start, int end)
        {
            if (start <= end)
            {
                return Enumerable.Range(start, end - start + 1).ToArray();
            }
            else
            {
                return Enumerable.Range(end, start - end + 1).Reverse().ToArray();
            }
        }

        /// <summary>
        /// Generates FizzBuzz output for an arbitrary array of integers.
        /// </summary>
        /// <param name="values">An array of integers to process.</param>
        /// <returns>An enumerable of FizzBuzz outputs for the provided integers.</returns>
        public IEnumerable<string> GenerateFizzBuzz(params int[] values)
        {
            foreach (int value in values)
            {
                yield return GetFizzBuzzOutput(value);
            }
        }

        /// <summary>
        /// Computes the FizzBuzz output for a single integer based on the registered tokens.<br/>
        /// Returns concatenated tokens for matching divisors or the integer as a string if no matches are found.
        /// </summary>
        /// <param name="value">The integer to process.</param>
        private string GetFizzBuzzOutput(int value)
        {
            string output = "";
            foreach (KeyValuePair<int, string> token in tokens)
            {
                if (value % token.Key == 0)
                {
                    output += token.Value;
                }
            }

            return !string.IsNullOrEmpty(output) ? output : value.ToString();
        }

        public Dictionary<int, string> GetTokens() => tokens;

        public void ClearTokens() => tokens.Clear();

        /// <summary>
        /// Asynchronously retrieves divisor-token pairs from an API and registers them.<br/>
        /// The API response should be in JSON format as a dictionary.<br/><br/>
        /// Note: This method has not been tested due to the unavailability of the API.
        /// </summary>
        /// <returns>The generator instance with the registered tokens.</returns>
        public async Task<TwistedFizzBuzzGenerator> RegisterTokensFromApi()
        {
            const string TOKENS_API_URL = "https://rich-red-cocoon-veil.cyclic.app/";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(TOKENS_API_URL);
            var tokens = JsonSerializer.Deserialize<Dictionary<int, string>>(response);

            if (tokens != null)
            {
                foreach (var token in tokens)
                {
                    RegisterToken(token.Key, token.Value);
                }
            }

            return this;
        }
    }
}
