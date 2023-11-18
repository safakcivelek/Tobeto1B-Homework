using System;
using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
                _instructorDal = instructorDal;
        }

        public List<Instructor> GetAll()
        {
            return _instructorDal.GetAll();
        }

        public Instructor GetById(int instructorId)
        {           
            return _instructorDal.Get(i => i.Id == instructorId);
        }
    }
}

