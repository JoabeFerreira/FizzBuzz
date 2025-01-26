using System;

namespace TwistedFizzBuzz.Tests
{
    public class TwistedFizzBuzzGeneratorTests
    {
        [Fact]
        public void RegisterTokenCorrectly()
        {
            var generator = new TwistedFizzBuzzGenerator();

            generator.RegisterToken(3, "Fizz");

            Dictionary<int, string> tokens = generator.GetTokens();
            Assert.Contains(tokens, t => t.Key == 3 && t.Value == "Fizz");
        }

        [Fact]
        public void ThrowsArgumentExceptionWhenRegisteringAZeroDivisor()
        {
            var generator = new TwistedFizzBuzzGenerator();

            ArgumentException message = Assert.Throws<ArgumentException>(new Action(() =>
                generator.RegisterToken(0, "Fizz")
            ));

            Assert.Equal("Divisor cannot be zero. (Parameter 'divisor')", message.Message);
        }

        [Fact]
        public void ClearTokensCorrectly()
        {
            var generator = new TwistedFizzBuzzGenerator();

            generator.RegisterToken(3, "Fizz");
            generator.ClearTokens();

            Dictionary<int, string> tokens = generator.GetTokens();
            Assert.Empty(tokens);
        }

        [Fact]
        public void ReturnNumberWhenNoTokensMatch()
        {
            var generator = new TwistedFizzBuzzGenerator();

            var result = generator.GenerateFizzBuzzInRange(1, 5);

            Assert.Equal(["1", "2", "3", "4", "5"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForNonSequentialNumbers()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz");

            var result = generator.GenerateFizzBuzz(-5, 6, 300, 12, 15);

            Assert.Equal(["-5", "Fizz", "Fizz", "Fizz", "Fizz"], result);
        }
        
        [Fact]
        public void ConcatenatesTokensWhenMultipleMatchesOccur()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzz(15);

            Assert.Equal(["FizzBuzz"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForAscendingRange()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzzInRange(1, 5);

            Assert.Equal(["1", "2", "Fizz", "4", "Buzz"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForDescendingRange()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzzInRange(5, 1);

            Assert.Equal(["Buzz", "4", "Fizz", "2", "1"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForNegativeRange()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzzInRange(-5, -1);

            Assert.Equal(["Buzz", "-4", "Fizz", "-2", "-1"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForNegativeToPositiveRange()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzzInRange(-5, 1);

            Assert.Equal(["Buzz", "-4", "Fizz", "-2", "-1", "FizzBuzz", "1"], result);
        }

        [Fact]
        public void GenerateCorrectOutputForNegativeToken()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(-3, "Fizz")
                .RegisterToken(5, "Buzz");

            var result = generator.GenerateFizzBuzzInRange(-5, 3);

            Assert.Equal(["Buzz", "-4", "Fizz", "-2", "-1", "FizzBuzz", "1", "2", "Fizz"], result);
        }

        [Fact]
        public void OverwriteExistingToken()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz")
                .RegisterToken(3, "OverwrittenFizz");

            var result = generator.GenerateFizzBuzz(3);

            Assert.Equal(["OverwrittenFizz"], result);
        }
        
        [Fact]
        public void GenerateCorrectOutputForLargeRange()
        {
            var generator = new TwistedFizzBuzzGenerator()
                .RegisterToken(3, "Fizz");

            var result = generator.GenerateFizzBuzzInRange(1, 2000000000);

            Assert.NotEmpty(result);
        }

        [Fact(Skip = "API is unavailable, so this method could not be tested.")]
        public async Task RegisterTokensFromApi()
        {
            // Placeholder test: Unable to test due to API unavailability.
        }
    }
}