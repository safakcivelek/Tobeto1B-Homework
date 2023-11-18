using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CourseAcademyContext>, ICategoryDal
    {       
        //Category'e ozel metod gövdeleri yazilabilir
    }
}

