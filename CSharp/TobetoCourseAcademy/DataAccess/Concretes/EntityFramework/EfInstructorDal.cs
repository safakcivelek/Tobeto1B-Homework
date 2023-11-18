using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, CourseAcademyContext>, IInstructorDal
    {
        //Instructor'a ozel metod gövdeleri yazilabilir
    }
}

