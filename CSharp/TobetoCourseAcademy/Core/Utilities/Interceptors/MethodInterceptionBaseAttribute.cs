using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //AOP yapısını sağlayacak olan alt yapı için gerekli kütüphanler;
    //Core katman: Autofac,Autofac.Extras.DynamicProxy, Autofac.Extensions.DependencyInjciton

    //"MethodInterceptionBaseAttribute" base sınıfı, AOP yapısını uygulamak için gerekli alt yapıyı içerir.
    //Bu sınıf "IInterceptor" interface'sini implement eder ve türetilen sınıflar tarafından metodları nasıl etkileyeceğini belirlemek için kullanılır.

    //"AttributeUsage" özelliği: bu özel niteliğin nasıl kullanılabileceğini belirtir.
    //"AttributeTargets.Class | AttributeTargets.Method" ifadesi bu niteliğin sınıflar ve metodlar üzerinde kullanılabileceğini ifade eder.
    //"AllowMultiple=true" aynı niteliğin bir sınıf veya bir metoda birden fazla kez uygulanabileceğini belirtlir.
    //"Inherited=true" ifadesi ise bu niteliğin miras alınan sınıflara da geçerli olacağını belirtir.

    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Priority özelliği: Aspect'lerin öncelik sırasını belirtir.
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            //Bu metot, bir metodun başında, sonunda veya istisna durumunda çalışacak olan temel Aspect mantığını içerir.
            //Ancak, bu sınıfın kendi uygulamasında bu metot boş bırakılmıştır.
            //Bu sınıftan türetilen sınıflar, bu metodu override ederek kendi Aspect mantıklarını ekleyebilirler.
        }
    }
}
