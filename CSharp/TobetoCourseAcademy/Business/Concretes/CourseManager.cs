using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    //Genelde Manager ifadesi iş katmanının somut yapıları ile birlikte kullanılır.
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
            #region Notlarım:
            //CourseManager new'lendiğinde bu Constructor metodu çalışır ilk olarak.
            //Ve Constructor burada diyorki bana bir tane ICourseDal referansı ver.
            //Yani ICourseDal interfacesini kendine implement etmiş bir class ver.
            //ICourseDal=>  EfCourseDal, InMemoryCourseDal, OracleCourseDal gibi...
            //Özetle; EfCourseDal, InMemoryCourseDal, OracleCourseDal gibi yapılara ulaşmak için ICourseDal gibi bir interface kullanmalıyız. Böylece bu farklı classlara direkt olarak bağımlı olmayız. 
            #endregion
        }
        public IDataResult<Course> GetById(int courseId) //tek veri çeker
        {
            //Consturctor içinde ICourseDal ile CourseManager class'ımın referans bilgisine ulaşabildiğimden dolayı artık CourseManager sınıfımın metodlarına erişebiliyorum 
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == courseId),Messages.CourseListed);//düzenle,message gibi...
        }
        public IDataResult<List<Course>> GetAll() //liste çeker
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Course>>(Messages.MaintenanceTime);//bakımda
            }
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(), Messages.CourseListed);
        }
        public IDataResult<List<Course>> GetAllByCategoryId(int categoryId)//5
        {
            //GetAll metodum içerisinde bir "Expression" yani bir "Lambda" ifadesi bekliyor
            //GetlAll Lamda yazımı => GetAll(p=>p.CategoryId == id)
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.CategoryId == categoryId));//düzenle
        }
        public IDataResult<List<Course>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.Price >= min && c.Price <= max));
        }
        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CourseDetailDto>>(Messages.MaintenanceTime);//bakımda
            }
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails(),Messages.CourseListed);
        }
        public IResult Add(Course course)
        {
            //Bana parametre olarak gönderilen veriyi al veritabanına ekle
            if (course.Name.Length < 2)
            {
                return new ErrorResult(Messages.CourseAdded);
            }
            _courseDal.Add(course);
            return new Result(true, "Kurs eklendi");
        }
        public void Delete(Course course)
        {
            #region Notlarım:
            //Bize parametre ile verinin referans bilgisi gelir //101  ve bu referans numarasının veritabanımızda kontrolü yapılır.
            //Eğer veritabanında bu referans mevcut ise referansı silerek veriyi kaldırabiliriz.
            //Eğer ki gelen referans numarasının veritabanında olup olmadığı kontrolünü yapmadan kaldırmayı dener isek , bu referans numarasının olmadığı durumlarda,  haliyle olmayan bir referansı,veriyi silemeyeceğimizden dolayı hatalı bir işlem ile karşılaşırız!
            #endregion
            _courseDal.Delete(course);
        }
        public void Update(Course course)
        {
            _courseDal.Update(course);
        }
    }
}

