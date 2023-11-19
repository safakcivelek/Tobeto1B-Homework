using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using System;
namespace Business.Abstracts
{
	public interface ICategoryService
	{
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}

