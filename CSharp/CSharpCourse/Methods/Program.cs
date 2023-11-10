
// *** Methods *** //
// Genel anlamda bizler metotları "dont repeat yourself" kendini tekrarlama! prensibi için kullanırız.

// Parametresiz değer döndürmeyen metot
using System.Numerics;

Add();
Add();
static void Add()
{
    Console.WriteLine("Added!");
}

// Parametreli değer döndüren metot
var result = Add2(20, 30);
Console.WriteLine(result);
static int Add2(int number1, int number2)
{
    var result = number1 + number2;
    return result;
}

// Default parametre => default değerlerin herzaman metotun en sonunda olması gerekir.
// paremetre gönderilez ise varsayılan bir değer gönderilmesini sağlar.
var result2 = Add3(10);
Console.WriteLine(result2);
static int Add3(int number1=20, int number2=30)
{
    var result2 = number1 + number2;
    return result2;
}

// Ref Keyword
// ref keywor'ü ile number1 değişkeninin referansını kullan ve parametre olarak Add4() metoduda number1'in referansını göndermiş olduk. Böylece Add4() metodu içerisinde number1 üzerinde yapılacak değişiklikler number1 değişkenini tamamen etkileycektir.
int number1 = 20;
int number2 = 100;
var result3 = Add4(ref number1, number2);
Console.WriteLine(result3);
Console.WriteLine(number1);
static int Add4(ref int number1, int number2)
{
    number1 = 30;
    return number1 + number2;
}

// Out Keyword
// out keyword'ü ref'den farkı; örneğin ref'de number1 değişkenine bir değer atamış olmamız gerekli fakat out'da gerek yok.
// eğerki out keywor'ü ile değer tanımlanmış olan bir değikeni metoda gönderirsek, aynı değişkeni metot içerisinde de tanımlamak durumundayız.
var result4 = Add5(out number1 , number2);
Console.WriteLine(result4);
static int Add5(out int number1, int number2)
{
    number1 = 15; 
    return number1 + number2; // 100 + 15 => 115 
}

// Method Overloading
var overLoading1 = OverLoading.Multiply(2,3);
var overLoading2 = OverLoading.Multiply(2,3,5);
Console.WriteLine(overLoading1); // Çıktı => 6
Console.WriteLine(overLoading2); // Çıktı => 30

// Params Keyword
// params ile metodumuza isdeğimiz kadar parametre gönderebiliriz.
// params metod paremetrelerinin en sonuncusu olmalıdır.
Console.WriteLine(Add6(1,2,3,4,5,6));
static int Add6(params int[] numbers)
{
    return numbers.Sum();
}

Console.ReadKey();
public class OverLoading
{  
    public static int Multiply(int number1, int number2)
    {
        return number1 * number2;
    }
    public static int Multiply(int number1, int number2, int number3)
    {
        return number1 * number2 * number3;
    }
}

