using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;


namespace Business.Concretes
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
                _categoryDal=categoryDal;
        }
        public Category GetById(int categoryId)
        {
           return _categoryDal.Get(ct =>ct.Id == categoryId);
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
    }
}
