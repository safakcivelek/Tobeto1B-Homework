using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    //Nuget: Microsoft.EntityFrameworkCore.SqlServer
    //Bunun anlamı biz artık DataAcces'in içinde EntityFrameworkCore kodu yazabiliriz.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using nesnesi bitince GarbageCollector hemen gelir ve işini yapar ve bellekten atar
            //Context nesnesi biraz pahalıdır o yüzden GbCollectorun hemen işini yapması faydalıdır.
            //IDisposable pattern implementation of c# (using)
            using (NorthwindContext context=new NorthwindContext())
            {
                // Entry: git veri kaynağından parametre ile gönderdiğim Product ile (entity) birtane nesneyi eşleştir.
                // Yani burada referansı yakalıyorum.
                var addedEntity = context.Entry(entity); 
                // Burada ise ekleme,güncelleme,silme işlemlerinden hangisini yapacağımızı bildiriyoruz.
                // sonuçta elimizde şuan bir referans var bununla ilgili istenilen işlemi gerçekleştiriyoruz.
                addedEntity.State = EntityState.Added;
                // referans bilgisi alındı (Entry), yapılacak işlem belirlendi (Added) ve artık SaveChanges() ile uygula!
                context.SaveChanges();
            }
        }
        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {               
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;              
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext contex= new NorthwindContext())
            {
                return contex.Set<Product>().SingleOrDefault(filter);
                //Set<Product>()    => Product ile çalışıcaz!
                //SingleOrDefault() => Product tablosunu foreach gibi dön!
                //SingleOrDefault(filter) => dönerken "filter" filtresi ile eşleşen kaydı yakala. (referans bilgisi elimizde!)
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Set<Product>.ToList()  Product'a yerleş ve oradaki(veritabanındaki) tüm datayı listeye çevir.
                //Set<Product>.ToList()  Bu bizim için arka planda SQL tarafında şunu yapar; Select * From Products               
                //Set<Product>() Ben ürünler tablosu ile çalışacağım demek.
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
                //Where(filter).ToList() Burası aslında Lambda yazımı ile bize gelen "filter" filtrelenmiş bir listedir.               
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
