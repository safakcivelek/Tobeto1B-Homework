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
                             join cat in context.Categories on c.CategoryId equals cat.Id
                             join ci in context.CoursesInstructors on c.Id equals ci.CourseId
                             join i in context.Instructors on ci.InstructorId equals i.Id
                             group i by new
                             {
                                 c.Id,
                                 c.Name,
                                 c.Price,
                                 catName = cat.Name
                             } into grouped
                             select new CourseDetailDto
                             {
                                 CourseId = grouped.Key.Id,
                                 CourseName = grouped.Key.Name,
                                 Price = grouped.Key.Price,
                                 CategoryName = grouped.Key.catName,
                                 Instructors = grouped.Select(i => new InstructorDetailDto
                                 {
                                     InstructorId = i.Id,
                                     InstructorName = $"{i.FirstName} {i.LastName}"
                                 }).ToList()
                             };
                return result.ToList();
            }
        }
    }
}

