// *** String *** //

// stringler aslında bir char array'idir.

// Intro();

// String Metodlar
string sentence = "My name is Engin Demiroğ";
// Lenght => karakter uzunluğunu verir.
var result = sentence.Length;
Console.WriteLine(result);

// Clone() => string değerin bir referansını daha oluşturmaya yarar.
var result2 = sentence.Clone();
sentence = "My name is Derin Demiroğ";
Console.WriteLine(result2);

// EndsWith() => bitiş karakteri
bool result3 = sentence.EndsWith("ğ");
Console.WriteLine(result3);
// StartsWith() => başlangıç karakteri
bool result4 = sentence.EndsWith("My name");
Console.WriteLine(result4);

// IndexOf() => bir stringde belli bir karakteri veya ifadeyi aramak için kullanılır.
// Bu örnekde çıktı 3'dür. Yani name'nin 3. karakterden itibaren başladığını belirtir.
// Eğer boşluk kontrolü yapılacaksa, birden çok boşluk varsa bulduğu ilk boşluğu hesaba katar.
var result5 = sentence.IndexOf("name");
Console.WriteLine(result5);
var result6 = sentence.IndexOf("namee");
Console.WriteLine(result6);
var result7 = sentence.IndexOf(" ");
Console.WriteLine(result7);

// LastIndexOf() => aramaya sondan başlar.
var result8 = sentence.LastIndexOf(" ");
Console.WriteLine(result8);

// Insert() => bir cümleye veya bir string ifadeye başka bir metni yerleştirmek için kullanılır.
var result9 = sentence.Insert(0, "Hello, ");
Console.WriteLine(result9);

// SubString() => metni parçalamak için kullanılır. Metnin belli bir yerinden itibaren almak için kullanılır.
var result10 = sentence.Substring(3);
Console.WriteLine(result10);
var result11 = sentence.Substring(3,4); // 3. karakterden itibaren 4 tane al
Console.WriteLine(result11);

// ToLower - ToUpper => karakterleri küçük veya büyük harf yapar.
var result12 = sentence.ToLower();
Console.WriteLine(result12);
var result13 = sentence.ToUpper();
Console.WriteLine(result13);

// Replace() => bir metin içerisinde belli karakterleri değiştirmek için kullanırız.
var result14 = sentence.Replace(" ","_");
Console.WriteLine(result14);

// Remove() => bir metinden  belli bir indexden sonrasını atmak için kullanılır.
var result15 = sentence.Remove(2); // 2 den itibaren uçur demiş olduk
Console.WriteLine(result15);
var result16 = sentence.Remove(2,5); // 2 den itibaren 5 tane uçur demiş olduk
Console.WriteLine(result16);


static void Intro()
{
    string city = "Ankara";
    //Console.WriteLine(city[0]);

    foreach (var item in city)
    {
        Console.WriteLine(item);
    }

    string city2 = "İstanbul";
    //string result = city + city2;

    //Console.WriteLine(result);
    Console.WriteLine(String.Format("{0} {1}", city, city2));
}

Console.ReadKey();