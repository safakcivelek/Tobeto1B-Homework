using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    //Context: Burada Db deki tablolarmızın projedeki karşılıklarını belirleriz
    //DbContext EntityFramework.Core kütüphanesi ile birlikte gelir
    
	public class CourseAcademyContext:DbContext
	{
        //OnConfiguring metodu ile projemizin veritabanı ile olan bağlantısını belirliyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RG37ON7\SQLEXPRESS;Database=CourseAcademy;Trusted_Connection=true;TrustServerCertificate=True");
        }

        //Projemdeki Entity'lerimin veritabanımdaki hangi tablolara karşılık geleceğini belirtiyoruz.
        //DbSet
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get; set; }
    }
}

