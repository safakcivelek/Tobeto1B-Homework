﻿using Core.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseInstructor : EfEntityRepositoryBase<CourseInstructor, CourseAcademyContext>, ICourseInstructorDal
    {      
        
    }
}

