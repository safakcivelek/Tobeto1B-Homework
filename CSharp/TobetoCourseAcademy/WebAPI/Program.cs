using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Autofac IoC Container'i icin
//Diyorumki DotNet.Core'a; evet biliyorum senin kendi IOC yapýlandýrman var, ama ben AutofacBusininessModule'unu kullanmaný istiyorum.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(options =>
{
    options.RegisterModule(new AutofacBusinessModules());
});
////KýsaYol Autofac container
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
//    options.RegisterModule(new AutofacBusinessModules())
//));

#region Dependency Injection - IOC | Not:
//***AddSingleton: Uygulama ayaða kalktýðýnda ilgili interface (ICourseService) herhangi biryerde çaðrýldýðýnda ilgili class için (CourseManager) bir örnek yani bir referans oluþturulur. Bundan sonra bu class'a (CourseManager) nerede ihtiyaç olursa olsun, oluþan ilk örneðin referans bilgisi gönderilir.Ta ki uygulama kapanana kadar!

//***AddScoped: ilgili class'ýn örneði, kullanýldýðý scope içerisinde her çaðrýldýðýnda ayný referans bilgisini verir Fakat her talep veya istek için. Örneðin api controller içinde bizim Get(), Update(), GetAll() gibi metodlarýmýza istek atýldýðýnda bu metodlara bir istek bir talep oluþturulur ve her metod için bir talep döner.Ayný metodun tekrar çaðrýlmasýda ayrý bir istektir,taleptir.

//***AddTransient: Bu ise ilgili class'a ihtiyaç duyulan heryerde yani ilgili interfacenin çaðrýldýðý heryerde scope içi ve dýþý farketmeksizin her seferinde yeni bir örnek oluþturur onu gönderir.Yani yeni bir referans bilgisi.  

////Course
//builder.Services.AddSingleton<ICourseService, CourseManager>();
//builder.Services.AddSingleton<ICourseDal, EfCourseDal>();
////Category
//builder.Services.AddSingleton<ICategoryService, CategoryManager>();
//builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
////Instructor
//builder.Services.AddSingleton<IInstructorService, InstructorManager>();
//builder.Services.AddSingleton<IInstructorDal, EfInstructorDal>();
////CourseInstructor
//builder.Services.AddSingleton<ICourseInstructorService, CourseInstructorManager>();
//builder.Services.AddSingleton<ICourseInstructorDal, EfCourseInstructor>();

#endregion

//Autofac bize AOP yapýsýný,desteðini sunar.
//Autofac, Ninject, CastleWindsor, StructureMap, LightInjecti DryInject ---> IoC Container
//AOP =>  Bir metodun önünde sonunda o metod hata verdiðinde o hatalarýn yazýldýðý yerdir. Log'larýn tutulduðu yerdir diyebiliriz.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
