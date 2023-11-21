using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseInstructorDal : EfEntityRepositoryBase<CourseInstructor, CourseAcademyContext>, ICourseInstructorDal
    {      
        
    }
}

