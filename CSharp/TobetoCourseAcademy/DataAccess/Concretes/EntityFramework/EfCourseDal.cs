using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, CourseAcademyContext>, ICourseDal
    {
        //Include işlemi veritabanındaki tüm veriyi projeye çeker daha sonra filtreleme yapar
        //Join işlemi filtrelenmiş nesneyi veritabanından filtrelenmiş olarak çeker
        //Join işlemi bu açıdan include işlmeine göre daha performanslıdır.
        #region ForIncludeV2      
        //public Course GetAllTables(Expression<Func<Course, bool>> filter)
        //{
        //    using (CourseAcademyContext context = new CourseAcademyContext())
        //    {
        //        return context.Set<CourseAcademyContext>()
        //           .Include(c => c.Category)
        //           .Include(c => c.CourseInstructors)
        //           .ThenInclude(ci => ci.Instructor)
        //           .SingleOrDefault(filter);
        //    }
        //} 
        #endregion
        public List<CourseDetailDto> GetCourseDetails()
        {
            using (CourseAcademyContext context = new CourseAcademyContext())
            {
                var result = from c in context.Courses
                                    join ct in context.Categories
                                    on c.CategoryId equals ct.Id
                                    select new CourseDetailDto
                                    {
                                        CourseId = c.Id,
                                        CourseName = c.Name,
                                        CategoryName = ct.Name,
                                        Price = c.Price
                                    };

                return result.ToList();
            }
        }
    }
}

