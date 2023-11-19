using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using System;
namespace Business.Abstracts
{
	public interface IInstructorService
	{
        IDataResult<Instructor> GetById(int instructorId);
        IDataResult<List<Instructor>> GetAll();
        IResult Add(Instructor instructor);
        IResult Update(Instructor instructor);
        IResult Delete(Instructor instructor);
    }
}

