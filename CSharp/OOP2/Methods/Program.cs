// Methods:

// Metotlar bizim için tekrar tekrar kullanılabilirliği sağlayan kod bloklarıdır.
// Dont repeat yourself - DRY - Clean Code - Best Practice

// C#, Java gibi programlama dillerinde herşey class'lardan oluşur. Yani yazdığımız kodlar bu class'ların içerisine yerleştirilir. Tabi çok küçük istisnai configürasyon vs. dosyaları hariçtir. Ama temel yapılar class'ların içerisinde olur.
using Methods;

string productName = "Elma";
double Price = 15;
string description = "Amasya elması";

string[] meyveler = new string[] { "Elma", "Karpuz" };

Product product1 = new Product();
product1.Name = "Elma";
product1.Price = 15;
product1.Description = "Amasya elması";

Product product2 = new Product();
product2.Name = "Karpuz";
product2.Price = 80;
product2.Description = "Diyarbakır karpuzu";

Product[] products = new Product[] { product1, product2 };

foreach (Product product in products)
{
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.Description);
    Console.WriteLine("-------------------------");
}

Console.WriteLine("-----------Metotlar----------");

//instance - örnek
CartManager cartManager = new CartManager();
cartManager.Add(product1);
cartManager.Add(product2);

cartManager.Add2("Armut", "Yeşil Armut", 12,10);
cartManager.Add2("Elma", "Yeşil Elma", 12,9);
cartManager.Add2("Karpuz", "Diyarbakır karpuzu", 12,8);

Console.ReadLine();