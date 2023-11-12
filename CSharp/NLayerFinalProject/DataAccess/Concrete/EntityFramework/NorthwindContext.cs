using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlama
    // DbContext EfCore ile birlikte gelir
    public class NorthwindContext:DbContext
    {
        //OnConfiguring metodu projenin hangi veritabanı ile ilişkili olduğunun belirtildiği yerdir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RG37ON7\SQLEXPRESS;Database=Northwind;Trusted_Connection=true;TrustServerCertificate=True");
        }

        //Projemdeki nesnelerim veritabanımdaki hangi nesnelere denk geleceğini belirtiyoruz.
        //DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
