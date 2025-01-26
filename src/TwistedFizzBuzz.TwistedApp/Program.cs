using TwistedFizzBuzz;

var generator = new TwistedFizzBuzzGenerator()
    .RegisterToken(5, "Fizz")
    .RegisterToken(9, "Buzz")
    .RegisterToken(27, "Bar");

foreach (string fizzBuzz in generator.GenerateFizzBuzzInRange(-20, 127))
{
    Console.WriteLine(fizzBuzz);
}
