using Entities.Concretes;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstracts
{
	public interface ICourseDal:IEntityRepository<Course>
	{        
        List<CourseDetailDto> GetCourseDetails();              
    }
}

