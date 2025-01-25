using TwistedFizzBuzz;

var generator = new TwistedFizzBuzzGenerator()
    .RegisterDivisorToken(5, "Fizz")
    .RegisterDivisorToken(9, "Buzz")
    .RegisterDivisorToken(27, "Bar");

foreach (string fizzBuzz in generator.GenerateFizzBuzzInRange(-20, 127))
{
    Console.WriteLine(fizzBuzz);
}
