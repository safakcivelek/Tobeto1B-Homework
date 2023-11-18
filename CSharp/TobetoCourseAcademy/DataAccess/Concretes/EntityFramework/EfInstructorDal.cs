using System;
using System.Linq;
using System.Linq.Expressions;
using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, CourseAcademyContext>, IInstructorDal
    {
        
    }
}

