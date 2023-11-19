using Business.Concretes;
using DataAccess.Concretes.EntityFramework;

namespace ConsoleUI
{
    #region Notlarım:
    //Concrete klasörler içerisinde somut nesnelerimizi tutarız.
    //Abstract klasörler içerisinde soyut nesnelerimizi tutarız. (interface, abstract)
    //Abstractlar aslında referans tutucu görevi görür.
    //Abstractlar nesneler ile projedeki katmanlar arası bağımlılıkları minimalize ederiz.
    //Hiçbir katmanın somut nesnesi başka bir katmanda new'lenmemelidir! ihtiyaç durumunda interfaceler aracılığı ile ulaşılmalıdır.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ForInclude
            CourseManager courseManager = new CourseManager(new EfCourseDal());

            ////1 adet kurs ve bilgilerini çeker
            //Console.WriteLine("Kodlama.io Eğitim Kanalına Hoşgeldiniz");
            //Console.WriteLine("**************************************");
            //Console.WriteLine("\nLütfen kurs numarası giriniz...");
            //Console.WriteLine("( C#:1 / Java:2 / Python:3 / HTML:4 / CSS:5 )");
            //int courseNumber = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("\nSeçim ekrana getiriliyor...\n---------------------------");

            //Course course = courseManager.GetAllTables(courseNumber);

            //Console.WriteLine($"Kategori: {course.Category.Name}\nKurs: {course.Name}");
            //Console.Write($"Eğitmenler: ");
            //foreach (var courseInstructor in course.CourseInstructors)
            //{
            //    Console.Write($"{courseInstructor.Instructor.FirstName} {courseInstructor.Instructor.LastName}, ");
            //}
            //---------------------------------// 
            #endregion

            //CourseTest();
            //CategoryTest();
            CourseDetailsTest();
            //GetOneCourseTest();
            Console.ReadLine();
        }

        //Kurs,Category,Eğitmen bilgilerini getirir
        private static void CourseDetailsTest()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());

            var result = courseManager.GetCourseDetails();                   
            if (result.Success == true)
            {
                foreach (var courseDetail in result.Data)
                {
                    Console.WriteLine($"Kurs: {courseDetail.CourseName}\n{"Kategori: "}{courseDetail.CategoryName}");
                    foreach (var instructor in courseDetail.Instructors)
                    {
                        Console.WriteLine($"Eğitmen: {instructor.InstructorName}");
                    }
                    Console.WriteLine("-----------------------");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine(result.Message);
        }

        private static void GetOneCourseTest()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());
            var result = courseManager.GetById(15);// değer giriniz
            if (result.Success)
            {
                Console.WriteLine(result.Data.Name);
            }
            else
                Console.WriteLine(result.Message);
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetAll();
            if (result.Success)
            {
                foreach (var category in result.Data)
                {
                    Console.WriteLine("Kategori: " + category.Name);
                }
            }
            else
                Console.WriteLine(result);

        }
        private static void CourseTest()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());
            var result = courseManager.GetAll();
            if (result.Success)
            {
                foreach (var course in result.Data)
                {
                    Console.WriteLine(course.Id + " " + course.Name);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine(result);
        }
    }
}

