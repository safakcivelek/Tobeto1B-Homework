using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            //ValidationContext sınıfından bir nesne oluşturuluyor. Bu nesne, doğrulama bağlamını,ortamını temsil eder.
            //context: Bu, doğrulama bağlamını temsil eden bir nesnedir. 
            var context = new ValidationContext<object>(entity);

            #region validator.Validate(context)
            //Verilen IValidator implementasyonu kullanılarak doğrulama yapılıyor.
            //IValidator: Bir nesnenin doğrulama kurallarını içeren bir arayüzü temsil eder.
            //validator: Bu, IValidator arayüzünü uygulayan bir sınıfın bir örneğidir.

            //validator.Validate(context): Bu ifade, belirtilen validator nesnesini kullanarak doğrulama işlemini başlatır.
            //Validate metodu, context içindeki nesneyi doğrular ve sonuçları bir ValidationResult nesnesi olarak döndürür.

            //Sonuç olarak, bu satırda yapılan işlem, belirli bir nesnenin doğrulama kurallarını içeren bir validator kullanarak doğrulama işlemini başlatmak ve doğrulama sonuçlarını elde etmektir.
            //Bu sonuçlar, ValidationResult nesnesi içinde bulunur ve bu nesne, doğrulama sürecinin başarılı olup olmadığını ve gerekirse hataların detaylarını içerir. 
            #endregion
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                // Hata durumu: Doğrulama başarısız oldu.
                throw new ValidationException(result.Errors);
                // Hata detayları da yazdırlabilir.
            }
        }
       
    }
}
