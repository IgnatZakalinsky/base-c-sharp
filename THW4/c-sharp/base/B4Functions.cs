/*
void SayHello()
{
    Console.WriteLine("Hello");
}

SayHello(); // Hello
*/

/*
void PrintMessage(string message, int x = 1)
{
    Console.WriteLine(message);
}

PrintMessage("x")
PrintMessage("x", 2)
PrintMessage(x: 3, message: "x")
*/

/*
int Sum(in int x, ref int y, out int z, out int q)
{
    // x read-only ref
    y++;
    z = x - y;
    q = 0;
    return x + y;
}

int r = 7, a = 1, b;
Sum(r, a, out b, out int q) // a == 2, b == 5
*/

/*
void Sum(int initialValue, params int[] numbers)
{
    int result = initialValue;
    foreach (var n in numbers)
    {
        result += n;
    }
    Console.WriteLine(result);
}
Sum(1, 2, 3, 4)
Sum(0)
*/

/*
int Sum(int[] numbers)
{
    int result = 0;
    int limit = 0;
    foreach (int number in numbers)
    {
        if (IsPassed(number, limit)) result += number;
    }
    return result;
 
    static bool IsPassed(int number, int lim)
    {
        // return number > limit; // error
        return number > lim;
    }
}
*/