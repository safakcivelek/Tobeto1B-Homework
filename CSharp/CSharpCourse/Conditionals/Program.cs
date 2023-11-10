// Console.WriteLine("Hello, World!");

// *** Conditionals *** //
// if, else, else if
var number = 200;
//if (number == 10)
//{
//    Console.WriteLine("Number is 10");
//}
//else if (number == 20)
//{
//    Console.WriteLine("Number is 20");
//}
//else
//{
//    Console.WriteLine("Number is not 10 or 20");
//}

//// Single Line If
//Console.WriteLine(number == 10 ? "Number is 10" : "Number is not 10");

//// Switch
//switch (number)
//{
//    case 10:
//        Console.WriteLine("Numbers is 10");
//        break;
//    case 20:
//        Console.WriteLine("Numbers is 20");
//        break;
//    default:
//        Console.WriteLine("Number is not 10 or 20");
//        break;
//}

//// Çoklu şartlarla çalışmak
//if (number >= 0 && number <= 100 )
//{
//    Console.WriteLine("Number is between 0-100");
//}
//else if (number > 100 && number <= 200)
//{
//    Console.WriteLine("Number is between 101-200");
//}
//else if (number > 200 || number < 0)
//{
//    Console.WriteLine("Number is less than 0 or greater than 200");
//}

// İç içe if / Nested if
if (number < 100)
{
	if (number >= 90 && number < 95)
	{
		// devamında else, else if bloklarıyla devam edebiliriz...
	}
}

Console.ReadKey();