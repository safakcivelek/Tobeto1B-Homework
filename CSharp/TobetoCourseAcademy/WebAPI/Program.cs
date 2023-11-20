using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//***AddSingleton: Uygulama aya�a kalkt���nda ilgili interface (ICourseService) herhangi biryerde �a�r�ld���nda ilgili class i�in (CourseManager) bir �rnek yani bir referans olu�turulur. Bundan sonra bu class'a (CourseManager) nerede ihtiya� olursa olsun, olu�an ilk �rne�in referans bilgisi g�nderilir.Ta ki uygulama kapanana kadar!

//***AddScoped: ilgili class'�n �rne�i, kullan�ld��� scope i�erisinde her �a�r�ld���nda ayn� referans bilgisini verir Fakat her talep veya istek i�in. �rne�in api controller i�inde bizim Get(), Update(), GetAll() gibi metodlar�m�za istek at�ld���nda bu metodlara bir istek bir talep olu�turulur ve her metod i�in bir talep d�ner.Ayn� metodun tekrar �a�r�lmas�da ayr� bir istektir,taleptir.

//***AddTransient: Bu ise ilgili class'a ihtiya� duyulan heryerde yani ilgili interfacenin �a�r�ld��� heryerde scope i�i ve d��� farketmeksizin her seferinde yeni bir �rnek olu�turur onu g�nderir.Yani yeni bir referans bilgisi. 

//Course
builder.Services.AddSingleton<ICourseService, CourseManager>();
builder.Services.AddSingleton<ICourseDal, EfCourseDal>();
//Category
builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
//Instructor
builder.Services.AddSingleton<IInstructorService, InstructorManager>();
builder.Services.AddSingleton<IInstructorDal, EfInstructorDal>();
//CourseInstructor
builder.Services.AddSingleton<ICourseInstructorService, CourseInstructorManager>();
builder.Services.AddSingleton<ICourseInstructorDal, EfCourseInstructor>();

//Autofac bize AOP yap�s�n� sunar.
//Autofac, Ninject, CastleWindsor, StructureMap, LightInjecti DryInject ---> IoC Container
//AOP =>  Bir metodun �n�nde sonunda o metod hata verdi�inde o hatalar�n yaz�ld��� yerdir. Log'lar�n tutuldu�u yerdir diyebiliriz.


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
