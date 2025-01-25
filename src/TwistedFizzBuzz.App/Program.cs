using TwistedFizzBuzz;

var generator = new TwistedFizzBuzzGenerator();
generator.RegisterDivisorToken(3, "Fizz");
generator.RegisterDivisorToken(5, "Buzz");

foreach (string fizzBuzz in generator.GenerateFizzBuzzInRange(1, 100))
{
    Console.WriteLine(fizzBuzz);
}