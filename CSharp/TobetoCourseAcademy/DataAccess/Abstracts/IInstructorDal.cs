using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
	public interface IInstructorDal:IEntityRepository<Instructor>
	{
        //Insturctor'a ozel metod imzalari gelebilir
    }
}

