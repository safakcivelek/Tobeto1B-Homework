using Autofac;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    //AUTOFAC: Program.cs de Dependency Injection vb. kodlar  için IOC'ye alternatif olarak yazdığımız kodları buradan yönetebilmemiz için ortam sağlar.
    //Ornek: builder.Services.AddSingleton<ICourseService, CourseManager>();
    //Paketler: Autofac, Autofac.extras
    public class AutofacBusinessModules : Module //using Autofac
    {
        protected override void Load(ContainerBuilder builder)
        {           
            // Course
            builder.RegisterType<CourseManager>().As<ICourseService>().SingleInstance();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().SingleInstance();

            // Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            // Instructor
            builder.RegisterType<InstructorManager>().As<IInstructorService>().SingleInstance();
            builder.RegisterType<EfInstructorDal>().As<IInstructorDal>().SingleInstance();

            // CourseInstructor
            builder.RegisterType<CourseInstructorManager>().As<ICourseInstructorService>().SingleInstance();
            builder.RegisterType<EfCourseInstructorDal>().As<ICourseInstructorDal>().SingleInstance();
        }
    }
}