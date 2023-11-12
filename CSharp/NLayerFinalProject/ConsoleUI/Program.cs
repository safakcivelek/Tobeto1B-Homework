
// Abstract klasörler içinde soyut nesneleri tutucaz. (interface,abstract)
// Abstractlar içinde aslında referans tutucuları koyucaz.
// Abstract ile uygulamalar arasındaki bağımlılıkları minimalize edeceğiz

// Concrete klasörler içinde somut nesnelermizi yani asıl işi yapıcak nesneleri tutarız.

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//Open Closed Princible
ProductManager productManager = new ProductManager(new EfProductDal());
foreach (var product in productManager.GetByUnitPrice(40,100))
{
    Console.WriteLine(product.ProductName);
}