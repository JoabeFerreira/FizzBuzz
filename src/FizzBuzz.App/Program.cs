OriginalFizzBuzz();

static void OriginalFizzBuzz()
{
    const int FIZZ_VALUE = 3;
    const int BUZZ_VALUE = 5;

    for (int i = 1; i <= 100; i++)
    {
        string output = (i % FIZZ_VALUE == 0 ? "Fizz" : "") + 
                        (i % BUZZ_VALUE == 0 ? "Buzz" : "");
        
        Console.WriteLine(!string.IsNullOrEmpty(output) ? output : i);
    }
}


