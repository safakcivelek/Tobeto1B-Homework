using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using System;
namespace Business.Abstracts
{
	public interface ICourseInstructorService
	{
        IDataResult<CourseInstructor> GetById(int courseInstructorId);
        IDataResult<List<CourseInstructor>> GetAll();
        IResult Add(CourseInstructor instructor);
        IResult Update(CourseInstructor instructor);
        IResult Delete(CourseInstructor ınstructor);
    }
}

