using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    // InMemory ile bellekte veri varmış gibi bir ortam oluşturuyoruz.
    // InMemoryProductDal bellek üzerinde ürünle ilgili veri erişim kodlarının yazılacağı yer demektir.
    public class InMemoryProductDal : IProductDal
    {
        // Global'de tanımlanmış referans tipi
        List<Product> _products;
        // Bu Constructor ile proje çalıştığında örnekteki gibi verilerimiz olacaktır.
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _products = new List<Product> {
                new Product { ProductId = 1,CategoryId = 1, ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product { ProductId = 2,CategoryId = 1, ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product { ProductId = 3,CategoryId = 2, ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product { ProductId = 4,CategoryId = 2, ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product { ProductId = 5,CategoryId = 2, ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }

        public void Add(Product product)
        {
            // Business katmanından parametre olarak bana gönderilen ürünü alıyorum ve oluşturmuş olduğum veritabanıma ekliyorum. Veritabanım örneğin; "List<Product> _products" olsun.
            _products.Add(product);
        }

        //Hatalı kod! => Product productDelete = new Product(); //201 hatalı çünkü burada new'leme ile heapde bir alan açıyoruz.Buna gerek yok çünkü silinecek olan ürünün referans noktası zaten var. O referans noktasını bul ve "productDelete" olan değişkene ver.Belleği yoruyoruz gereksiz yere!!!
        public void Delete(Product product)
        {
            // UI'dan bize parametre ile ürünün referans bilgisi gelir ve bu referans numarasının veritabanımızda kontrolünü yaparız eşitleme ile. Eğer var ise ve o referansı siler isek veritabanından ürünü kaldırmış oluruz. Yani UI'dan gelen referans numarsını karşılaştırmadan silmeyi denersek eğer ki bu durumda veri tabanında öyle bir referans numarası yoksa  olmayan bir referansı silemeyeceğimizden hatalı bir durum ile karşılaşırız.

            #region UzunYöntem
            //Product productToDelete=null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        //UI'dan parametre ile gelen referansın veritabanındaki kontrolü!
            //        productToDelete = p;
            //    }
            //}
            //Eğerki LINQ olmasaydı yukarıdaki gibi listeyi tek tek dolaşıp veri kontrolü yani referans numarasıkontrolü yapmamız gerekirdi.Şimdide LINQ kullanarak yapalım aşağıda!
            #endregion
            //LINQ
            //Lambda işareti:  =>
            //SingleOrDefault(p =>) bu kod "foreach" gibi listeyi tek tek döner.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            //Where içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve o listeyli döndürür.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
