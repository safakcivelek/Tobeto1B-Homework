using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
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


            //Burada yapılan işlem, bizim AOP desteği alan metodlarımız vardı(Add,Update vb.) işte class'larmızın bu metodlarına, AspectInterceptorSelector aracılığı ile Aspectler tarafından müdahele edilmesi sağlanır.
            //Yani, ValidationAspect, LogAspect gibi Aspect'lerin metodları etkileyebilmesini sağlar.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}