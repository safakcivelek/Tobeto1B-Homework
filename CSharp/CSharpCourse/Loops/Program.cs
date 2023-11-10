
// ***  Loops *** //

//FoorLoop();
//WhileLoop();
//DoWhileLoop();
//ForEachLoop();

// Asal Sayı
if (IsPrimeNumber(7))
{
    Console.WriteLine("This is a prime number");
}
else
{
    Console.WriteLine("This is not a prime number");
}
 static bool IsPrimeNumber(int number)
{
    bool result = true;
    for (int i = 2; i < number-1; i++)
    {
        if (number % i == 0)
        {
            result = false;
            i = number;
        }
    }
    return result;
}


//For
static void FoorLoop()
{
    for (int i = 100; i >= 0; i = i - 2)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("Finished!");
}
//While
static void WhileLoop()
{
    int number = 100;
    while (number >= 0)
    {
        Console.WriteLine(number);
        number--;
    }
    Console.WriteLine("Now number is {0}", number);
}
//Do While
static void DoWhileLoop()
{
    int number = 10;
    do
    {
        Console.WriteLine(number);
        number--;
    } while (number >= 11);
}
//Foreach
static void ForEachLoop()
{
    string[] students = new string[3] { "Engin", "Derin", "Salih" };
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}

Console.ReadKey();
