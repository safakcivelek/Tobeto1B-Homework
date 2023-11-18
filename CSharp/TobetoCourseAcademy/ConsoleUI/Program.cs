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
            // CourseManager courseManager = new CourseManager(new EfCourseDal());     

            ////1 adet kurs ve bilgilerini çeker
            // Console.WriteLine("Kodlama.io Eğitim Kanalına Hoşgeldiniz");
            // Console.WriteLine("**************************************");
            // Console.WriteLine("\nLütfen kurs numarası giriniz...");
            // Console.WriteLine("( C#:1 / Java:2 / Python:3 / HTML:4 / CSS:5 )");
            // int courseNumber = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("\nSeçim ekrana getiriliyor...\n---------------------------");

            // Course course = courseManager.GetAllTables(courseNumber);

            // Console.WriteLine($"Kategori: {course.Category.Name}\nKurs: {course.Name}");
            // Console.Write($"Eğitmenler: ");
            // foreach (var courseInstructor in course.CourseInstructors)
            // {
            //     Console.Write($"{courseInstructor.Instructor.FirstName} {courseInstructor.Instructor.LastName}, ");
            // }
            //---------------------------------// 
            #endregion

            //CourseTest();

            //CategoryTest();

            CourseDetailsTest();

            Console.ReadLine();
        }
        private static void CourseDetailsTest()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());
           
            var result = courseManager.GetCourseDetails();
            //(result.Success==true yani GetCourseDetails() metodu sonucunda dönüş değeri SuccessDataResult class'ına düştüyse bu if bloğu çalışır         
            if (result.Success == true)
            {
                foreach (var courseDetail in result.Data)
                {
                    Console.WriteLine(courseDetail.CourseName + " / " + courseDetail.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }           
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.Name);
            }
        }
        private static void CourseTest()
        {
            CourseManager courseManager = new CourseManager(new EfCourseDal());

            //foreach (var course in courseManager.GetAll())
            //{
            //    Console.WriteLine(course.Name);
            //}
        }
    }
}

