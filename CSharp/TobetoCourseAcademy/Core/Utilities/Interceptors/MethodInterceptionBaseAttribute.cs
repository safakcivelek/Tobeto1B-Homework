using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //AOP yapısını sağlayacak olan alt yapı için gerekli kütüphanler;
    //Core katman: Autofac,Autofac.Extras.DynamicProxy, Autofac.Extensions.DependencyInjciton
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
