using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    //AspectInterceptorSelector:
    //Bu sınıfın temel amacı belirli bir sınıf veya metodun etrafında uygulanacak olan interceptor'ları seçmek ve bu interceptor'ları belirli bir öncelik sırasına göre düzenlemektir.
    //Bu sayede, Aspect'lerin belirli bir sırayla çalışmasını sağlar ve istenilen Aspectleri seçebiliriz.
    //Örneğin, aynı metoda birden fazla Aspect eklemek ve bu Aspect'lerin sırasını kontrol etmek gibi durumlar için kullanılır.

    //Aspect vs Interceptor:
    //Örneğin; [Log] attribute'u bir Aspect'i temsil eder.
    //Bu Aspectin nasıl uygulanacağını ve hangi metodlarda kullanılacağını belirlemek için bir "Interceptor" kullanılır.

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //Class'ın üzerinde tanımlanmış olan 'MethodInterceptionBaseAttribute' türündeki attribute'ları alır ve bir listeye ekler.MethodInterceptionBaseAttribute class'ı incelenebilir.
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();

            //Metodun üzerinde tanımlanmış olan 'MethodInterceptionBaseAttribute' türündeki attribute'ları alır.
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            //Sınıfı ve metodun üzerinde tanımlanmış olan attribute'ları birleştirir.
            classAttributes.AddRange(methodAttributes);            

            //Belirtilen sınıf veya metodun üzerinde tanımlanmış olan attribute'ları öncelik sırasına göre sıralar ve bir diziye dönüştürerek döndürür.
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
