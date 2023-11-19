using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//AddSingleton<>:(); birisi senden ICourseService istersen arka planda CourseManager sýnýfýný 1 kereye mahsus new'le ve new'lenmiþ olaný ICourseService istenen heryerde gönder.1milyon tane yerde bile ihtiyaç olsa ayný newlenmiþ CoursManager'i gönder. Yani 1 kere bir referans numarasý oluþtur örneðin // 101  olsun ve heryere o referans numarasýný gönder.

//Autofac bize AOP yapýsýný sunar.
//Autofac, Ninject, CastleWindsor, StructureMap, LightInjecti DryInject ---> IoC Container
//AOP =>  Bir metodun önünde sonunda o metod hata verdiðinde o hatalarýn yazýldýðý yerdir. Log'larýn tutulduðu yerdir diyebiliriz.

//Course
builder.Services.AddSingleton<ICourseService, CourseManager>();
builder.Services.AddSingleton<ICourseDal, EfCourseDal>();
//Category
builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
//Instructor
builder.Services.AddSingleton<IInstructorService, InstructorManager>();
builder.Services.AddSingleton<IInstructorDal, EfInstructorDal>();


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
