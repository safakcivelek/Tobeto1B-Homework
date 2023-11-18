using Entities.Concretes;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstracts
{
	public interface ICourseDal:IEntityRepository<Course>
	{
        List<CourseDetailDto> GetCourseDetails();


        //Kurslara özel metod
        //Kurslar kategori bilgileri ile gelir      
        //Ekleme kod
        //public Course GetAllTables(Expression<Func<Course, bool>> filter);
         
    }
}

