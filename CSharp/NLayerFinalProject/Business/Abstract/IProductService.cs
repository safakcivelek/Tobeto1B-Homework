using Entities.Concrete;

namespace Business.Abstract
{
    // İş katmanında kullanılacak servis operasyonları
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);

        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
