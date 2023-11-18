using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concretes.InMemory
{
    // Bu class projemizin farklı veritabanı sistemleri ile çalışılabileceğini gösteren bir örneğini teşkil eder
    // Projede üzerinde etkisi olmayacaktır
    public class InMemoryCourseDal : ICourseDal
    {      
        public Course Get(Expression<Func<Course, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll(Expression<Func<Course, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CourseDetailDto> GetCourseDetails()
        {
            throw new NotImplementedException();
        }
        public void Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Course entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
