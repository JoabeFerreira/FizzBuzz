using TwistedFizzBuzz;

var generator = new TwistedFizzBuzzGenerator()
    .RegisterToken(3, "Fizz")
    .RegisterToken(5, "Buzz");

foreach (string fizzBuzz in generator.GenerateFizzBuzzInRange(1, 100))
{
    Console.WriteLine(fizzBuzz);
}