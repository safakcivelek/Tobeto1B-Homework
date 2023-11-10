
//  İlk projenin oluşturulması //
// Console.WriteLine("Hello, World!");

// *** Value Types *** //
// int veri tipinin sınırları =>  -2147483648 ile 2147483647 arasındadır. / 32bit
int number1 = 2147483647;
Console.WriteLine("Number1 is {0}",number1);

// long veri tipi integer'in tam iki katı olarak bellekte yer kaplar. / 64 bit
// long aslında kapsar integer'i diyebiliriz.
// long sınırları => -9223372036854775808 ile 9223372036854775807 arasındadır.
long number2 = -9223372036854775808;
Console.WriteLine("Number2 is {0}",number2);

// short veri tpi 16 bit'lik yer kaplar. / 16 bit
// short sınırıları => -32768 ile 32767 arasındadır.
short number3 = 32767;
Console.WriteLine("Number3 is {0}", number3);

// byte veri tipi bellekte 8 bit'lik yer kaplar. / 8 bit
// byte sınırıları => 0 ile 255 arasındadır.
byte number4 = 255;
Console.WriteLine("Number4 is {0}", number4);

// bool veri tipinin tuttuğu değer "true veya false" dir.
bool condition = false;
Console.WriteLine("MyCondition is {0}",condition);

// char veri tipi ile ASCII dediğmiz klavyemizideki tüm karakterleri tutabiliriz.
// char tipindeki tüm karakterlerin sayısal bir karşılığı vardır.(A => 65)
char character = 'A';
Console.WriteLine("Character is {0}", character);
Console.WriteLine("Character is {0}", (int)character); // sayısal karşılığı

// double veri tipi ile tam sayı tutan (int,short,long) veri tiplerinden farklı olarak ondalıklı sayıları da tutabiliyoruz.  / 64bit yer kaplar
double number5 = 10.4;
Console.WriteLine("Number5 is {0}", number5);

// decimal veri tipi aslında int için long neyse, double için decimal o dur diyebiliriz.
// biraz daha hassasiyet gösteren değerler için örneğin para tutarı için decimal veri dipinden yararlanıyoruz.
// double veri dipi virgülden sonra 15,16 tane karakter tutabiliyorken, decimal ise 28,28 tane değer tutabiliyor.
decimal number6 = 10.4m;
Console.WriteLine("Number6 is {0}", number6 + " (decimal)");

// Enum => enum'daki en temel amaç magic string ile uğraşmak zorunda kalmayız. Yani her değişken için ayrı ayrı string tanımlanmasının önüne geçeriz.
// enum sabitleri değerlerini 0'dan başlatıcak şekilde gerçekleştirir.
// başlangıç değerini değiştirebiliriz.
// enum sabitlerine farklı değerlerde vermek de mümkün.
Console.WriteLine("enum sabiti => " + Days.Friday);
Console.WriteLine("enum sabitinin değeri => " +(int)Days.Friday);

// var keyword
// değişkenin tipi değer atanırken belirlenir. Daha sonra var keywordü ile belirlenen değişken tipini değiştiremeyiz!
var number7 = 10;
number7 = 'A';
//number7 = "A"  //yanlış kullanım!
Console.WriteLine("Number7 is {0}", number7);

Console.ReadKey();

enum Days // enum tanımlaması
{
    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
}

