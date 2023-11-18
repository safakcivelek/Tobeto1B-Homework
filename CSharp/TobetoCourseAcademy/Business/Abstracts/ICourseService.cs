using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstracts
{
	// İş katmanında kullanılacak servis operasyonları imzaları
	public interface ICourseService
	{
        IDataResult<Course> GetById(int courseId);
		IDataResult<List<Course>> GetAll();
        IDataResult<List<Course>> GetAllByCategoryId(int categoryId);
        IDataResult<List<Course>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<CourseDetailDto>> GetCourseDetails();

        IResult Add(Course course);
		void Delete(Course course);
		void Update(Course course);
	}
}

