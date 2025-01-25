namespace TwistedFizzBuzz
{
    public class TwistedFizzBuzzGenerator
    {
        private readonly Dictionary<int, string> tokens = [];

        public TwistedFizzBuzzGenerator RegisterDivisorToken(int divisor, string token)
        {
            tokens[divisor] = token;
            return this;
        }

        public IEnumerable<string> GenerateFizzBuzzInRange(int start, int end)
        {
            var range = GenerateRange(start, end);
            return GenerateFizzBuzz(range);
        }

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

        public IEnumerable<string> GenerateFizzBuzz(params int[] values)
        {
            foreach (int value in values)
            {
                yield return GetFizzBuzzOutput(value);
            }
        }

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
    }
}
