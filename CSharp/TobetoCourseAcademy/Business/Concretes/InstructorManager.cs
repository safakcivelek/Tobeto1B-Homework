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
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
                _instructorDal = instructorDal;
        }

        public IDataResult<Instructor> GetById(int instructorId)
        {
            var insturctor = _instructorDal.Get(c => c.Id == instructorId);
            if (insturctor != null)
            {
                return new SuccessDataResult<Instructor>(_instructorDal.Get(c => c.Id == instructorId), InstructorMessages.GetOne(insturctor.FirstName+" "+insturctor.FirstName));
            }
            return new ErrorDataResult<Instructor>(InstructorMessages.NotFound(isPlural: false));
        }
        public IDataResult<List<Instructor>> GetAll()
        {
            var insturctorList = _instructorDal.GetAll();
            if (insturctorList.Any())
            {
                if (DateTime.Now.Hour == 15)
                {
                    return new ErrorDataResult<List<Instructor>>(InstructorMessages.MaintenanceTime());
                }
                return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll(), InstructorMessages.Listed());
            }
            return new ErrorDataResult<List<Instructor>>(InstructorMessages.NotFound(isPlural: true));
        }
        public IResult Add(Instructor insturctor)
        {

            _instructorDal.Add(insturctor);
            return new Result(true, InstructorMessages.Added());
        }
        public IResult Delete(Instructor insturctor)
        {
            var data = _instructorDal.Get(c => c.Id == insturctor.Id);
            if (data != null)
            {
                _instructorDal.Delete(insturctor);
                return new Result(true, InstructorMessages.Deleted());
            }
            return new ErrorResult(InstructorMessages.NotFound(isPlural: false));
        }
        public IResult Update(Instructor insturctor)
        {
            var data = _instructorDal.Get(c => c.Id == insturctor.Id);
            if (data != null)
            {
                _instructorDal.Update(insturctor);
                return new Result(true, InstructorMessages.Updated());
            }
            return new ErrorResult(InstructorMessages.NotFound(isPlural: false));
        }
    }
}

