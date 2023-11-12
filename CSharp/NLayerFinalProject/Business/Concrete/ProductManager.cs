using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //Genelde Manager ifadesi iş katmanının somut katmanında kullanılır.
    public class ProductManager : IProductService
    {
        //Bir iş sınıfı başka sınıflar new'lemez!
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            // ProductManager new'lendiğinde bu Consturctor metodu çağrılır ilk olarak.
            // Ve Constructor burada diyorki bana bir tane IProductDal referansı ver.            
            _productDal = productDal;
        }
         
        public List<Product> GetAll()
        {
            //İş kodları
            //yukarıda constructor da IProductDal referansı verdiğim için artık metodlarımı çekebiliyorum.
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
            //Burada "_productDal.GetAll()" ifadesinin parantezii içinde bir "Expression" yani bir "Lambda" ifadesi bekliyor.
            //GetAll içinde Lambda yazımı=>  "GetAll(p=>p.CategoryId == id)"
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}