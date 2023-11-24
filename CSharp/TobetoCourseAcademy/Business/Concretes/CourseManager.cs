using Business.Abstracts;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using FluentValidation;

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
        public IDataResult<Course> GetById(int courseId) //tek veri getirir
        {
            //Consturctor içinde ICourseDal ile CourseManager class'ımın referans bilgisine ulaşabildiğimden dolayı artık CourseManager sınıfımın metodlarına erişebiliyorum. 

            var course = _courseDal.Get(c => c.Id == courseId);       
            if (course != null)
            {
                return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == courseId), CourseMessages.GetOne(course.Name));
            }
            return new ErrorDataResult<Course>(CourseMessages.NotFound(isPlural: false));            
        }
        public IDataResult<List<Course>> GetAll() //liste getirir
        {
            var courseList = _courseDal.GetAll();            
            if (courseList.Any())
            {
                if (DateTime.Now.Hour==15)
                {
                    return new ErrorDataResult<List<Course>>(CourseMessages.MaintenanceTime());
                }
                return new SuccessDataResult<List<Course>>(_courseDal.GetAll(),CourseMessages.Listed());
            }        
            return new ErrorDataResult<List<Course>>(CourseMessages.NotFound(isPlural:true));
        }
        public IDataResult<List<Course>> GetAllByCategoryId(int categoryId)//5
        {
            //GetAll metodum içerisinde bir "Expression" yani bir "Lambda" ifadesi bekliyor
            //GetlAll Lamda yazımı => GetAll(p=>p.CategoryId == id)
            var data = _courseDal.GetAll(c => c.CategoryId == categoryId);
            if (data != null)
            {
                return new SuccessDataResult<List<Course>>(data,CourseMessages.Listed());
            }
            return new ErrorDataResult<List<Course>>(CourseMessages.NotFound(isPlural: true));
        }
        public IDataResult<List<Course>> GetByUnitPrice(decimal min, decimal max)
        {
            var datas = _courseDal.GetAll(c => c.Price >= min && c.Price <= max);
            if (datas.Any())
            {
                return new SuccessDataResult<List<Course>>(datas, CourseMessages.Listed());
            }
            return new ErrorDataResult<List<Course>>(CourseMessages.NotFound(isPlural: true));            
        }
        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            var datas = _courseDal.GetCourseDetails();
            if (datas.Any())
            {
                return new SuccessDataResult<List<CourseDetailDto>>(datas, CourseMessages.Listed());               
            }
            return new ErrorDataResult<List<CourseDetailDto>>(CourseMessages.NotFound(isPlural:true));
        }

        #region AOP / Validasyon
        //*** Validasyon:
        //Validasyon ile iş kuralı aynı şey değildir.
        //Validasyon, bir nesnenin (Course) iş kurallarına dahil etmek için o nesnenin uygun olup olmadığına formatsal olarak bakmaktır.
        //Yani verinin formatıyla ilgilenir.
        //Örnek; ürünün adı min 2 karakter olmalı, fiyatı 0 dan büyük eşit olmalı vb.
        //Add metodunu doğrula CourseValidator'daki kurallara göre!

        //*** İş Kuralı:
        //Örnek; bu ürün tekrar edemez, bir kategoride max 10 ürün olmalı, bir kişi max 5 ürün alabilir bakınız bunlar format ile alakalı değildir  bunlar iş kurallarımıza örnektir.

        //AOP: Cross Cutting Concerns => Uygulamayı dikine kesen ilgi alanları
        //ÖrneK; Validasyon, Cache, Transaction, Performans, Güvenlik, Log vb.
        //İşte bu 6 madde "AOP" yapısı ile rahatlıkla çözülür.
        //AOP: Özetle, AOP, tekrar eden kodu temsil eden ve genellikle geniş bir uygulama boyunca dağılan konuları modüler hale getirme amacını taşıyan bir programlama paradigmasıdır. 
        #endregion
        //Add metodunun Course course parametresini ValidationAspect ile alır gönderir ve kurallarına tabi tutar.
        [ValidationAspect(typeof(CourseValidator))] // Aspect       
        public IResult Add(Course course)  
        {                               
            _courseDal.Add(course);
            return new Result(true, CourseMessages.Added());
        }
        public IResult Delete(Course course)
        {
            #region Notlarım:
            //Bize parametre ile verinin referans bilgisi gelir //101  ve bu referans numarasının veritabanımızda kontrolü yapılır.
            //Eğer veritabanında bu referans mevcut ise referansı silerek veriyi kaldırabiliriz.
            //Eğer ki gelen referans numarasının veritabanında olup olmadığı kontrolünü yapmadan kaldırmayı dener isek , bu referans numarasının olmadığı durumlarda,  haliyle olmayan bir referansı,veriyi silemeyeceğimizden dolayı hatalı bir işlem ile karşılaşırız!
            #endregion
            var data = _courseDal.Get(c => c.Id == course.Id);
            if (data !=null)
            {
                _courseDal.Delete(course);
                return new Result(true,CourseMessages.Deleted());
            }
            return new ErrorResult(CourseMessages.NotFound(isPlural: false));
            
        }
        public IResult Update(Course course)
        {
            var data = _courseDal.Get(c => c.Id == course.Id);
            if (data != null)
            {
                _courseDal.Update(course);
                return new Result(true, CourseMessages.Updated());
            }
            return new ErrorResult(CourseMessages.NotFound(isPlural: false));
        }
    }
}

