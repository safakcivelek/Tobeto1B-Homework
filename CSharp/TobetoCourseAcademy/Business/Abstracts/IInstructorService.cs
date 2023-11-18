using Entities.Concretes;
using System;
namespace Business.Abstracts
{
	public interface IInstructorService
	{
		List<Instructor> GetAll();
		Instructor GetById(int instructorId);
	}
}

