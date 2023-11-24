using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;


namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        //Constructor'daki Type tipindeki parametre doğrulama işleminin hangi sınıf tarafından gerçekleştirileceğini temsil eder.
        public ValidationAspect(Type validatorType) //CourseValidator geldiğini varsayarsak...
        {
            //Consturctor içinde, verilen Type'ın bir 'IValidator' arayüzünden miras alıp almadığı kontrol edilir.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Tip yanlış ise patlat!
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            //Type parametresi atanır. örnek; CourseValidator
            _validatorType = validatorType;
        }

        //OnBefore metodu, bir metot çağrılmadan hemen önce çalışan metottur.Burada, metot çağrılmadan önce doğrulama işlemleri gerçekleştirilecektir.
        protected override void OnBefore(IInvocation invocation)
        {            
            //Burada _validatorType'ın bir örneği oluşturulur.
            //Yani Aspect'e constructor ile verilen doğrulama sınıfının bir örneğini oluşturur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            
            //Burada ise doğrulama sınıfının(CourseValidator) generic argümanlarını alırız.
            //Yani "AbstractValidator<Course>",  CourseValidator sınıfı için "Course" tipini temsil eder.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //Invocation metoddur. Örneğin Add metodunun parametreleri içinde tipi Course olanları bul seç.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Bulduklarını tek tek dolaş ve validate et yani doğrulama işlemine tabi tut!
            foreach (var entity in entities)
            {
                //validator:CourseValidator, entity:Course bu parametreleri belirledik.
                //Artık ValidationTool sınıfına geçip orada  doğrulama işlemine tabi tutabiliriz.
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
