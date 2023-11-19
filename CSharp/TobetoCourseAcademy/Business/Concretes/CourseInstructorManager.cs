using System;
using Business.Abstracts;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseInstructorManager : ICourseInstructorService
    {
        ICourseInstructorDal _courseInstructorDal;
        public CourseInstructorManager(ICourseInstructorDal courseInstructorDal)
        {
            _courseInstructorDal = courseInstructorDal;
        }
        public IDataResult<CourseInstructor> GetById(int courseInstructorId)
        {
            var courseInstructor = _courseInstructorDal.Get(c => c.Id == courseInstructorId);
            if (courseInstructor != null)
            {
                return new SuccessDataResult<CourseInstructor>(_courseInstructorDal.Get(c => c.Id == courseInstructorId),CourseInstructorMessages.GetOne(courseInstructor.Id));
            }
            return new ErrorDataResult<CourseInstructor>(CourseInstructorMessages.NotFound(isPlural: false));
        }
        public IDataResult<List<CourseInstructor>> GetAll()
        {
            var courseInstructorList = _courseInstructorDal.GetAll();
            if (courseInstructorList.Any())
            {
                if (DateTime.Now.Hour == 15)
                {
                    return new ErrorDataResult<List<CourseInstructor>>(CourseInstructorMessages.MaintenanceTime());
                }
                return new SuccessDataResult<List<CourseInstructor>>(_courseInstructorDal.GetAll(), CourseInstructorMessages.Listed());
            }
            return new ErrorDataResult<List<CourseInstructor>>(CourseInstructorMessages.NotFound(isPlural: true));
        }
        public IResult Add(CourseInstructor courseInstructor)
        {
            _courseInstructorDal.Add(courseInstructor);
            return new Result(true, CourseInstructorMessages.Added());
        }
        public IResult Delete(CourseInstructor courseInstructor)
        {
            var data = _courseInstructorDal.Get(c => c.Id == courseInstructor.Id);
            if (data != null)
            {
                _courseInstructorDal.Delete(courseInstructor);
                return new Result(true, CourseInstructorMessages.Deleted());
            }
            return new ErrorResult(CourseInstructorMessages.NotFound(isPlural: false));
        }
        public IResult Update(CourseInstructor courseInstructor)
        {
            var data = _courseInstructorDal.Get(c => c.Id == courseInstructor.Id);
            if (data != null)
            {
                _courseInstructorDal.Update(courseInstructor);
                return new Result(true, CourseInstructorMessages.Updated());
            }
            return new ErrorResult(CourseInstructorMessages.NotFound(isPlural: false));
        }
    }
}

