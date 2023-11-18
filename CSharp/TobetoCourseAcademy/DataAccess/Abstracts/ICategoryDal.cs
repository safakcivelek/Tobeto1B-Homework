using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
	public interface ICategoryDal:IEntityRepository<Category>
	{
        //Category'e ozel metod imzalari gelebilir
    }
}

