using Entities.Concretes;
using System;
namespace Business.Abstracts
{
	public interface ICategoryService
	{
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}

