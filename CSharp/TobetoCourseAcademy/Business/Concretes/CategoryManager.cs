using Business.Abstracts;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
                _categoryDal=categoryDal;
        }

        public IDataResult<Category> GetById(int categoryId) 
        {           
            var category = _categoryDal.Get(c => c.Id == categoryId);
            if (category != null)
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId), CategoryMessages.GetOne(category.Name));
            }
            return new ErrorDataResult<Category>(CategoryMessages.NotFound(isPlural: false));
        }
        public IDataResult<List<Category>> GetAll() 
        {
            var categoryList = _categoryDal.GetAll();
            if (categoryList.Any())
            {
                if (DateTime.Now.Hour == 15)
                {
                    return new ErrorDataResult<List<Category>>(CategoryMessages.MaintenanceTime());
                }
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), CategoryMessages.Listed());
            }
            return new ErrorDataResult<List<Category>>(CategoryMessages.NotFound(isPlural: true));
        }            
        public IResult Add(Category category)
        {

            _categoryDal.Add(category);
            return new Result(true, CategoryMessages.Added());
        }
        public IResult Delete(Category category)
        {                        
            var data = _categoryDal.Get(c => c.Id == category.Id);
            if (data != null)
            {
                _categoryDal.Delete(category);
                return new Result(true, CategoryMessages.Deleted());
            }
            return new ErrorResult(CategoryMessages.NotFound(isPlural: false));
        }
        public IResult Update(Category category)
        {
            var data = _categoryDal.Get(c => c.Id == category.Id);
            if (data != null)
            {
                _categoryDal.Update(category);
                return new Result(true, CategoryMessages.Updated());
            }
            return new ErrorResult(CategoryMessages.NotFound(isPlural: false));
        }
    }
}
